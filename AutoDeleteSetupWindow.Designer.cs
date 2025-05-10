namespace ZomboidBackupManager
{
    partial class AutoDeleteSetupWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoDeleteSetupWindow));
            AutoDeleteEnabledCheckBox = new CheckBox();
            AutoDeleteCountTrackBar = new TrackBar();
            TrackbarPanel = new Panel();
            AutoDeleteCountValueLabel = new Label();
            AutoDeleteCountTextLabel = new Label();
            OkButton = new Button();
            ((System.ComponentModel.ISupportInitialize)AutoDeleteCountTrackBar).BeginInit();
            TrackbarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // AutoDeleteEnabledCheckBox
            // 
            AutoDeleteEnabledCheckBox.AutoSize = true;
            AutoDeleteEnabledCheckBox.Dock = DockStyle.Top;
            AutoDeleteEnabledCheckBox.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AutoDeleteEnabledCheckBox.Location = new Point(0, 0);
            AutoDeleteEnabledCheckBox.Margin = new Padding(5);
            AutoDeleteEnabledCheckBox.Name = "AutoDeleteEnabledCheckBox";
            AutoDeleteEnabledCheckBox.Padding = new Padding(5);
            AutoDeleteEnabledCheckBox.Size = new Size(284, 33);
            AutoDeleteEnabledCheckBox.TabIndex = 0;
            AutoDeleteEnabledCheckBox.Text = "Auto Delete Enabled";
            AutoDeleteEnabledCheckBox.UseVisualStyleBackColor = true;
            AutoDeleteEnabledCheckBox.CheckedChanged += AutoDeleteEnabledCheckBox_CheckedChanged;
            // 
            // AutoDeleteCountTrackBar
            // 
            AutoDeleteCountTrackBar.BackColor = SystemColors.Control;
            AutoDeleteCountTrackBar.Dock = DockStyle.Bottom;
            AutoDeleteCountTrackBar.LargeChange = 1;
            AutoDeleteCountTrackBar.Location = new Point(0, 37);
            AutoDeleteCountTrackBar.Margin = new Padding(5);
            AutoDeleteCountTrackBar.Name = "AutoDeleteCountTrackBar";
            AutoDeleteCountTrackBar.Size = new Size(284, 45);
            AutoDeleteCountTrackBar.TabIndex = 1;
            AutoDeleteCountTrackBar.TickStyle = TickStyle.None;
            AutoDeleteCountTrackBar.ValueChanged += AutoDeleteCountTrackBar_ValueChanged;
            // 
            // TrackbarPanel
            // 
            TrackbarPanel.Controls.Add(AutoDeleteCountValueLabel);
            TrackbarPanel.Controls.Add(AutoDeleteCountTextLabel);
            TrackbarPanel.Controls.Add(AutoDeleteCountTrackBar);
            TrackbarPanel.Location = new Point(0, 41);
            TrackbarPanel.Name = "TrackbarPanel";
            TrackbarPanel.Size = new Size(284, 82);
            TrackbarPanel.TabIndex = 5;
            // 
            // AutoDeleteCountValueLabel
            // 
            AutoDeleteCountValueLabel.AutoSize = true;
            AutoDeleteCountValueLabel.BackColor = SystemColors.ControlLightLight;
            AutoDeleteCountValueLabel.BorderStyle = BorderStyle.FixedSingle;
            AutoDeleteCountValueLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AutoDeleteCountValueLabel.Location = new Point(133, 13);
            AutoDeleteCountValueLabel.Name = "AutoDeleteCountValueLabel";
            AutoDeleteCountValueLabel.Size = new Size(20, 21);
            AutoDeleteCountValueLabel.TabIndex = 3;
            AutoDeleteCountValueLabel.Text = "5";
            AutoDeleteCountValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AutoDeleteCountTextLabel
            // 
            AutoDeleteCountTextLabel.AutoSize = true;
            AutoDeleteCountTextLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AutoDeleteCountTextLabel.Location = new Point(12, 13);
            AutoDeleteCountTextLabel.Name = "AutoDeleteCountTextLabel";
            AutoDeleteCountTextLabel.Size = new Size(115, 19);
            AutoDeleteCountTextLabel.TabIndex = 2;
            AutoDeleteCountTextLabel.Text = "Keep Backups:";
            // 
            // OkButton
            // 
            OkButton.AutoSize = true;
            OkButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            OkButton.Dock = DockStyle.Bottom;
            OkButton.Location = new Point(0, 132);
            OkButton.Margin = new Padding(25, 5, 5, 5);
            OkButton.Name = "OkButton";
            OkButton.RightToLeft = RightToLeft.No;
            OkButton.Size = new Size(284, 29);
            OkButton.TabIndex = 6;
            OkButton.Text = "Ok";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // AutoDeleteSetupWindow
            // 
            AcceptButton = OkButton;
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(284, 161);
            Controls.Add(OkButton);
            Controls.Add(AutoDeleteEnabledCheckBox);
            Controls.Add(TrackbarPanel);
            Font = new Font("Bahnschrift", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "AutoDeleteSetupWindow";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Setup: Auto Delete";
            TopMost = true;
            Shown += AutoDeleteSetupWindow_Shown;
            ((System.ComponentModel.ISupportInitialize)AutoDeleteCountTrackBar).EndInit();
            TrackbarPanel.ResumeLayout(false);
            TrackbarPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox AutoDeleteEnabledCheckBox;
        private TrackBar AutoDeleteCountTrackBar;
        private Panel TrackbarPanel;
        private Label AutoDeleteCountTextLabel;
        private Label AutoDeleteCountValueLabel;
        private Button OkButton;
    }
}