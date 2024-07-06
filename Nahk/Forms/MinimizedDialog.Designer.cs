namespace Nahk.Forms;

partial class MinimizedDialog
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
        labelStatus = new Label();
        buttonRun = new Button();
        buttonStop = new Button();
        SuspendLayout();
        // 
        // labelStatus
        // 
        labelStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        labelStatus.AutoSize = true;
        labelStatus.ForeColor = Color.Red;
        labelStatus.Location = new Point(10, 11);
        labelStatus.Name = "labelStatus";
        labelStatus.Size = new Size(51, 15);
        labelStatus.TabIndex = 19;
        labelStatus.Text = "Stopped";
        // 
        // buttonRun
        // 
        buttonRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonRun.Enabled = false;
        buttonRun.Location = new Point(88, 7);
        buttonRun.Name = "buttonRun";
        buttonRun.Size = new Size(75, 23);
        buttonRun.TabIndex = 16;
        buttonRun.Text = "Run";
        buttonRun.UseVisualStyleBackColor = true;
        buttonRun.Click += buttonRun_Click;
        // 
        // buttonStop
        // 
        buttonStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonStop.Enabled = false;
        buttonStop.Location = new Point(169, 7);
        buttonStop.Name = "buttonStop";
        buttonStop.Size = new Size(75, 23);
        buttonStop.TabIndex = 17;
        buttonStop.Text = "Stop";
        buttonStop.UseVisualStyleBackColor = true;
        buttonStop.Click += buttonStop_Click;
        // 
        // MinimizedDialog
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(257, 36);
        Controls.Add(labelStatus);
        Controls.Add(buttonRun);
        Controls.Add(buttonStop);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "MinimizedDialog";
        Opacity = 0.9D;
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "MinimizedDialog";
        TopMost = true;
        FormClosing += MinimizedDialog_FormClosing;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelStatus;
    private Button buttonRun;
    private Button buttonStop;
}