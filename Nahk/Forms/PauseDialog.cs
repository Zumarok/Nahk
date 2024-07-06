using Gma.System.MouseKeyHook;
using Nahk.Utils;
using Nahk.ViewModels;
using NahkLogic.Business;
using NahkLogic.Common;

namespace Nahk.Forms;

/// <summary>
/// PauseDialog
/// Shows a dialog window with all needed options for a user to set up a pause event.
/// </summary>
public partial class PauseDialog : Form
{
    public required ProfileViewModel ProfileVM { get; set; }
    public PauseViewModel PauseVM { get; set; } = new();
    public PixelCheck PixelCheck { get; set; } = new();
    public bool IsEditMode { get; set; }
    public int SelectedIndex { get; set; } = -1;

    private bool debugPixelInfo = false;


    public PauseDialog()
    {
        InitializeComponent();
    }

    private void PauseDialog_Load(object sender, EventArgs e)
    {
        Text = IsEditMode ? "Editing Pause Condition" : "New Pause Condition";
        textBoxWinName.Text = ProfileVM.Model.WindowTitle;
        SetBindings();
        SetDataSources();

        if (comboBoxPixelChecks.Items.Count > 0)
        {
            comboBoxPixelChecks.SelectedIndex = 0;
            PixelCheck = PauseVM.Model.PixelChecks[comboBoxPixelChecks.SelectedIndex];
            RefreshPixelInfo();
        }
    }

    private void PauseDialog_FormClosed(object sender, FormClosedEventArgs e)
    {
        Unsubscribe();
    }

    public void Subscribe()
    {
        FormMain.Hook.MouseDownExt += MouseHook;
    }

    public void Unsubscribe()
    {
        FormMain.Hook.MouseDownExt -= MouseHook;
    }

    private void SetBindings()
    {
        textBoxName.DataBindings.Add("Text", this, "PauseVM.Model.Name", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxEnabled.DataBindings.Add("Checked", this, "PauseVM.Model.Enabled", true, DataSourceUpdateMode.OnPropertyChanged);

        textBoxPixelCheckName.DataBindings.Add("Text", this, "PixelCheck.Name", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxX.DataBindings.Add("Text", this, "PixelCheck.X", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxY.DataBindings.Add("Text", this, "PixelCheck.Y", true, DataSourceUpdateMode.OnPropertyChanged);
        pictureBoxColor.DataBindings.Add("BackColor", this, "PixelCheck.Color", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxOnFound.DataBindings.Add("Checked", this, "PixelCheck.OnFound", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void SetDataSources()
    {
        comboBoxPixelChecks.DataSource = null;
        comboBoxPixelChecks.DataSource = PauseVM.Model.PixelChecks;
        comboBoxPixelChecks.DisplayMember = "Name";
        groupBoxPixelCheck.Enabled = comboBoxPixelChecks.Items.Count > 0;
    }

    private void buttonOk_Click(object sender, EventArgs e)
    {
        if (ProfileValidation.ValidatePause(ProfileVM.Model, PauseVM.Model, IsEditMode))
        {
            DialogResult = DialogResult.OK;
        }
        errorProvider.SetError(buttonOk, ProfileValidation.ErrorMessage);
    }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Delete this Pause Condition?", "Delete Pause Condition", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result != DialogResult.Yes || SelectedIndex == -1) return;

        ProfileVM.Model.PauseList.RemoveAt(SelectedIndex);
        DialogResult = DialogResult.Cancel;
    }

    private void buttonPixelInfo_Click(object sender, EventArgs e)
    {
        var hWnd = Nhk.GetWindowHandle(ProfileVM.Model.WindowTitle);
        if (hWnd == IntPtr.Zero)
        {
            textBoxWinName.Text = "Window not found...";
            return;
        }
        Subscribe();
        debugPixelInfo = true;
        Task.Run(() => GetPixelInfo(hWnd));
    }

    private async Task GetPixelInfo(IntPtr hWnd)
    {
        while (debugPixelInfo)
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

    private void MouseHook(object? sender, MouseEventExtArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            e.Handled = true;
            debugPixelInfo = false;
        }
    }

    private void textBoxName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (!ProfileValidation.ValidatePauseName(ProfileVM.Model, textBoxName.Text, IsEditMode))
        {
            e.Cancel = true;
            textBoxName.SelectAll();
        }
        errorProvider.SetError(buttonOk, ProfileValidation.ErrorMessage);
    }

    private void comboBoxPixelChecks_SelectionChangeCommitted(object sender, EventArgs e)
    {
        if (comboBoxPixelChecks.SelectedIndex < 0) return;
        PixelCheck = PauseVM.Model.PixelChecks[comboBoxPixelChecks.SelectedIndex];
        RefreshPixelInfo();
    }

    private void buttonAddPixelCheck_Click(object sender, EventArgs e)
    {
        PixelCheck = new PixelCheck();
        PauseVM.Model.PixelChecks.Add(PixelCheck);
        SetDataSources();
        RefreshPixelInfo();
    }

    private void buttonDeletePixelCheck_Click(object sender, EventArgs e)
    {
        PauseVM.Model.PixelChecks.Remove(PixelCheck);
        SetDataSources();

        if (comboBoxPixelChecks.Items.Count <= 0) return;

        comboBoxPixelChecks.SelectedIndex = comboBoxPixelChecks.Items.Count - 1;
        PixelCheck = PauseVM.Model.PixelChecks[comboBoxPixelChecks.SelectedIndex];
        RefreshPixelInfo();
    }

    private void RefreshPixelInfo()
    {
        textBoxPixelCheckName.BindingContext = new BindingContext();
        textBoxX.BindingContext = new BindingContext();
        textBoxY.BindingContext = new BindingContext();
        pictureBoxColor.BindingContext = new BindingContext();
        checkBoxOnFound.BindingContext = new BindingContext();
    }

    private void PauseDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        debugPixelInfo = false;
    }
}
