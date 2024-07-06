namespace Nahk.Forms;

partial class PauseDialog
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
        buttonOk = new Button();
        errorProvider = new ErrorProvider(components);
        buttonDelete = new Button();
        labelName = new Label();
        textBoxName = new TextBox();
        toolTip = new ToolTip(components);
        label1 = new Label();
        buttonPixelInfo = new Button();
        label2 = new Label();
        labelY = new Label();
        labelX = new Label();
        checkBoxOnFound = new CheckBox();
        checkBoxEnabled = new CheckBox();
        buttonAddPixelCheck = new Button();
        labelPixelChecks = new Label();
        buttonDeletePixelCheck = new Button();
        label3 = new Label();
        groupBoxPixelCheck = new GroupBox();
        textBoxPixelCheckName = new TextBox();
        pictureBoxColor = new PictureBox();
        textBoxY = new TextBox();
        textBoxX = new TextBox();
        textBoxWinName = new TextBox();
        comboBoxPixelChecks = new ComboBox();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        groupBoxPixelCheck.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxColor).BeginInit();
        SuspendLayout();
        // 
        // buttonCancel
        // 
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Location = new Point(177, 287);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(75, 23);
        buttonCancel.TabIndex = 0;
        buttonCancel.Text = "Cancel";
        buttonCancel.UseVisualStyleBackColor = true;
        // 
        // buttonOk
        // 
        buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        errorProvider.SetIconAlignment(buttonOk, ErrorIconAlignment.MiddleLeft);
        errorProvider.SetIconPadding(buttonOk, 3);
        buttonOk.Location = new Point(15, 287);
        buttonOk.Name = "buttonOk";
        buttonOk.Size = new Size(75, 23);
        buttonOk.TabIndex = 1;
        buttonOk.Text = "Save";
        buttonOk.UseVisualStyleBackColor = true;
        buttonOk.Click += buttonOk_Click;
        // 
        // errorProvider
        // 
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        // 
        // buttonDelete
        // 
        buttonDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        errorProvider.SetIconAlignment(buttonDelete, ErrorIconAlignment.MiddleLeft);
        errorProvider.SetIconPadding(buttonDelete, 3);
        buttonDelete.Location = new Point(96, 287);
        buttonDelete.Name = "buttonDelete";
        buttonDelete.Size = new Size(75, 23);
        buttonDelete.TabIndex = 7;
        buttonDelete.Text = "Delete";
        buttonDelete.UseVisualStyleBackColor = true;
        buttonDelete.Click += buttonDelete_Click;
        // 
        // labelName
        // 
        labelName.AutoSize = true;
        labelName.Location = new Point(18, 19);
        labelName.Name = "labelName";
        labelName.Size = new Size(42, 15);
        labelName.TabIndex = 2;
        labelName.Text = "Name:";
        toolTip.SetToolTip(labelName, "Name for this pause condition.");
        // 
        // textBoxName
        // 
        textBoxName.Location = new Point(66, 16);
        textBoxName.Name = "textBoxName";
        textBoxName.PlaceholderText = "ex. Chat Window Open...";
        textBoxName.Size = new Size(174, 23);
        textBoxName.TabIndex = 3;
        textBoxName.Validating += textBoxName_Validating;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(29, 85);
        label1.Name = "label1";
        label1.Size = new Size(31, 15);
        label1.TabIndex = 14;
        label1.Text = "Win:";
        toolTip.SetToolTip(label1, "Name of the window that the current X and Y pos is relative to.\r\nThis should match the target window, if it doesn't, click in the window to activate it.\r\n");
        // 
        // buttonPixelInfo
        // 
        buttonPixelInfo.Location = new Point(200, 25);
        buttonPixelInfo.Name = "buttonPixelInfo";
        buttonPixelInfo.Size = new Size(28, 23);
        buttonPixelInfo.TabIndex = 13;
        buttonPixelInfo.Text = "?";
        toolTip.SetToolTip(buttonPixelInfo, "Get Pixel Info.\r\nGet position and color info of the pixel at the mouse cursor.\r\nRight click to end.");
        buttonPixelInfo.UseVisualStyleBackColor = true;
        buttonPixelInfo.Click += buttonPixelInfo_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(9, 115);
        label2.Name = "label2";
        label2.Size = new Size(39, 15);
        label2.TabIndex = 10;
        label2.Text = "Color:";
        toolTip.SetToolTip(label2, "Color to check for.\r\nWill pause execution if the color is found.\r\n");
        // 
        // labelY
        // 
        labelY.AutoSize = true;
        labelY.Location = new Point(31, 86);
        labelY.Name = "labelY";
        labelY.Size = new Size(17, 15);
        labelY.TabIndex = 6;
        labelY.Text = "Y:";
        toolTip.SetToolTip(labelY, "Y position of pixel to check.");
        // 
        // labelX
        // 
        labelX.AutoSize = true;
        labelX.Location = new Point(31, 57);
        labelX.Name = "labelX";
        labelX.Size = new Size(17, 15);
        labelX.TabIndex = 4;
        labelX.Text = "X:";
        toolTip.SetToolTip(labelX, "X position of pixel to check.");
        // 
        // checkBoxOnFound
        // 
        checkBoxOnFound.AutoSize = true;
        checkBoxOnFound.Location = new Point(149, 82);
        checkBoxOnFound.Name = "checkBoxOnFound";
        checkBoxOnFound.Size = new Size(79, 19);
        checkBoxOnFound.TabIndex = 24;
        checkBoxOnFound.Text = "On Found";
        toolTip.SetToolTip(checkBoxOnFound, "Checked- Skill wil be used when this color is found.\r\nUnchecked- Skill will be used when this color is NOT found.");
        checkBoxOnFound.UseVisualStyleBackColor = true;
        // 
        // checkBoxEnabled
        // 
        checkBoxEnabled.AutoSize = true;
        checkBoxEnabled.Location = new Point(12, 262);
        checkBoxEnabled.Name = "checkBoxEnabled";
        checkBoxEnabled.Size = new Size(68, 19);
        checkBoxEnabled.TabIndex = 27;
        checkBoxEnabled.Text = "Enabled";
        toolTip.SetToolTip(checkBoxEnabled, "Enable or disable this KeyEvent when in 'Running' mode.");
        checkBoxEnabled.UseVisualStyleBackColor = true;
        // 
        // buttonAddPixelCheck
        // 
        buttonAddPixelCheck.Location = new Point(212, 53);
        buttonAddPixelCheck.Name = "buttonAddPixelCheck";
        buttonAddPixelCheck.Size = new Size(28, 23);
        buttonAddPixelCheck.TabIndex = 28;
        buttonAddPixelCheck.Text = " +";
        toolTip.SetToolTip(buttonAddPixelCheck, "Get Pixel Info.\r\nGet position and color info of the pixel at the mouse cursor.\r\nRight click to end.");
        buttonAddPixelCheck.UseVisualStyleBackColor = true;
        buttonAddPixelCheck.Click += buttonAddPixelCheck_Click;
        // 
        // labelPixelChecks
        // 
        labelPixelChecks.AutoSize = true;
        labelPixelChecks.Location = new Point(12, 45);
        labelPixelChecks.Name = "labelPixelChecks";
        labelPixelChecks.Size = new Size(48, 30);
        labelPixelChecks.TabIndex = 29;
        labelPixelChecks.Text = "    Pixel\r\nChecks:";
        toolTip.SetToolTip(labelPixelChecks, "Name for this pause condition.");
        // 
        // buttonDeletePixelCheck
        // 
        buttonDeletePixelCheck.Location = new Point(200, 112);
        buttonDeletePixelCheck.Name = "buttonDeletePixelCheck";
        buttonDeletePixelCheck.Size = new Size(28, 23);
        buttonDeletePixelCheck.TabIndex = 30;
        buttonDeletePixelCheck.Text = " X";
        toolTip.SetToolTip(buttonDeletePixelCheck, "Get Pixel Info.\r\nGet position and color info of the pixel at the mouse cursor.\r\nRight click to end.");
        buttonDeletePixelCheck.UseVisualStyleBackColor = true;
        buttonDeletePixelCheck.Click += buttonDeletePixelCheck_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(6, 18);
        label3.Name = "label3";
        label3.Size = new Size(42, 30);
        label3.TabIndex = 30;
        label3.Text = "  Pixel\r\nName:";
        toolTip.SetToolTip(label3, "Name for this pause condition.");
        // 
        // groupBoxPixelCheck
        // 
        groupBoxPixelCheck.Controls.Add(textBoxPixelCheckName);
        groupBoxPixelCheck.Controls.Add(label3);
        groupBoxPixelCheck.Controls.Add(buttonDeletePixelCheck);
        groupBoxPixelCheck.Controls.Add(pictureBoxColor);
        groupBoxPixelCheck.Controls.Add(checkBoxOnFound);
        groupBoxPixelCheck.Controls.Add(buttonPixelInfo);
        groupBoxPixelCheck.Controls.Add(label2);
        groupBoxPixelCheck.Controls.Add(textBoxY);
        groupBoxPixelCheck.Controls.Add(labelY);
        groupBoxPixelCheck.Controls.Add(textBoxX);
        groupBoxPixelCheck.Controls.Add(labelX);
        groupBoxPixelCheck.Enabled = false;
        groupBoxPixelCheck.Location = new Point(12, 111);
        groupBoxPixelCheck.Name = "groupBoxPixelCheck";
        groupBoxPixelCheck.Size = new Size(241, 145);
        groupBoxPixelCheck.TabIndex = 6;
        groupBoxPixelCheck.TabStop = false;
        groupBoxPixelCheck.Text = "Pixel Check Info";
        // 
        // textBoxPixelCheckName
        // 
        textBoxPixelCheckName.Location = new Point(54, 25);
        textBoxPixelCheckName.Name = "textBoxPixelCheckName";
        textBoxPixelCheckName.Size = new Size(140, 23);
        textBoxPixelCheckName.TabIndex = 31;
        // 
        // pictureBoxColor
        // 
        pictureBoxColor.BackColor = SystemColors.ControlLight;
        pictureBoxColor.Location = new Point(54, 112);
        pictureBoxColor.Name = "pictureBoxColor";
        pictureBoxColor.Size = new Size(23, 23);
        pictureBoxColor.TabIndex = 27;
        pictureBoxColor.TabStop = false;
        // 
        // textBoxY
        // 
        textBoxY.Location = new Point(54, 83);
        textBoxY.Name = "textBoxY";
        textBoxY.ReadOnly = true;
        textBoxY.Size = new Size(38, 23);
        textBoxY.TabIndex = 7;
        // 
        // textBoxX
        // 
        textBoxX.Location = new Point(54, 54);
        textBoxX.Name = "textBoxX";
        textBoxX.ReadOnly = true;
        textBoxX.Size = new Size(38, 23);
        textBoxX.TabIndex = 5;
        // 
        // textBoxWinName
        // 
        textBoxWinName.Location = new Point(66, 82);
        textBoxWinName.Name = "textBoxWinName";
        textBoxWinName.PlaceholderText = "Set target window";
        textBoxWinName.ReadOnly = true;
        textBoxWinName.Size = new Size(140, 23);
        textBoxWinName.TabIndex = 15;
        // 
        // comboBoxPixelChecks
        // 
        comboBoxPixelChecks.FormattingEnabled = true;
        comboBoxPixelChecks.Location = new Point(66, 53);
        comboBoxPixelChecks.Name = "comboBoxPixelChecks";
        comboBoxPixelChecks.Size = new Size(140, 23);
        comboBoxPixelChecks.TabIndex = 28;
        comboBoxPixelChecks.SelectionChangeCommitted += comboBoxPixelChecks_SelectionChangeCommitted;
        // 
        // PauseDialog
        // 
        AcceptButton = buttonOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = buttonCancel;
        ClientSize = new Size(264, 322);
        Controls.Add(labelPixelChecks);
        Controls.Add(buttonAddPixelCheck);
        Controls.Add(comboBoxPixelChecks);
        Controls.Add(label1);
        Controls.Add(textBoxWinName);
        Controls.Add(checkBoxEnabled);
        Controls.Add(buttonDelete);
        Controls.Add(groupBoxPixelCheck);
        Controls.Add(textBoxName);
        Controls.Add(labelName);
        Controls.Add(buttonOk);
        Controls.Add(buttonCancel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PauseDialog";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "New Pause Condition";
        TopMost = true;
        FormClosing += PauseDialog_FormClosing;
        FormClosed += PauseDialog_FormClosed;
        Load += PauseDialog_Load;
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        groupBoxPixelCheck.ResumeLayout(false);
        groupBoxPixelCheck.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxColor).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button buttonCancel;
    private Button buttonOk;
    private ErrorProvider errorProvider;
    private TextBox textBoxName;
    private Label labelName;
    private ToolTip toolTip;
    private GroupBox groupBoxPixelCheck;
    private Button buttonPixelInfo;
    private Label label2;
    private TextBox textBoxY;
    private Label labelY;
    private TextBox textBoxX;
    private Label labelX;
    private TextBox textBoxWinName;
    private Label label1;
    private Button buttonDelete;
    private CheckBox checkBoxOnFound;
    private PictureBox pictureBoxColor;
    private CheckBox checkBoxEnabled;
    private Label labelPixelChecks;
    private Button buttonAddPixelCheck;
    private ComboBox comboBoxPixelChecks;
    private Button buttonDeletePixelCheck;
    private TextBox textBoxPixelCheckName;
    private Label label3;
}