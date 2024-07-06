using System.ComponentModel;
using System.Net;
using AutoHotkey.Interop;
using Gma.System.MouseKeyHook;
using Nahk.Utils;
using Nahk.ViewModels;
using NahkLogic;
using NahkLogic.Business;
using NahkLogic.Common;

namespace Nahk.Forms;

public partial class FormMain : Form
{
    #region Fields / Properties
    public static AutoHotkeyEngine Ahk { get; } = AutoHotkeyEngine.Instance;
    public static IKeyboardMouseEvents Hook { get; } = Gma.System.MouseKeyHook.Hook.GlobalEvents();

    private readonly ProfileViewModel profileVM;
    private readonly BindingList<string> eventLog = new();
    private UserSettings userSettings;

    private bool isRunning;

    private bool isAltDown;
    private bool isCtrlDown;
    private bool isShiftDown;
    private IntPtr targetHwnd;
    private enum PauseType { None, WindowNotFound, WindowInactive, PauseCondition }
    private PauseType pauseType;

    private readonly List<string> ignoreKeys = new(20);
    #endregion

    #region Constructors, Init, DeInit

    public FormMain()
    {
        InitializeComponent();
        profileVM = new ProfileViewModel();
        userSettings = SettingsValidation.LoadSettings();
    }

    private void SetBindings()
    {
        DataBindings.Add("Text", profileVM, "Model.ProfileName", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxWindowTitle.DataBindings.Add("Text", profileVM, "Model.WindowTitle", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void SetDataSources()
    {
        eventLog.Clear();
        comboBoxKeys.DataSource = profileVM.Model.KeyEventList;
        comboBoxPauseChecks.DataSource = profileVM.Model.PauseList;
        comboBoxSkillChecks.DataSource = profileVM.Model.SkillList;
        listBoxEventLog.DataSource = eventLog;
    }

    #endregion

    #region Async Game Loops

    private async Task ScreenGrabLoop()
    {
        Log($"ScreenGrab() start @{userSettings.ScreenGrabTimerMs}ms.");
        while (isRunning)
        {
            Nhk.CaptureWindowBmp(targetHwnd);
            await Task.Delay(userSettings.ScreenGrabTimerMs);
        }
        Log("Screen Grab async loop has ended.");
    }

    private async Task ContinuousCheck()
    {
        Log($"Continuous() start @{userSettings.ContinuousLoopTimerMs}ms.");

        var pauses = profileVM.Model.PauseList.ToArray();
        var pauseCount = pauses.Length;

        var skills = profileVM.Model.SkillList.GetContinuousSkills;
        var skillCount = skills.Length;

        while (isRunning)
        {
            if (targetHwnd == IntPtr.Zero)
            {
                targetHwnd = Nhk.GetWindowHandle(profileVM.Model.WindowTitle);
                if (pauseType != PauseType.WindowNotFound)
                {
                    SetPaused(PauseType.WindowNotFound, $"Window not found.");
                }

                await Task.Delay(Config.CheckForWindowExistenceDelay);
                continue;
            }

            if (!Nhk.IsWinActive(targetHwnd))
            {
                if (pauseType != PauseType.WindowInactive)
                {
                    SetPaused(PauseType.WindowInactive, $"Window not active.");
                }

                await Task.Delay(userSettings.ContinuousLoopTimerMs);
                continue;
            }

            var foundPause = false;
            var nullPixel = false;
            Color? pixelColor = null;
            for (int i = 0; i < pauseCount; i++)
            {
                if (!pauses[i].Enabled) continue;

                foreach (var pixelCheck in pauses[i].PixelChecks)
                {
                    pixelColor = Nhk.GetBmpPixel(new Point(pixelCheck.X, pixelCheck.Y));

                    if (pixelColor == null)
                    {
                        nullPixel = true;
                        break;
                    }

                    if (pixelCheck.OnFound && pixelColor != pixelCheck.Color ||
                        !pixelCheck.OnFound && pixelColor == pixelCheck.Color) continue;

                    foundPause = true;
                    if (pauseType != PauseType.PauseCondition)
                    {
                        SetPaused(PauseType.PauseCondition, $"{pauses[i].Name}");
                    }
                    break;
                }

                if (foundPause || nullPixel || pixelColor == new Color())
                    break;
            }

            if (foundPause || nullPixel || pixelColor == new Color())
            {
                await Task.Delay(userSettings.ContinuousLoopTimerMs);
                continue;
            }

            if (pauseType != PauseType.None)
            {
                SetPaused(PauseType.None);
            }

            for (int i = 0; i < skillCount; i++)
            {
                if (await TrySendSkill(skills[i], null))
                {
                    await DelayRandom(Config.DefaultMinSendDelay);
                }
            }

            await Task.Delay(userSettings.ContinuousLoopTimerMs);
        }
        Log("Continuous Check async loop has ended.");
    }

    private async Task KeyEventLoop(KeyEvent keyEvent, List<string> onStartCommands, List<string> igKeys)
    {
        var skills = profileVM.Model.SkillList.GetEnabledNonContinuousSkillsByName(keyEvent.SkillNames);
        var skillsCount = skills.Length;
        Log(keyEvent + $" start @{userSettings.KeyEventTimerMs}ms.");

        if (pauseType == PauseType.None || keyEvent.Pauseable == false)
        {
            foreach (var c in onStartCommands)
            {
                SendRaw(c);
                await Task.Delay(Config.DefaultMinSendDelay);
            }
            igKeys.ForEach(k => ignoreKeys.Add(k));
        }

        while (isRunning)
        {
            if (keyEvent.GetCancelToken() == null) break;
            if (keyEvent.GetCancelToken()!.IsCancellationRequested) break;

            if (keyEvent.Pauseable == true && pauseType != PauseType.None)
            {
                await Task.Delay(userSettings.KeyEventTimerMs);
                continue;
            }

            if (keyEvent.Key.Alt && isAltDown || keyEvent.Key.Ctrl && isCtrlDown || keyEvent.Key.Shift && isShiftDown)
            {
            }
            else if (!keyEvent.IgnoreModifiers &&
                (isAltDown != keyEvent.Key.Alt || isCtrlDown != keyEvent.Key.Ctrl || isShiftDown != keyEvent.Key.Shift))
            {
                await Task.Delay(userSettings.KeyEventTimerMs);
                continue;
            }

            Color? cursorColor = null;
            for (int i = 0; i < skillsCount; i++)
            {
                if (!await TrySendSkill(skills[i], keyEvent)) continue;

                if (keyEvent.FirstFound)
                {
                    break;
                }

                await DelayRandom(keyEvent.DelayMs);
            }

            await Task.Delay(userSettings.KeyEventTimerMs);

            if (keyEvent.Key.KeyCode is "WheelUp" or "WheelDown") break;
        }

        var se = keyEvent.Stop();
        se.ignoreKeys.ForEach(k => ignoreKeys.Remove(k));
        foreach (var c in se.commands)
        {
            SendRaw(c);
            await Task.Delay(Config.DefaultMinSendDelay);
        }

        Log(keyEvent + " end");
    }

    #endregion

    #region Mouse/Key Hook Event Handlers

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (ignoreKeys.Contains(e.KeyCode.ToString())) return;

        //Log(e.KeyCode + " down");

        if (e.KeyCode is Keys.LMenu or Keys.LControlKey or Keys.LShiftKey or Keys.LWin)
        {
            if (e is { KeyCode: Keys.LMenu })
                isAltDown = true;
            else if (e is { KeyCode: Keys.LControlKey })
                isCtrlDown = true;
            else if (e is { KeyCode: Keys.LShiftKey })
                isShiftDown = true;
            return;
        }

        var keyEvents = profileVM.Model.KeyEventList.GetKeyEventsWithMatchingModifierKeys(e.KeyCode.ToString(), isAltDown, isCtrlDown, isShiftDown);

        foreach (var keyEvent in keyEvents)
        {
            if (keyEvent is not { Enabled: true }) continue;
            if (keyEvent.BlockEventKey) e.Handled = true;
            if (keyEvent.IsRunning()) continue;

            var token = new CancellationTokenSource();
            var s = keyEvent.Start(token);
            Task.Run(() => KeyEventLoop(keyEvent, s.commands, s.ignoreKeys), token.Token);
        }
    }

    private void OnKeyUp(object? sender, KeyEventArgs e)
    {
        if (ignoreKeys.Contains(e.KeyCode.ToString())) return;

        //Log(e.KeyCode + " up");

        if (e.KeyCode is Keys.LMenu or Keys.LControlKey or Keys.LShiftKey or Keys.LWin)
        {
            if (e is { KeyCode: Keys.LMenu })
                isAltDown = false;
            else if (e is { KeyCode: Keys.LControlKey })
                isCtrlDown = false;
            else if (e is { KeyCode: Keys.LShiftKey })
                isShiftDown = false;
            return;
        }

        var keyEvents = profileVM.Model.KeyEventList.GetKeyEventsByKeyValue(e.KeyCode.ToString());
        keyEvents.ForEach(k => k.GetCancelToken()?.Cancel());
    }

    private void OnMouseDown(object? sender, MouseEventArgs e)
    {
        if (ignoreKeys.Contains(e.Button.ToString())) return;

        //Log(e.Button.ToString() + "down");

        var keyEvents = profileVM.Model.KeyEventList.GetKeyEventsWithMatchingModifierKeys(e.Button.ToString(), isAltDown, isCtrlDown, isShiftDown);

        foreach (var keyEvent in keyEvents)
        {
            if (keyEvent is not { Enabled: true }) continue;
            //if (keyEvent.BlockEventKey) e.Handled = true;
            if (keyEvent.IsRunning()) continue;

            var token = new CancellationTokenSource();
            var s = keyEvent.Start(token);
            Task.Run(() => KeyEventLoop(keyEvent, s.commands, s.ignoreKeys), token.Token);
        }
    }

    private void OnWheelScroll(object? sender, MouseEventExtArgs e)
    {
        var wheelDirection = e.Delta > 0 ? "WheelUp" : "WheelDown";
        if (ignoreKeys.Contains(wheelDirection)) return;

        //Log(wheelDirection);

        var keyEvents = profileVM.Model.KeyEventList.GetKeyEventsWithMatchingModifierKeys(wheelDirection, isAltDown, isCtrlDown, isShiftDown);

        foreach (var keyEvent in keyEvents)
        {
            if (keyEvent is not { Enabled: true }) continue;
            //if (keyEvent.BlockEventKey) e.Handled = true;
            if (keyEvent.IsRunning()) continue;

            var token = new CancellationTokenSource();
            var s = keyEvent.Start(token);
            Task.Run(() => KeyEventLoop(keyEvent, s.commands, s.ignoreKeys), token.Token);
        }
    }

    private void OnMouseUp(object? sender, MouseEventArgs e)
    {
        if (ignoreKeys.Contains(e.Button.ToString())) return;

        //Log(e.Button.ToString() + "up");
        var keyEvents = profileVM.Model.KeyEventList.GetKeyEventsByKeyValue(e.Button.ToString());
        keyEvents.ForEach(k => k.GetCancelToken()?.Cancel());
    }

    #endregion

    #region Form Event Handlers

    private void FormMain_Load(object sender, EventArgs e)
    {
        SetBindings();
        if (userSettings.AutoLoadLastProfile && !string.IsNullOrEmpty(userSettings.LastProfileName))
        {
            var profile = ProfileValidation.LoadProfile(userSettings.LastProfileName);
            if (profile == null)
            {
                NewProfile();
                return;
            }

            profileVM.Model = profile;
            SetDataSources();

            if (profileVM.Model.ProfileName == Config.DefaultProfileName) return;

            saveToolStripMenuItem.Enabled = true;
            deleteProfileToolStripMenuItem.Enabled = true;

            alwaysOnTopToolStripMenuItem.Checked = userSettings.MainWindowAlwaysOnTop;
            TopMost = userSettings.MainWindowAlwaysOnTop;

            Log($"{profileVM.Model.ProfileName} loaded.");
        }
        else
        {
            NewProfile();
        }
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        CheckForUnsavedChanges(sender, e);
        Unsubscribe();
        Hook.Dispose();
    }

    private void buttonRun_Click(object sender, EventArgs e)
    {
        eventLog.Clear();
        Log("Started.");
        labelStatus.Text = "Running";
        labelStatus.ForeColor = Color.Green;
        buttonRun.Enabled = false;
        buttonStop.Enabled = true;
        ToggleFormElements(false);

        foreach (var skill in profileVM.Model.SkillList)
        {
            skill.OnRun();
        }

        foreach (var keyEvent in profileVM.Model.KeyEventList)
        {
            keyEvent.OnRun(profileVM.Model.SkillList);
        }

        Subscribe();
        targetHwnd = Nhk.GetWindowHandle(profileVM.Model.WindowTitle);
        isRunning = true;
        Nhk.CaptureWindowBmp(targetHwnd);
        Task.Run(ScreenGrabLoop);
        Task.Run(ContinuousCheck);
    }

    private void buttonStop_Click(object sender, EventArgs e)
    {
        Log("Stopped.");
        labelStatus.Text = "Stopped";
        labelStatus.ForeColor = Color.Red;
        buttonRun.Enabled = true;
        buttonStop.Enabled = false;
        ToggleFormElements(true);
        Unsubscribe();
        isRunning = false;
        pauseType = PauseType.None;
    }

    private void buttonAddPausePoint_Click(object sender, EventArgs e)
    {
        PauseDialog dialog = new()
        {
            ProfileVM = profileVM,
            IsEditMode = false
        };

        dialog.ShowDialog();

        if (dialog.DialogResult == DialogResult.OK)
        {
            var profile = profileVM.Model;
            profile.PauseList.Add(dialog.PauseVM.Model);
        }

        dialog.Dispose();
    }

    private void buttonAddSkillCheck_Click(object sender, EventArgs e)
    {
        SkillDialog dialog = new()
        {
            ProfileVM = profileVM,
            IsEditMode = false
        };

        dialog.ShowDialog();

        if (dialog.DialogResult == DialogResult.OK)
        {
            var profile = profileVM.Model;
            profile.SkillList.Add(dialog.SkillVM.Model);
        }

        dialog.Dispose();
    }

    private void buttonAddKeyEvent_Click(object sender, EventArgs e)
    {
        KeyDialog dialog = new()
        {
            ProfileVM = profileVM,
            IsEditMode = false
        };

        dialog.ShowDialog();

        if (DialogResult.OK == dialog.DialogResult)
        {
            profileVM.Model.KeyEventList.Add(dialog.KeyEventVM.Model);
        }

        dialog.Dispose();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void comboBoxPauseChecks_SelectionChangeCommitted(object sender, EventArgs e)
    {
        if (sender is not ComboBox cb) return;

        PauseDialog dialog = new()
        {
            ProfileVM = profileVM,
            IsEditMode = true,
            SelectedIndex = cb.SelectedIndex
        };
        dialog.PauseVM.Model = profileVM.Model.PauseList[cb.SelectedIndex];
        dialog.ShowDialog();

        if (dialog.DialogResult == DialogResult.OK)
        {
            var profile = profileVM.Model;
            profile.PauseList[cb.SelectedIndex] = dialog.PauseVM.Model;
        }

        dialog.Dispose();
    }

    private void comboBoxSkillChecks_SelectionChangeCommitted(object sender, EventArgs e)
    {
        if (sender is not ComboBox cb) return;

        SkillDialog dialog = new()
        {
            ProfileVM = profileVM,
            IsEditMode = true,
            SelectedIndex = cb.SelectedIndex
        };
        dialog.SkillVM.Model = profileVM.Model.SkillList[cb.SelectedIndex];
        var oldName = dialog.SkillVM.Model.Name;
        dialog.ShowDialog();

        if (dialog.DialogResult == DialogResult.OK)
        {
            var profile = profileVM.Model;
            profile.SkillList[cb.SelectedIndex] = dialog.SkillVM.Model;

            var newName = dialog.SkillVM.Model.Name;
            if (newName != oldName)
            {
                foreach (var ke in profileVM.Model.KeyEventList)
                {
                    var i = ke.SkillNames.IndexOf(oldName);
                    if (i >= 0)
                    {
                        ke.SkillNames[i] = newName;
                    }
                }
            }
        }

        dialog.Dispose();
    }

    private void comboBoxKeys_SelectionChangeCommitted(object sender, EventArgs e)
    {
        if (sender is not ComboBox cb) return;

        KeyDialog dialog = new()
        {
            ProfileVM = profileVM,
            IsEditMode = true,
            SelectedIndex = cb.SelectedIndex
        };
        dialog.KeyEventVM.Model = profileVM.Model.KeyEventList[cb.SelectedIndex];
        dialog.ShowDialog();

        if (dialog.DialogResult == DialogResult.OK)
        {
            var profile = profileVM.Model;
            profile.KeyEventList[cb.SelectedIndex] = dialog.KeyEventVM.Model;
        }

        dialog.Dispose();
    }

    private void deleteProfileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var profile = profileVM.Model;
        var result = MessageBox.Show("Are you sure you want to delete this profile?",
            $"Deleting {profile.ProfileName}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            ProfileValidation.DeleteProfile(profile);
            NewProfile();
        }
    }

    private void newProfileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CheckForUnsavedChanges(sender, e);
        NewProfile();
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            var profile = profileVM.Model;
            int result = ProfileValidation.SaveProfile(profile);
            profileVM.RefreshDisplay();

            Log(result == -1 ? ProfileValidation.ErrorMessage : $"{profile.ProfileName} saved.");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var profile = profileVM.Model;
        SaveAsDialog dialog = new()
        {
            ProfileName = profile.ProfileName
        };

        dialog.ShowDialog();

        if (dialog.DialogResult == DialogResult.OK)
        {
            profile.ProfileName = dialog.ProfileName;
            profileVM.RefreshDisplay();
            saveToolStripMenuItem_Click(sender, e);
            saveToolStripMenuItem.Enabled = true;
            deleteProfileToolStripMenuItem.Enabled = true;
            userSettings.LastProfileName = profile.ProfileName;
            SettingsValidation.SaveSettings(userSettings);
        }

        dialog.Dispose();
    }

    private void loadProfileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var dialog = new LoadProfileDialog();

        dialog.ShowDialog();

        if (dialog is not { DialogResult: DialogResult.OK, Profile: not null }) return;

        profileVM.Model = dialog.Profile;
        SetDataSources();

        if (profileVM.Model.ProfileName == Config.DefaultProfileName) return;

        saveToolStripMenuItem.Enabled = true;
        deleteProfileToolStripMenuItem.Enabled = true;
        userSettings.LastProfileName = profileVM.Model.ProfileName;
        SettingsValidation.SaveSettings(userSettings);
        Log($"{profileVM.Model.ProfileName} loaded.");
    }

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var dialog = new SettingsDialog();
        dialog.UserSettingsVm.Model = userSettings;

        dialog.ShowDialog();

        if (dialog.DialogResult != DialogResult.OK) return;

        userSettings = dialog.UserSettingsVm.Model;
    }

    private void FormMain_Resize(object sender, EventArgs e)
    {
        if (userSettings.UseMinimizeOverlay && WindowState == FormWindowState.Minimized)
        {
            var dialog = new MinimizedDialog
            {
                Text = profileVM.Model.ProfileName,
                FormMain = this,
                IsRunning = isRunning
            };
            ShowInTaskbar = false;
            dialog.ShowDialog();

            if (dialog.DialogResult == DialogResult.OK)
            {
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
            }

            dialog.Dispose();
        }
    }
    
    private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
    {
        userSettings.MainWindowAlwaysOnTop = !userSettings.MainWindowAlwaysOnTop;
        SettingsValidation.SaveSettings(userSettings);
        alwaysOnTopToolStripMenuItem.Checked = userSettings.MainWindowAlwaysOnTop;
        TopMost = userSettings.MainWindowAlwaysOnTop;
    }

    #endregion

    #region Utility Methods

    public void Run(object sender, EventArgs e)
    {
        buttonRun_Click(sender, e);
    }

    public void Stop(object sender, EventArgs e)
    {
        buttonStop_Click(sender, e);
    }

    private void NewProfile()
    {
        profileVM.Model = new Profile();
        SetDataSources();
        ClearComboBoxes();
        saveToolStripMenuItem.Enabled = false;
        deleteProfileToolStripMenuItem.Enabled = false;
        Log("New profile created.");
    }

    private void ClearComboBoxes()
    {
        comboBoxPauseChecks.Text = string.Empty;
        comboBoxSkillChecks.Text = string.Empty;
        comboBoxKeys.Text = string.Empty;
    }

    public void Subscribe()
    {
        Hook.KeyDown += OnKeyDown;
        Hook.KeyUp += OnKeyUp;
        Hook.MouseDown += OnMouseDown;
        Hook.MouseUp += OnMouseUp;
        Hook.MouseWheelExt += OnWheelScroll;
    }

    public void Unsubscribe()
    {
        Hook.KeyDown -= OnKeyDown;
        Hook.KeyUp -= OnKeyUp;
        Hook.MouseDown -= OnMouseDown;
        Hook.MouseUp -= OnMouseUp;
        Hook.MouseWheelExt -= OnWheelScroll;
        isAltDown = false;
        isCtrlDown = false;
        isShiftDown = false;
    }

    private void CheckForUnsavedChanges(object sender, EventArgs e)
    {
        if (profileVM.HasChangedSinceLoad())
        {
            var result = MessageBox.Show("Save changes?", "Unsaved changes to profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (profileVM.Model.ProfileName == Config.DefaultProfileName)
                {
                    saveAsToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
            }
        }
    }

    private void Log(string message, bool timestamp = true)
    {
        if (labelStatus.InvokeRequired)
        {
            void ThreadSafe()
            {
                Log(message, timestamp);
            }

            labelStatus.Invoke(ThreadSafe);
        }
        else
        {
            var msg = $"{(timestamp ? DateTime.Now.ToString("T") + ": " : "")}{message}";
            while (msg.Length > Config.LogCharacterLimit)
            {
                eventLog.Add(msg.Substring(0, Config.LogCharacterLimit));
                msg = msg.Substring(Config.LogCharacterLimit);
            }

            eventLog.Add(msg);

            if (eventLog.Count >= Config.MaxLogEntries)
            {
                eventLog.RemoveAt(0);
            }

            listBoxEventLog.TopIndex = listBoxEventLog.Items.Count - 1;
        }
    }

    private void ToggleFormElements(bool enable)
    {
        textBoxWindowTitle.Enabled = enable;
        comboBoxPauseChecks.Enabled = enable;
        comboBoxSkillChecks.Enabled = enable;
        comboBoxKeys.Enabled = enable;
        buttonAddPausePoint.Enabled = enable;
        buttonAddSkillCheck.Enabled = enable;
        buttonAddKeyEvent.Enabled = enable;
        fileToolStripMenuItem.Enabled = enable;
    }

    private void SetPaused(PauseType type, string reason = "")
    {
        if (labelStatus.InvokeRequired)
        {
            void ThreadSafe()
            {
                SetPaused(type, reason);
            }

            labelStatus.Invoke(ThreadSafe);
        }
        else
        {
            pauseType = type;
            labelStatus.Text = pauseType == PauseType.None ? "Running" : "Paused";
            labelStatus.ForeColor = pauseType == PauseType.None ? Color.Green : Color.Tomato;
            Log($"{(pauseType == PauseType.None ? "Unpaused" : "Paused")}{(reason != "" ? ": " : "")}{reason}");
        }
    }

    private async Task<bool> TrySendSkill(Skill skill, KeyEvent? keyEvent)
    {
        if (!skill.Enabled) return false;
        if (!skill.IsCoolDownReady()) return false;
        if (keyEvent?.Pauseable != false && skill.Pauseable && pauseType != PauseType.None) return false;
        //if (!Nhk.IsWinActive(targetHwnd)) return false;

        Point? foundPoint = null;

        if (!skill.Timed)
        {
            var colorConditionMet = false;
            var mouseWndPos = Nhk.ScreenToWindowPoint(targetHwnd, Cursor.Position);
            var mouseChecks = skill.GetAllAtMouseChecks();
            var mouseColor = mouseChecks.Length > 0
                                 ? (skill.Precise ? Nhk.GetColorAt(Cursor.Position) : Nhk.GetBmpPixel(mouseWndPos))
                                 : null;

            for (var i = 0; i < mouseChecks.Length; i++)
            {
                if (mouseChecks[i].OnFound && mouseColor == mouseChecks[i].Color ||
                   !mouseChecks[i].OnFound && mouseColor != mouseChecks[i].Color)
                {
                    colorConditionMet = true;
                    break;
                }
            }

            if (!colorConditionMet)
            {
                var nonMouseChecks = skill.GetAllNonMouseChecks();

                for (int i = 0; i < nonMouseChecks.Length; i++)
                {
                    var wndPoint = new Point(nonMouseChecks[i].X, nonMouseChecks[i].Y);
                    var pixelColor = Nhk.GetBmpPixel(wndPoint);

                    if (nonMouseChecks[i].OnFound && pixelColor == nonMouseChecks[i].Color ||
                        !nonMouseChecks[i].OnFound && pixelColor != nonMouseChecks[i].Color)
                    {
                        colorConditionMet = true;
                        break;
                    }
                }
            }

            if (!colorConditionMet)
            {
                var areaChecks = skill.GetAllAreaSearches();
                foundPoint = Nhk.SearchAreaForColors(targetHwnd, mouseWndPos, areaChecks, skill.GetMaxAreaSearchDistance(), skill.Precise);

                if (foundPoint != null)
                {
                    colorConditionMet = true;
                }
            }

            if (!colorConditionMet) return false;
        }

        if (skill.MaxPreDelay > 0)
        {
            await Task.Delay(Random.Shared.Next(skill.MinPreDelay, skill.MaxPreDelay));
        }

        var str = "";
        if (foundPoint != null && skill.Key.IsMouse)
        {
            str = $"Click, {skill.Key.KeyCode} {foundPoint.Value.X}, {foundPoint.Value.Y}";
        }
        else
        {
            str = $"Send {(skill.Key.Alt && !isAltDown ? "!" : "")}{(skill.Key.Ctrl && !isCtrlDown ? "^" : "")}{(skill.Key.Shift && !isShiftDown ? "+" : "")}{{{skill.Key.AhkKey}}}";
        }
        Log(str);
        Ahk.ExecRaw(str);
        skill.OnCast();

        return true;
    }

    private void SendRaw(string str)
    {
        Log(str);
        Ahk.ExecRaw(str);
    }

    private async Task DelayRandom(int delay, int randomMs = 25)
    {
        await Task.Delay(delay + Random.Shared.Next(0, randomMs));
    }


    #endregion

    //private void SpeedTest()
    //{
    //    targetHwnd = Nhk.GetWindowHandle(profileVM.Model.WindowTitle);
    //    var sw = new Stopwatch();
    //    var numOfChecks = 1000;
    //    var numScreenGrabs = 5;
    //    Color color = new Color();
    //    //Log($"Starting GetPixel() (({numOfChecks})) times.");
    //    //sw.Start();
    //    //for (int i = 0; i < numOfChecks; i++)
    //    //{
    //    //    //color = Nhk.GetColorAtWndPoint(targetHwnd, new Point(20,20));
    //    //}
    //    //sw.Stop();
    //    //Log($"Finished GetPixel():{color.ToHex()} -- runtime: (({sw.ElapsedMilliseconds}ms))");
    //    Log($"Starting CaptureWnd() {numScreenGrabs} times, then GetBmpPixel() (({numOfChecks})) times.");
    //    sw.Reset();
    //    sw.Start();
    //    for (int i = 0; i < numScreenGrabs; i++)
    //    {
    //        Nhk.CaptureWindowBmp(targetHwnd);
    //    }

    //    for (int i = 0; i < numOfChecks; i++)
    //    {
    //        color = Nhk.GetBmpPixel(new Point(20, 20)) ?? new Color();
    //    }
    //    sw.Stop();
    //    Log($"Finished GetBmpPixel():{color.ToHex()} -- runtime: (({sw.ElapsedMilliseconds}ms))");
    //}

}
