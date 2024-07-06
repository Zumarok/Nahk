using Gma.System.MouseKeyHook;
using Nahk.ViewModels;
using NahkLogic.Business;
using NahkLogic.Common;

namespace Nahk.Forms;
public partial class KeyDialog : Form
{
    public required ProfileViewModel ProfileVM { get; set; }
    public KeyEventViewModel KeyEventVM { get; set; } = new();
    public bool IsEditMode { get; set; }
    public int SelectedIndex { get; set; } = -1;

    private bool altDown;
    private bool ctrlDown;
    private bool shiftDown;
    public KeyDialog()
    {
        InitializeComponent();
    }

    private void KeyDialog_Load(object sender, EventArgs e)
    {
        Text = IsEditMode ? "Editing Key Event" : "New Key Event";
        SetBindings();
        SetDataSources();
    }

    private void KeyDialog_FormClosed(object sender, FormClosedEventArgs e)
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
        textBoxName.DataBindings.Add("Text", this, "KeyEventVM.Model.Name", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxKey.DataBindings.Add("Text", this, "KeyEventVM.Model.Key", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxPausable.DataBindings.Add("CheckState", this, "KeyEventVM.Model.Pauseable", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxEnabled.DataBindings.Add("Checked", this, "KeyEventVM.Model.Enabled", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxBlockEventKey.DataBindings.Add("Checked", this, "KeyEventVM.Model.BlockEventKey", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxIgnoreModifiers.DataBindings.Add("Checked", this, "KeyEventVM.Model.IgnoreModifiers", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxFirstFound.DataBindings.Add("Checked", this, "KeyEventVM.Model.FirstFound", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxDelay.DataBindings.Add("Text", this, "KeyEventVM.Model.DelayMs", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxAlt.DataBindings.Add("Checked", this, "KeyEventVM.Model.Alt", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxCtrl.DataBindings.Add("Checked", this, "KeyEventVM.Model.Ctrl", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxShift.DataBindings.Add("Checked", this, "KeyEventVM.Model.Shift", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void SetDataSources()
    {
        listBoxSkills.DataSource = null;
        listBoxSkills.DataSource = KeyEventVM.Model.SkillNames;
        comboBoxAllSkills.Items.Clear();
        //comboBoxAllSkills.Items.AddRange(ProfileVM.Model.SkillList.NonContinuousSkillNamesWithExclusions(KeyEventVM.Model.SkillNames).ToArray<object>());
        comboBoxAllSkills.Items.AddRange(ProfileVM.Model.SkillList.NonContinuousSkillNames.ToArray<object>());
    }

    private void OnMouseDown(object? sender, MouseEventExtArgs e)
    {
        e.Handled = true;

        KeyEventVM.Model.Key = new Key
        {
            Alt = altDown,
            Ctrl = ctrlDown,
            Shift = shiftDown,
            KeyCode = e.Button.ToString()
        };

        KeyEventVM.RefreshDisplay();

        Unsubscribe();
    }

    private void OnMouseWheel(object? sender, MouseEventExtArgs e)
    {
        if (!e.WheelScrolled) return;

        KeyEventVM.Model.Key = new Key
        {
            Alt = altDown,
            Ctrl = ctrlDown,
            Shift = shiftDown,
            KeyCode = e.Delta > 0 ? "WheelUp" : "WheelDown"
        };

        KeyEventVM.RefreshDisplay();
        Unsubscribe();
    }

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        e.Handled = true;

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

        KeyEventVM.Model.Key = new Key
        {
            Alt = altDown,
            Ctrl = ctrlDown,
            Shift = shiftDown,
            KeyCode = e.KeyCode.ToString()
        };

        KeyEventVM.RefreshDisplay();

        Unsubscribe();
    }

    private void OnKeyUp(object? sender, KeyEventArgs e)
    {
        e.Handled = true;

        if (e.KeyCode == Keys.LMenu)
            altDown = false;
        else if (e.KeyCode == Keys.LControlKey)
            ctrlDown = false;
        else if (e.KeyCode == Keys.LShiftKey)
            shiftDown = false;
    }

    private void buttonGetKey_Click(object sender, EventArgs e)
    {
        FormMain.Hook.KeyDown += OnKeyDown;
        FormMain.Hook.KeyUp += OnKeyUp;
        FormMain.Hook.MouseDownExt += OnMouseDown;
        FormMain.Hook.MouseWheelExt += OnMouseWheel;
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
        if (ProfileValidation.ValidateKeyEvent(ProfileVM.Model, KeyEventVM.Model, IsEditMode))
        {
            DialogResult = DialogResult.OK;
        }
        errorProvider.SetError(buttonSave, ProfileValidation.ErrorMessage);
    }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Delete this Key Event?", "Delete Key Event", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result != DialogResult.Yes || SelectedIndex == -1) return;

        ProfileVM.Model.KeyEventList.RemoveAt(SelectedIndex);
        DialogResult = DialogResult.Cancel;
    }

    private void listBoxSkills_MouseDown(object sender, MouseEventArgs e)
    {
        var lb = sender as ListBox;
        if (lb?.SelectedItem == null) return;

        lb.DoDragDrop(lb.SelectedItem, DragDropEffects.Move);
    }

    private void listBoxSkills_DragOver(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Move;
    }

    private void listBoxSkills_DragDrop(object sender, DragEventArgs e)
    {
        var lb = sender as ListBox;
        if (lb?.SelectedItem == null) return;

        var point = lb.PointToClient(new Point(e.X, e.Y));
        var index = lb.IndexFromPoint(point);
        if (index < 0)
        {
            index = lb.Items.Count - 1;
        }

        var data = (string)lb.SelectedItem;
        KeyEventVM.Model.SkillNames.Remove(data);
        KeyEventVM.Model.SkillNames.Insert(index, data);
        SetDataSources();
        KeyEventVM.RefreshDisplay();
    }

    private void listBoxSkills_KeyDown(object sender, KeyEventArgs e)
    {
        var lb = sender as ListBox;
        var k = e.KeyCode;

        if (lb?.SelectedItem == null) return;
        if (!e.Shift || k is not (Keys.Down or Keys.Up)) return;

        var index = lb.SelectedIndex;
        var desiredIndex = k is Keys.Down ? index + 1 : index - 1;

        if (desiredIndex < 0 || desiredIndex > lb.Items.Count -1) return;

        var data = (string)lb.SelectedItem;
        KeyEventVM.Model.SkillNames.Remove(data);
        KeyEventVM.Model.SkillNames.Insert(desiredIndex, data);
        SetDataSources();
        KeyEventVM.RefreshDisplay();
        lb.SelectedIndex = index;
    }

    private void comboBoxAllSkills_SelectionChangeCommitted(object sender, EventArgs e)
    {
        var cb = sender as ComboBox;
        if (cb?.SelectedItem == null) return;

        if (cb.Items[comboBoxAllSkills.SelectedIndex] is string name)
        {
            KeyEventVM.Model.SkillNames.Add(name);
            cb.Items.Remove(cb.SelectedItem);
        }

        SetDataSources();
    }

    private void buttonRemoveSkill_Click(object sender, EventArgs e)
    {
        if (listBoxSkills.SelectedItem is string name &&
            KeyEventVM.Model.SkillNames.Contains(name))
        {
            KeyEventVM.Model.SkillNames.Remove(name);
        }
        SetDataSources();
    }

    private void comboBoxAllSkills_Leave(object sender, EventArgs e)
    {
        if (sender is not ComboBox cb) return;
        cb.Text = "Select a skill to add";
    }

    private void checkBoxAlt_CheckedChanged(object sender, EventArgs e)
    {
        UpdateIgnoreMods();
    }

    private void checkBoxCtrl_CheckedChanged(object sender, EventArgs e)
    {
        UpdateIgnoreMods();
    }

    private void checkBoxShift_CheckedChanged(object sender, EventArgs e)
    {
        UpdateIgnoreMods();
    }

    private void UpdateIgnoreMods()
    {
        //if (checkBoxAlt.Checked || checkBoxCtrl.Checked || checkBoxShift.Checked)
        //{
        //    KeyEventVM.Model.IgnoreModifiers = true;
        //}

        //checkBoxIgnoreModifiers.Enabled = !checkBoxAlt.Checked && !checkBoxCtrl.Checked && !checkBoxShift.Checked;
    }

    private void checkBoxIgnoreModifiers_CheckedChanged(object sender, EventArgs e)
    {
        if (!checkBoxIgnoreModifiers.Checked) return;

        KeyEventVM.Model.Key = new Key
        {
            Alt = false,
            Ctrl = false,
            Shift = false,
            KeyCode = KeyEventVM.Model.Key.KeyCode
        };
    }
}
