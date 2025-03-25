namespace ZomboidBackupManager
{
    partial class MiniBackupWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniBackupWindow));
            BackupButton = new Button();
            ProgressBar = new ProgressBar();
            ProgressLabel = new Label();
            SuspendLayout();
            // 
            // BackupButton
            // 
            BackupButton.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackupButton.Location = new Point(112, 123);
            BackupButton.Margin = new Padding(100, 3, 100, 3);
            BackupButton.Name = "BackupButton";
            BackupButton.Size = new Size(160, 50);
            BackupButton.TabIndex = 0;
            BackupButton.Text = "Backup";
            BackupButton.UseVisualStyleBackColor = true;
            BackupButton.Click += BackupButton_Click;
            // 
            // ProgressBar
            // 
            ProgressBar.Location = new Point(19, 49);
            ProgressBar.Margin = new Padding(10, 10, 10, 20);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(346, 50);
            ProgressBar.TabIndex = 1;
            // 
            // ProgressLabel
            // 
            ProgressLabel.AutoSize = true;
            ProgressLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProgressLabel.Location = new Point(19, 24);
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new Size(17, 19);
            ProgressLabel.TabIndex = 2;
            ProgressLabel.Text = "-";
            ProgressLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MiniBackupWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 181);
            Controls.Add(ProgressLabel);
            Controls.Add(ProgressBar);
            Controls.Add(BackupButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MiniBackupWindow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Mini Backup Window";
            FormClosing += MiniBackupWindow_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BackupButton;
        private ProgressBar ProgressBar;
        private Label ProgressLabel;
    }
}