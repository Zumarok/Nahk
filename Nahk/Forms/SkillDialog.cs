using Gma.System.MouseKeyHook;
using Nahk.Utils;
using Nahk.ViewModels;
using NahkLogic.Business;
using NahkLogic.Common;

namespace Nahk.Forms;
public partial class SkillDialog : Form
{
    public required ProfileViewModel ProfileVM { get; set; }
    public SkillViewModel SkillVM { get; set; } = new();
    public PixelCheck PixelCheck { get; set; } = new();
    public bool IsEditMode { get; set; }
    public int SelectedIndex { get; set; } = -1;

    private bool getPixelInfo;
    private bool altDown;
    private bool ctrlDown;
    private bool shiftDown;


    public SkillDialog()
    {
        InitializeComponent();
    }

    private void SkillDialog_Load(object sender, EventArgs e)
    {
        Text = IsEditMode ? "Editing Skill Trigger" : "New Skill Trigger";
        textBoxWinName.Text = ProfileVM.Model.WindowTitle;
        SetBindings();
        SetDataSources();

        if (comboBoxPixelChecks.Items.Count > 0)
        {
            comboBoxPixelChecks.SelectedIndex = 0;
            PixelCheck = SkillVM.Model.PixelChecks[comboBoxPixelChecks.SelectedIndex];
            RefreshPixelInfo();
        }
        textBoxName.SelectAll();
    }

    private void SkillDialog_FormClosed(object sender, FormClosedEventArgs e)
    {
        Unsubscribe();
    }

    public void Unsubscribe()
    {
        altDown = false;
        ctrlDown = false;
        shiftDown = false;
        FormMain.Hook.MouseDownExt -= OnMouseDown;
        FormMain.Hook.MouseWheelExt -= OnMouseWheel;
        FormMain.Hook.KeyDown -= OnKeyDown;
        FormMain.Hook.KeyUp -= OnKeyUp;
    }

    private void SetBindings()
    {
        textBoxName.DataBindings.Add("Text", this, "SkillVM.Model.Name", true, DataSourceUpdateMode.OnPropertyChanged);
        //textBoxColor.DataBindings.Add("Text", this, "SkillVM.Model.PixelCheck.Color", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxDelay.DataBindings.Add("Text", this, "SkillVM.Model.CoolDownMs", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxKey.DataBindings.Add("Text", this, "SkillVM.Model.Key", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxContinuous.DataBindings.Add("Checked", this, "SkillVM.Model.Continuous", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxTimed.DataBindings.Add("Checked", this, "SkillVM.Model.Timed", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxPausable.DataBindings.Add("Checked", this, "SkillVM.Model.Pauseable", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxEnabled.DataBindings.Add("Checked", this, "SkillVM.Model.Enabled", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxPrecise.DataBindings.Add("Checked", this, "SkillVM.Model.Precise", true, DataSourceUpdateMode.OnPropertyChanged);

        textBoxPixelCheckName.DataBindings.Add("Text", this, "PixelCheck.Name", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxX.DataBindings.Add("Text", this, "PixelCheck.X", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxY.DataBindings.Add("Text", this, "PixelCheck.Y", true, DataSourceUpdateMode.OnPropertyChanged);
        pictureBoxColor.DataBindings.Add("BackColor", this, "PixelCheck.Color", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxOnFound.DataBindings.Add("Checked", this, "PixelCheck.OnFound", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxAtMouse.DataBindings.Add("Checked", this, "PixelCheck.AtMouse", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxAreaSearch.DataBindings.Add("Checked", this, "PixelCheck.AreaSearch", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxAreaSearchDistance.DataBindings.Add("Text", this, "PixelCheck.AreaSearchDistance", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxMinPreDelay.DataBindings.Add("Text", this, "SkillVM.Model.MinPreDelay", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxMaxPreDelay.DataBindings.Add("Text", this, "SkillVM.Model.MaxPreDelay", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void SetDataSources()
    {
        comboBoxPixelChecks.DataSource = null;
        comboBoxPixelChecks.DataSource = SkillVM.Model.PixelChecks;
        comboBoxPixelChecks.DisplayMember = "Name";
        groupBoxPixelCheck.Enabled = comboBoxPixelChecks.Items.Count > 0;
    }

    private void buttonPixelInfo_Click(object sender, EventArgs e)
    {
        var hWnd = Nhk.GetWindowHandle(ProfileVM.Model.WindowTitle);
        if (hWnd == IntPtr.Zero)
        {
            textBoxWinName.Text = "Window not found...";
            return;
        }
        getPixelInfo = true;
        FormMain.Hook.MouseDownExt += OnMouseDown;
        Task.Run(() => GetPixelInfo(hWnd));
    }

    private async Task GetPixelInfo(IntPtr hWnd)
    {
        while (getPixelInfo)
        {
            Invoke((MethodInvoker)Inv);
            await Task.Delay(200);
            continue;

            void Inv()
            {
                var screenPoint = new Point(Cursor.Position.X, Cursor.Position.Y);
                var wndPoint = Nhk.ScreenToWindowPoint(hWnd, screenPoint);
                Nhk.CaptureWindowBmp(hWnd);
                var color = Nhk.GetBmpPixel(wndPoint);
                textBoxX.Text = $"{wndPoint.X}";
                textBoxY.Text = $"{wndPoint.Y}";
                if (color != null)
                {
                    pictureBoxColor.BackColor = (Color)color;
                }
            }
        }
    }

    private void OnMouseDown(object? sender, MouseEventExtArgs e)
    {

        if (getPixelInfo && e.Button == MouseButtons.Right)
        {
            e.Handled = true;
            getPixelInfo = false;
            FormMain.Hook.MouseDownExt -= OnMouseDown;
            return;
        }

        if (getPixelInfo) return;

        SkillVM.Model.Key = new Key
        {
            Alt = altDown,
            Ctrl = ctrlDown,
            Shift = shiftDown,
            KeyCode = e.Button.ToString()
        };

        SkillVM.RefreshDisplay();
        Unsubscribe();
    }

    private void OnMouseWheel(object? sender, MouseEventExtArgs e)
    {
        if (!e.WheelScrolled) return;

        SkillVM.Model.Key = new Key
        {
            Alt = altDown,
            Ctrl = ctrlDown,
            Shift = shiftDown,
            KeyCode = e.Delta > 0 ? "WheelUp" : "WheelDown"
        };

        SkillVM.RefreshDisplay();
        Unsubscribe();
    }

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode is Keys.LMenu or Keys.LControlKey or Keys.LShiftKey or Keys.LWin)
        {
            if (e.KeyCode == Keys.LMenu)
                altDown = true;
            else if (e.KeyCode == Keys.LControlKey)
                ctrlDown = true;
            else if (e.KeyCode == Keys.LShiftKey)
                shiftDown = true;
            return;
        }

        SkillVM.Model.Key = new Key
        {
            Alt = altDown,
            Ctrl = ctrlDown,
            Shift = shiftDown,
            KeyCode = e.KeyCode.ToString()
        };

        SkillVM.RefreshDisplay();
        Unsubscribe();
    }

    private void OnKeyUp(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.LMenu)
            altDown = false;
        else if (e.KeyCode == Keys.LControlKey)
            ctrlDown = false;
        else if (e.KeyCode == Keys.LShiftKey)
            shiftDown = false;
    }

    private void buttonKeyInfo_Click(object sender, EventArgs e)
    {
        FormMain.Hook.KeyDown += OnKeyDown;
        FormMain.Hook.KeyUp += OnKeyUp;
        FormMain.Hook.MouseDownExt += OnMouseDown;
        FormMain.Hook.MouseWheelExt += OnMouseWheel;
    }

    private void buttonOk_Click(object sender, EventArgs e)
    {
        if (ProfileValidation.ValidateSkill(ProfileVM.Model, SkillVM.Model, IsEditMode))
        {
            DialogResult = DialogResult.OK;
        }
        errorProvider.SetError(buttonOk, ProfileValidation.ErrorMessage);
    }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Delete this Skill?", "Delete Skill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result != DialogResult.Yes || SelectedIndex == -1) return;

        ProfileVM.Model.SkillList.RemoveAt(SelectedIndex);
        DialogResult = DialogResult.Cancel;
    }

    private void textBoxName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (!ProfileValidation.ValidateSkillName(ProfileVM.Model, textBoxName.Text, IsEditMode))
        {
            e.Cancel = true;
            textBoxName.SelectAll();
        }
        errorProvider.SetError(buttonOk, ProfileValidation.ErrorMessage);
    }

    private void checkBoxAtMouse_CheckedChanged(object sender, EventArgs e)
    {
        var cb = (CheckBox)sender;

        textBoxX.Enabled = !cb.Checked;
        textBoxY.Enabled = !cb.Checked;
        textBoxAreaSearchDistance.Enabled = cb.Checked;
        checkBoxAreaSearch.Enabled = cb.Checked;
    }

    private void checkBoxAreaSearch_CheckedChanged(object sender, EventArgs e)
    {
        var cb = (CheckBox)sender;

        textBoxAreaSearchDistance.Enabled = cb.Checked;
    }

    private void RefreshPixelInfo()
    {
        textBoxPixelCheckName.BindingContext = new BindingContext();
        textBoxX.BindingContext = new BindingContext();
        textBoxY.BindingContext = new BindingContext();
        pictureBoxColor.BindingContext = new BindingContext();
        checkBoxOnFound.BindingContext = new BindingContext();
        checkBoxAtMouse.BindingContext = new BindingContext();
        checkBoxAreaSearch.BindingContext = new BindingContext();
        textBoxAreaSearchDistance.BindingContext = new BindingContext();

        textBoxX.Enabled = !checkBoxAtMouse.Checked;
        textBoxY.Enabled = !checkBoxAtMouse.Checked;
        checkBoxAreaSearch.Enabled = checkBoxAtMouse.Checked;
        textBoxAreaSearchDistance.Enabled = checkBoxAreaSearch.Checked;
    }


    private void comboBoxPixelChecks_SelectionChangeCommitted(object sender, EventArgs e)
    {
        if (comboBoxPixelChecks.SelectedIndex < 0) return;
        PixelCheck = SkillVM.Model.PixelChecks[comboBoxPixelChecks.SelectedIndex];
        RefreshPixelInfo();
    }

    private void buttonAddPixelCheck_Click(object sender, EventArgs e)
    {
        PixelCheck = new PixelCheck();
        SkillVM.Model.PixelChecks.Add(PixelCheck);
        SetDataSources();
        RefreshPixelInfo();
    }

    private void buttonDeletePixelCheck_Click(object sender, EventArgs e)
    {
        SkillVM.Model.PixelChecks.Remove(PixelCheck);
        SetDataSources();

        if (comboBoxPixelChecks.Items.Count <= 0) return;

        comboBoxPixelChecks.SelectedIndex = comboBoxPixelChecks.Items.Count - 1;
        PixelCheck = SkillVM.Model.PixelChecks[comboBoxPixelChecks.SelectedIndex];
        RefreshPixelInfo();
    }

    private void SkillDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        getPixelInfo = false;
    }

}
