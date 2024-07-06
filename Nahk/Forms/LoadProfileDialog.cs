using NahkLogic.Business;
using NahkLogic.Common;

namespace Nahk.Forms;
public partial class LoadProfileDialog : Form
{
    public Profile? Profile { get; set; }

    public LoadProfileDialog()
    {
        InitializeComponent();
    }

    private void LoadProfileDialog_Load(object sender, EventArgs e)
    {
        listBoxProfiles.DataSource = ProfileValidation.GetProfileNames();
    }

    private void buttonLoad_Click(object sender, EventArgs e)
    {
        Profile = ProfileValidation.LoadProfile(listBoxProfiles.SelectedItem as string ?? "");

        errorProvider.SetError(buttonLoad, ProfileValidation.ErrorMessage);

        if (Profile != null)
        {
            DialogResult = DialogResult.OK;
        }

    }
}
