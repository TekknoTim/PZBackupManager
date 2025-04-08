namespace ZomboidBackupManager
{
    partial class AboutInfoWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutInfoWindow));
            OkButton = new Button();
            ChangelogButton = new Button();
            AuthorPanel = new Panel();
            AuthorLinkLabel = new LinkLabel();
            AuthorHeadlineLabel = new Label();
            panel3 = new Panel();
            VersionLabel = new Label();
            WindowTitleLabel = new Label();
            PictureBackgroundPanel = new Panel();
            PZBackupManagerLogoPictureBox = new PictureBox();
            GitHubPanel = new Panel();
            GitHubLinkLabel = new LinkLabel();
            GitHubHeadlineLabel = new Label();
            WorkshopPanel = new Panel();
            WorkshopLinkLabel = new LinkLabel();
            WorkshopHeadlineLabel = new Label();
            AuthorPanel.SuspendLayout();
            panel3.SuspendLayout();
            PictureBackgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PZBackupManagerLogoPictureBox).BeginInit();
            GitHubPanel.SuspendLayout();
            WorkshopPanel.SuspendLayout();
            SuspendLayout();
            // 
            // OkButton
            // 
            OkButton.AutoSize = true;
            OkButton.Font = new Font("Bahnschrift", 9F);
            OkButton.Location = new Point(385, 502);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(75, 29);
            OkButton.TabIndex = 0;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // ChangelogButton
            // 
            ChangelogButton.AutoSize = true;
            ChangelogButton.Font = new Font("Bahnschrift", 9F);
            ChangelogButton.Location = new Point(24, 502);
            ChangelogButton.Name = "ChangelogButton";
            ChangelogButton.Size = new Size(75, 29);
            ChangelogButton.TabIndex = 1;
            ChangelogButton.Text = "Changelog";
            ChangelogButton.UseVisualStyleBackColor = true;
            ChangelogButton.Click += ChangelogButton_Click;
            // 
            // AuthorPanel
            // 
            AuthorPanel.BackColor = SystemColors.ControlDark;
            AuthorPanel.BorderStyle = BorderStyle.Fixed3D;
            AuthorPanel.Controls.Add(AuthorLinkLabel);
            AuthorPanel.Controls.Add(AuthorHeadlineLabel);
            AuthorPanel.Location = new Point(24, 254);
            AuthorPanel.Name = "AuthorPanel";
            AuthorPanel.Size = new Size(436, 40);
            AuthorPanel.TabIndex = 2;
            // 
            // AuthorLinkLabel
            // 
            AuthorLinkLabel.AutoSize = true;
            AuthorLinkLabel.BackColor = SystemColors.Control;
            AuthorLinkLabel.Font = new Font("Bahnschrift", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AuthorLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            AuthorLinkLabel.Location = new Point(97, 6);
            AuthorLinkLabel.Name = "AuthorLinkLabel";
            AuthorLinkLabel.Size = new Size(98, 23);
            AuthorLinkLabel.TabIndex = 1;
            AuthorLinkLabel.TabStop = true;
            AuthorLinkLabel.Text = "TekknoTim";
            AuthorLinkLabel.TextAlign = ContentAlignment.MiddleCenter;
            AuthorLinkLabel.LinkClicked += AuthorLinkLabel_LinkClicked;
            // 
            // AuthorHeadlineLabel
            // 
            AuthorHeadlineLabel.BackColor = SystemColors.Control;
            AuthorHeadlineLabel.Font = new Font("Bahnschrift", 14F, FontStyle.Bold);
            AuthorHeadlineLabel.ForeColor = SystemColors.ControlText;
            AuthorHeadlineLabel.Location = new Point(5, 5);
            AuthorHeadlineLabel.Margin = new Padding(5);
            AuthorHeadlineLabel.Name = "AuthorHeadlineLabel";
            AuthorHeadlineLabel.Size = new Size(84, 25);
            AuthorHeadlineLabel.TabIndex = 0;
            AuthorHeadlineLabel.Text = "Author";
            AuthorHeadlineLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDark;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(VersionLabel);
            panel3.Controls.Add(WindowTitleLabel);
            panel3.Controls.Add(PictureBackgroundPanel);
            panel3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel3.Location = new Point(24, 24);
            panel3.Margin = new Padding(15);
            panel3.Name = "panel3";
            panel3.Size = new Size(436, 190);
            panel3.TabIndex = 3;
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.BackColor = SystemColors.ControlDarkDark;
            VersionLabel.BorderStyle = BorderStyle.FixedSingle;
            VersionLabel.Font = new Font("Bahnschrift", 18F, FontStyle.Bold);
            VersionLabel.ForeColor = SystemColors.Info;
            VersionLabel.Location = new Point(256, 134);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(72, 31);
            VersionLabel.TabIndex = 3;
            VersionLabel.Text = "v0.0.0";
            VersionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WindowTitleLabel
            // 
            WindowTitleLabel.AutoSize = true;
            WindowTitleLabel.BackColor = SystemColors.ControlDarkDark;
            WindowTitleLabel.Font = new Font("a dripping marker", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            WindowTitleLabel.ForeColor = SystemColors.Info;
            WindowTitleLabel.Location = new Point(183, 15);
            WindowTitleLabel.Name = "WindowTitleLabel";
            WindowTitleLabel.Size = new Size(231, 94);
            WindowTitleLabel.TabIndex = 2;
            WindowTitleLabel.Text = "Project Zomboid\r\nBackup  Manager";
            WindowTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PictureBackgroundPanel
            // 
            PictureBackgroundPanel.BackColor = SystemColors.Info;
            PictureBackgroundPanel.BorderStyle = BorderStyle.Fixed3D;
            PictureBackgroundPanel.Controls.Add(PZBackupManagerLogoPictureBox);
            PictureBackgroundPanel.Location = new Point(15, 15);
            PictureBackgroundPanel.Margin = new Padding(15);
            PictureBackgroundPanel.Name = "PictureBackgroundPanel";
            PictureBackgroundPanel.Size = new Size(150, 150);
            PictureBackgroundPanel.TabIndex = 1;
            // 
            // PZBackupManagerLogoPictureBox
            // 
            PZBackupManagerLogoPictureBox.BackColor = SystemColors.Info;
            PZBackupManagerLogoPictureBox.BackgroundImageLayout = ImageLayout.Center;
            PZBackupManagerLogoPictureBox.Image = Properties.Resources.PZBackupManagerLogo;
            PZBackupManagerLogoPictureBox.Location = new Point(11, 11);
            PZBackupManagerLogoPictureBox.Margin = new Padding(11);
            PZBackupManagerLogoPictureBox.Name = "PZBackupManagerLogoPictureBox";
            PZBackupManagerLogoPictureBox.Size = new Size(128, 128);
            PZBackupManagerLogoPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            PZBackupManagerLogoPictureBox.TabIndex = 0;
            PZBackupManagerLogoPictureBox.TabStop = false;
            // 
            // GitHubPanel
            // 
            GitHubPanel.BackColor = SystemColors.ControlDark;
            GitHubPanel.BorderStyle = BorderStyle.Fixed3D;
            GitHubPanel.Controls.Add(GitHubLinkLabel);
            GitHubPanel.Controls.Add(GitHubHeadlineLabel);
            GitHubPanel.Location = new Point(24, 300);
            GitHubPanel.Name = "GitHubPanel";
            GitHubPanel.Size = new Size(436, 40);
            GitHubPanel.TabIndex = 3;
            // 
            // GitHubLinkLabel
            // 
            GitHubLinkLabel.AutoSize = true;
            GitHubLinkLabel.BackColor = SystemColors.Control;
            GitHubLinkLabel.Font = new Font("Bahnschrift", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GitHubLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            GitHubLinkLabel.Location = new Point(97, 6);
            GitHubLinkLabel.Name = "GitHubLinkLabel";
            GitHubLinkLabel.Size = new Size(113, 23);
            GitHubLinkLabel.TabIndex = 1;
            GitHubLinkLabel.TabStop = true;
            GitHubLinkLabel.Text = "Open Github";
            GitHubLinkLabel.TextAlign = ContentAlignment.MiddleCenter;
            GitHubLinkLabel.LinkClicked += GitHubLinkLabel_LinkClicked;
            // 
            // GitHubHeadlineLabel
            // 
            GitHubHeadlineLabel.BackColor = SystemColors.Control;
            GitHubHeadlineLabel.Font = new Font("Bahnschrift", 14F, FontStyle.Bold);
            GitHubHeadlineLabel.ForeColor = SystemColors.ControlText;
            GitHubHeadlineLabel.Location = new Point(5, 5);
            GitHubHeadlineLabel.Margin = new Padding(5);
            GitHubHeadlineLabel.Name = "GitHubHeadlineLabel";
            GitHubHeadlineLabel.Size = new Size(84, 25);
            GitHubHeadlineLabel.TabIndex = 0;
            GitHubHeadlineLabel.Text = "GitHub";
            GitHubHeadlineLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WorkshopPanel
            // 
            WorkshopPanel.BackColor = SystemColors.ControlDark;
            WorkshopPanel.BorderStyle = BorderStyle.Fixed3D;
            WorkshopPanel.Controls.Add(WorkshopLinkLabel);
            WorkshopPanel.Controls.Add(WorkshopHeadlineLabel);
            WorkshopPanel.Location = new Point(24, 346);
            WorkshopPanel.Name = "WorkshopPanel";
            WorkshopPanel.Size = new Size(436, 40);
            WorkshopPanel.TabIndex = 4;
            // 
            // WorkshopLinkLabel
            // 
            WorkshopLinkLabel.AutoSize = true;
            WorkshopLinkLabel.BackColor = SystemColors.Control;
            WorkshopLinkLabel.Font = new Font("Bahnschrift", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            WorkshopLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            WorkshopLinkLabel.Location = new Point(97, 6);
            WorkshopLinkLabel.Name = "WorkshopLinkLabel";
            WorkshopLinkLabel.Size = new Size(142, 23);
            WorkshopLinkLabel.TabIndex = 1;
            WorkshopLinkLabel.TabStop = true;
            WorkshopLinkLabel.Text = "Open Workshop";
            WorkshopLinkLabel.TextAlign = ContentAlignment.MiddleCenter;
            WorkshopLinkLabel.LinkClicked += WorkshopLinkLabel_LinkClicked;
            // 
            // WorkshopHeadlineLabel
            // 
            WorkshopHeadlineLabel.BackColor = SystemColors.Control;
            WorkshopHeadlineLabel.Font = new Font("Bahnschrift SemiCondensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            WorkshopHeadlineLabel.ForeColor = SystemColors.ControlText;
            WorkshopHeadlineLabel.Location = new Point(5, 5);
            WorkshopHeadlineLabel.Margin = new Padding(5);
            WorkshopHeadlineLabel.Name = "WorkshopHeadlineLabel";
            WorkshopHeadlineLabel.Size = new Size(84, 25);
            WorkshopHeadlineLabel.TabIndex = 0;
            WorkshopHeadlineLabel.Text = "Workshop";
            WorkshopHeadlineLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AboutInfoWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 543);
            Controls.Add(WorkshopPanel);
            Controls.Add(GitHubPanel);
            Controls.Add(panel3);
            Controls.Add(AuthorPanel);
            Controls.Add(ChangelogButton);
            Controls.Add(OkButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AboutInfoWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About";
            TopMost = true;
            AuthorPanel.ResumeLayout(false);
            AuthorPanel.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            PictureBackgroundPanel.ResumeLayout(false);
            PictureBackgroundPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PZBackupManagerLogoPictureBox).EndInit();
            GitHubPanel.ResumeLayout(false);
            GitHubPanel.PerformLayout();
            WorkshopPanel.ResumeLayout(false);
            WorkshopPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OkButton;
        private Button ChangelogButton;
        private Panel AuthorPanel;
        private Panel panel3;
        private PictureBox PZBackupManagerLogoPictureBox;
        private Panel PictureBackgroundPanel;
        private Label WindowTitleLabel;
        private Label VersionLabel;
        private Label AuthorHeadlineLabel;
        private LinkLabel AuthorLinkLabel;
        private Panel GitHubPanel;
        private LinkLabel GitHubLinkLabel;
        private Label GitHubHeadlineLabel;
        private Panel WorkshopPanel;
        private LinkLabel WorkshopLinkLabel;
        private Label WorkshopHeadlineLabel;
    }
}