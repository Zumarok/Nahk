namespace Nahk.Forms;

partial class FormMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
        menuStripMain = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        newProfileToolStripMenuItem = new ToolStripMenuItem();
        saveToolStripMenuItem = new ToolStripMenuItem();
        saveAsToolStripMenuItem = new ToolStripMenuItem();
        loadProfileToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        deleteProfileToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator2 = new ToolStripSeparator();
        exitToolStripMenuItem = new ToolStripMenuItem();
        editToolStripMenuItem = new ToolStripMenuItem();
        settingsToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator3 = new ToolStripSeparator();
        alwaysOnTopToolStripMenuItem = new ToolStripMenuItem();
        helpToolStripMenuItem = new ToolStripMenuItem();
        toolTipMain = new ToolTip(components);
        labelWindowTitle = new Label();
        labelPauses = new Label();
        labelSkills = new Label();
        labelKeys = new Label();
        labelLog = new Label();
        labelStatusStatic = new Label();
        labelStatus = new Label();
        errorProviderMain = new ErrorProvider(components);
        textBoxWindowTitle = new TextBox();
        comboBoxPauseChecks = new ComboBox();
        buttonAddPausePoint = new Button();
        buttonAddSkillCheck = new Button();
        comboBoxSkillChecks = new ComboBox();
        buttonAddKeyEvent = new Button();
        comboBoxKeys = new ComboBox();
        buttonStop = new Button();
        buttonRun = new Button();
        listBoxEventLog = new ListBox();
        menuStripMain.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errorProviderMain).BeginInit();
        SuspendLayout();
        // 
        // menuStripMain
        // 
        menuStripMain.BackColor = SystemColors.ButtonFace;
        menuStripMain.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, helpToolStripMenuItem });
        menuStripMain.Location = new Point(0, 0);
        menuStripMain.Name = "menuStripMain";
        menuStripMain.Size = new Size(351, 24);
        menuStripMain.TabIndex = 2;
        menuStripMain.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newProfileToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, loadProfileToolStripMenuItem, toolStripSeparator1, deleteProfileToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "File";
        // 
        // newProfileToolStripMenuItem
        // 
        newProfileToolStripMenuItem.Name = "newProfileToolStripMenuItem";
        newProfileToolStripMenuItem.Size = new Size(160, 22);
        newProfileToolStripMenuItem.Text = "New Profile";
        newProfileToolStripMenuItem.Click += newProfileToolStripMenuItem_Click;
        // 
        // saveToolStripMenuItem
        // 
        saveToolStripMenuItem.Enabled = false;
        saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        saveToolStripMenuItem.Size = new Size(160, 22);
        saveToolStripMenuItem.Text = "Save Profile";
        saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
        // 
        // saveAsToolStripMenuItem
        // 
        saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
        saveAsToolStripMenuItem.Size = new Size(160, 22);
        saveAsToolStripMenuItem.Text = "Save Profile As...";
        saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
        // 
        // loadProfileToolStripMenuItem
        // 
        loadProfileToolStripMenuItem.Name = "loadProfileToolStripMenuItem";
        loadProfileToolStripMenuItem.Size = new Size(160, 22);
        loadProfileToolStripMenuItem.Text = "Load Profile";
        loadProfileToolStripMenuItem.Click += loadProfileToolStripMenuItem_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(157, 6);
        // 
        // deleteProfileToolStripMenuItem
        // 
        deleteProfileToolStripMenuItem.Enabled = false;
        deleteProfileToolStripMenuItem.Name = "deleteProfileToolStripMenuItem";
        deleteProfileToolStripMenuItem.Size = new Size(160, 22);
        deleteProfileToolStripMenuItem.Text = "Delete Profile";
        deleteProfileToolStripMenuItem.Click += deleteProfileToolStripMenuItem_Click;
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(157, 6);
        // 
        // exitToolStripMenuItem
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new Size(160, 22);
        exitToolStripMenuItem.Text = "Exit";
        exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
        // 
        // editToolStripMenuItem
        // 
        editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, toolStripSeparator3, alwaysOnTopToolStripMenuItem });
        editToolStripMenuItem.Name = "editToolStripMenuItem";
        editToolStripMenuItem.Size = new Size(39, 20);
        editToolStripMenuItem.Text = "Edit";
        // 
        // settingsToolStripMenuItem
        // 
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        settingsToolStripMenuItem.Size = new Size(149, 22);
        settingsToolStripMenuItem.Text = "Settings";
        settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
        // 
        // toolStripSeparator3
        // 
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new Size(146, 6);
        // 
        // alwaysOnTopToolStripMenuItem
        // 
        alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
        alwaysOnTopToolStripMenuItem.Size = new Size(149, 22);
        alwaysOnTopToolStripMenuItem.Text = "Always on top";
        alwaysOnTopToolStripMenuItem.Click += alwaysOnTopToolStripMenuItem_Click;
        // 
        // helpToolStripMenuItem
        // 
        helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        helpToolStripMenuItem.Size = new Size(44, 20);
        helpToolStripMenuItem.Text = "Help";
        // 
        // labelWindowTitle
        // 
        labelWindowTitle.AutoSize = true;
        labelWindowTitle.Location = new Point(12, 24);
        labelWindowTitle.Name = "labelWindowTitle";
        labelWindowTitle.Size = new Size(114, 15);
        labelWindowTitle.TabIndex = 3;
        labelWindowTitle.Text = "Target Window Title:";
        toolTipMain.SetToolTip(labelWindowTitle, "Full name of the game window (case insensitive).\r\n");
        // 
        // labelPauses
        // 
        labelPauses.AutoSize = true;
        labelPauses.Location = new Point(12, 90);
        labelPauses.Name = "labelPauses";
        labelPauses.Size = new Size(46, 15);
        labelPauses.TabIndex = 5;
        labelPauses.Text = "Pauses:";
        toolTipMain.SetToolTip(labelPauses, "Automation will pause for these.\r\nConsists of a pixel position and color.");
        // 
        // labelSkills
        // 
        labelSkills.AutoSize = true;
        labelSkills.Location = new Point(12, 119);
        labelSkills.Name = "labelSkills";
        labelSkills.Size = new Size(36, 15);
        labelSkills.TabIndex = 8;
        labelSkills.Text = "Skills:";
        toolTipMain.SetToolTip(labelSkills, "Skills to automate.\r\nConsists of a Name, a Key, and a Timer or Color check.");
        // 
        // labelKeys
        // 
        labelKeys.AutoSize = true;
        labelKeys.Location = new Point(12, 148);
        labelKeys.Name = "labelKeys";
        labelKeys.Size = new Size(34, 15);
        labelKeys.TabIndex = 11;
        labelKeys.Text = "Keys:";
        toolTipMain.SetToolTip(labelKeys, "Keys that will trigger skills.\r\nConsists of a key combo and the a list of skills that will trigger when pressed.");
        // 
        // labelLog
        // 
        labelLog.AutoSize = true;
        labelLog.Location = new Point(12, 177);
        labelLog.Name = "labelLog";
        labelLog.Size = new Size(62, 15);
        labelLog.TabIndex = 16;
        labelLog.Text = "Event Log:";
        toolTipMain.SetToolTip(labelLog, "Keys that will trigger skills.\r\nConsists of a key combo and the a list of skills that will trigger when pressed.");
        // 
        // labelStatusStatic
        // 
        labelStatusStatic.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        labelStatusStatic.AutoSize = true;
        labelStatusStatic.Location = new Point(16, 314);
        labelStatusStatic.Name = "labelStatusStatic";
        labelStatusStatic.Size = new Size(42, 15);
        labelStatusStatic.TabIndex = 14;
        labelStatusStatic.Text = "Status:";
        // 
        // labelStatus
        // 
        labelStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        labelStatus.AutoSize = true;
        labelStatus.ForeColor = Color.Red;
        labelStatus.Location = new Point(64, 314);
        labelStatus.Name = "labelStatus";
        labelStatus.Size = new Size(51, 15);
        labelStatus.TabIndex = 15;
        labelStatus.Text = "Stopped";
        // 
        // errorProviderMain
        // 
        errorProviderMain.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProviderMain.ContainerControl = this;
        // 
        // textBoxWindowTitle
        // 
        textBoxWindowTitle.Location = new Point(12, 42);
        textBoxWindowTitle.Name = "textBoxWindowTitle";
        textBoxWindowTitle.PlaceholderText = "ex. Diablo II";
        textBoxWindowTitle.Size = new Size(326, 23);
        textBoxWindowTitle.TabIndex = 4;
        // 
        // comboBoxPauseChecks
        // 
        comboBoxPauseChecks.FormattingEnabled = true;
        comboBoxPauseChecks.Location = new Point(74, 87);
        comboBoxPauseChecks.Name = "comboBoxPauseChecks";
        comboBoxPauseChecks.Size = new Size(225, 23);
        comboBoxPauseChecks.TabIndex = 6;
        comboBoxPauseChecks.SelectionChangeCommitted += comboBoxPauseChecks_SelectionChangeCommitted;
        // 
        // buttonAddPausePoint
        // 
        buttonAddPausePoint.Location = new Point(305, 87);
        buttonAddPausePoint.Name = "buttonAddPausePoint";
        buttonAddPausePoint.Size = new Size(33, 23);
        buttonAddPausePoint.TabIndex = 7;
        buttonAddPausePoint.Text = " +";
        buttonAddPausePoint.UseVisualStyleBackColor = true;
        buttonAddPausePoint.Click += buttonAddPausePoint_Click;
        // 
        // buttonAddSkillCheck
        // 
        buttonAddSkillCheck.Location = new Point(305, 116);
        buttonAddSkillCheck.Name = "buttonAddSkillCheck";
        buttonAddSkillCheck.Size = new Size(33, 23);
        buttonAddSkillCheck.TabIndex = 10;
        buttonAddSkillCheck.Text = " +";
        buttonAddSkillCheck.UseVisualStyleBackColor = true;
        buttonAddSkillCheck.Click += buttonAddSkillCheck_Click;
        // 
        // comboBoxSkillChecks
        // 
        comboBoxSkillChecks.FormattingEnabled = true;
        comboBoxSkillChecks.Location = new Point(74, 116);
        comboBoxSkillChecks.Name = "comboBoxSkillChecks";
        comboBoxSkillChecks.Size = new Size(225, 23);
        comboBoxSkillChecks.TabIndex = 9;
        comboBoxSkillChecks.SelectionChangeCommitted += comboBoxSkillChecks_SelectionChangeCommitted;
        // 
        // buttonAddKeyEvent
        // 
        buttonAddKeyEvent.Location = new Point(305, 145);
        buttonAddKeyEvent.Name = "buttonAddKeyEvent";
        buttonAddKeyEvent.Size = new Size(33, 23);
        buttonAddKeyEvent.TabIndex = 13;
        buttonAddKeyEvent.Text = " +";
        buttonAddKeyEvent.UseVisualStyleBackColor = true;
        buttonAddKeyEvent.Click += buttonAddKeyEvent_Click;
        // 
        // comboBoxKeys
        // 
        comboBoxKeys.FormattingEnabled = true;
        comboBoxKeys.Location = new Point(74, 145);
        comboBoxKeys.Name = "comboBoxKeys";
        comboBoxKeys.Size = new Size(225, 23);
        comboBoxKeys.TabIndex = 12;
        comboBoxKeys.SelectionChangeCommitted += comboBoxKeys_SelectionChangeCommitted;
        // 
        // buttonStop
        // 
        buttonStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonStop.Enabled = false;
        buttonStop.Location = new Point(264, 310);
        buttonStop.Name = "buttonStop";
        buttonStop.Size = new Size(75, 23);
        buttonStop.TabIndex = 1;
        buttonStop.Text = "Stop";
        buttonStop.UseVisualStyleBackColor = true;
        buttonStop.Click += buttonStop_Click;
        // 
        // buttonRun
        // 
        buttonRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonRun.Location = new Point(183, 310);
        buttonRun.Name = "buttonRun";
        buttonRun.Size = new Size(75, 23);
        buttonRun.TabIndex = 0;
        buttonRun.Text = "Run";
        buttonRun.UseVisualStyleBackColor = true;
        buttonRun.Click += buttonRun_Click;
        // 
        // listBoxEventLog
        // 
        listBoxEventLog.FormattingEnabled = true;
        listBoxEventLog.ItemHeight = 15;
        listBoxEventLog.Location = new Point(16, 195);
        listBoxEventLog.Name = "listBoxEventLog";
        listBoxEventLog.ScrollAlwaysVisible = true;
        listBoxEventLog.SelectionMode = SelectionMode.None;
        listBoxEventLog.Size = new Size(322, 109);
        listBoxEventLog.TabIndex = 17;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(351, 345);
        Controls.Add(listBoxEventLog);
        Controls.Add(labelLog);
        Controls.Add(labelStatus);
        Controls.Add(labelStatusStatic);
        Controls.Add(buttonRun);
        Controls.Add(buttonStop);
        Controls.Add(buttonAddKeyEvent);
        Controls.Add(labelKeys);
        Controls.Add(comboBoxKeys);
        Controls.Add(buttonAddSkillCheck);
        Controls.Add(labelSkills);
        Controls.Add(comboBoxSkillChecks);
        Controls.Add(buttonAddPausePoint);
        Controls.Add(labelPauses);
        Controls.Add(comboBoxPauseChecks);
        Controls.Add(textBoxWindowTitle);
        Controls.Add(labelWindowTitle);
        Controls.Add(menuStripMain);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MainMenuStrip = menuStripMain;
        MaximizeBox = false;
        Name = "FormMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "New Profile";
        FormClosing += FormMain_FormClosing;
        Load += FormMain_Load;
        Resize += FormMain_Resize;
        menuStripMain.ResumeLayout(false);
        menuStripMain.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)errorProviderMain).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStripMain;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripMenuItem loadProfileToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolTip toolTipMain;
    private ErrorProvider errorProviderMain;
    private Label labelWindowTitle;
    private TextBox textBoxWindowTitle;
    private Label labelPauses;
    private ComboBox comboBoxPauseChecks;
    private Button buttonAddPausePoint;
    private Button buttonAddSkillCheck;
    private Label labelSkills;
    private ComboBox comboBoxSkillChecks;
    private Button buttonAddKeyEvent;
    private Label labelKeys;
    private ComboBox comboBoxKeys;
    private Button buttonRun;
    private Button buttonStop;
    private ToolStripMenuItem saveAsToolStripMenuItem;
    private ToolStripMenuItem newProfileToolStripMenuItem;
    private ToolStripMenuItem deleteProfileToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private Label labelStatus;
    private Label labelStatusStatic;
    private ListBox listBoxEventLog;
    private Label labelLog;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem settingsToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem alwaysOnTopToolStripMenuItem;
}
