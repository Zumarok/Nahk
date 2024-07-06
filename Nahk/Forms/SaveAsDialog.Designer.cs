namespace Nahk.Forms;

partial class SaveAsDialog
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
        buttonCancel = new Button();
        buttonSave = new Button();
        label1 = new Label();
        textBoxProfileName = new TextBox();
        errorProvider = new ErrorProvider(components);
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        // 
        // buttonCancel
        // 
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Location = new Point(205, 40);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(75, 23);
        buttonCancel.TabIndex = 0;
        buttonCancel.Text = "Cancel";
        buttonCancel.UseVisualStyleBackColor = true;
        // 
        // buttonSave
        // 
        buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        errorProvider.SetIconAlignment(buttonSave, ErrorIconAlignment.MiddleLeft);
        errorProvider.SetIconPadding(buttonSave, 3);
        buttonSave.Location = new Point(124, 40);
        buttonSave.Name = "buttonSave";
        buttonSave.Size = new Size(75, 23);
        buttonSave.TabIndex = 1;
        buttonSave.Text = "Save";
        buttonSave.UseVisualStyleBackColor = true;
        buttonSave.Click += buttonSave_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(79, 15);
        label1.TabIndex = 2;
        label1.Text = "Profile Name:";
        // 
        // textBoxProfileName
        // 
        textBoxProfileName.Location = new Point(97, 6);
        textBoxProfileName.Name = "textBoxProfileName";
        textBoxProfileName.Size = new Size(182, 23);
        textBoxProfileName.TabIndex = 3;
        // 
        // errorProvider
        // 
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        // 
        // SaveAsDialog
        // 
        AcceptButton = buttonSave;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = buttonCancel;
        ClientSize = new Size(292, 75);
        Controls.Add(textBoxProfileName);
        Controls.Add(label1);
        Controls.Add(buttonSave);
        Controls.Add(buttonCancel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SaveAsDialog";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Save Profile As...";
        Load += SaveAsDialog_Load;
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button buttonCancel;
    private Button buttonSave;
    private ErrorProvider errorProvider;
    private TextBox textBoxProfileName;
    private Label label1;
}