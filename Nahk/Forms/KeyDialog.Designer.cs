namespace Nahk.Forms;

partial class KeyDialog
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyDialog));
        buttonDelete = new Button();
        groupBox1 = new GroupBox();
        label1 = new Label();
        comboBoxAllSkills = new ComboBox();
        buttonRemoveSkill = new Button();
        listBoxSkills = new ListBox();
        buttonGetKey = new Button();
        textBoxKey = new TextBox();
        labelName = new Label();
        buttonSave = new Button();
        buttonCancel = new Button();
        errorProvider = new ErrorProvider(components);
        checkBoxPausable = new CheckBox();
        checkBoxEnabled = new CheckBox();
        toolTip = new ToolTip(components);
        checkBoxBlockEventKey = new CheckBox();
        checkBoxIgnoreModifiers = new CheckBox();
        checkBoxFirstFound = new CheckBox();
        labelDelay = new Label();
        checkBoxAlt = new CheckBox();
        checkBoxCtrl = new CheckBox();
        checkBoxShift = new CheckBox();
        textBoxDelay = new TextBox();
        groupBoxMods = new GroupBox();
        textBoxName = new TextBox();
        label2 = new Label();
        groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        groupBoxMods.SuspendLayout();
        SuspendLayout();
        // 
        // buttonDelete
        // 
        buttonDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonDelete.Location = new Point(106, 396);
        buttonDelete.Name = "buttonDelete";
        buttonDelete.Size = new Size(75, 23);
        buttonDelete.TabIndex = 13;
        buttonDelete.Text = "Delete";
        buttonDelete.UseVisualStyleBackColor = true;
        buttonDelete.Click += buttonDelete_Click;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(comboBoxAllSkills);
        groupBox1.Controls.Add(buttonRemoveSkill);
        groupBox1.Controls.Add(listBoxSkills);
        groupBox1.Location = new Point(12, 65);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(248, 185);
        groupBox1.TabIndex = 12;
        groupBox1.TabStop = false;
        groupBox1.Text = "Key Press Skill Priorities";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(6, 24);
        label1.Name = "label1";
        label1.Size = new Size(36, 15);
        label1.TabIndex = 18;
        label1.Text = "Skills:";
        toolTip.SetToolTip(label1, "Shift + Up to move an item up in the list.\r\nShift + Down to move an item down in the list.\r\n");
        // 
        // comboBoxAllSkills
        // 
        comboBoxAllSkills.FormattingEnabled = true;
        comboBoxAllSkills.Location = new Point(48, 21);
        comboBoxAllSkills.Name = "comboBoxAllSkills";
        comboBoxAllSkills.Size = new Size(157, 23);
        comboBoxAllSkills.Sorted = true;
        comboBoxAllSkills.TabIndex = 17;
        comboBoxAllSkills.Text = "Select a skill to add";
        comboBoxAllSkills.SelectionChangeCommitted += comboBoxAllSkills_SelectionChangeCommitted;
        comboBoxAllSkills.Leave += comboBoxAllSkills_Leave;
        // 
        // buttonRemoveSkill
        // 
        buttonRemoveSkill.Location = new Point(209, 51);
        buttonRemoveSkill.Name = "buttonRemoveSkill";
        buttonRemoveSkill.Size = new Size(28, 23);
        buttonRemoveSkill.TabIndex = 16;
        buttonRemoveSkill.Text = " -";
        buttonRemoveSkill.UseVisualStyleBackColor = true;
        buttonRemoveSkill.Click += buttonRemoveSkill_Click;
        // 
        // listBoxSkills
        // 
        listBoxSkills.AllowDrop = true;
        listBoxSkills.FormattingEnabled = true;
        listBoxSkills.ItemHeight = 15;
        listBoxSkills.Location = new Point(6, 50);
        listBoxSkills.Name = "listBoxSkills";
        listBoxSkills.Size = new Size(199, 124);
        listBoxSkills.TabIndex = 0;
        listBoxSkills.DragDrop += listBoxSkills_DragDrop;
        listBoxSkills.DragOver += listBoxSkills_DragOver;
        listBoxSkills.KeyDown += listBoxSkills_KeyDown;
        listBoxSkills.MouseDown += listBoxSkills_MouseDown;
        // 
        // buttonGetKey
        // 
        buttonGetKey.Location = new Point(221, 36);
        buttonGetKey.Name = "buttonGetKey";
        buttonGetKey.Size = new Size(28, 23);
        buttonGetKey.TabIndex = 13;
        buttonGetKey.Text = "?";
        buttonGetKey.UseVisualStyleBackColor = true;
        buttonGetKey.Click += buttonGetKey_Click;
        // 
        // textBoxKey
        // 
        textBoxKey.Location = new Point(56, 36);
        textBoxKey.Name = "textBoxKey";
        textBoxKey.PlaceholderText = "ex. Spacebar";
        textBoxKey.ReadOnly = true;
        textBoxKey.Size = new Size(157, 23);
        textBoxKey.TabIndex = 11;
        // 
        // labelName
        // 
        labelName.AutoSize = true;
        labelName.Location = new Point(25, 39);
        labelName.Name = "labelName";
        labelName.Size = new Size(29, 15);
        labelName.TabIndex = 10;
        labelName.Text = "Key:";
        // 
        // buttonSave
        // 
        buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        errorProvider.SetIconAlignment(buttonSave, ErrorIconAlignment.MiddleLeft);
        errorProvider.SetIconPadding(buttonSave, 3);
        buttonSave.Location = new Point(25, 396);
        buttonSave.Name = "buttonSave";
        buttonSave.Size = new Size(75, 23);
        buttonSave.TabIndex = 9;
        buttonSave.Text = "Save";
        buttonSave.UseVisualStyleBackColor = true;
        buttonSave.Click += buttonSave_Click;
        // 
        // buttonCancel
        // 
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Location = new Point(187, 396);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(75, 23);
        buttonCancel.TabIndex = 8;
        buttonCancel.Text = "Cancel";
        buttonCancel.UseVisualStyleBackColor = true;
        // 
        // errorProvider
        // 
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        // 
        // checkBoxPausable
        // 
        checkBoxPausable.AutoSize = true;
        checkBoxPausable.Location = new Point(32, 285);
        checkBoxPausable.Name = "checkBoxPausable";
        checkBoxPausable.Size = new Size(73, 19);
        checkBoxPausable.TabIndex = 27;
        checkBoxPausable.Text = "Pausable";
        checkBoxPausable.ThreeState = true;
        toolTip.SetToolTip(checkBoxPausable, resources.GetString("checkBoxPausable.ToolTip"));
        checkBoxPausable.UseVisualStyleBackColor = true;
        // 
        // checkBoxEnabled
        // 
        checkBoxEnabled.AutoSize = true;
        checkBoxEnabled.Location = new Point(32, 260);
        checkBoxEnabled.Name = "checkBoxEnabled";
        checkBoxEnabled.Size = new Size(68, 19);
        checkBoxEnabled.TabIndex = 26;
        checkBoxEnabled.Text = "Enabled";
        toolTip.SetToolTip(checkBoxEnabled, "Enable or disable this KeyEvent when in 'Running' mode.");
        checkBoxEnabled.UseVisualStyleBackColor = true;
        // 
        // checkBoxBlockEventKey
        // 
        checkBoxBlockEventKey.AutoSize = true;
        checkBoxBlockEventKey.Location = new Point(147, 285);
        checkBoxBlockEventKey.Name = "checkBoxBlockEventKey";
        checkBoxBlockEventKey.Size = new Size(77, 19);
        checkBoxBlockEventKey.TabIndex = 29;
        checkBoxBlockEventKey.Text = "Block Key";
        toolTip.SetToolTip(checkBoxBlockEventKey, "Checked - Will not send the pressed key to the window\r\nUnchecked(default) - Will send the pressed key, along with any triggering skills.");
        checkBoxBlockEventKey.UseVisualStyleBackColor = true;
        // 
        // checkBoxIgnoreModifiers
        // 
        checkBoxIgnoreModifiers.AutoSize = true;
        checkBoxIgnoreModifiers.Location = new Point(32, 310);
        checkBoxIgnoreModifiers.Name = "checkBoxIgnoreModifiers";
        checkBoxIgnoreModifiers.Size = new Size(117, 19);
        checkBoxIgnoreModifiers.TabIndex = 28;
        checkBoxIgnoreModifiers.Text = "Any Modifier Key";
        toolTip.SetToolTip(checkBoxIgnoreModifiers, "Checked - Will trigger regardless of modifier key states.\r\nUnchecked - Will only trigger when the correct modifier key(s) are pressed.");
        checkBoxIgnoreModifiers.UseVisualStyleBackColor = true;
        checkBoxIgnoreModifiers.CheckedChanged += checkBoxIgnoreModifiers_CheckedChanged;
        // 
        // checkBoxFirstFound
        // 
        checkBoxFirstFound.AutoSize = true;
        checkBoxFirstFound.Location = new Point(147, 310);
        checkBoxFirstFound.Name = "checkBoxFirstFound";
        checkBoxFirstFound.Size = new Size(85, 19);
        checkBoxFirstFound.TabIndex = 30;
        checkBoxFirstFound.Text = "First Found";
        toolTip.SetToolTip(checkBoxFirstFound, "Checked - Will stop when a skill is successfuly triggered.\r\nUnchecked - Will attempt to trigger all skills.\r\n\r\nCommon use: PoE loot key. Looking for many labels, \r\njust click on the first found.");
        checkBoxFirstFound.UseVisualStyleBackColor = true;
        // 
        // labelDelay
        // 
        labelDelay.AutoSize = true;
        labelDelay.Location = new Point(142, 259);
        labelDelay.Name = "labelDelay";
        labelDelay.Size = new Size(39, 15);
        labelDelay.TabIndex = 31;
        labelDelay.Text = "Delay:";
        toolTip.SetToolTip(labelDelay, "Delay between each skill send in the Key Event.");
        // 
        // checkBoxAlt
        // 
        checkBoxAlt.AutoSize = true;
        checkBoxAlt.Location = new Point(40, 22);
        checkBoxAlt.Name = "checkBoxAlt";
        checkBoxAlt.Size = new Size(41, 19);
        checkBoxAlt.TabIndex = 34;
        checkBoxAlt.Text = "Alt";
        toolTip.SetToolTip(checkBoxAlt, "Enable or disable this KeyEvent when in 'Running' mode.");
        checkBoxAlt.UseVisualStyleBackColor = true;
        checkBoxAlt.CheckedChanged += checkBoxAlt_CheckedChanged;
        // 
        // checkBoxCtrl
        // 
        checkBoxCtrl.AutoSize = true;
        checkBoxCtrl.Location = new Point(87, 22);
        checkBoxCtrl.Name = "checkBoxCtrl";
        checkBoxCtrl.Size = new Size(45, 19);
        checkBoxCtrl.TabIndex = 35;
        checkBoxCtrl.Text = "Ctrl";
        toolTip.SetToolTip(checkBoxCtrl, "Enable or disable this KeyEvent when in 'Running' mode.");
        checkBoxCtrl.UseVisualStyleBackColor = true;
        checkBoxCtrl.CheckedChanged += checkBoxCtrl_CheckedChanged;
        // 
        // checkBoxShift
        // 
        checkBoxShift.AutoSize = true;
        checkBoxShift.Location = new Point(138, 22);
        checkBoxShift.Name = "checkBoxShift";
        checkBoxShift.Size = new Size(50, 19);
        checkBoxShift.TabIndex = 36;
        checkBoxShift.Text = "Shift";
        toolTip.SetToolTip(checkBoxShift, "Enable or disable this KeyEvent when in 'Running' mode.");
        checkBoxShift.UseVisualStyleBackColor = true;
        checkBoxShift.CheckedChanged += checkBoxShift_CheckedChanged;
        // 
        // textBoxDelay
        // 
        textBoxDelay.Location = new Point(187, 256);
        textBoxDelay.Name = "textBoxDelay";
        textBoxDelay.Size = new Size(62, 23);
        textBoxDelay.TabIndex = 32;
        // 
        // groupBoxMods
        // 
        groupBoxMods.Controls.Add(checkBoxShift);
        groupBoxMods.Controls.Add(checkBoxCtrl);
        groupBoxMods.Controls.Add(checkBoxAlt);
        groupBoxMods.Location = new Point(25, 337);
        groupBoxMods.Name = "groupBoxMods";
        groupBoxMods.Size = new Size(224, 48);
        groupBoxMods.TabIndex = 33;
        groupBoxMods.TabStop = false;
        groupBoxMods.Text = "Hold Modifier Keys";
        // 
        // textBoxName
        // 
        textBoxName.Location = new Point(56, 7);
        textBoxName.Name = "textBoxName";
        textBoxName.Size = new Size(157, 23);
        textBoxName.TabIndex = 35;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 10);
        label2.Name = "label2";
        label2.Size = new Size(42, 15);
        label2.TabIndex = 34;
        label2.Text = "Name:";
        // 
        // KeyDialog
        // 
        AcceptButton = buttonSave;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = buttonCancel;
        ClientSize = new Size(271, 428);
        Controls.Add(textBoxName);
        Controls.Add(label2);
        Controls.Add(groupBoxMods);
        Controls.Add(textBoxDelay);
        Controls.Add(labelDelay);
        Controls.Add(checkBoxFirstFound);
        Controls.Add(checkBoxBlockEventKey);
        Controls.Add(checkBoxIgnoreModifiers);
        Controls.Add(checkBoxPausable);
        Controls.Add(checkBoxEnabled);
        Controls.Add(buttonDelete);
        Controls.Add(groupBox1);
        Controls.Add(buttonGetKey);
        Controls.Add(textBoxKey);
        Controls.Add(labelName);
        Controls.Add(buttonSave);
        Controls.Add(buttonCancel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "KeyDialog";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "KeyDialog";
        FormClosed += KeyDialog_FormClosed;
        Load += KeyDialog_Load;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        groupBoxMods.ResumeLayout(false);
        groupBoxMods.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button buttonDelete;
    private GroupBox groupBox1;
    private Button buttonGetKey;
    private TextBox textBoxKey;
    private Label labelName;
    private Button buttonSave;
    private Button buttonCancel;
    private Button buttonRemoveSkill;
    private ListBox listBoxSkills;
    private Label label1;
    private ComboBox comboBoxAllSkills;
    private ErrorProvider errorProvider;
    private CheckBox checkBoxPausable;
    private CheckBox checkBoxEnabled;
    private ToolTip toolTip;
    private CheckBox checkBoxBlockEventKey;
    private CheckBox checkBoxIgnoreModifiers;
    private CheckBox checkBoxFirstFound;
    private TextBox textBoxDelay;
    private Label labelDelay;
    private GroupBox groupBoxMods;
    private CheckBox checkBoxAlt;
    private CheckBox checkBoxShift;
    private CheckBox checkBoxCtrl;
    private TextBox textBoxName;
    private Label label2;
}