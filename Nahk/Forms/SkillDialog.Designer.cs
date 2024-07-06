namespace Nahk.Forms;

partial class SkillDialog
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
        buttonDelete = new Button();
        groupBoxPixelCheck = new GroupBox();
        textBoxAreaSearchDistance = new TextBox();
        labelAreaSearchDistance = new Label();
        checkBoxAreaSearch = new CheckBox();
        buttonDeletePixelCheck = new Button();
        textBoxPixelCheckName = new TextBox();
        label3 = new Label();
        pictureBoxColor = new PictureBox();
        checkBoxOnFound = new CheckBox();
        checkBoxAtMouse = new CheckBox();
        buttonPixelInfo = new Button();
        label2 = new Label();
        textBoxY = new TextBox();
        labelY = new Label();
        textBoxX = new TextBox();
        labelX = new Label();
        textBoxWinName = new TextBox();
        label1 = new Label();
        textBoxName = new TextBox();
        labelName = new Label();
        buttonOk = new Button();
        buttonCancel = new Button();
        textBoxDelay = new TextBox();
        labelDelay = new Label();
        errorProvider = new ErrorProvider(components);
        textBoxKey = new TextBox();
        labelKey = new Label();
        buttonKeyInfo = new Button();
        toolTip = new ToolTip(components);
        checkBoxContinuous = new CheckBox();
        checkBoxTimed = new CheckBox();
        checkBoxEnabled = new CheckBox();
        checkBoxPausable = new CheckBox();
        labelPixelChecks = new Label();
        buttonAddPixelCheck = new Button();
        checkBoxPrecise = new CheckBox();
        label4 = new Label();
        label5 = new Label();
        comboBoxPixelChecks = new ComboBox();
        textBoxMinPreDelay = new TextBox();
        groupBox1 = new GroupBox();
        textBoxMaxPreDelay = new TextBox();
        groupBoxPixelCheck.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxColor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // buttonDelete
        // 
        buttonDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonDelete.Location = new Point(107, 378);
        buttonDelete.Name = "buttonDelete";
        buttonDelete.Size = new Size(75, 23);
        buttonDelete.TabIndex = 13;
        buttonDelete.Text = "Delete";
        buttonDelete.UseVisualStyleBackColor = true;
        buttonDelete.Click += buttonDelete_Click;
        // 
        // groupBoxPixelCheck
        // 
        groupBoxPixelCheck.Controls.Add(textBoxAreaSearchDistance);
        groupBoxPixelCheck.Controls.Add(labelAreaSearchDistance);
        groupBoxPixelCheck.Controls.Add(checkBoxAreaSearch);
        groupBoxPixelCheck.Controls.Add(buttonDeletePixelCheck);
        groupBoxPixelCheck.Controls.Add(textBoxPixelCheckName);
        groupBoxPixelCheck.Controls.Add(label3);
        groupBoxPixelCheck.Controls.Add(pictureBoxColor);
        groupBoxPixelCheck.Controls.Add(checkBoxOnFound);
        groupBoxPixelCheck.Controls.Add(checkBoxAtMouse);
        groupBoxPixelCheck.Controls.Add(buttonPixelInfo);
        groupBoxPixelCheck.Controls.Add(label2);
        groupBoxPixelCheck.Controls.Add(textBoxY);
        groupBoxPixelCheck.Controls.Add(labelY);
        groupBoxPixelCheck.Controls.Add(textBoxX);
        groupBoxPixelCheck.Controls.Add(labelX);
        groupBoxPixelCheck.Location = new Point(12, 100);
        groupBoxPixelCheck.Name = "groupBoxPixelCheck";
        groupBoxPixelCheck.Size = new Size(248, 149);
        groupBoxPixelCheck.TabIndex = 12;
        groupBoxPixelCheck.TabStop = false;
        groupBoxPixelCheck.Text = "Pixel Check Info";
        // 
        // textBoxAreaSearchDistance
        // 
        textBoxAreaSearchDistance.Location = new Point(204, 86);
        textBoxAreaSearchDistance.Name = "textBoxAreaSearchDistance";
        textBoxAreaSearchDistance.Size = new Size(38, 23);
        textBoxAreaSearchDistance.TabIndex = 37;
        toolTip.SetToolTip(textBoxAreaSearchDistance, "Area search distance in pixels.\r\n");
        // 
        // labelAreaSearchDistance
        // 
        labelAreaSearchDistance.AutoSize = true;
        labelAreaSearchDistance.Location = new Point(168, 91);
        labelAreaSearchDistance.Name = "labelAreaSearchDistance";
        labelAreaSearchDistance.Size = new Size(30, 15);
        labelAreaSearchDistance.TabIndex = 36;
        labelAreaSearchDistance.Text = "Dist:";
        toolTip.SetToolTip(labelAreaSearchDistance, "X position of pixel to check.");
        // 
        // checkBoxAreaSearch
        // 
        checkBoxAreaSearch.AutoSize = true;
        checkBoxAreaSearch.Location = new Point(98, 80);
        checkBoxAreaSearch.Name = "checkBoxAreaSearch";
        checkBoxAreaSearch.Size = new Size(61, 34);
        checkBoxAreaSearch.TabIndex = 35;
        checkBoxAreaSearch.Text = "Area \r\nSearch";
        toolTip.SetToolTip(checkBoxAreaSearch, "If enabled, At Mouse is set to true automatically.\r\nChecks for the pixel color in an area around the mouse position.");
        checkBoxAreaSearch.UseVisualStyleBackColor = true;
        checkBoxAreaSearch.CheckedChanged += checkBoxAreaSearch_CheckedChanged;
        // 
        // buttonDeletePixelCheck
        // 
        buttonDeletePixelCheck.Location = new Point(214, 121);
        buttonDeletePixelCheck.Name = "buttonDeletePixelCheck";
        buttonDeletePixelCheck.Size = new Size(28, 23);
        buttonDeletePixelCheck.TabIndex = 34;
        buttonDeletePixelCheck.Text = " X";
        toolTip.SetToolTip(buttonDeletePixelCheck, "Get Pixel Info.\r\nGet position and color info of the pixel at the mouse cursor.\r\nRight click to end.");
        buttonDeletePixelCheck.UseVisualStyleBackColor = true;
        buttonDeletePixelCheck.Click += buttonDeletePixelCheck_Click;
        // 
        // textBoxPixelCheckName
        // 
        textBoxPixelCheckName.Location = new Point(54, 23);
        textBoxPixelCheckName.Name = "textBoxPixelCheckName";
        textBoxPixelCheckName.Size = new Size(154, 23);
        textBoxPixelCheckName.TabIndex = 33;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(6, 16);
        label3.Name = "label3";
        label3.Size = new Size(42, 30);
        label3.TabIndex = 32;
        label3.Text = "  Pixel\r\nName:";
        toolTip.SetToolTip(label3, "Name for this pause condition.");
        // 
        // pictureBoxColor
        // 
        pictureBoxColor.BackColor = SystemColors.ControlLight;
        pictureBoxColor.Location = new Point(54, 115);
        pictureBoxColor.Name = "pictureBoxColor";
        pictureBoxColor.Size = new Size(23, 23);
        pictureBoxColor.TabIndex = 25;
        pictureBoxColor.TabStop = false;
        // 
        // checkBoxOnFound
        // 
        checkBoxOnFound.AutoSize = true;
        checkBoxOnFound.Location = new Point(98, 118);
        checkBoxOnFound.Name = "checkBoxOnFound";
        checkBoxOnFound.Size = new Size(79, 19);
        checkBoxOnFound.TabIndex = 23;
        checkBoxOnFound.Text = "On Found";
        toolTip.SetToolTip(checkBoxOnFound, "Checked- Skill wil be used when this color is found.\r\nUnchecked- Skill will be used when this color is NOT found.");
        checkBoxOnFound.UseVisualStyleBackColor = true;
        // 
        // checkBoxAtMouse
        // 
        checkBoxAtMouse.AutoSize = true;
        checkBoxAtMouse.Location = new Point(98, 60);
        checkBoxAtMouse.Name = "checkBoxAtMouse";
        checkBoxAtMouse.Size = new Size(77, 19);
        checkBoxAtMouse.TabIndex = 22;
        checkBoxAtMouse.Text = "At Mouse";
        toolTip.SetToolTip(checkBoxAtMouse, "If enabled, the color check will be performed at the mouse cursor position, rather than at the defined x and y pos.");
        checkBoxAtMouse.UseVisualStyleBackColor = true;
        checkBoxAtMouse.CheckedChanged += checkBoxAtMouse_CheckedChanged;
        // 
        // buttonPixelInfo
        // 
        buttonPixelInfo.Location = new Point(214, 23);
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
        label2.Location = new Point(9, 118);
        label2.Name = "label2";
        label2.Size = new Size(39, 15);
        label2.TabIndex = 10;
        label2.Text = "Color:";
        toolTip.SetToolTip(label2, "Color to check for.\r\nWill send the skill key if the color is found and the delay is met.");
        // 
        // textBoxY
        // 
        textBoxY.Location = new Point(54, 86);
        textBoxY.Name = "textBoxY";
        textBoxY.Size = new Size(38, 23);
        textBoxY.TabIndex = 7;
        // 
        // labelY
        // 
        labelY.AutoSize = true;
        labelY.Location = new Point(31, 89);
        labelY.Name = "labelY";
        labelY.Size = new Size(17, 15);
        labelY.TabIndex = 6;
        labelY.Text = "Y:";
        toolTip.SetToolTip(labelY, "Y position of pixel to check.");
        // 
        // textBoxX
        // 
        textBoxX.Location = new Point(54, 57);
        textBoxX.Name = "textBoxX";
        textBoxX.Size = new Size(38, 23);
        textBoxX.TabIndex = 5;
        // 
        // labelX
        // 
        labelX.AutoSize = true;
        labelX.Location = new Point(31, 60);
        labelX.Name = "labelX";
        labelX.Size = new Size(17, 15);
        labelX.TabIndex = 4;
        labelX.Text = "X:";
        toolTip.SetToolTip(labelX, "X position of pixel to check.");
        // 
        // textBoxWinName
        // 
        textBoxWinName.Location = new Point(71, 71);
        textBoxWinName.Name = "textBoxWinName";
        textBoxWinName.PlaceholderText = "Window Title";
        textBoxWinName.ReadOnly = true;
        textBoxWinName.Size = new Size(149, 23);
        textBoxWinName.TabIndex = 15;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 74);
        label1.Name = "label1";
        label1.Size = new Size(54, 15);
        label1.TabIndex = 14;
        label1.Text = "Window:";
        toolTip.SetToolTip(label1, "Name of the window that the current X and Y pos is relative to.\r\nThis should match the target window, if it doesn't, click in the window to activate it.");
        // 
        // textBoxName
        // 
        textBoxName.Location = new Point(66, 10);
        textBoxName.Name = "textBoxName";
        textBoxName.PlaceholderText = "ex. Frostbolt...";
        textBoxName.Size = new Size(188, 23);
        textBoxName.TabIndex = 11;
        textBoxName.Validating += textBoxName_Validating;
        // 
        // labelName
        // 
        labelName.AutoSize = true;
        labelName.Location = new Point(18, 13);
        labelName.Name = "labelName";
        labelName.Size = new Size(42, 15);
        labelName.TabIndex = 10;
        labelName.Text = "Name:";
        toolTip.SetToolTip(labelName, "Unique name for the skill.");
        // 
        // buttonOk
        // 
        buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        errorProvider.SetIconAlignment(buttonOk, ErrorIconAlignment.MiddleLeft);
        errorProvider.SetIconPadding(buttonOk, 3);
        buttonOk.Location = new Point(26, 378);
        buttonOk.Name = "buttonOk";
        buttonOk.Size = new Size(75, 23);
        buttonOk.TabIndex = 9;
        buttonOk.Text = "Save";
        buttonOk.UseVisualStyleBackColor = true;
        buttonOk.Click += buttonOk_Click;
        // 
        // buttonCancel
        // 
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Location = new Point(188, 378);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(75, 23);
        buttonCancel.TabIndex = 8;
        buttonCancel.Text = "Cancel";
        buttonCancel.UseVisualStyleBackColor = true;
        // 
        // textBoxDelay
        // 
        textBoxDelay.Location = new Point(66, 285);
        textBoxDelay.Name = "textBoxDelay";
        textBoxDelay.Size = new Size(38, 23);
        textBoxDelay.TabIndex = 17;
        // 
        // labelDelay
        // 
        labelDelay.AutoSize = true;
        labelDelay.Location = new Point(21, 289);
        labelDelay.Name = "labelDelay";
        labelDelay.Size = new Size(39, 15);
        labelDelay.TabIndex = 16;
        labelDelay.Text = "Delay:";
        toolTip.SetToolTip(labelDelay, "Key will never be sent faster than this.");
        // 
        // errorProvider
        // 
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        // 
        // textBoxKey
        // 
        textBoxKey.Location = new Point(66, 256);
        textBoxKey.Name = "textBoxKey";
        textBoxKey.ReadOnly = true;
        textBoxKey.Size = new Size(149, 23);
        textBoxKey.TabIndex = 19;
        // 
        // labelKey
        // 
        labelKey.AutoSize = true;
        labelKey.Location = new Point(31, 260);
        labelKey.Name = "labelKey";
        labelKey.Size = new Size(29, 15);
        labelKey.TabIndex = 18;
        labelKey.Text = "Key:";
        toolTip.SetToolTip(labelKey, "The key to send to the window.");
        // 
        // buttonKeyInfo
        // 
        buttonKeyInfo.Location = new Point(226, 255);
        buttonKeyInfo.Name = "buttonKeyInfo";
        buttonKeyInfo.Size = new Size(28, 23);
        buttonKeyInfo.TabIndex = 16;
        buttonKeyInfo.Text = "?";
        toolTip.SetToolTip(buttonKeyInfo, "Get next key combo pressed.");
        buttonKeyInfo.UseVisualStyleBackColor = true;
        buttonKeyInfo.Click += buttonKeyInfo_Click;
        // 
        // checkBoxContinuous
        // 
        checkBoxContinuous.AutoSize = true;
        checkBoxContinuous.Location = new Point(110, 288);
        checkBoxContinuous.Name = "checkBoxContinuous";
        checkBoxContinuous.Size = new Size(88, 19);
        checkBoxContinuous.TabIndex = 21;
        checkBoxContinuous.Text = "Continuous";
        toolTip.SetToolTip(checkBoxContinuous, "If enabled, ignores pixel check and fires continuously each delay while in 'Running' mode.");
        checkBoxContinuous.UseVisualStyleBackColor = true;
        // 
        // checkBoxTimed
        // 
        checkBoxTimed.AutoSize = true;
        checkBoxTimed.Location = new Point(204, 288);
        checkBoxTimed.Name = "checkBoxTimed";
        checkBoxTimed.Size = new Size(59, 19);
        checkBoxTimed.TabIndex = 23;
        checkBoxTimed.Text = "Timed";
        toolTip.SetToolTip(checkBoxTimed, "If enabled, ignores pixel check and fires each delay while the assigned key event is pressed.");
        checkBoxTimed.UseVisualStyleBackColor = true;
        // 
        // checkBoxEnabled
        // 
        checkBoxEnabled.AutoSize = true;
        checkBoxEnabled.Location = new Point(26, 314);
        checkBoxEnabled.Name = "checkBoxEnabled";
        checkBoxEnabled.Size = new Size(68, 19);
        checkBoxEnabled.TabIndex = 24;
        checkBoxEnabled.Text = "Enabled";
        toolTip.SetToolTip(checkBoxEnabled, "Enable or disable this skill.");
        checkBoxEnabled.UseVisualStyleBackColor = true;
        // 
        // checkBoxPausable
        // 
        checkBoxPausable.AutoSize = true;
        checkBoxPausable.Location = new Point(110, 313);
        checkBoxPausable.Name = "checkBoxPausable";
        checkBoxPausable.Size = new Size(73, 19);
        checkBoxPausable.TabIndex = 25;
        checkBoxPausable.Text = "Pausable";
        toolTip.SetToolTip(checkBoxPausable, "If enabled, will not run when pause conditions are met.\r\nThis setting is overwritten by KeyEvent Pausable.");
        checkBoxPausable.UseVisualStyleBackColor = true;
        // 
        // labelPixelChecks
        // 
        labelPixelChecks.AutoSize = true;
        labelPixelChecks.Location = new Point(17, 34);
        labelPixelChecks.Name = "labelPixelChecks";
        labelPixelChecks.Size = new Size(48, 30);
        labelPixelChecks.TabIndex = 32;
        labelPixelChecks.Text = "    Pixel\r\nChecks:";
        toolTip.SetToolTip(labelPixelChecks, "Name for this pause condition.");
        // 
        // buttonAddPixelCheck
        // 
        buttonAddPixelCheck.Location = new Point(228, 42);
        buttonAddPixelCheck.Name = "buttonAddPixelCheck";
        buttonAddPixelCheck.Size = new Size(28, 23);
        buttonAddPixelCheck.TabIndex = 30;
        buttonAddPixelCheck.Text = " +";
        toolTip.SetToolTip(buttonAddPixelCheck, "Get Pixel Info.\r\nGet position and color info of the pixel at the mouse cursor.\r\nRight click to end.");
        buttonAddPixelCheck.UseVisualStyleBackColor = true;
        buttonAddPixelCheck.Click += buttonAddPixelCheck_Click;
        // 
        // checkBoxPrecise
        // 
        checkBoxPrecise.AutoSize = true;
        checkBoxPrecise.Location = new Point(197, 314);
        checkBoxPrecise.Name = "checkBoxPrecise";
        checkBoxPrecise.Size = new Size(63, 19);
        checkBoxPrecise.TabIndex = 33;
        checkBoxPrecise.Text = "Precise";
        toolTip.SetToolTip(checkBoxPrecise, "Enabled - At Mouse and Area Searches will check real time pixel data to give time-accurate precision.\r\nUseful for moving targets. Note: this is an expensive operation and will increase CPU usage.");
        checkBoxPrecise.UseVisualStyleBackColor = true;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(17, 17);
        label4.Name = "label4";
        label4.Size = new Size(31, 15);
        label4.TabIndex = 34;
        label4.Text = "Min:";
        toolTip.SetToolTip(label4, "Key will never be sent faster than this.");
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(138, 17);
        label5.Name = "label5";
        label5.Size = new Size(33, 15);
        label5.TabIndex = 36;
        label5.Text = "Max:";
        toolTip.SetToolTip(label5, "Key will never be sent faster than this.");
        // 
        // comboBoxPixelChecks
        // 
        comboBoxPixelChecks.FormattingEnabled = true;
        comboBoxPixelChecks.Location = new Point(71, 42);
        comboBoxPixelChecks.Name = "comboBoxPixelChecks";
        comboBoxPixelChecks.Size = new Size(149, 23);
        comboBoxPixelChecks.TabIndex = 31;
        comboBoxPixelChecks.SelectionChangeCommitted += comboBoxPixelChecks_SelectionChangeCommitted;
        // 
        // textBoxMinPreDelay
        // 
        textBoxMinPreDelay.Location = new Point(54, 14);
        textBoxMinPreDelay.Name = "textBoxMinPreDelay";
        textBoxMinPreDelay.Size = new Size(55, 23);
        textBoxMinPreDelay.TabIndex = 35;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(textBoxMaxPreDelay);
        groupBox1.Controls.Add(label5);
        groupBox1.Controls.Add(textBoxMinPreDelay);
        groupBox1.Controls.Add(label4);
        groupBox1.Location = new Point(17, 332);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(243, 40);
        groupBox1.TabIndex = 36;
        groupBox1.TabStop = false;
        groupBox1.Text = "Randomized Pre-Delay";
        // 
        // textBoxMaxPreDelay
        // 
        textBoxMaxPreDelay.Location = new Point(175, 14);
        textBoxMaxPreDelay.Name = "textBoxMaxPreDelay";
        textBoxMaxPreDelay.Size = new Size(55, 23);
        textBoxMaxPreDelay.TabIndex = 37;
        // 
        // SkillDialog
        // 
        AcceptButton = buttonOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = buttonCancel;
        ClientSize = new Size(272, 409);
        Controls.Add(groupBox1);
        Controls.Add(checkBoxPrecise);
        Controls.Add(labelPixelChecks);
        Controls.Add(buttonAddPixelCheck);
        Controls.Add(comboBoxPixelChecks);
        Controls.Add(checkBoxPausable);
        Controls.Add(checkBoxEnabled);
        Controls.Add(checkBoxTimed);
        Controls.Add(textBoxWinName);
        Controls.Add(label1);
        Controls.Add(checkBoxContinuous);
        Controls.Add(buttonKeyInfo);
        Controls.Add(textBoxKey);
        Controls.Add(labelKey);
        Controls.Add(textBoxDelay);
        Controls.Add(labelDelay);
        Controls.Add(buttonDelete);
        Controls.Add(groupBoxPixelCheck);
        Controls.Add(textBoxName);
        Controls.Add(labelName);
        Controls.Add(buttonOk);
        Controls.Add(buttonCancel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SkillDialog";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "SkillDialog";
        TopMost = true;
        FormClosing += SkillDialog_FormClosing;
        FormClosed += SkillDialog_FormClosed;
        Load += SkillDialog_Load;
        groupBoxPixelCheck.ResumeLayout(false);
        groupBoxPixelCheck.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxColor).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button buttonDelete;
    private GroupBox groupBoxPixelCheck;
    private TextBox textBoxWinName;
    private Label label1;
    private Button buttonPixelInfo;
    private TextBox textBoxColor;
    private Label label2;
    private TextBox textBoxY;
    private Label labelY;
    private TextBox textBoxX;
    private Label labelX;
    private TextBox textBoxName;
    private Label labelName;
    private Button buttonOk;
    private Button buttonCancel;
    private TextBox textBoxDelay;
    private Label labelDelay;
    private ErrorProvider errorProvider;
    private Button buttonKeyInfo;
    private TextBox textBoxKey;
    private Label labelKey;
    private ToolTip toolTip;
    private CheckBox checkBoxContinuous;
    private CheckBox checkBoxAtMouse;
    private CheckBox checkBoxTimed;
    private CheckBox checkBoxEnabled;
    private CheckBox checkBoxPausable;
    private CheckBox checkBoxOnFound;
    private PictureBox pictureBoxColor;
    private TextBox textBoxPixelCheckName;
    private Label label3;
    private Button buttonDeletePixelCheck;
    private Label labelPixelChecks;
    private Button buttonAddPixelCheck;
    private ComboBox comboBoxPixelChecks;
    private CheckBox checkBoxAreaSearch;
    private TextBox textBoxAreaSearchDistance;
    private Label labelAreaSearchDistance;
    private CheckBox checkBoxPrecise;
    private GroupBox groupBox1;
    private TextBox textBoxMinPreDelay;
    private Label label4;
    private TextBox textBoxMaxPreDelay;
    private Label label5;
}