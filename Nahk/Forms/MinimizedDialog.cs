namespace Nahk.Forms;
public partial class MinimizedDialog : Form
{
    private bool isRunning;
    public required FormMain FormMain { get; set; }

    public required bool IsRunning
    {
        get => isRunning;
        set
        {
            isRunning = value;
            buttonRun.Enabled = !value;
            buttonStop.Enabled = value;
            labelStatus.Text = value ? "Running" : "Stopped";
            labelStatus.ForeColor = value ? Color.Green : Color.Red;
        }
    }

    public MinimizedDialog()
    {
        InitializeComponent();
    }

    private void buttonRun_Click(object sender, EventArgs e)
    {
        FormMain.Run(sender, e);
        IsRunning = true;
    }

    private void buttonStop_Click(object sender, EventArgs e)
    {
        FormMain.Stop(sender, e);
        IsRunning = false;
    }

    private void MinimizedDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult = DialogResult.OK;
    }
}
