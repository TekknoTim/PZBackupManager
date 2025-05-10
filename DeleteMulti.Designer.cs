namespace ZomboidBackupManager
{
    partial class DeleteMulti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteMulti));
            ProgressBarOverall = new ProgressBar();
            ProgressBar = new ProgressBar();
            StatusLabel = new Label();
            CancelNextProcessButton = new Button();
            StatusOverallLabel = new Label();
            SuspendLayout();
            // 
            // ProgressBarOverall
            // 
            ProgressBarOverall.Location = new Point(12, 38);
            ProgressBarOverall.Name = "ProgressBarOverall";
            ProgressBarOverall.Size = new Size(560, 25);
            ProgressBarOverall.TabIndex = 0;
            // 
            // ProgressBar
            // 
            ProgressBar.Location = new Point(12, 96);
            ProgressBar.Margin = new Padding(3, 10, 3, 30);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(560, 25);
            ProgressBar.TabIndex = 1;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StatusLabel.Location = new Point(12, 74);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(59, 19);
            StatusLabel.TabIndex = 2;
            StatusLabel.Text = "Status:";
            // 
            // CancelNextProcessButton
            // 
            CancelNextProcessButton.Location = new Point(219, 154);
            CancelNextProcessButton.Margin = new Padding(210, 30, 210, 3);
            CancelNextProcessButton.Name = "CancelNextProcessButton";
            CancelNextProcessButton.Size = new Size(146, 30);
            CancelNextProcessButton.TabIndex = 3;
            CancelNextProcessButton.Text = "Cancel";
            CancelNextProcessButton.UseVisualStyleBackColor = true;
            CancelNextProcessButton.Click += CancelNextProcessButton_Click;
            // 
            // StatusOverallLabel
            // 
            StatusOverallLabel.AutoSize = true;
            StatusOverallLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StatusOverallLabel.Location = new Point(12, 9);
            StatusOverallLabel.Name = "StatusOverallLabel";
            StatusOverallLabel.Size = new Size(59, 19);
            StatusOverallLabel.TabIndex = 4;
            StatusOverallLabel.Text = "Status:";
            // 
            // DeleteMulti
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 196);
            Controls.Add(StatusOverallLabel);
            Controls.Add(CancelNextProcessButton);
            Controls.Add(StatusLabel);
            Controls.Add(ProgressBar);
            Controls.Add(ProgressBarOverall);
            Font = new Font("Bahnschrift", 10F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "DeleteMulti";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Process Active";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar ProgressBarOverall;
        private ProgressBar ProgressBar;
        private Label StatusLabel;
        private Button CancelNextProcessButton;
        private Label StatusOverallLabel;
    }
}