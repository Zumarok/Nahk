namespace Nahk.Forms;

partial class LoadProfileDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        listBoxProfiles = new ListBox();
        buttonCancel = new Button();
        buttonLoad = new Button();
        errorProvider = new ErrorProvider(components);
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        // 
        // listBoxProfiles
        // 
        listBoxProfiles.FormattingEnabled = true;
        listBoxProfiles.ItemHeight = 15;
        listBoxProfiles.Location = new Point(12, 12);
        listBoxProfiles.Name = "listBoxProfiles";
        listBoxProfiles.ScrollAlwaysVisible = true;
        listBoxProfiles.Size = new Size(300, 169);
        listBoxProfiles.TabIndex = 0;
        // 
        // buttonCancel
        // 
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Location = new Point(238, 200);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(75, 23);
        buttonCancel.TabIndex = 1;
        buttonCancel.Text = "Cancel";
        buttonCancel.UseVisualStyleBackColor = true;
        // 
        // buttonLoad
        // 
        buttonLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        errorProvider.SetIconAlignment(buttonLoad, ErrorIconAlignment.MiddleLeft);
        errorProvider.SetIconPadding(buttonLoad, 3);
        buttonLoad.Location = new Point(157, 200);
        buttonLoad.Name = "buttonLoad";
        buttonLoad.Size = new Size(75, 23);
        buttonLoad.TabIndex = 2;
        buttonLoad.Text = "Load";
        buttonLoad.UseVisualStyleBackColor = true;
        buttonLoad.Click += buttonLoad_Click;
        // 
        // errorProvider
        // 
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        // 
        // LoadProfileDialog
        // 
        AcceptButton = buttonLoad;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = buttonCancel;
        ClientSize = new Size(324, 235);
        Controls.Add(buttonLoad);
        Controls.Add(buttonCancel);
        Controls.Add(listBoxProfiles);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoadProfileDialog";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Load Profile...";
        Load += LoadProfileDialog_Load;
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private ListBox listBoxProfiles;
    private Button buttonCancel;
    private Button buttonLoad;
    private ErrorProvider errorProvider;
}