namespace ZomboidBackupManager
{
    partial class UnlistedBackupsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnlistedBackupsWindow));
            StatusLog = new ListBox();
            DepricatedBackupsLabel = new Label();
            ListBoxPanel = new Panel();
            DoneButton = new Button();
            UnlistedBackupsToolStrip = new ToolStrip();
            ToolStripDropDownOptions = new ToolStripDropDownButton();
            UnlistedSettingsContextMenuStrip = new ContextMenuStrip(components);
            AskDeleteOnAutoCleanMenuItem = new ToolStripMenuItem();
            ShowDetailesAfterScanMenuItem = new ToolStripMenuItem();
            AutoCleanToolStripButton = new ToolStripButton();
            ScanJsonToolStripButton = new ToolStripButton();
            ScanToolStripButton = new ToolStripButton();
            HelpToolStripButton = new ToolStripButton();
            ToolStripPanel = new Panel();
            CleanUpDataHeadLabel = new Label();
            CleanUpHeadLabel = new Label();
            OpenDirInExplorerButton = new Button();
            ButtonToolTips = new ToolTip(components);
            EditLogToolStripPanel = new Panel();
            EditLogToolStrip = new ToolStrip();
            StatusLogSettingsTSDropDownButton = new ToolStripDropDownButton();
            StatusLogConfigContextStripMenu = new ContextMenuStrip(components);
            LogGeneralMenuCMStrip = new ToolStripMenuItem();
            LogSetupGeneralCSMenu = new ContextMenuStrip(components);
            LogToggleNumCMStrip = new ToolStripMenuItem();
            LogSepMenuCMStrip = new ToolStripMenuItem();
            LogSetupSepCSMenu = new ContextMenuStrip(components);
            ChangeSep01_TextBox = new ToolStripTextBox();
            ClearStatusLogTSButton = new ToolStripButton();
            ListBoxPanel.SuspendLayout();
            UnlistedBackupsToolStrip.SuspendLayout();
            UnlistedSettingsContextMenuStrip.SuspendLayout();
            ToolStripPanel.SuspendLayout();
            EditLogToolStripPanel.SuspendLayout();
            EditLogToolStrip.SuspendLayout();
            StatusLogConfigContextStripMenu.SuspendLayout();
            LogSetupGeneralCSMenu.SuspendLayout();
            LogSetupSepCSMenu.SuspendLayout();
            SuspendLayout();
            // 
            // StatusLog
            // 
            StatusLog.BackColor = SystemColors.ControlLightLight;
            StatusLog.Dock = DockStyle.Fill;
            StatusLog.Font = new Font("Ubuntu Mono", 11F);
            StatusLog.FormattingEnabled = true;
            StatusLog.HorizontalExtent = 10;
            StatusLog.Items.AddRange(new object[] { "Loading..." });
            StatusLog.Location = new Point(0, 35);
            StatusLog.Margin = new Padding(0);
            StatusLog.MaximumSize = new Size(600, 465);
            StatusLog.MinimumSize = new Size(600, 465);
            StatusLog.Name = "StatusLog";
            StatusLog.ScrollAlwaysVisible = true;
            StatusLog.Size = new Size(600, 465);
            StatusLog.TabIndex = 16;
            // 
            // DepricatedBackupsLabel
            // 
            DepricatedBackupsLabel.BackColor = Color.MistyRose;
            DepricatedBackupsLabel.BorderStyle = BorderStyle.FixedSingle;
            DepricatedBackupsLabel.Dock = DockStyle.Top;
            DepricatedBackupsLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DepricatedBackupsLabel.ForeColor = SystemColors.ControlText;
            DepricatedBackupsLabel.Location = new Point(0, 0);
            DepricatedBackupsLabel.Name = "DepricatedBackupsLabel";
            DepricatedBackupsLabel.Size = new Size(600, 35);
            DepricatedBackupsLabel.TabIndex = 17;
            DepricatedBackupsLabel.Text = "Status Log";
            DepricatedBackupsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ListBoxPanel
            // 
            ListBoxPanel.BackColor = Color.Transparent;
            ListBoxPanel.Controls.Add(StatusLog);
            ListBoxPanel.Controls.Add(DepricatedBackupsLabel);
            ListBoxPanel.Location = new Point(12, 134);
            ListBoxPanel.MaximumSize = new Size(600, 500);
            ListBoxPanel.MinimumSize = new Size(600, 500);
            ListBoxPanel.Name = "ListBoxPanel";
            ListBoxPanel.Size = new Size(600, 500);
            ListBoxPanel.TabIndex = 21;
            // 
            // DoneButton
            // 
            DoneButton.AutoSize = true;
            DoneButton.DialogResult = DialogResult.OK;
            DoneButton.Location = new Point(522, 700);
            DoneButton.Margin = new Padding(5, 10, 3, 4);
            DoneButton.MaximumSize = new Size(90, 36);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new Size(90, 36);
            DoneButton.TabIndex = 22;
            DoneButton.Text = "Done";
            DoneButton.UseVisualStyleBackColor = true;
            DoneButton.Click += DoneButton_Click;
            // 
            // UnlistedBackupsToolStrip
            // 
            UnlistedBackupsToolStrip.AutoSize = false;
            UnlistedBackupsToolStrip.BackColor = SystemColors.ControlDarkDark;
            UnlistedBackupsToolStrip.Font = new Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UnlistedBackupsToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            UnlistedBackupsToolStrip.ImageScalingSize = new Size(32, 32);
            UnlistedBackupsToolStrip.Items.AddRange(new ToolStripItem[] { ToolStripDropDownOptions, AutoCleanToolStripButton, ScanJsonToolStripButton, ScanToolStripButton, HelpToolStripButton });
            UnlistedBackupsToolStrip.Location = new Point(0, 0);
            UnlistedBackupsToolStrip.MinimumSize = new Size(526, 48);
            UnlistedBackupsToolStrip.Name = "UnlistedBackupsToolStrip";
            UnlistedBackupsToolStrip.Padding = new Padding(1);
            UnlistedBackupsToolStrip.Size = new Size(596, 48);
            UnlistedBackupsToolStrip.TabIndex = 23;
            // 
            // ToolStripDropDownOptions
            // 
            ToolStripDropDownOptions.AutoSize = false;
            ToolStripDropDownOptions.BackColor = SystemColors.Control;
            ToolStripDropDownOptions.DropDown = UnlistedSettingsContextMenuStrip;
            ToolStripDropDownOptions.Font = new Font("Bahnschrift SemiBold Condensed", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ToolStripDropDownOptions.Image = (Image)resources.GetObject("ToolStripDropDownOptions.Image");
            ToolStripDropDownOptions.ImageScaling = ToolStripItemImageScaling.None;
            ToolStripDropDownOptions.ImageTransparentColor = Color.Magenta;
            ToolStripDropDownOptions.Margin = new Padding(2);
            ToolStripDropDownOptions.MergeAction = MergeAction.MatchOnly;
            ToolStripDropDownOptions.Name = "ToolStripDropDownOptions";
            ToolStripDropDownOptions.Overflow = ToolStripItemOverflow.Never;
            ToolStripDropDownOptions.Padding = new Padding(10, 0, 10, 0);
            ToolStripDropDownOptions.Size = new Size(110, 38);
            ToolStripDropDownOptions.Text = "Settings";
            // 
            // UnlistedSettingsContextMenuStrip
            // 
            UnlistedSettingsContextMenuStrip.BackColor = SystemColors.ControlLight;
            UnlistedSettingsContextMenuStrip.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UnlistedSettingsContextMenuStrip.ImageScalingSize = new Size(32, 32);
            UnlistedSettingsContextMenuStrip.Items.AddRange(new ToolStripItem[] { AskDeleteOnAutoCleanMenuItem, ShowDetailesAfterScanMenuItem });
            UnlistedSettingsContextMenuStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            UnlistedSettingsContextMenuStrip.Name = "ToolStripOptionsContextMenuStrip";
            UnlistedSettingsContextMenuStrip.OwnerItem = ToolStripDropDownOptions;
            UnlistedSettingsContextMenuStrip.RightToLeft = RightToLeft.Yes;
            UnlistedSettingsContextMenuStrip.ShowCheckMargin = true;
            UnlistedSettingsContextMenuStrip.ShowImageMargin = false;
            UnlistedSettingsContextMenuStrip.Size = new Size(287, 48);
            // 
            // AskDeleteOnAutoCleanMenuItem
            // 
            AskDeleteOnAutoCleanMenuItem.AutoToolTip = true;
            AskDeleteOnAutoCleanMenuItem.Checked = true;
            AskDeleteOnAutoCleanMenuItem.CheckOnClick = true;
            AskDeleteOnAutoCleanMenuItem.CheckState = CheckState.Checked;
            AskDeleteOnAutoCleanMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            AskDeleteOnAutoCleanMenuItem.Font = new Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AskDeleteOnAutoCleanMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            AskDeleteOnAutoCleanMenuItem.MergeAction = MergeAction.MatchOnly;
            AskDeleteOnAutoCleanMenuItem.Name = "AskDeleteOnAutoCleanMenuItem";
            AskDeleteOnAutoCleanMenuItem.RightToLeft = RightToLeft.No;
            AskDeleteOnAutoCleanMenuItem.Size = new Size(286, 22);
            AskDeleteOnAutoCleanMenuItem.Text = "Deletion Requires Confirmation";
            AskDeleteOnAutoCleanMenuItem.ToolTipText = "When running \"Auto Clean\",\r\nyou will be asked before any\r\nvalid backup data is deleted.";
            AskDeleteOnAutoCleanMenuItem.Click += AskDeleteOnAutoCleanMenuItem_Click;
            // 
            // ShowDetailesAfterScanMenuItem
            // 
            ShowDetailesAfterScanMenuItem.AutoToolTip = true;
            ShowDetailesAfterScanMenuItem.Checked = true;
            ShowDetailesAfterScanMenuItem.CheckOnClick = true;
            ShowDetailesAfterScanMenuItem.CheckState = CheckState.Checked;
            ShowDetailesAfterScanMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ShowDetailesAfterScanMenuItem.Font = new Font("Bahnschrift", 11F);
            ShowDetailesAfterScanMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            ShowDetailesAfterScanMenuItem.MergeAction = MergeAction.MatchOnly;
            ShowDetailesAfterScanMenuItem.Name = "ShowDetailesAfterScanMenuItem";
            ShowDetailesAfterScanMenuItem.RightToLeft = RightToLeft.No;
            ShowDetailesAfterScanMenuItem.Size = new Size(286, 22);
            ShowDetailesAfterScanMenuItem.Text = "Show Detailed Infos in Log";
            ShowDetailesAfterScanMenuItem.ToolTipText = "Shows more information in log.\r\n\r\ne.g. shows details about scanned\r\nissues, instead of just showing\r\nhow many were found. (Experimental)";
            ShowDetailesAfterScanMenuItem.Click += ShowDetailesAfterScanMenuItem_Click;
            // 
            // AutoCleanToolStripButton
            // 
            AutoCleanToolStripButton.Alignment = ToolStripItemAlignment.Right;
            AutoCleanToolStripButton.AutoSize = false;
            AutoCleanToolStripButton.BackColor = SystemColors.Control;
            AutoCleanToolStripButton.BackgroundImageLayout = ImageLayout.Zoom;
            AutoCleanToolStripButton.Font = new Font("Bahnschrift SemiCondensed", 11F);
            AutoCleanToolStripButton.Image = (Image)resources.GetObject("AutoCleanToolStripButton.Image");
            AutoCleanToolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            AutoCleanToolStripButton.ImageTransparentColor = Color.Magenta;
            AutoCleanToolStripButton.Margin = new Padding(2);
            AutoCleanToolStripButton.MergeAction = MergeAction.MatchOnly;
            AutoCleanToolStripButton.Name = "AutoCleanToolStripButton";
            AutoCleanToolStripButton.Overflow = ToolStripItemOverflow.Never;
            AutoCleanToolStripButton.Padding = new Padding(10, 0, 10, 0);
            AutoCleanToolStripButton.Size = new Size(115, 38);
            AutoCleanToolStripButton.Text = "Auto Clean";
            AutoCleanToolStripButton.Click += AutoCleanToolStripButton_Click;
            // 
            // ScanJsonToolStripButton
            // 
            ScanJsonToolStripButton.Alignment = ToolStripItemAlignment.Right;
            ScanJsonToolStripButton.AutoSize = false;
            ScanJsonToolStripButton.BackColor = SystemColors.Control;
            ScanJsonToolStripButton.BackgroundImageLayout = ImageLayout.Zoom;
            ScanJsonToolStripButton.Font = new Font("Bahnschrift SemiCondensed", 11F);
            ScanJsonToolStripButton.Image = (Image)resources.GetObject("ScanJsonToolStripButton.Image");
            ScanJsonToolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            ScanJsonToolStripButton.ImageTransparentColor = Color.Magenta;
            ScanJsonToolStripButton.Margin = new Padding(2);
            ScanJsonToolStripButton.MergeAction = MergeAction.MatchOnly;
            ScanJsonToolStripButton.Name = "ScanJsonToolStripButton";
            ScanJsonToolStripButton.Overflow = ToolStripItemOverflow.Never;
            ScanJsonToolStripButton.Padding = new Padding(10, 0, 10, 0);
            ScanJsonToolStripButton.Size = new Size(110, 38);
            ScanJsonToolStripButton.Text = "Scan Json";
            ScanJsonToolStripButton.Click += ScanJsonToolStripButton_Click;
            // 
            // ScanToolStripButton
            // 
            ScanToolStripButton.Alignment = ToolStripItemAlignment.Right;
            ScanToolStripButton.AutoSize = false;
            ScanToolStripButton.BackColor = SystemColors.Control;
            ScanToolStripButton.BackgroundImageLayout = ImageLayout.Zoom;
            ScanToolStripButton.Font = new Font("Bahnschrift", 12F);
            ScanToolStripButton.Image = (Image)resources.GetObject("ScanToolStripButton.Image");
            ScanToolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            ScanToolStripButton.ImageTransparentColor = Color.Magenta;
            ScanToolStripButton.Margin = new Padding(2);
            ScanToolStripButton.MergeAction = MergeAction.MatchOnly;
            ScanToolStripButton.Name = "ScanToolStripButton";
            ScanToolStripButton.Overflow = ToolStripItemOverflow.Never;
            ScanToolStripButton.Padding = new Padding(10, 0, 10, 0);
            ScanToolStripButton.Size = new Size(80, 38);
            ScanToolStripButton.Text = "Scan";
            ScanToolStripButton.Click += ScanToolStripButton_Click;
            // 
            // HelpToolStripButton
            // 
            HelpToolStripButton.AutoSize = false;
            HelpToolStripButton.BackColor = SystemColors.Control;
            HelpToolStripButton.BackgroundImageLayout = ImageLayout.Zoom;
            HelpToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            HelpToolStripButton.Font = new Font("Bahnschrift", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HelpToolStripButton.Image = (Image)resources.GetObject("HelpToolStripButton.Image");
            HelpToolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            HelpToolStripButton.ImageTransparentColor = Color.Magenta;
            HelpToolStripButton.Margin = new Padding(2);
            HelpToolStripButton.MergeAction = MergeAction.MatchOnly;
            HelpToolStripButton.Name = "HelpToolStripButton";
            HelpToolStripButton.Overflow = ToolStripItemOverflow.Never;
            HelpToolStripButton.Padding = new Padding(10, 0, 10, 0);
            HelpToolStripButton.Size = new Size(40, 38);
            HelpToolStripButton.ToolTipText = "Show's detailed informations &\r\ninstructions about this window!";
            HelpToolStripButton.Click += HelpToolStripButton_Click;
            // 
            // ToolStripPanel
            // 
            ToolStripPanel.AutoSize = true;
            ToolStripPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ToolStripPanel.BackColor = Color.Transparent;
            ToolStripPanel.BorderStyle = BorderStyle.Fixed3D;
            ToolStripPanel.Controls.Add(UnlistedBackupsToolStrip);
            ToolStripPanel.Location = new Point(12, 78);
            ToolStripPanel.MinimumSize = new Size(600, 48);
            ToolStripPanel.Name = "ToolStripPanel";
            ToolStripPanel.Size = new Size(600, 52);
            ToolStripPanel.TabIndex = 24;
            // 
            // CleanUpDataHeadLabel
            // 
            CleanUpDataHeadLabel.AutoSize = true;
            CleanUpDataHeadLabel.BackColor = Color.Transparent;
            CleanUpDataHeadLabel.Dock = DockStyle.Fill;
            CleanUpDataHeadLabel.Font = new Font("Lintsec", 19F);
            CleanUpDataHeadLabel.ForeColor = Color.Gainsboro;
            CleanUpDataHeadLabel.Location = new Point(0, 0);
            CleanUpDataHeadLabel.Margin = new Padding(5, 3, 5, 3);
            CleanUpDataHeadLabel.Name = "CleanUpDataHeadLabel";
            CleanUpDataHeadLabel.Padding = new Padding(2);
            CleanUpDataHeadLabel.Size = new Size(492, 37);
            CleanUpDataHeadLabel.TabIndex = 26;
            CleanUpDataHeadLabel.Text = "Backup Data Cleaner";
            CleanUpDataHeadLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CleanUpHeadLabel
            // 
            CleanUpHeadLabel.AutoSize = true;
            CleanUpHeadLabel.BackColor = Color.MistyRose;
            CleanUpHeadLabel.Font = new Font("Zombie", 40F);
            CleanUpHeadLabel.Location = new Point(16, 18);
            CleanUpHeadLabel.Margin = new Padding(2, 0, 2, 0);
            CleanUpHeadLabel.Name = "CleanUpHeadLabel";
            CleanUpHeadLabel.Size = new Size(591, 43);
            CleanUpHeadLabel.TabIndex = 25;
            CleanUpHeadLabel.Text = "Backup Data Cleaner";
            // 
            // OpenDirInExplorerButton
            // 
            OpenDirInExplorerButton.AutoSize = true;
            OpenDirInExplorerButton.Font = new Font("Bahnschrift", 12F);
            OpenDirInExplorerButton.Location = new Point(12, 700);
            OpenDirInExplorerButton.Margin = new Padding(5, 10, 3, 4);
            OpenDirInExplorerButton.MaximumSize = new Size(90, 36);
            OpenDirInExplorerButton.Name = "OpenDirInExplorerButton";
            OpenDirInExplorerButton.Size = new Size(90, 36);
            OpenDirInExplorerButton.TabIndex = 26;
            OpenDirInExplorerButton.Text = "Open";
            ButtonToolTips.SetToolTip(OpenDirInExplorerButton, "Opens the currently set backup-directory\r\nin the windows explorer.");
            OpenDirInExplorerButton.UseVisualStyleBackColor = true;
            OpenDirInExplorerButton.Click += OpenDirInExplorerButton_Click;
            // 
            // EditLogToolStripPanel
            // 
            EditLogToolStripPanel.AutoSize = true;
            EditLogToolStripPanel.BackColor = Color.Transparent;
            EditLogToolStripPanel.BorderStyle = BorderStyle.Fixed3D;
            EditLogToolStripPanel.Controls.Add(EditLogToolStrip);
            EditLogToolStripPanel.Location = new Point(12, 635);
            EditLogToolStripPanel.MaximumSize = new Size(600, 32);
            EditLogToolStripPanel.MinimumSize = new Size(600, 32);
            EditLogToolStripPanel.Name = "EditLogToolStripPanel";
            EditLogToolStripPanel.Size = new Size(600, 32);
            EditLogToolStripPanel.TabIndex = 27;
            // 
            // EditLogToolStrip
            // 
            EditLogToolStrip.AutoSize = false;
            EditLogToolStrip.BackColor = SystemColors.ControlLight;
            EditLogToolStrip.Font = new Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditLogToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            EditLogToolStrip.Items.AddRange(new ToolStripItem[] { StatusLogSettingsTSDropDownButton, ClearStatusLogTSButton });
            EditLogToolStrip.Location = new Point(0, 0);
            EditLogToolStrip.MaximumSize = new Size(600, 32);
            EditLogToolStrip.MinimumSize = new Size(600, 32);
            EditLogToolStrip.Name = "EditLogToolStrip";
            EditLogToolStrip.Padding = new Padding(5, 1, 5, 1);
            EditLogToolStrip.Size = new Size(600, 32);
            EditLogToolStrip.TabIndex = 23;
            // 
            // StatusLogSettingsTSDropDownButton
            // 
            StatusLogSettingsTSDropDownButton.BackColor = Color.RosyBrown;
            StatusLogSettingsTSDropDownButton.DropDown = StatusLogConfigContextStripMenu;
            StatusLogSettingsTSDropDownButton.Font = new Font("Bahnschrift SemiCondensed", 11.25F);
            StatusLogSettingsTSDropDownButton.ForeColor = Color.White;
            StatusLogSettingsTSDropDownButton.Image = (Image)resources.GetObject("StatusLogSettingsTSDropDownButton.Image");
            StatusLogSettingsTSDropDownButton.ImageAlign = ContentAlignment.MiddleLeft;
            StatusLogSettingsTSDropDownButton.ImageScaling = ToolStripItemImageScaling.None;
            StatusLogSettingsTSDropDownButton.ImageTransparentColor = Color.Magenta;
            StatusLogSettingsTSDropDownButton.Margin = new Padding(1, 1, 5, 1);
            StatusLogSettingsTSDropDownButton.MergeAction = MergeAction.MatchOnly;
            StatusLogSettingsTSDropDownButton.Name = "StatusLogSettingsTSDropDownButton";
            StatusLogSettingsTSDropDownButton.Overflow = ToolStripItemOverflow.Never;
            StatusLogSettingsTSDropDownButton.RightToLeft = RightToLeft.No;
            StatusLogSettingsTSDropDownButton.Size = new Size(98, 28);
            StatusLogSettingsTSDropDownButton.Text = "Log Config";
            StatusLogSettingsTSDropDownButton.TextAlign = ContentAlignment.TopRight;
            StatusLogSettingsTSDropDownButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            // 
            // StatusLogConfigContextStripMenu
            // 
            StatusLogConfigContextStripMenu.BackColor = SystemColors.ControlLight;
            StatusLogConfigContextStripMenu.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StatusLogConfigContextStripMenu.Items.AddRange(new ToolStripItem[] { LogGeneralMenuCMStrip, LogSepMenuCMStrip });
            StatusLogConfigContextStripMenu.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            StatusLogConfigContextStripMenu.Name = "ToolStripOptionsContextMenuStrip";
            StatusLogConfigContextStripMenu.OwnerItem = StatusLogSettingsTSDropDownButton;
            StatusLogConfigContextStripMenu.RightToLeft = RightToLeft.Yes;
            StatusLogConfigContextStripMenu.ShowCheckMargin = true;
            StatusLogConfigContextStripMenu.ShowImageMargin = false;
            StatusLogConfigContextStripMenu.Size = new Size(172, 48);
            // 
            // LogGeneralMenuCMStrip
            // 
            LogGeneralMenuCMStrip.DropDown = LogSetupGeneralCSMenu;
            LogGeneralMenuCMStrip.ImageScaling = ToolStripItemImageScaling.None;
            LogGeneralMenuCMStrip.MergeAction = MergeAction.MatchOnly;
            LogGeneralMenuCMStrip.Name = "LogGeneralMenuCMStrip";
            LogGeneralMenuCMStrip.RightToLeft = RightToLeft.No;
            LogGeneralMenuCMStrip.Size = new Size(171, 22);
            LogGeneralMenuCMStrip.Text = "General";
            // 
            // LogSetupGeneralCSMenu
            // 
            LogSetupGeneralCSMenu.AllowMerge = false;
            LogSetupGeneralCSMenu.BackColor = SystemColors.ControlLight;
            LogSetupGeneralCSMenu.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LogSetupGeneralCSMenu.Items.AddRange(new ToolStripItem[] { LogToggleNumCMStrip });
            LogSetupGeneralCSMenu.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            LogSetupGeneralCSMenu.Name = "ToolStripOptionsContextMenuStrip";
            LogSetupGeneralCSMenu.OwnerItem = LogGeneralMenuCMStrip;
            LogSetupGeneralCSMenu.ShowCheckMargin = true;
            LogSetupGeneralCSMenu.ShowImageMargin = false;
            LogSetupGeneralCSMenu.Size = new Size(143, 24);
            LogSetupGeneralCSMenu.Text = "General";
            // 
            // LogToggleNumCMStrip
            // 
            LogToggleNumCMStrip.Alignment = ToolStripItemAlignment.Right;
            LogToggleNumCMStrip.Checked = true;
            LogToggleNumCMStrip.CheckOnClick = true;
            LogToggleNumCMStrip.CheckState = CheckState.Checked;
            LogToggleNumCMStrip.ImageScaling = ToolStripItemImageScaling.None;
            LogToggleNumCMStrip.MergeAction = MergeAction.MatchOnly;
            LogToggleNumCMStrip.Name = "LogToggleNumCMStrip";
            LogToggleNumCMStrip.Padding = new Padding(0);
            LogToggleNumCMStrip.RightToLeft = RightToLeft.No;
            LogToggleNumCMStrip.Size = new Size(142, 20);
            LogToggleNumCMStrip.Text = "Numeration";
            LogToggleNumCMStrip.CheckedChanged += LogToggleNumCMStrip_CheckedChanged;
            // 
            // LogSepMenuCMStrip
            // 
            LogSepMenuCMStrip.DropDown = LogSetupSepCSMenu;
            LogSepMenuCMStrip.ImageScaling = ToolStripItemImageScaling.None;
            LogSepMenuCMStrip.MergeAction = MergeAction.MatchOnly;
            LogSepMenuCMStrip.Name = "LogSepMenuCMStrip";
            LogSepMenuCMStrip.RightToLeft = RightToLeft.No;
            LogSepMenuCMStrip.Size = new Size(171, 22);
            LogSepMenuCMStrip.Text = "Separator Chars";
            LogSepMenuCMStrip.Visible = false;
            // 
            // LogSetupSepCSMenu
            // 
            LogSetupSepCSMenu.BackColor = SystemColors.ControlLight;
            LogSetupSepCSMenu.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LogSetupSepCSMenu.Items.AddRange(new ToolStripItem[] { ChangeSep01_TextBox });
            LogSetupSepCSMenu.LayoutStyle = ToolStripLayoutStyle.Table;
            LogSetupSepCSMenu.MaximumSize = new Size(180, 50);
            LogSetupSepCSMenu.MinimumSize = new Size(180, 50);
            LogSetupSepCSMenu.Name = "ToolStripOptionsContextMenuStrip";
            LogSetupSepCSMenu.OwnerItem = LogSepMenuCMStrip;
            LogSetupSepCSMenu.ShowImageMargin = false;
            LogSetupSepCSMenu.Size = new Size(180, 50);
            // 
            // ChangeSep01_TextBox
            // 
            ChangeSep01_TextBox.AcceptsReturn = true;
            ChangeSep01_TextBox.AutoSize = false;
            ChangeSep01_TextBox.BorderStyle = BorderStyle.FixedSingle;
            ChangeSep01_TextBox.CharacterCasing = CharacterCasing.Upper;
            ChangeSep01_TextBox.Font = new Font("Ubuntu Mono", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            ChangeSep01_TextBox.MaxLength = 19;
            ChangeSep01_TextBox.MergeAction = MergeAction.MatchOnly;
            ChangeSep01_TextBox.Name = "ChangeSep01_TextBox";
            ChangeSep01_TextBox.Overflow = ToolStripItemOverflow.Never;
            ChangeSep01_TextBox.Size = new Size(146, 21);
            ChangeSep01_TextBox.Text = " A | B | C | D | E ";
            ChangeSep01_TextBox.TextBoxTextAlign = HorizontalAlignment.Center;
            ChangeSep01_TextBox.KeyDown += ChangeSep01_TextBox_KeyDown;
            // 
            // ClearStatusLogTSButton
            // 
            ClearStatusLogTSButton.BackColor = Color.RosyBrown;
            ClearStatusLogTSButton.Font = new Font("Bahnschrift SemiCondensed", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ClearStatusLogTSButton.ForeColor = Color.White;
            ClearStatusLogTSButton.Image = (Image)resources.GetObject("ClearStatusLogTSButton.Image");
            ClearStatusLogTSButton.ImageAlign = ContentAlignment.MiddleLeft;
            ClearStatusLogTSButton.ImageScaling = ToolStripItemImageScaling.None;
            ClearStatusLogTSButton.ImageTransparentColor = Color.Magenta;
            ClearStatusLogTSButton.Margin = new Padding(5, 1, 5, 1);
            ClearStatusLogTSButton.MergeAction = MergeAction.MatchOnly;
            ClearStatusLogTSButton.Name = "ClearStatusLogTSButton";
            ClearStatusLogTSButton.Overflow = ToolStripItemOverflow.Never;
            ClearStatusLogTSButton.Padding = new Padding(5, 1, 5, 1);
            ClearStatusLogTSButton.Size = new Size(95, 28);
            ClearStatusLogTSButton.Text = "Clear Log";
            ClearStatusLogTSButton.TextAlign = ContentAlignment.TopRight;
            ClearStatusLogTSButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            ClearStatusLogTSButton.Click += ClearStatusLogTSButton_Click;
            // 
            // UnlistedBackupsWindow
            // 
            AcceptButton = DoneButton;
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(624, 741);
            Controls.Add(EditLogToolStripPanel);
            Controls.Add(OpenDirInExplorerButton);
            Controls.Add(CleanUpHeadLabel);
            Controls.Add(DoneButton);
            Controls.Add(ListBoxPanel);
            Controls.Add(ToolStripPanel);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(640, 780);
            MinimizeBox = false;
            MinimumSize = new Size(640, 780);
            Name = "UnlistedBackupsWindow";
            Padding = new Padding(1);
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Backup Data Cleaner";
            TopMost = true;
            FormClosing += UnlistedBackupsWindow_FormClosing;
            ListBoxPanel.ResumeLayout(false);
            UnlistedBackupsToolStrip.ResumeLayout(false);
            UnlistedBackupsToolStrip.PerformLayout();
            UnlistedSettingsContextMenuStrip.ResumeLayout(false);
            ToolStripPanel.ResumeLayout(false);
            EditLogToolStripPanel.ResumeLayout(false);
            EditLogToolStrip.ResumeLayout(false);
            EditLogToolStrip.PerformLayout();
            StatusLogConfigContextStripMenu.ResumeLayout(false);
            LogSetupGeneralCSMenu.ResumeLayout(false);
            LogSetupSepCSMenu.ResumeLayout(false);
            LogSetupSepCSMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox StatusLog;
        private Label DepricatedBackupsLabel;
        private Panel ListBoxPanel;
        private Button DoneButton;
        private ToolStrip UnlistedBackupsToolStrip;
        private Panel ToolStripPanel;
        private ContextMenuStrip UnlistedSettingsContextMenuStrip;
        private ToolStripDropDownButton ToolStripDropDownOptions;
        private ToolStripButton ScanToolStripButton;
        private ToolStripButton AutoCleanToolStripButton;
        private ToolStripMenuItem AskDeleteOnAutoCleanMenuItem;
        private ToolStripButton ScanJsonToolStripButton;
        private Label CleanUpDataHeadLabel;
        private ToolStripButton HelpToolStripButton;
        private Label CleanUpHeadLabel;
        private Button OpenDirInExplorerButton;
        private ToolTip ButtonToolTips;
        private Panel EditLogToolStripPanel;
        private ToolStrip EditLogToolStrip;
        private ToolStripButton ClearStatusLogTSButton;
        private ToolStripDropDownButton StatusLogSettingsTSDropDownButton;
        private ContextMenuStrip StatusLogConfigContextStripMenu;
        private ToolStripMenuItem LogSepMenuCMStrip;
        private ContextMenuStrip LogSetupSepCSMenu;
        private ToolStripTextBox ChangeSep01_TextBox;
        private ToolStripMenuItem LogGeneralMenuCMStrip;
        private ContextMenuStrip LogSetupGeneralCSMenu;
        private ToolStripMenuItem LogToggleNumCMStrip;
        private ToolStripMenuItem ShowDetailesAfterScanMenuItem;
    }
}