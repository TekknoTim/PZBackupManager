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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutInfoWindow));
            AuthorPanel = new Panel();
            AuthorLinkLabel = new LinkLabel();
            AuthorHeadlineLabel = new Label();
            HeadlinePanel = new Panel();
            HeadlineAndVersionPanel = new Panel();
            VersionLabel = new Label();
            WindowTitleLabel = new Label();
            PictureBackgroundPanel = new Panel();
            PZBackupManagerLogoPictureBox = new PictureBox();
            WebsiteLinkLogoPanel = new Panel();
            LogoPanelA = new Panel();
            GithubLogoPictureBox = new PictureBox();
            LogoPanelB = new Panel();
            SteamLogoPictureBox = new PictureBox();
            ToolStripPanel = new Panel();
            AboutWindowButtonTS = new ToolStrip();
            TSChangeLogButton = new ToolStripButton();
            TSAcceptButton = new ToolStripButton();
            TS_SeparatorB = new ToolStripSeparator();
            TS_SeparatorA = new ToolStripSeparator();
            TS_FolderPathShortCutsDropDownButton = new ToolStripDropDownButton();
            FolderShortcutDropDownMenu = new ContextMenuStrip(components);
            FolderPathShortCutsDropDownItemA = new ToolStripMenuItem();
            FolderPathShortCutsDropDownItemB = new ToolStripMenuItem();
            FolderPathShortCutsDropDownItemC = new ToolStripMenuItem();
            TS_FileShortCutDropDownButton = new ToolStripDropDownButton();
            JsonFilesShortcutDropDownMenu = new ContextMenuStrip(components);
            JsonFileShortCutsDropDownItemA = new ToolStripMenuItem();
            JsonFileShortCutsDropDownItemB = new ToolStripMenuItem();
            JsonFileShortCutsDropDownItemC = new ToolStripMenuItem();
            MainPanel = new Panel();
            VerticalSpacerPanel = new Panel();
            AuthorPanel.SuspendLayout();
            HeadlinePanel.SuspendLayout();
            HeadlineAndVersionPanel.SuspendLayout();
            PictureBackgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PZBackupManagerLogoPictureBox).BeginInit();
            WebsiteLinkLogoPanel.SuspendLayout();
            LogoPanelA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GithubLogoPictureBox).BeginInit();
            LogoPanelB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SteamLogoPictureBox).BeginInit();
            ToolStripPanel.SuspendLayout();
            AboutWindowButtonTS.SuspendLayout();
            FolderShortcutDropDownMenu.SuspendLayout();
            JsonFilesShortcutDropDownMenu.SuspendLayout();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // AuthorPanel
            // 
            AuthorPanel.BackColor = Color.RosyBrown;
            AuthorPanel.BorderStyle = BorderStyle.Fixed3D;
            AuthorPanel.Controls.Add(AuthorLinkLabel);
            AuthorPanel.Controls.Add(AuthorHeadlineLabel);
            AuthorPanel.Dock = DockStyle.Left;
            AuthorPanel.Location = new Point(180, 4);
            AuthorPanel.MaximumSize = new Size(350, 88);
            AuthorPanel.MinimumSize = new Size(350, 88);
            AuthorPanel.Name = "AuthorPanel";
            AuthorPanel.Padding = new Padding(4);
            AuthorPanel.Size = new Size(350, 88);
            AuthorPanel.TabIndex = 2;
            // 
            // AuthorLinkLabel
            // 
            AuthorLinkLabel.BackColor = SystemColors.Control;
            AuthorLinkLabel.BorderStyle = BorderStyle.Fixed3D;
            AuthorLinkLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            AuthorLinkLabel.ForeColor = Color.Black;
            AuthorLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            AuthorLinkLabel.Location = new Point(4, 46);
            AuthorLinkLabel.MaximumSize = new Size(335, 32);
            AuthorLinkLabel.MinimumSize = new Size(335, 32);
            AuthorLinkLabel.Name = "AuthorLinkLabel";
            AuthorLinkLabel.Padding = new Padding(4);
            AuthorLinkLabel.Size = new Size(335, 32);
            AuthorLinkLabel.TabIndex = 1;
            AuthorLinkLabel.TabStop = true;
            AuthorLinkLabel.Text = "TekknoTim";
            AuthorLinkLabel.TextAlign = ContentAlignment.MiddleCenter;
            AuthorLinkLabel.LinkClicked += AuthorLinkLabel_LinkClicked;
            // 
            // AuthorHeadlineLabel
            // 
            AuthorHeadlineLabel.BackColor = SystemColors.Control;
            AuthorHeadlineLabel.BorderStyle = BorderStyle.Fixed3D;
            AuthorHeadlineLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            AuthorHeadlineLabel.ForeColor = SystemColors.ControlText;
            AuthorHeadlineLabel.Location = new Point(4, 3);
            AuthorHeadlineLabel.Margin = new Padding(4);
            AuthorHeadlineLabel.MaximumSize = new Size(335, 32);
            AuthorHeadlineLabel.MinimumSize = new Size(335, 32);
            AuthorHeadlineLabel.Name = "AuthorHeadlineLabel";
            AuthorHeadlineLabel.Size = new Size(335, 32);
            AuthorHeadlineLabel.TabIndex = 0;
            AuthorHeadlineLabel.Text = "Author";
            AuthorHeadlineLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HeadlinePanel
            // 
            HeadlinePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            HeadlinePanel.BackColor = Color.Transparent;
            HeadlinePanel.BorderStyle = BorderStyle.FixedSingle;
            HeadlinePanel.Controls.Add(HeadlineAndVersionPanel);
            HeadlinePanel.Controls.Add(PictureBackgroundPanel);
            HeadlinePanel.Dock = DockStyle.Top;
            HeadlinePanel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HeadlinePanel.Location = new Point(0, 0);
            HeadlinePanel.Margin = new Padding(13);
            HeadlinePanel.MaximumSize = new Size(540, 161);
            HeadlinePanel.MinimumSize = new Size(540, 161);
            HeadlinePanel.Name = "HeadlinePanel";
            HeadlinePanel.Padding = new Padding(13);
            HeadlinePanel.Size = new Size(540, 161);
            HeadlinePanel.TabIndex = 3;
            // 
            // HeadlineAndVersionPanel
            // 
            HeadlineAndVersionPanel.Controls.Add(VersionLabel);
            HeadlineAndVersionPanel.Controls.Add(WindowTitleLabel);
            HeadlineAndVersionPanel.Location = new Point(142, 13);
            HeadlineAndVersionPanel.Name = "HeadlineAndVersionPanel";
            HeadlineAndVersionPanel.Padding = new Padding(5, 0, 5, 0);
            HeadlineAndVersionPanel.Size = new Size(390, 130);
            HeadlineAndVersionPanel.TabIndex = 4;
            // 
            // VersionLabel
            // 
            VersionLabel.BackColor = Color.FromArgb(64, 64, 64);
            VersionLabel.BorderStyle = BorderStyle.FixedSingle;
            VersionLabel.Dock = DockStyle.Top;
            VersionLabel.Font = new Font("Bahnschrift", 18F, FontStyle.Bold);
            VersionLabel.ForeColor = SystemColors.Info;
            VersionLabel.Location = new Point(5, 90);
            VersionLabel.MaximumSize = new Size(380, 40);
            VersionLabel.MinimumSize = new Size(380, 40);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(380, 40);
            VersionLabel.TabIndex = 3;
            VersionLabel.Text = "v0.0.0";
            VersionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WindowTitleLabel
            // 
            WindowTitleLabel.BackColor = Color.FromArgb(64, 64, 64);
            WindowTitleLabel.BorderStyle = BorderStyle.Fixed3D;
            WindowTitleLabel.Dock = DockStyle.Top;
            WindowTitleLabel.Font = new Font("Impact", 21.75F, FontStyle.Underline, GraphicsUnit.Point, 0);
            WindowTitleLabel.ForeColor = SystemColors.Info;
            WindowTitleLabel.Location = new Point(5, 0);
            WindowTitleLabel.Name = "WindowTitleLabel";
            WindowTitleLabel.Padding = new Padding(4);
            WindowTitleLabel.Size = new Size(380, 90);
            WindowTitleLabel.TabIndex = 2;
            WindowTitleLabel.Text = "Project Zomboid\r\nBackup  Manager";
            WindowTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PictureBackgroundPanel
            // 
            PictureBackgroundPanel.AutoSize = true;
            PictureBackgroundPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PictureBackgroundPanel.BackColor = Color.Red;
            PictureBackgroundPanel.BorderStyle = BorderStyle.Fixed3D;
            PictureBackgroundPanel.Controls.Add(PZBackupManagerLogoPictureBox);
            PictureBackgroundPanel.Dock = DockStyle.Left;
            PictureBackgroundPanel.Location = new Point(13, 13);
            PictureBackgroundPanel.Margin = new Padding(0);
            PictureBackgroundPanel.MaximumSize = new Size(129, 131);
            PictureBackgroundPanel.MinimumSize = new Size(129, 131);
            PictureBackgroundPanel.Name = "PictureBackgroundPanel";
            PictureBackgroundPanel.Padding = new Padding(1);
            PictureBackgroundPanel.Size = new Size(129, 131);
            PictureBackgroundPanel.TabIndex = 1;
            // 
            // PZBackupManagerLogoPictureBox
            // 
            PZBackupManagerLogoPictureBox.BackColor = Color.DimGray;
            PZBackupManagerLogoPictureBox.BackgroundImageLayout = ImageLayout.Center;
            PZBackupManagerLogoPictureBox.BorderStyle = BorderStyle.Fixed3D;
            PZBackupManagerLogoPictureBox.Dock = DockStyle.Fill;
            PZBackupManagerLogoPictureBox.Image = (Image)resources.GetObject("PZBackupManagerLogoPictureBox.Image");
            PZBackupManagerLogoPictureBox.Location = new Point(1, 1);
            PZBackupManagerLogoPictureBox.Margin = new Padding(0);
            PZBackupManagerLogoPictureBox.Name = "PZBackupManagerLogoPictureBox";
            PZBackupManagerLogoPictureBox.Size = new Size(123, 125);
            PZBackupManagerLogoPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            PZBackupManagerLogoPictureBox.TabIndex = 0;
            PZBackupManagerLogoPictureBox.TabStop = false;
            PZBackupManagerLogoPictureBox.Click += PZBackupManagerLogoPictureBox_Click;
            // 
            // WebsiteLinkLogoPanel
            // 
            WebsiteLinkLogoPanel.AutoSize = true;
            WebsiteLinkLogoPanel.BackColor = Color.DimGray;
            WebsiteLinkLogoPanel.BorderStyle = BorderStyle.Fixed3D;
            WebsiteLinkLogoPanel.Controls.Add(AuthorPanel);
            WebsiteLinkLogoPanel.Controls.Add(LogoPanelA);
            WebsiteLinkLogoPanel.Controls.Add(LogoPanelB);
            WebsiteLinkLogoPanel.Dock = DockStyle.Bottom;
            WebsiteLinkLogoPanel.Location = new Point(0, 502);
            WebsiteLinkLogoPanel.Margin = new Padding(5, 3, 5, 3);
            WebsiteLinkLogoPanel.MaximumSize = new Size(535, 100);
            WebsiteLinkLogoPanel.MinimumSize = new Size(535, 100);
            WebsiteLinkLogoPanel.Name = "WebsiteLinkLogoPanel";
            WebsiteLinkLogoPanel.Padding = new Padding(4);
            WebsiteLinkLogoPanel.Size = new Size(535, 100);
            WebsiteLinkLogoPanel.TabIndex = 3;
            // 
            // LogoPanelA
            // 
            LogoPanelA.AutoSize = true;
            LogoPanelA.BackColor = Color.Transparent;
            LogoPanelA.Controls.Add(GithubLogoPictureBox);
            LogoPanelA.Dock = DockStyle.Left;
            LogoPanelA.Location = new Point(92, 4);
            LogoPanelA.MaximumSize = new Size(88, 88);
            LogoPanelA.MinimumSize = new Size(88, 88);
            LogoPanelA.Name = "LogoPanelA";
            LogoPanelA.Padding = new Padding(1);
            LogoPanelA.Size = new Size(88, 88);
            LogoPanelA.TabIndex = 4;
            LogoPanelA.Paint += LogoPanelA_Paint;
            // 
            // GithubLogoPictureBox
            // 
            GithubLogoPictureBox.BackColor = Color.White;
            GithubLogoPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            GithubLogoPictureBox.BorderStyle = BorderStyle.FixedSingle;
            GithubLogoPictureBox.Cursor = Cursors.Hand;
            GithubLogoPictureBox.Dock = DockStyle.Left;
            GithubLogoPictureBox.Image = Properties.Resources.GitHubLogo128;
            GithubLogoPictureBox.InitialImage = Properties.Resources.SteamLogo128;
            GithubLogoPictureBox.Location = new Point(1, 1);
            GithubLogoPictureBox.Margin = new Padding(4);
            GithubLogoPictureBox.MaximumSize = new Size(88, 88);
            GithubLogoPictureBox.MinimumSize = new Size(88, 88);
            GithubLogoPictureBox.Name = "GithubLogoPictureBox";
            GithubLogoPictureBox.Size = new Size(88, 88);
            GithubLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            GithubLogoPictureBox.TabIndex = 3;
            GithubLogoPictureBox.TabStop = false;
            GithubLogoPictureBox.Click += GitHubLogoPictureBox_Click;
            // 
            // LogoPanelB
            // 
            LogoPanelB.AutoSize = true;
            LogoPanelB.BackColor = Color.Transparent;
            LogoPanelB.Controls.Add(SteamLogoPictureBox);
            LogoPanelB.Dock = DockStyle.Left;
            LogoPanelB.Location = new Point(4, 4);
            LogoPanelB.MaximumSize = new Size(88, 88);
            LogoPanelB.MinimumSize = new Size(88, 88);
            LogoPanelB.Name = "LogoPanelB";
            LogoPanelB.Size = new Size(88, 88);
            LogoPanelB.TabIndex = 5;
            // 
            // SteamLogoPictureBox
            // 
            SteamLogoPictureBox.BackColor = Color.White;
            SteamLogoPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            SteamLogoPictureBox.BorderStyle = BorderStyle.FixedSingle;
            SteamLogoPictureBox.Cursor = Cursors.Hand;
            SteamLogoPictureBox.Dock = DockStyle.Left;
            SteamLogoPictureBox.Image = Properties.Resources.SteamLogo128;
            SteamLogoPictureBox.InitialImage = Properties.Resources.SteamLogo128;
            SteamLogoPictureBox.Location = new Point(0, 0);
            SteamLogoPictureBox.Margin = new Padding(0);
            SteamLogoPictureBox.MaximumSize = new Size(88, 88);
            SteamLogoPictureBox.MinimumSize = new Size(88, 88);
            SteamLogoPictureBox.Name = "SteamLogoPictureBox";
            SteamLogoPictureBox.Size = new Size(88, 88);
            SteamLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            SteamLogoPictureBox.TabIndex = 2;
            SteamLogoPictureBox.TabStop = false;
            SteamLogoPictureBox.Click += SteamLogoPictureBox_Click;
            // 
            // ToolStripPanel
            // 
            ToolStripPanel.AutoSize = true;
            ToolStripPanel.BackColor = Color.Transparent;
            ToolStripPanel.Controls.Add(AboutWindowButtonTS);
            ToolStripPanel.Dock = DockStyle.Bottom;
            ToolStripPanel.Font = new Font("Bahnschrift", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ToolStripPanel.Location = new Point(0, 611);
            ToolStripPanel.MaximumSize = new Size(535, 64);
            ToolStripPanel.MinimumSize = new Size(535, 64);
            ToolStripPanel.Name = "ToolStripPanel";
            ToolStripPanel.Padding = new Padding(1);
            ToolStripPanel.Size = new Size(535, 64);
            ToolStripPanel.TabIndex = 7;
            // 
            // AboutWindowButtonTS
            // 
            AboutWindowButtonTS.BackgroundImage = Properties.Resources.RedBar;
            AboutWindowButtonTS.BackgroundImageLayout = ImageLayout.Stretch;
            AboutWindowButtonTS.Font = new Font("Bahnschrift", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AboutWindowButtonTS.GripStyle = ToolStripGripStyle.Hidden;
            AboutWindowButtonTS.ImageScalingSize = new Size(32, 32);
            AboutWindowButtonTS.Items.AddRange(new ToolStripItem[] { TSChangeLogButton, TSAcceptButton, TS_SeparatorB, TS_SeparatorA, TS_FolderPathShortCutsDropDownButton, TS_FileShortCutDropDownButton });
            AboutWindowButtonTS.Location = new Point(1, 1);
            AboutWindowButtonTS.MaximumSize = new Size(535, 60);
            AboutWindowButtonTS.MinimumSize = new Size(535, 60);
            AboutWindowButtonTS.Name = "AboutWindowButtonTS";
            AboutWindowButtonTS.RenderMode = ToolStripRenderMode.Professional;
            AboutWindowButtonTS.Size = new Size(535, 60);
            AboutWindowButtonTS.TabIndex = 0;
            AboutWindowButtonTS.ItemClicked += AboutWindowButtonTS_ItemClicked;
            // 
            // TSChangeLogButton
            // 
            TSChangeLogButton.AutoSize = false;
            TSChangeLogButton.Font = new Font("Impact", 9.75F, FontStyle.Underline, GraphicsUnit.Point, 0);
            TSChangeLogButton.ForeColor = Color.White;
            TSChangeLogButton.Image = Properties.Resources.InfoIcon;
            TSChangeLogButton.ImageScaling = ToolStripItemImageScaling.None;
            TSChangeLogButton.ImageTransparentColor = Color.Magenta;
            TSChangeLogButton.MergeAction = MergeAction.MatchOnly;
            TSChangeLogButton.Name = "TSChangeLogButton";
            TSChangeLogButton.Overflow = ToolStripItemOverflow.Never;
            TSChangeLogButton.Padding = new Padding(5, 0, 5, 0);
            TSChangeLogButton.Size = new Size(82, 57);
            TSChangeLogButton.Text = "Changelog";
            TSChangeLogButton.TextImageRelation = TextImageRelation.ImageAboveText;
            TSChangeLogButton.ToolTipText = "Show the changelog window\r\nwhich will be desplayed after\r\ninstalling a new version.";
            TSChangeLogButton.Click += TSChangeLogButton_Click;
            // 
            // TSAcceptButton
            // 
            TSAcceptButton.Alignment = ToolStripItemAlignment.Right;
            TSAcceptButton.AutoSize = false;
            TSAcceptButton.BackColor = Color.Transparent;
            TSAcceptButton.Font = new Font("Impact", 9.75F, FontStyle.Underline, GraphicsUnit.Point, 0);
            TSAcceptButton.ForeColor = Color.White;
            TSAcceptButton.Image = Properties.Resources.CheckmarkIcon;
            TSAcceptButton.ImageScaling = ToolStripItemImageScaling.None;
            TSAcceptButton.ImageTransparentColor = Color.Magenta;
            TSAcceptButton.MergeAction = MergeAction.MatchOnly;
            TSAcceptButton.Name = "TSAcceptButton";
            TSAcceptButton.Overflow = ToolStripItemOverflow.Never;
            TSAcceptButton.Padding = new Padding(5, 0, 5, 0);
            TSAcceptButton.Size = new Size(82, 57);
            TSAcceptButton.Text = "Close";
            TSAcceptButton.TextImageRelation = TextImageRelation.ImageAboveText;
            TSAcceptButton.ToolTipText = "Close This Window";
            TSAcceptButton.Click += TSAcceptButton_Click;
            // 
            // TS_SeparatorB
            // 
            TS_SeparatorB.AutoSize = false;
            TS_SeparatorB.Margin = new Padding(5);
            TS_SeparatorB.MergeAction = MergeAction.MatchOnly;
            TS_SeparatorB.Name = "TS_SeparatorB";
            TS_SeparatorB.Overflow = ToolStripItemOverflow.Never;
            TS_SeparatorB.Padding = new Padding(15, 0, 15, 0);
            TS_SeparatorB.Size = new Size(15, 60);
            // 
            // TS_SeparatorA
            // 
            TS_SeparatorA.Alignment = ToolStripItemAlignment.Right;
            TS_SeparatorA.AutoSize = false;
            TS_SeparatorA.Margin = new Padding(5);
            TS_SeparatorA.MergeAction = MergeAction.MatchOnly;
            TS_SeparatorA.Name = "TS_SeparatorA";
            TS_SeparatorA.Overflow = ToolStripItemOverflow.Never;
            TS_SeparatorA.Padding = new Padding(15, 0, 15, 0);
            TS_SeparatorA.Size = new Size(15, 60);
            // 
            // TS_FolderPathShortCutsDropDownButton
            // 
            TS_FolderPathShortCutsDropDownButton.AutoSize = false;
            TS_FolderPathShortCutsDropDownButton.DropDown = FolderShortcutDropDownMenu;
            TS_FolderPathShortCutsDropDownButton.Font = new Font("Impact", 9.75F, FontStyle.Underline, GraphicsUnit.Point, 0);
            TS_FolderPathShortCutsDropDownButton.ForeColor = Color.White;
            TS_FolderPathShortCutsDropDownButton.Image = Properties.Resources.FolderIcon;
            TS_FolderPathShortCutsDropDownButton.ImageScaling = ToolStripItemImageScaling.None;
            TS_FolderPathShortCutsDropDownButton.ImageTransparentColor = Color.Magenta;
            TS_FolderPathShortCutsDropDownButton.MergeAction = MergeAction.MatchOnly;
            TS_FolderPathShortCutsDropDownButton.Name = "TS_FolderPathShortCutsDropDownButton";
            TS_FolderPathShortCutsDropDownButton.Overflow = ToolStripItemOverflow.Never;
            TS_FolderPathShortCutsDropDownButton.Size = new Size(82, 57);
            TS_FolderPathShortCutsDropDownButton.Text = "Directories";
            TS_FolderPathShortCutsDropDownButton.TextImageRelation = TextImageRelation.ImageAboveText;
            TS_FolderPathShortCutsDropDownButton.ToolTipText = "Directory Shortcut Links.\r\n\r\n(Opens Win. Explorer at\r\nthe directory you chose)";
            TS_FolderPathShortCutsDropDownButton.Click += TS_FolderPathShortCutsDropDownButton_Click;
            // 
            // FolderShortcutDropDownMenu
            // 
            FolderShortcutDropDownMenu.Items.AddRange(new ToolStripItem[] { FolderPathShortCutsDropDownItemA, FolderPathShortCutsDropDownItemB, FolderPathShortCutsDropDownItemC });
            FolderShortcutDropDownMenu.Name = "FolderShortcutDropDownMenu";
            FolderShortcutDropDownMenu.OwnerItem = TS_FolderPathShortCutsDropDownButton;
            FolderShortcutDropDownMenu.Size = new Size(117, 70);
            // 
            // FolderPathShortCutsDropDownItemA
            // 
            FolderPathShortCutsDropDownItemA.AutoToolTip = true;
            FolderPathShortCutsDropDownItemA.BackColor = Color.MistyRose;
            FolderPathShortCutsDropDownItemA.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FolderPathShortCutsDropDownItemA.Image = Properties.Resources.FolderIcon;
            FolderPathShortCutsDropDownItemA.Name = "FolderPathShortCutsDropDownItemA";
            FolderPathShortCutsDropDownItemA.Size = new Size(116, 22);
            FolderPathShortCutsDropDownItemA.Text = "App";
            FolderPathShortCutsDropDownItemA.ToolTipText = "Open Application Install Directory";
            FolderPathShortCutsDropDownItemA.Click += FolderPathShortCutsDropDownItemA_Click;
            // 
            // FolderPathShortCutsDropDownItemB
            // 
            FolderPathShortCutsDropDownItemB.AutoToolTip = true;
            FolderPathShortCutsDropDownItemB.BackColor = Color.MistyRose;
            FolderPathShortCutsDropDownItemB.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FolderPathShortCutsDropDownItemB.Image = Properties.Resources.FolderIcon;
            FolderPathShortCutsDropDownItemB.Name = "FolderPathShortCutsDropDownItemB";
            FolderPathShortCutsDropDownItemB.Size = new Size(116, 22);
            FolderPathShortCutsDropDownItemB.Text = "Backup";
            FolderPathShortCutsDropDownItemB.ToolTipText = "Open Backup Directory";
            FolderPathShortCutsDropDownItemB.Click += FolderPathShortCutsDropDownItemB_Click;
            // 
            // FolderPathShortCutsDropDownItemC
            // 
            FolderPathShortCutsDropDownItemC.AutoToolTip = true;
            FolderPathShortCutsDropDownItemC.BackColor = Color.MistyRose;
            FolderPathShortCutsDropDownItemC.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FolderPathShortCutsDropDownItemC.Image = Properties.Resources.FolderIcon;
            FolderPathShortCutsDropDownItemC.Name = "FolderPathShortCutsDropDownItemC";
            FolderPathShortCutsDropDownItemC.Size = new Size(116, 22);
            FolderPathShortCutsDropDownItemC.Text = "Saves";
            FolderPathShortCutsDropDownItemC.ToolTipText = "Open Saves Directory";
            FolderPathShortCutsDropDownItemC.Click += FolderPathShortCutsDropDownItemC_Click;
            // 
            // TS_FileShortCutDropDownButton
            // 
            TS_FileShortCutDropDownButton.Alignment = ToolStripItemAlignment.Right;
            TS_FileShortCutDropDownButton.AutoSize = false;
            TS_FileShortCutDropDownButton.BackgroundImageLayout = ImageLayout.Center;
            TS_FileShortCutDropDownButton.DropDown = JsonFilesShortcutDropDownMenu;
            TS_FileShortCutDropDownButton.Font = new Font("Impact", 9.75F, FontStyle.Underline, GraphicsUnit.Point, 0);
            TS_FileShortCutDropDownButton.ForeColor = Color.White;
            TS_FileShortCutDropDownButton.Image = Properties.Resources.DocumentIcon;
            TS_FileShortCutDropDownButton.ImageScaling = ToolStripItemImageScaling.None;
            TS_FileShortCutDropDownButton.ImageTransparentColor = Color.Magenta;
            TS_FileShortCutDropDownButton.MergeAction = MergeAction.MatchOnly;
            TS_FileShortCutDropDownButton.Name = "TS_FileShortCutDropDownButton";
            TS_FileShortCutDropDownButton.Overflow = ToolStripItemOverflow.Never;
            TS_FileShortCutDropDownButton.Size = new Size(82, 57);
            TS_FileShortCutDropDownButton.Text = "Files.Json";
            TS_FileShortCutDropDownButton.TextImageRelation = TextImageRelation.ImageAboveText;
            TS_FileShortCutDropDownButton.ToolTipText = "Json Files Shortcut Links\r\n\r\n(Opens your default texteditor\r\nand loads the json you selected)";
            TS_FileShortCutDropDownButton.Click += TS_FileShortCutDropDownButton_Click;
            // 
            // JsonFilesShortcutDropDownMenu
            // 
            JsonFilesShortcutDropDownMenu.Items.AddRange(new ToolStripItem[] { JsonFileShortCutsDropDownItemA, JsonFileShortCutsDropDownItemB, JsonFileShortCutsDropDownItemC });
            JsonFilesShortcutDropDownMenu.Name = "JsonFilesShortcutDropDownMenu";
            JsonFilesShortcutDropDownMenu.OwnerItem = TS_FileShortCutDropDownButton;
            JsonFilesShortcutDropDownMenu.Size = new Size(186, 92);
            // 
            // JsonFileShortCutsDropDownItemA
            // 
            JsonFileShortCutsDropDownItemA.AutoToolTip = true;
            JsonFileShortCutsDropDownItemA.BackColor = Color.MistyRose;
            JsonFileShortCutsDropDownItemA.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            JsonFileShortCutsDropDownItemA.Image = Properties.Resources.DocumentIcon;
            JsonFileShortCutsDropDownItemA.MergeAction = MergeAction.MatchOnly;
            JsonFileShortCutsDropDownItemA.Name = "JsonFileShortCutsDropDownItemA";
            JsonFileShortCutsDropDownItemA.Size = new Size(185, 22);
            JsonFileShortCutsDropDownItemA.Text = "Config.Json";
            JsonFileShortCutsDropDownItemA.ToolTipText = "Open the config.json\r\nfile in you default text editor.";
            JsonFileShortCutsDropDownItemA.Click += JsonFileShortCutsDropDownItemA_Click;
            // 
            // JsonFileShortCutsDropDownItemB
            // 
            JsonFileShortCutsDropDownItemB.AutoToolTip = true;
            JsonFileShortCutsDropDownItemB.BackColor = Color.MistyRose;
            JsonFileShortCutsDropDownItemB.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            JsonFileShortCutsDropDownItemB.Image = Properties.Resources.DocumentIcon;
            JsonFileShortCutsDropDownItemB.MergeAction = MergeAction.MatchOnly;
            JsonFileShortCutsDropDownItemB.Name = "JsonFileShortCutsDropDownItemB";
            JsonFileShortCutsDropDownItemB.Size = new Size(185, 22);
            JsonFileShortCutsDropDownItemB.Text = "Databasedata.Json";
            JsonFileShortCutsDropDownItemB.ToolTipText = "Open the Databasedata.Json file,\r\nin your default text editor.";
            JsonFileShortCutsDropDownItemB.Click += JsonFileShortCutsDropDownItemB_Click;
            // 
            // JsonFileShortCutsDropDownItemC
            // 
            JsonFileShortCutsDropDownItemC.AutoToolTip = true;
            JsonFileShortCutsDropDownItemC.BackColor = Color.MistyRose;
            JsonFileShortCutsDropDownItemC.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            JsonFileShortCutsDropDownItemC.Image = Properties.Resources.DocumentIcon;
            JsonFileShortCutsDropDownItemC.MergeAction = MergeAction.MatchOnly;
            JsonFileShortCutsDropDownItemC.Name = "JsonFileShortCutsDropDownItemC";
            JsonFileShortCutsDropDownItemC.Size = new Size(185, 22);
            JsonFileShortCutsDropDownItemC.Text = "Readme.md";
            JsonFileShortCutsDropDownItemC.ToolTipText = "Opens the readme.md file\r\nin your default text editor.";
            JsonFileShortCutsDropDownItemC.Click += JsonFileShortCutsDropDownItemC_Click;
            // 
            // MainPanel
            // 
            MainPanel.AutoSize = true;
            MainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainPanel.BackColor = Color.WhiteSmoke;
            MainPanel.BackgroundImage = Properties.Resources.SpiffoHighlightsWithBackground;
            MainPanel.BackgroundImageLayout = ImageLayout.Zoom;
            MainPanel.BorderStyle = BorderStyle.Fixed3D;
            MainPanel.Controls.Add(HeadlinePanel);
            MainPanel.Controls.Add(WebsiteLinkLogoPanel);
            MainPanel.Controls.Add(VerticalSpacerPanel);
            MainPanel.Controls.Add(ToolStripPanel);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(5, 9);
            MainPanel.MaximumSize = new Size(539, 679);
            MainPanel.MinimumSize = new Size(539, 679);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(539, 679);
            MainPanel.TabIndex = 8;
            // 
            // VerticalSpacerPanel
            // 
            VerticalSpacerPanel.AutoSize = true;
            VerticalSpacerPanel.BackColor = Color.Transparent;
            VerticalSpacerPanel.Dock = DockStyle.Bottom;
            VerticalSpacerPanel.Location = new Point(0, 602);
            VerticalSpacerPanel.MaximumSize = new Size(386, 9);
            VerticalSpacerPanel.MinimumSize = new Size(386, 9);
            VerticalSpacerPanel.Name = "VerticalSpacerPanel";
            VerticalSpacerPanel.Size = new Size(386, 9);
            VerticalSpacerPanel.TabIndex = 8;
            // 
            // AboutInfoWindow
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Red;
            ClientSize = new Size(549, 697);
            Controls.Add(MainPanel);
            DoubleBuffered = true;
            Font = new Font("Bahnschrift", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(569, 740);
            MinimizeBox = false;
            MinimumSize = new Size(569, 740);
            Name = "AboutInfoWindow";
            Padding = new Padding(5, 9, 5, 9);
            RightToLeft = RightToLeft.No;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            AuthorPanel.ResumeLayout(false);
            HeadlinePanel.ResumeLayout(false);
            HeadlinePanel.PerformLayout();
            HeadlineAndVersionPanel.ResumeLayout(false);
            PictureBackgroundPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PZBackupManagerLogoPictureBox).EndInit();
            WebsiteLinkLogoPanel.ResumeLayout(false);
            WebsiteLinkLogoPanel.PerformLayout();
            LogoPanelA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GithubLogoPictureBox).EndInit();
            LogoPanelB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SteamLogoPictureBox).EndInit();
            ToolStripPanel.ResumeLayout(false);
            ToolStripPanel.PerformLayout();
            AboutWindowButtonTS.ResumeLayout(false);
            AboutWindowButtonTS.PerformLayout();
            FolderShortcutDropDownMenu.ResumeLayout(false);
            JsonFilesShortcutDropDownMenu.ResumeLayout(false);
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel AuthorPanel;
        private Panel HeadlinePanel;
        private PictureBox PZBackupManagerLogoPictureBox;
        private Panel PictureBackgroundPanel;
        private Label WindowTitleLabel;
        private Label VersionLabel;
        private Label AuthorHeadlineLabel;
        private LinkLabel AuthorLinkLabel;
        private Panel WebsiteLinkLogoPanel;
        private Panel LogoPanelA;
        private Panel ToolStripPanel;
        private ToolStrip AboutWindowButtonTS;
        private ToolStripButton TSChangeLogButton;
        private ToolStripButton TSAcceptButton;
        private ToolStripSeparator TS_SeparatorB;
        private ToolStripSeparator TS_SeparatorA;
        private ToolStripDropDownButton TS_FolderPathShortCutsDropDownButton;
        private ToolStripDropDownButton TS_FileShortCutDropDownButton;
        private ContextMenuStrip FolderShortcutDropDownMenu;
        private ToolStripMenuItem FolderPathShortCutsDropDownItemA;
        private ToolStripMenuItem FolderPathShortCutsDropDownItemB;
        private ContextMenuStrip JsonFilesShortcutDropDownMenu;
        private ToolStripMenuItem FolderPathShortCutsDropDownItemC;
        private ToolStripMenuItem JsonFileShortCutsDropDownItemA;
        private ToolStripMenuItem JsonFileShortCutsDropDownItemB;
        private ToolStripMenuItem JsonFileShortCutsDropDownItemC;
        private Panel MainPanel;
        private PictureBox SteamLogoPictureBox;
        private PictureBox GithubLogoPictureBox;
        private Panel LogoPanelB;
        private Panel VerticalSpacerPanel;
        private Panel HeadlineAndVersionPanel;
    }
}