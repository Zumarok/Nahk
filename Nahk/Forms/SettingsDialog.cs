using Nahk.ViewModels;
using NahkLogic.Business;

namespace Nahk.Forms;
public partial class SettingsDialog : Form
{
    public UserSettingsViewModel UserSettingsVm { get; set; } = new UserSettingsViewModel();

    public SettingsDialog()
    {
        InitializeComponent();
    }

    private void SettingsDialog_Load(object sender, EventArgs e)
    {
        SetBindings();
    }

    private void SetBindings()
    {
        textBoxScreenGrabTimer.DataBindings.Add("Text", this, "UserSettingsVm.Model.ScreenGrabTimerMs", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxContinuousTimer.DataBindings.Add("Text", this, "UserSettingsVm.Model.ContinuousLoopTimerMs", true, DataSourceUpdateMode.OnPropertyChanged);
        textBoxKeyEventTimer.DataBindings.Add("Text", this, "UserSettingsVm.Model.KeyEventTimerMs", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxAutoLoadProfile.DataBindings.Add("Checked", this, "UserSettingsVm.Model.AutoLoadLastProfile", true, DataSourceUpdateMode.OnPropertyChanged);
        checkBoxMinimizedOverlay.DataBindings.Add("Checked", this, "UserSettingsVm.Model.UseMinimizeOverlay", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void buttonOk_Click(object? sender, EventArgs e)
    {
        if (SettingsValidation.SaveSettings(UserSettingsVm.Model) != -1)
        {
            DialogResult = DialogResult.OK;
        }
        else
        {
            errorProvider.SetError(buttonOk, SettingsValidation.ErrorMessage);
        }
    }
}
