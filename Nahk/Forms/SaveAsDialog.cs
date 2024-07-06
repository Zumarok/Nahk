using NahkLogic.Business;

namespace Nahk.Forms;
public partial class SaveAsDialog : Form
{
    public required string ProfileName { get; set; }
    public SaveAsDialog()
    {
        InitializeComponent();
    }

    private void SaveAsDialog_Load(object sender, EventArgs e)
    {
        textBoxProfileName.Text = ProfileName;
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
        var isValid = ProfileValidation.ValidateProfileName(textBoxProfileName.Text);
        errorProvider.SetError(buttonSave, ProfileValidation.ErrorMessage);

        if (!isValid) return;

        ProfileName = textBoxProfileName.Text;
        DialogResult = DialogResult.OK;
    }

}
