namespace Nahk.Forms;

partial class SettingsDialog
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
        checkBoxAutoLoadProfile = new CheckBox();
        buttonOk = new Button();
        buttonCancel = new Button();
        textBoxScreenGrabTimer = new TextBox();
        labelX = new Label();
        textBoxContinuousTimer = new TextBox();
        label1 = new Label();
        textBoxKeyEventTimer = new TextBox();
        label2 = new Label();
        errorProvider = new ErrorProvider(components);
        checkBoxMinimizedOverlay = new CheckBox();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        // 
        // checkBoxAutoLoadProfile
        // 
        checkBoxAutoLoadProfile.AutoSize = true;
        checkBoxAutoLoadProfile.Location = new Point(30, 118);
        checkBoxAutoLoadProfile.Name = "checkBoxAutoLoadProfile";
        checkBoxAutoLoadProfile.Size = new Size(144, 19);
        checkBoxAutoLoadProfile.TabIndex = 31;
        checkBoxAutoLoadProfile.Text = "Auto-Load Last Profile";
        checkBoxAutoLoadProfile.UseVisualStyleBackColor = true;
        // 
        // buttonOk
        // 
        buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        errorProvider.SetIconAlignment(buttonOk, ErrorIconAlignment.MiddleLeft);
        errorProvider.SetIconPadding(buttonOk, 3);
        buttonOk.Location = new Point(95, 172);
        buttonOk.Name = "buttonOk";
        buttonOk.Size = new Size(75, 23);
        buttonOk.TabIndex = 29;
        buttonOk.Text = "Save";
        buttonOk.UseVisualStyleBackColor = true;
        buttonOk.Click += buttonOk_Click;
        // 
        // buttonCancel
        // 
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Location = new Point(176, 172);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(75, 23);
        buttonCancel.TabIndex = 28;
        buttonCancel.Text = "Cancel";
        buttonCancel.UseVisualStyleBackColor = true;
        // 
        // textBoxScreenGrabTimer
        // 
        textBoxScreenGrabTimer.Location = new Point(180, 9);
        textBoxScreenGrabTimer.Name = "textBoxScreenGrabTimer";
        textBoxScreenGrabTimer.Size = new Size(51, 23);
        textBoxScreenGrabTimer.TabIndex = 33;
        // 
        // labelX
        // 
        labelX.AutoSize = true;
        labelX.Location = new Point(41, 12);
        labelX.Name = "labelX";
        labelX.Size = new Size(133, 15);
        labelX.TabIndex = 32;
        labelX.Text = "Screen Grab Timer (ms):";
        // 
        // textBoxContinuousTimer
        // 
        textBoxContinuousTimer.Location = new Point(180, 41);
        textBoxContinuousTimer.Name = "textBoxContinuousTimer";
        textBoxContinuousTimer.Size = new Size(51, 23);
        textBoxContinuousTimer.TabIndex = 35;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 44);
        label1.Name = "label1";
        label1.Size = new Size(162, 15);
        label1.TabIndex = 34;
        label1.Text = "Continuous Loop Timer (ms):";
        // 
        // textBoxKeyEventTimer
        // 
        textBoxKeyEventTimer.Location = new Point(180, 74);
        textBoxKeyEventTimer.Name = "textBoxKeyEventTimer";
        textBoxKeyEventTimer.Size = new Size(51, 23);
        textBoxKeyEventTimer.TabIndex = 37;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(53, 77);
        label2.Name = "label2";
        label2.Size = new Size(121, 15);
        label2.TabIndex = 36;
        label2.Text = "Key Event Timer (ms):";
        // 
        // errorProvider
        // 
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        // 
        // checkBoxMinimizedOverlay
        // 
        checkBoxMinimizedOverlay.AutoSize = true;
        checkBoxMinimizedOverlay.Location = new Point(30, 143);
        checkBoxMinimizedOverlay.Name = "checkBoxMinimizedOverlay";
        checkBoxMinimizedOverlay.Size = new Size(157, 19);
        checkBoxMinimizedOverlay.TabIndex = 38;
        checkBoxMinimizedOverlay.Text = "Show Minimized Overlay";
        checkBoxMinimizedOverlay.UseVisualStyleBackColor = true;
        // 
        // SettingsDialog
        // 
        AcceptButton = buttonOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = buttonCancel;
        ClientSize = new Size(265, 207);
        Controls.Add(checkBoxMinimizedOverlay);
        Controls.Add(textBoxKeyEventTimer);
        Controls.Add(label2);
        Controls.Add(textBoxContinuousTimer);
        Controls.Add(label1);
        Controls.Add(textBoxScreenGrabTimer);
        Controls.Add(labelX);
        Controls.Add(checkBoxAutoLoadProfile);
        Controls.Add(buttonOk);
        Controls.Add(buttonCancel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SettingsDialog";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Settings";
        Load += SettingsDialog_Load;
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private CheckBox checkBoxAutoLoadProfile;
    private Button buttonOk;
    private Button buttonCancel;
    private TextBox textBoxScreenGrabTimer;
    private Label labelX;
    private TextBox textBoxContinuousTimer;
    private Label label1;
    private TextBox textBoxKeyEventTimer;
    private Label label2;
    private ErrorProvider errorProvider;
    private CheckBox checkBoxMinimizedOverlay;
}