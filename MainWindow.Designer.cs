using System.Resources;
using ZomboidBackupManager.Properties;
using static ZomboidBackupManager.Configuration;

namespace ZomboidBackupManager
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            GamemodeComboBox = new ComboBox();
            SelectSavegameLabel = new Label();
            SelectSavegamePanel = new Panel();
            DatabasePresetTSPanel = new Panel();
            DatabaseToolStrip = new ToolStrip();
            OpenDatabaseSetupTSButton = new ToolStripButton();
            TSSeparator3 = new ToolStripSeparator();
            LoadDataBaseButton = new ToolStripButton();
            TSSeparator4 = new ToolStripSeparator();
            SavegameHeadlineLabel = new Label();
            SavegameListBox = new ListBox();
            ThumbnailPictureBox = new PictureBox();
            SavegameInfoPanel = new Panel();
            BackupModeInfoPanel = new Panel();
            HasBaseBackupValuePictureBox = new PictureBox();
            HasBaseBackupTextLabel = new Label();
            IsDatabaseLoadedValuePictureBox = new PictureBox();
            ActiveBackupModeValueLabel = new Label();
            ActiveBackupModeTextLabel = new Label();
            IsDatabaseLoadedTextLabel = new Label();
            BackupCountSubPanel = new Panel();
            BackupCountValueLabel = new Label();
            BackupCountTextLabel = new Label();
            GamemodeAndSavegameInfoSubPanel = new Panel();
            SavgameInfoValueLabel = new Label();
            GamemodeInfoValueLabel = new Label();
            SavgameInfoTextLabel = new Label();
            GamemodeInfoTextLabel = new Label();
            EditBackupsContextMenu = new ContextMenuStrip(components);
            SelectContextMenuItem = new ToolStripMenuItem();
            SelectMultiMenuItem = new ToolStripMenuItem();
            SelectAllMenuItem = new ToolStripMenuItem();
            DeleteContextMenuItem = new ToolStripMenuItem();
            DeleteSelectedMenuOption = new ToolStripMenuItem();
            DeleteZipMenuOption = new ToolStripMenuItem();
            DeleteLooseMenuOption = new ToolStripMenuItem();
            RenameContextMenuItem = new ToolStripMenuItem();
            RenameContextMenu = new ContextMenuStrip(components);
            RenameLabelTextItem = new ToolStripTextBox();
            ToolStripSeparatorA = new ToolStripSeparator();
            RenameEnterTextOption = new ToolStripTextBox();
            ToolStripSeparatorB = new ToolStripSeparator();
            ConfrimRenameOption = new ToolStripMenuItem();
            StopMultiSelectMenuItem = new ToolStripMenuItem();
            ToolStripSeparator3 = new ToolStripSeparator();
            CreateZipEditBackupMenuOption = new ToolStripMenuItem();
            RenameBackupsToolbarMenuOption = new ToolStripMenuItem();
            ProgressbarPanel = new Panel();
            ProgressBarA = new ProgressBar();
            ProgressbarLabel = new Label();
            ChangeBackupFolderTextbox = new Panel();
            BackupFolderLabel = new Label();
            BackupFolderPathTextbox = new RichTextBox();
            BackgroundPanel = new Panel();
            SelectBackupPanel = new Panel();
            HalfWindowModeRadioButton = new RadioButton();
            NormalWindowModeRadioButton = new RadioButton();
            BackupRestoreTSPanel = new Panel();
            BackupRestoreToolStrip = new ToolStrip();
            RestoreButton = new ToolStripButton();
            TSSeparator1 = new ToolStripSeparator();
            BackupButton = new ToolStripButton();
            TSSeparator2 = new ToolStripSeparator();
            AutoDeleteInfoLabel = new Label();
            BackupInfoPanel = new Panel();
            BackupDataInfoPanel = new Panel();
            HasLooseValuePictureBox = new PictureBox();
            HasLooseTextLabel = new Label();
            HasZipValuePictureBox = new PictureBox();
            HasZipTextLabel = new Label();
            BackupSizeInfoTextLabel = new Label();
            BackupSizeInfoValueLabel = new Label();
            BackupDateInfoTextLabel = new Label();
            BackupTimeInfoTextLabel = new Label();
            BackupTimeInfoValueLabel = new Label();
            BackupDateInfoValueLabel = new Label();
            BackupFolderTextLabel = new Label();
            BackupFolderValueLabel = new Label();
            BackupIndexTextLabel = new Label();
            BackupNameTextLabel = new Label();
            BackupIndexValueLabel = new Label();
            BackupNameValueLabel = new Label();
            SelectBackupLabel = new Label();
            BackupsPictureBox = new PictureBox();
            BackupListBox = new ListBox();
            SettingsPanelA = new Panel();
            Toolstrip1 = new ToolStrip();
            SettingsDropDownButton = new ToolStripDropDownButton();
            GeneralSettingsMenuOption = new ToolStripMenuItem();
            GeneralSettingsContextMenuStrip = new ContextMenuStrip(components);
            CompressZipSettingMenuOption = new ToolStripMenuItem();
            KeepFolderSettingMenuOption = new ToolStripMenuItem();
            AutoSelectSGSettingMenuOption = new ToolStripMenuItem();
            ShowMsgSettingMenuOption = new ToolStripMenuItem();
            AutoDeleteBackupMenuOption = new ToolStripMenuItem();
            ChangeDirectoryMenuOption = new ToolStripMenuItem();
            DataCleanerMenuOption = new ToolStripMenuItem();
            SmartBackupMenuOption = new ToolStripMenuItem();
            ZipSetupMenuOption = new ToolStripMenuItem();
            AboutToolStripMenuItem = new ToolStripMenuItem();
            EditSettingsDropDownButton = new ToolStripDropDownButton();
            EditBackupsToolbarMenu = new ContextMenuStrip(components);
            SelectBackupsToolbarMenuOption = new ToolStripMenuItem();
            SelectMultiBackupsToolbarOption = new ToolStripMenuItem();
            SelectAllBackupsToolbarOption = new ToolStripMenuItem();
            DeleteBackupsToolbarMenuOption = new ToolStripMenuItem();
            DeleteSelectedToolbarOption = new ToolStripMenuItem();
            DeleteZipToolbarOption = new ToolStripMenuItem();
            DeleteLooseToolbarOption = new ToolStripMenuItem();
            StopMultiSelBackupsToolbarMenuOption = new ToolStripMenuItem();
            EditBackupsToolbarSeparator = new ToolStripSeparator();
            CreateZipToolbarMenuOption = new ToolStripMenuItem();
            ToolStripSeparator1 = new ToolStripSeparator();
            DeleteSelectedToolStripButton = new ToolStripButton();
            StopMultiSelectToolTipButton = new ToolStripButton();
            StartMultiSelectToolTipButton = new ToolStripButton();
            ToolStripSeparator2 = new ToolStripSeparator();
            ListenToPZToolStripButton = new ToolStripButton();
            MinimizeButtonToolTip = new ToolTip(components);
            SelectSavegamePanel.SuspendLayout();
            DatabasePresetTSPanel.SuspendLayout();
            DatabaseToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ThumbnailPictureBox).BeginInit();
            SavegameInfoPanel.SuspendLayout();
            BackupModeInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HasBaseBackupValuePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IsDatabaseLoadedValuePictureBox).BeginInit();
            BackupCountSubPanel.SuspendLayout();
            GamemodeAndSavegameInfoSubPanel.SuspendLayout();
            EditBackupsContextMenu.SuspendLayout();
            RenameContextMenu.SuspendLayout();
            ProgressbarPanel.SuspendLayout();
            ChangeBackupFolderTextbox.SuspendLayout();
            BackgroundPanel.SuspendLayout();
            SelectBackupPanel.SuspendLayout();
            BackupRestoreTSPanel.SuspendLayout();
            BackupRestoreToolStrip.SuspendLayout();
            BackupInfoPanel.SuspendLayout();
            BackupDataInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HasLooseValuePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HasZipValuePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BackupsPictureBox).BeginInit();
            SettingsPanelA.SuspendLayout();
            Toolstrip1.SuspendLayout();
            GeneralSettingsContextMenuStrip.SuspendLayout();
            EditBackupsToolbarMenu.SuspendLayout();
            SuspendLayout();
            // 
            // GamemodeComboBox
            // 
            GamemodeComboBox.BackColor = SystemColors.ControlLightLight;
            GamemodeComboBox.Font = new Font("Bahnschrift", 13F);
            GamemodeComboBox.Location = new Point(20, 114);
            GamemodeComboBox.Margin = new Padding(18, 3, 3, 3);
            GamemodeComboBox.Name = "GamemodeComboBox";
            GamemodeComboBox.Size = new Size(530, 29);
            GamemodeComboBox.TabIndex = 0;
            GamemodeComboBox.Text = "Select Gamemode";
            GamemodeComboBox.SelectedIndexChanged += GamemodeComboBox_SelectedIndexChanged;
            // 
            // SelectSavegameLabel
            // 
            SelectSavegameLabel.AutoSize = true;
            SelectSavegameLabel.BackColor = SystemColors.ControlLight;
            SelectSavegameLabel.BorderStyle = BorderStyle.Fixed3D;
            SelectSavegameLabel.Font = new Font("Bahnschrift", 25F);
            SelectSavegameLabel.Location = new Point(43, 15);
            SelectSavegameLabel.Name = "SelectSavegameLabel";
            SelectSavegameLabel.Size = new Size(273, 84);
            SelectSavegameLabel.TabIndex = 1;
            SelectSavegameLabel.Text = "Project Zomboid\r\nBackup Manager";
            SelectSavegameLabel.TextAlign = ContentAlignment.MiddleCenter;
            MinimizeButtonToolTip.SetToolTip(SelectSavegameLabel, "Click to Reload Window\r\n\r\n(Reloads the whole window,\r\nif something isn't showing\r\nup properly)");
            SelectSavegameLabel.Click += SelectSavegameLabel_Click;
            // 
            // SelectSavegamePanel
            // 
            SelectSavegamePanel.BackColor = SystemColors.ControlLight;
            SelectSavegamePanel.BorderStyle = BorderStyle.FixedSingle;
            SelectSavegamePanel.Controls.Add(DatabasePresetTSPanel);
            SelectSavegamePanel.Controls.Add(SelectSavegameLabel);
            SelectSavegamePanel.Controls.Add(SavegameHeadlineLabel);
            SelectSavegamePanel.Controls.Add(SavegameListBox);
            SelectSavegamePanel.Controls.Add(ThumbnailPictureBox);
            SelectSavegamePanel.Controls.Add(GamemodeComboBox);
            SelectSavegamePanel.Controls.Add(SavegameInfoPanel);
            SelectSavegamePanel.Dock = DockStyle.Left;
            SelectSavegamePanel.Location = new Point(10, 10);
            SelectSavegamePanel.Name = "SelectSavegamePanel";
            SelectSavegamePanel.Size = new Size(575, 800);
            SelectSavegamePanel.TabIndex = 2;
            // 
            // DatabasePresetTSPanel
            // 
            DatabasePresetTSPanel.BackColor = SystemColors.ControlLight;
            DatabasePresetTSPanel.BackgroundImageLayout = ImageLayout.Center;
            DatabasePresetTSPanel.BorderStyle = BorderStyle.Fixed3D;
            DatabasePresetTSPanel.Controls.Add(DatabaseToolStrip);
            DatabasePresetTSPanel.Location = new Point(20, 645);
            DatabasePresetTSPanel.MaximumSize = new Size(530, 74);
            DatabasePresetTSPanel.MinimumSize = new Size(530, 74);
            DatabasePresetTSPanel.Name = "DatabasePresetTSPanel";
            DatabasePresetTSPanel.Padding = new Padding(10, 5, 10, 5);
            DatabasePresetTSPanel.Size = new Size(530, 74);
            DatabasePresetTSPanel.TabIndex = 26;
            // 
            // DatabaseToolStrip
            // 
            DatabaseToolStrip.AllowMerge = false;
            DatabaseToolStrip.AutoSize = false;
            DatabaseToolStrip.BackColor = SystemColors.ControlDark;
            DatabaseToolStrip.CanOverflow = false;
            DatabaseToolStrip.Dock = DockStyle.Fill;
            DatabaseToolStrip.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DatabaseToolStrip.GripMargin = new Padding(5);
            DatabaseToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            DatabaseToolStrip.ImageScalingSize = new Size(32, 32);
            DatabaseToolStrip.Items.AddRange(new ToolStripItem[] { OpenDatabaseSetupTSButton, TSSeparator3, LoadDataBaseButton, TSSeparator4 });
            DatabaseToolStrip.Location = new Point(10, 5);
            DatabaseToolStrip.Name = "DatabaseToolStrip";
            DatabaseToolStrip.Padding = new Padding(0);
            DatabaseToolStrip.Size = new Size(506, 60);
            DatabaseToolStrip.TabIndex = 0;
            // 
            // OpenDatabaseSetupTSButton
            // 
            OpenDatabaseSetupTSButton.AutoSize = false;
            OpenDatabaseSetupTSButton.BackColor = SystemColors.ControlDarkDark;
            OpenDatabaseSetupTSButton.Font = new Font("Impact", 9F);
            OpenDatabaseSetupTSButton.ForeColor = SystemColors.ButtonHighlight;
            OpenDatabaseSetupTSButton.Image = (Image)resources.GetObject("OpenDatabaseSetupTSButton.Image");
            OpenDatabaseSetupTSButton.ImageScaling = ToolStripItemImageScaling.None;
            OpenDatabaseSetupTSButton.ImageTransparentColor = Color.Magenta;
            OpenDatabaseSetupTSButton.Margin = new Padding(2);
            OpenDatabaseSetupTSButton.MergeAction = MergeAction.MatchOnly;
            OpenDatabaseSetupTSButton.MergeIndex = 3;
            OpenDatabaseSetupTSButton.Name = "OpenDatabaseSetupTSButton";
            OpenDatabaseSetupTSButton.Overflow = ToolStripItemOverflow.Never;
            OpenDatabaseSetupTSButton.Padding = new Padding(1, 1, 5, 1);
            OpenDatabaseSetupTSButton.Size = new Size(100, 56);
            OpenDatabaseSetupTSButton.Text = "Database Setup";
            OpenDatabaseSetupTSButton.TextImageRelation = TextImageRelation.ImageAboveText;
            OpenDatabaseSetupTSButton.ToolTipText = "Create and/or Load Database for\r\nthe Savegame selected in the box\r\nto the left.";
            OpenDatabaseSetupTSButton.Click += OpenDatabaseSetupTSButton_Click;
            // 
            // TSSeparator3
            // 
            TSSeparator3.AutoSize = false;
            TSSeparator3.BackColor = Color.White;
            TSSeparator3.ForeColor = SystemColors.AppWorkspace;
            TSSeparator3.Margin = new Padding(5, 0, 5, 0);
            TSSeparator3.MergeAction = MergeAction.MatchOnly;
            TSSeparator3.Name = "TSSeparator3";
            TSSeparator3.Overflow = ToolStripItemOverflow.Never;
            TSSeparator3.Padding = new Padding(5, 0, 5, 0);
            TSSeparator3.Size = new Size(25, 55);
            // 
            // LoadDataBaseButton
            // 
            LoadDataBaseButton.Alignment = ToolStripItemAlignment.Right;
            LoadDataBaseButton.AutoSize = false;
            LoadDataBaseButton.BackColor = SystemColors.ControlDarkDark;
            LoadDataBaseButton.Enabled = false;
            LoadDataBaseButton.Font = new Font("Impact", 9F);
            LoadDataBaseButton.ForeColor = SystemColors.ButtonHighlight;
            LoadDataBaseButton.Image = (Image)resources.GetObject("LoadDataBaseButton.Image");
            LoadDataBaseButton.ImageScaling = ToolStripItemImageScaling.None;
            LoadDataBaseButton.ImageTransparentColor = Color.Magenta;
            LoadDataBaseButton.Margin = new Padding(2);
            LoadDataBaseButton.MergeAction = MergeAction.MatchOnly;
            LoadDataBaseButton.MergeIndex = 3;
            LoadDataBaseButton.Name = "LoadDataBaseButton";
            LoadDataBaseButton.Overflow = ToolStripItemOverflow.Never;
            LoadDataBaseButton.Padding = new Padding(1, 1, 5, 1);
            LoadDataBaseButton.Size = new Size(100, 56);
            LoadDataBaseButton.Text = "Load Database";
            LoadDataBaseButton.TextImageRelation = TextImageRelation.ImageAboveText;
            LoadDataBaseButton.ToolTipText = "Create and/or Load Database for\r\nthe Savegame selected in the box\r\nto the left.";
            LoadDataBaseButton.Click += LoadDataBaseButton_Click;
            // 
            // TSSeparator4
            // 
            TSSeparator4.Alignment = ToolStripItemAlignment.Right;
            TSSeparator4.AutoSize = false;
            TSSeparator4.BackColor = Color.DarkGray;
            TSSeparator4.ForeColor = Color.Black;
            TSSeparator4.Margin = new Padding(5, 0, 5, 0);
            TSSeparator4.MergeAction = MergeAction.MatchOnly;
            TSSeparator4.Name = "TSSeparator4";
            TSSeparator4.Overflow = ToolStripItemOverflow.Never;
            TSSeparator4.Padding = new Padding(5, 0, 5, 0);
            TSSeparator4.Size = new Size(25, 55);
            // 
            // SavegameHeadlineLabel
            // 
            SavegameHeadlineLabel.BackColor = SystemColors.ControlLightLight;
            SavegameHeadlineLabel.BorderStyle = BorderStyle.FixedSingle;
            SavegameHeadlineLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SavegameHeadlineLabel.Location = new Point(20, 416);
            SavegameHeadlineLabel.Name = "SavegameHeadlineLabel";
            SavegameHeadlineLabel.Size = new Size(530, 35);
            SavegameHeadlineLabel.TabIndex = 25;
            SavegameHeadlineLabel.Text = "Select a Savegame:";
            SavegameHeadlineLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SavegameListBox
            // 
            SavegameListBox.BackColor = Color.White;
            SavegameListBox.Font = new Font("Bahnschrift", 12F);
            SavegameListBox.FormattingEnabled = true;
            SavegameListBox.HorizontalExtent = 10;
            SavegameListBox.Items.AddRange(new object[] { "Select a Gamemode first!" });
            SavegameListBox.Location = new Point(20, 450);
            SavegameListBox.Margin = new Padding(15);
            SavegameListBox.MaximumSize = new Size(530, 194);
            SavegameListBox.MinimumSize = new Size(530, 194);
            SavegameListBox.Name = "SavegameListBox";
            SavegameListBox.ScrollAlwaysVisible = true;
            SavegameListBox.Size = new Size(530, 194);
            SavegameListBox.TabIndex = 24;
            SavegameListBox.SelectedIndexChanged += SavegameListBox_SelectedIndexChanged;
            // 
            // ThumbnailPictureBox
            // 
            ThumbnailPictureBox.BorderStyle = BorderStyle.Fixed3D;
            ThumbnailPictureBox.Image = (Image)resources.GetObject("ThumbnailPictureBox.Image");
            ThumbnailPictureBox.InitialImage = (Image)resources.GetObject("ThumbnailPictureBox.InitialImage");
            ThumbnailPictureBox.Location = new Point(18, 150);
            ThumbnailPictureBox.Margin = new Padding(18, 3, 3, 3);
            ThumbnailPictureBox.Name = "ThumbnailPictureBox";
            ThumbnailPictureBox.Size = new Size(256, 256);
            ThumbnailPictureBox.TabIndex = 8;
            ThumbnailPictureBox.TabStop = false;
            // 
            // SavegameInfoPanel
            // 
            SavegameInfoPanel.BackColor = Color.Black;
            SavegameInfoPanel.BorderStyle = BorderStyle.Fixed3D;
            SavegameInfoPanel.Controls.Add(BackupModeInfoPanel);
            SavegameInfoPanel.Controls.Add(BackupCountSubPanel);
            SavegameInfoPanel.Controls.Add(GamemodeAndSavegameInfoSubPanel);
            SavegameInfoPanel.Location = new Point(280, 150);
            SavegameInfoPanel.Name = "SavegameInfoPanel";
            SavegameInfoPanel.Size = new Size(270, 256);
            SavegameInfoPanel.TabIndex = 12;
            // 
            // BackupModeInfoPanel
            // 
            BackupModeInfoPanel.BackColor = SystemColors.ControlDark;
            BackupModeInfoPanel.BorderStyle = BorderStyle.FixedSingle;
            BackupModeInfoPanel.Controls.Add(HasBaseBackupValuePictureBox);
            BackupModeInfoPanel.Controls.Add(HasBaseBackupTextLabel);
            BackupModeInfoPanel.Controls.Add(IsDatabaseLoadedValuePictureBox);
            BackupModeInfoPanel.Controls.Add(ActiveBackupModeValueLabel);
            BackupModeInfoPanel.Controls.Add(ActiveBackupModeTextLabel);
            BackupModeInfoPanel.Controls.Add(IsDatabaseLoadedTextLabel);
            BackupModeInfoPanel.Location = new Point(2, 148);
            BackupModeInfoPanel.Margin = new Padding(2, 1, 2, 2);
            BackupModeInfoPanel.Name = "BackupModeInfoPanel";
            BackupModeInfoPanel.Size = new Size(262, 100);
            BackupModeInfoPanel.TabIndex = 19;
            // 
            // HasBaseBackupValuePictureBox
            // 
            HasBaseBackupValuePictureBox.BackColor = SystemColors.Control;
            HasBaseBackupValuePictureBox.BorderStyle = BorderStyle.FixedSingle;
            HasBaseBackupValuePictureBox.Image = (Image)resources.GetObject("HasBaseBackupValuePictureBox.Image");
            HasBaseBackupValuePictureBox.Location = new Point(215, 71);
            HasBaseBackupValuePictureBox.Name = "HasBaseBackupValuePictureBox";
            HasBaseBackupValuePictureBox.Size = new Size(24, 24);
            HasBaseBackupValuePictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            HasBaseBackupValuePictureBox.TabIndex = 33;
            HasBaseBackupValuePictureBox.TabStop = false;
            // 
            // HasBaseBackupTextLabel
            // 
            HasBaseBackupTextLabel.BackColor = SystemColors.Control;
            HasBaseBackupTextLabel.BorderStyle = BorderStyle.FixedSingle;
            HasBaseBackupTextLabel.Font = new Font("Bahnschrift", 10F);
            HasBaseBackupTextLabel.Location = new Point(23, 71);
            HasBaseBackupTextLabel.Name = "HasBaseBackupTextLabel";
            HasBaseBackupTextLabel.Size = new Size(193, 24);
            HasBaseBackupTextLabel.TabIndex = 32;
            HasBaseBackupTextLabel.Text = "Base Backup Exists";
            HasBaseBackupTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IsDatabaseLoadedValuePictureBox
            // 
            IsDatabaseLoadedValuePictureBox.BackColor = SystemColors.Control;
            IsDatabaseLoadedValuePictureBox.BorderStyle = BorderStyle.FixedSingle;
            IsDatabaseLoadedValuePictureBox.Image = (Image)resources.GetObject("IsDatabaseLoadedValuePictureBox.Image");
            IsDatabaseLoadedValuePictureBox.Location = new Point(215, 48);
            IsDatabaseLoadedValuePictureBox.Name = "IsDatabaseLoadedValuePictureBox";
            IsDatabaseLoadedValuePictureBox.Size = new Size(24, 24);
            IsDatabaseLoadedValuePictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            IsDatabaseLoadedValuePictureBox.TabIndex = 31;
            IsDatabaseLoadedValuePictureBox.TabStop = false;
            // 
            // ActiveBackupModeValueLabel
            // 
            ActiveBackupModeValueLabel.BackColor = SystemColors.Control;
            ActiveBackupModeValueLabel.BorderStyle = BorderStyle.FixedSingle;
            ActiveBackupModeValueLabel.Font = new Font("Bahnschrift", 10F);
            ActiveBackupModeValueLabel.Location = new Point(23, 24);
            ActiveBackupModeValueLabel.Margin = new Padding(23, 0, 23, 8);
            ActiveBackupModeValueLabel.Name = "ActiveBackupModeValueLabel";
            ActiveBackupModeValueLabel.Size = new Size(216, 20);
            ActiveBackupModeValueLabel.TabIndex = 17;
            ActiveBackupModeValueLabel.Text = "Default";
            ActiveBackupModeValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ActiveBackupModeTextLabel
            // 
            ActiveBackupModeTextLabel.BackColor = SystemColors.Control;
            ActiveBackupModeTextLabel.BorderStyle = BorderStyle.FixedSingle;
            ActiveBackupModeTextLabel.Font = new Font("Bahnschrift", 10F);
            ActiveBackupModeTextLabel.Location = new Point(23, 5);
            ActiveBackupModeTextLabel.Margin = new Padding(23, 8, 23, 0);
            ActiveBackupModeTextLabel.Name = "ActiveBackupModeTextLabel";
            ActiveBackupModeTextLabel.Size = new Size(216, 20);
            ActiveBackupModeTextLabel.TabIndex = 16;
            ActiveBackupModeTextLabel.Text = "Backup Mode:";
            ActiveBackupModeTextLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // IsDatabaseLoadedTextLabel
            // 
            IsDatabaseLoadedTextLabel.BackColor = SystemColors.Control;
            IsDatabaseLoadedTextLabel.BorderStyle = BorderStyle.FixedSingle;
            IsDatabaseLoadedTextLabel.Font = new Font("Bahnschrift", 10F);
            IsDatabaseLoadedTextLabel.Location = new Point(23, 48);
            IsDatabaseLoadedTextLabel.Name = "IsDatabaseLoadedTextLabel";
            IsDatabaseLoadedTextLabel.Size = new Size(193, 24);
            IsDatabaseLoadedTextLabel.TabIndex = 30;
            IsDatabaseLoadedTextLabel.Text = "Database Loaded";
            IsDatabaseLoadedTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupCountSubPanel
            // 
            BackupCountSubPanel.BackColor = SystemColors.ControlDark;
            BackupCountSubPanel.BorderStyle = BorderStyle.FixedSingle;
            BackupCountSubPanel.Controls.Add(BackupCountValueLabel);
            BackupCountSubPanel.Controls.Add(BackupCountTextLabel);
            BackupCountSubPanel.Location = new Point(2, 98);
            BackupCountSubPanel.Margin = new Padding(2, 1, 2, 2);
            BackupCountSubPanel.Name = "BackupCountSubPanel";
            BackupCountSubPanel.Size = new Size(262, 48);
            BackupCountSubPanel.TabIndex = 18;
            // 
            // BackupCountValueLabel
            // 
            BackupCountValueLabel.BackColor = SystemColors.Control;
            BackupCountValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupCountValueLabel.Font = new Font("Bahnschrift", 10F);
            BackupCountValueLabel.Location = new Point(23, 21);
            BackupCountValueLabel.Margin = new Padding(23, 0, 23, 2);
            BackupCountValueLabel.Name = "BackupCountValueLabel";
            BackupCountValueLabel.Size = new Size(216, 20);
            BackupCountValueLabel.TabIndex = 17;
            BackupCountValueLabel.Text = "-";
            BackupCountValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            BackupCountValueLabel.Click += BackupCountValueLabel_Click;
            // 
            // BackupCountTextLabel
            // 
            BackupCountTextLabel.BackColor = SystemColors.Control;
            BackupCountTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupCountTextLabel.Font = new Font("Bahnschrift", 10F);
            BackupCountTextLabel.Location = new Point(23, 2);
            BackupCountTextLabel.Margin = new Padding(23, 2, 23, 0);
            BackupCountTextLabel.Name = "BackupCountTextLabel";
            BackupCountTextLabel.Size = new Size(216, 20);
            BackupCountTextLabel.TabIndex = 16;
            BackupCountTextLabel.Text = "Backups:";
            BackupCountTextLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // GamemodeAndSavegameInfoSubPanel
            // 
            GamemodeAndSavegameInfoSubPanel.BackColor = SystemColors.ControlDark;
            GamemodeAndSavegameInfoSubPanel.BorderStyle = BorderStyle.FixedSingle;
            GamemodeAndSavegameInfoSubPanel.Controls.Add(SavgameInfoValueLabel);
            GamemodeAndSavegameInfoSubPanel.Controls.Add(GamemodeInfoValueLabel);
            GamemodeAndSavegameInfoSubPanel.Controls.Add(SavgameInfoTextLabel);
            GamemodeAndSavegameInfoSubPanel.Controls.Add(GamemodeInfoTextLabel);
            GamemodeAndSavegameInfoSubPanel.Location = new Point(2, 2);
            GamemodeAndSavegameInfoSubPanel.Margin = new Padding(2);
            GamemodeAndSavegameInfoSubPanel.Name = "GamemodeAndSavegameInfoSubPanel";
            GamemodeAndSavegameInfoSubPanel.Size = new Size(262, 94);
            GamemodeAndSavegameInfoSubPanel.TabIndex = 15;
            // 
            // SavgameInfoValueLabel
            // 
            SavgameInfoValueLabel.BackColor = SystemColors.Control;
            SavgameInfoValueLabel.BorderStyle = BorderStyle.FixedSingle;
            SavgameInfoValueLabel.Font = new Font("Bahnschrift", 10F);
            SavgameInfoValueLabel.Location = new Point(23, 62);
            SavgameInfoValueLabel.Margin = new Padding(23, 0, 23, 8);
            SavgameInfoValueLabel.Name = "SavgameInfoValueLabel";
            SavgameInfoValueLabel.Size = new Size(216, 20);
            SavgameInfoValueLabel.TabIndex = 11;
            SavgameInfoValueLabel.Text = "-";
            SavgameInfoValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GamemodeInfoValueLabel
            // 
            GamemodeInfoValueLabel.BackColor = SystemColors.Control;
            GamemodeInfoValueLabel.BorderStyle = BorderStyle.FixedSingle;
            GamemodeInfoValueLabel.Font = new Font("Bahnschrift", 10F);
            GamemodeInfoValueLabel.Location = new Point(23, 21);
            GamemodeInfoValueLabel.Margin = new Padding(23, 0, 23, 8);
            GamemodeInfoValueLabel.Name = "GamemodeInfoValueLabel";
            GamemodeInfoValueLabel.Size = new Size(216, 20);
            GamemodeInfoValueLabel.TabIndex = 14;
            GamemodeInfoValueLabel.Text = "-";
            GamemodeInfoValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SavgameInfoTextLabel
            // 
            SavgameInfoTextLabel.BackColor = SystemColors.Control;
            SavgameInfoTextLabel.BorderStyle = BorderStyle.FixedSingle;
            SavgameInfoTextLabel.Font = new Font("Bahnschrift", 10F);
            SavgameInfoTextLabel.Location = new Point(23, 43);
            SavgameInfoTextLabel.Margin = new Padding(23, 2, 23, 0);
            SavgameInfoTextLabel.Name = "SavgameInfoTextLabel";
            SavgameInfoTextLabel.Size = new Size(216, 20);
            SavgameInfoTextLabel.TabIndex = 10;
            SavgameInfoTextLabel.Text = "Savegame:";
            SavgameInfoTextLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // GamemodeInfoTextLabel
            // 
            GamemodeInfoTextLabel.BackColor = SystemColors.Control;
            GamemodeInfoTextLabel.BorderStyle = BorderStyle.FixedSingle;
            GamemodeInfoTextLabel.Font = new Font("Bahnschrift", 10F);
            GamemodeInfoTextLabel.Location = new Point(23, 2);
            GamemodeInfoTextLabel.Margin = new Padding(23, 2, 23, 2);
            GamemodeInfoTextLabel.Name = "GamemodeInfoTextLabel";
            GamemodeInfoTextLabel.Size = new Size(216, 20);
            GamemodeInfoTextLabel.TabIndex = 13;
            GamemodeInfoTextLabel.Text = "Gamemode:";
            GamemodeInfoTextLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // EditBackupsContextMenu
            // 
            EditBackupsContextMenu.AccessibleRole = AccessibleRole.Cursor;
            EditBackupsContextMenu.AllowClickThrough = true;
            EditBackupsContextMenu.BackColor = SystemColors.ControlDark;
            EditBackupsContextMenu.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditBackupsContextMenu.Items.AddRange(new ToolStripItem[] { SelectContextMenuItem, DeleteContextMenuItem, RenameContextMenuItem, StopMultiSelectMenuItem, ToolStripSeparator3, CreateZipEditBackupMenuOption });
            EditBackupsContextMenu.Name = "EditBackupsMenuButton";
            EditBackupsContextMenu.ShowImageMargin = false;
            EditBackupsContextMenu.Size = new Size(176, 130);
            EditBackupsContextMenu.Text = "Edit";
            EditBackupsContextMenu.Opening += EditBackupsContextMenu_Opening;
            // 
            // SelectContextMenuItem
            // 
            SelectContextMenuItem.BackColor = SystemColors.ControlDarkDark;
            SelectContextMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SelectContextMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SelectMultiMenuItem, SelectAllMenuItem });
            SelectContextMenuItem.ForeColor = Color.White;
            SelectContextMenuItem.MergeIndex = 2;
            SelectContextMenuItem.Name = "SelectContextMenuItem";
            SelectContextMenuItem.Overflow = ToolStripItemOverflow.AsNeeded;
            SelectContextMenuItem.Size = new Size(175, 24);
            SelectContextMenuItem.Text = "Select";
            // 
            // SelectMultiMenuItem
            // 
            SelectMultiMenuItem.BackColor = SystemColors.ControlDarkDark;
            SelectMultiMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SelectMultiMenuItem.ForeColor = SystemColors.Control;
            SelectMultiMenuItem.Name = "SelectMultiMenuItem";
            SelectMultiMenuItem.Size = new Size(163, 24);
            SelectMultiMenuItem.Text = "Select Multi";
            SelectMultiMenuItem.Click += SelectMultiOption_Click;
            // 
            // SelectAllMenuItem
            // 
            SelectAllMenuItem.BackColor = SystemColors.ControlDarkDark;
            SelectAllMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SelectAllMenuItem.ForeColor = SystemColors.Control;
            SelectAllMenuItem.Name = "SelectAllMenuItem";
            SelectAllMenuItem.Size = new Size(163, 24);
            SelectAllMenuItem.Text = "Select All";
            SelectAllMenuItem.Click += SelectAllOption_Click;
            // 
            // DeleteContextMenuItem
            // 
            DeleteContextMenuItem.BackColor = SystemColors.ControlDarkDark;
            DeleteContextMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            DeleteContextMenuItem.DropDownItems.AddRange(new ToolStripItem[] { DeleteSelectedMenuOption, DeleteZipMenuOption, DeleteLooseMenuOption });
            DeleteContextMenuItem.ForeColor = Color.White;
            DeleteContextMenuItem.MergeIndex = 1;
            DeleteContextMenuItem.Name = "DeleteContextMenuItem";
            DeleteContextMenuItem.Overflow = ToolStripItemOverflow.AsNeeded;
            DeleteContextMenuItem.Size = new Size(175, 24);
            DeleteContextMenuItem.Text = "Delete";
            // 
            // DeleteSelectedMenuOption
            // 
            DeleteSelectedMenuOption.AutoSize = false;
            DeleteSelectedMenuOption.BackColor = SystemColors.ControlDarkDark;
            DeleteSelectedMenuOption.ForeColor = SystemColors.Control;
            DeleteSelectedMenuOption.Name = "DeleteSelectedMenuOption";
            DeleteSelectedMenuOption.Size = new Size(175, 25);
            DeleteSelectedMenuOption.Text = "Delete";
            DeleteSelectedMenuOption.Click += DeleteSelected_OnClick;
            // 
            // DeleteZipMenuOption
            // 
            DeleteZipMenuOption.AutoSize = false;
            DeleteZipMenuOption.BackColor = SystemColors.ControlDarkDark;
            DeleteZipMenuOption.ForeColor = SystemColors.Control;
            DeleteZipMenuOption.Name = "DeleteZipMenuOption";
            DeleteZipMenuOption.Size = new Size(175, 25);
            DeleteZipMenuOption.Text = "Delete Zip";
            // 
            // DeleteLooseMenuOption
            // 
            DeleteLooseMenuOption.AutoSize = false;
            DeleteLooseMenuOption.BackColor = SystemColors.ControlDarkDark;
            DeleteLooseMenuOption.ForeColor = SystemColors.Control;
            DeleteLooseMenuOption.Name = "DeleteLooseMenuOption";
            DeleteLooseMenuOption.Size = new Size(175, 25);
            DeleteLooseMenuOption.Text = "Delete Loose";
            // 
            // RenameContextMenuItem
            // 
            RenameContextMenuItem.BackColor = SystemColors.ControlDarkDark;
            RenameContextMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            RenameContextMenuItem.DropDown = RenameContextMenu;
            RenameContextMenuItem.ForeColor = Color.White;
            RenameContextMenuItem.MergeAction = MergeAction.Remove;
            RenameContextMenuItem.MergeIndex = 0;
            RenameContextMenuItem.Name = "RenameContextMenuItem";
            RenameContextMenuItem.Overflow = ToolStripItemOverflow.AsNeeded;
            RenameContextMenuItem.Size = new Size(175, 24);
            RenameContextMenuItem.Text = "Rename";
            // 
            // RenameContextMenu
            // 
            RenameContextMenu.AutoSize = false;
            RenameContextMenu.BackColor = SystemColors.ControlDarkDark;
            RenameContextMenu.Font = new Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RenameContextMenu.Items.AddRange(new ToolStripItem[] { RenameLabelTextItem, ToolStripSeparatorA, RenameEnterTextOption, ToolStripSeparatorB, ConfrimRenameOption });
            RenameContextMenu.Name = "RenameContextMenu";
            RenameContextMenu.OwnerItem = RenameBackupsToolbarMenuOption;
            RenameContextMenu.ShowImageMargin = false;
            RenameContextMenu.Size = new Size(280, 130);
            // 
            // RenameLabelTextItem
            // 
            RenameLabelTextItem.AutoSize = false;
            RenameLabelTextItem.BackColor = SystemColors.ControlDark;
            RenameLabelTextItem.Font = new Font("Bahnschrift", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RenameLabelTextItem.ForeColor = SystemColors.HighlightText;
            RenameLabelTextItem.MaxLength = 100;
            RenameLabelTextItem.Name = "RenameLabelTextItem";
            RenameLabelTextItem.ReadOnly = true;
            RenameLabelTextItem.Size = new Size(260, 26);
            RenameLabelTextItem.Text = "Backup: ";
            RenameLabelTextItem.TextBoxTextAlign = HorizontalAlignment.Center;
            // 
            // ToolStripSeparatorA
            // 
            ToolStripSeparatorA.Name = "ToolStripSeparatorA";
            ToolStripSeparatorA.Size = new Size(276, 6);
            // 
            // RenameEnterTextOption
            // 
            RenameEnterTextOption.AutoSize = false;
            RenameEnterTextOption.BackColor = SystemColors.ControlLightLight;
            RenameEnterTextOption.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RenameEnterTextOption.ForeColor = SystemColors.ControlText;
            RenameEnterTextOption.Name = "RenameEnterTextOption";
            RenameEnterTextOption.Size = new Size(260, 25);
            RenameEnterTextOption.Text = "Enter new name";
            RenameEnterTextOption.TextBoxTextAlign = HorizontalAlignment.Center;
            RenameEnterTextOption.Click += RenameEnterTextOption_Click;
            // 
            // ToolStripSeparatorB
            // 
            ToolStripSeparatorB.Name = "ToolStripSeparatorB";
            ToolStripSeparatorB.Size = new Size(276, 6);
            // 
            // ConfrimRenameOption
            // 
            ConfrimRenameOption.AutoSize = false;
            ConfrimRenameOption.BackColor = SystemColors.Control;
            ConfrimRenameOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ConfrimRenameOption.ImageScaling = ToolStripItemImageScaling.None;
            ConfrimRenameOption.Margin = new Padding(85, 0, 0, 0);
            ConfrimRenameOption.Name = "ConfrimRenameOption";
            ConfrimRenameOption.Overflow = ToolStripItemOverflow.AsNeeded;
            ConfrimRenameOption.Padding = new Padding(25, 5, 5, 5);
            ConfrimRenameOption.Size = new Size(100, 30);
            ConfrimRenameOption.Text = "  Rename";
            ConfrimRenameOption.Click += ConfrimRenameOption_Click;
            // 
            // StopMultiSelectMenuItem
            // 
            StopMultiSelectMenuItem.BackColor = SystemColors.ControlDarkDark;
            StopMultiSelectMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            StopMultiSelectMenuItem.ForeColor = SystemColors.Control;
            StopMultiSelectMenuItem.MergeIndex = 3;
            StopMultiSelectMenuItem.Name = "StopMultiSelectMenuItem";
            StopMultiSelectMenuItem.Overflow = ToolStripItemOverflow.AsNeeded;
            StopMultiSelectMenuItem.Size = new Size(175, 24);
            StopMultiSelectMenuItem.Text = "Stop Multi Select";
            StopMultiSelectMenuItem.Visible = false;
            StopMultiSelectMenuItem.MouseDown += StopMultiSelectMenuItem_MouseDown;
            // 
            // ToolStripSeparator3
            // 
            ToolStripSeparator3.BackColor = SystemColors.ControlDarkDark;
            ToolStripSeparator3.ForeColor = SystemColors.ControlDarkDark;
            ToolStripSeparator3.Name = "ToolStripSeparator3";
            ToolStripSeparator3.Overflow = ToolStripItemOverflow.Never;
            ToolStripSeparator3.Size = new Size(172, 6);
            // 
            // CreateZipEditBackupMenuOption
            // 
            CreateZipEditBackupMenuOption.BackColor = SystemColors.ControlDarkDark;
            CreateZipEditBackupMenuOption.ForeColor = SystemColors.Control;
            CreateZipEditBackupMenuOption.Name = "CreateZipEditBackupMenuOption";
            CreateZipEditBackupMenuOption.Size = new Size(175, 24);
            CreateZipEditBackupMenuOption.Text = "Create Zip";
            // 
            // RenameBackupsToolbarMenuOption
            // 
            RenameBackupsToolbarMenuOption.BackColor = SystemColors.ControlDarkDark;
            RenameBackupsToolbarMenuOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            RenameBackupsToolbarMenuOption.DropDown = RenameContextMenu;
            RenameBackupsToolbarMenuOption.ForeColor = Color.White;
            RenameBackupsToolbarMenuOption.MergeAction = MergeAction.Remove;
            RenameBackupsToolbarMenuOption.MergeIndex = 0;
            RenameBackupsToolbarMenuOption.Name = "RenameBackupsToolbarMenuOption";
            RenameBackupsToolbarMenuOption.Overflow = ToolStripItemOverflow.AsNeeded;
            RenameBackupsToolbarMenuOption.Size = new Size(175, 24);
            RenameBackupsToolbarMenuOption.Text = "Rename";
            // 
            // ProgressbarPanel
            // 
            ProgressbarPanel.BackColor = SystemColors.ScrollBar;
            ProgressbarPanel.BorderStyle = BorderStyle.Fixed3D;
            ProgressbarPanel.Controls.Add(ProgressBarA);
            ProgressbarPanel.Controls.Add(ProgressbarLabel);
            ProgressbarPanel.Dock = DockStyle.Bottom;
            ProgressbarPanel.Location = new Point(15, 728);
            ProgressbarPanel.Name = "ProgressbarPanel";
            ProgressbarPanel.Size = new Size(528, 60);
            ProgressbarPanel.TabIndex = 10;
            ProgressbarPanel.Visible = false;
            // 
            // ProgressBarA
            // 
            ProgressBarA.BackColor = Color.White;
            ProgressBarA.Dock = DockStyle.Top;
            ProgressBarA.ForeColor = Color.Red;
            ProgressBarA.Location = new Point(0, 0);
            ProgressBarA.Margin = new Padding(15, 4, 15, 4);
            ProgressBarA.MarqueeAnimationSpeed = 10;
            ProgressBarA.Name = "ProgressBarA";
            ProgressBarA.Size = new Size(524, 32);
            ProgressBarA.Step = 1;
            ProgressBarA.Style = ProgressBarStyle.Continuous;
            ProgressBarA.TabIndex = 8;
            // 
            // ProgressbarLabel
            // 
            ProgressbarLabel.BackColor = SystemColors.ControlLightLight;
            ProgressbarLabel.BorderStyle = BorderStyle.Fixed3D;
            ProgressbarLabel.Dock = DockStyle.Bottom;
            ProgressbarLabel.Font = new Font("Bahnschrift", 10F);
            ProgressbarLabel.Location = new Point(0, 31);
            ProgressbarLabel.Margin = new Padding(3, 2, 3, 8);
            ProgressbarLabel.Name = "ProgressbarLabel";
            ProgressbarLabel.Size = new Size(524, 25);
            ProgressbarLabel.TabIndex = 7;
            ProgressbarLabel.Text = "-";
            ProgressbarLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ChangeBackupFolderTextbox
            // 
            ChangeBackupFolderTextbox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ChangeBackupFolderTextbox.BackColor = Color.DarkGray;
            ChangeBackupFolderTextbox.BorderStyle = BorderStyle.Fixed3D;
            ChangeBackupFolderTextbox.Controls.Add(BackupFolderLabel);
            ChangeBackupFolderTextbox.Controls.Add(BackupFolderPathTextbox);
            ChangeBackupFolderTextbox.Location = new Point(15, 68);
            ChangeBackupFolderTextbox.Margin = new Padding(5);
            ChangeBackupFolderTextbox.MaximumSize = new Size(530, 64);
            ChangeBackupFolderTextbox.MinimumSize = new Size(530, 54);
            ChangeBackupFolderTextbox.Name = "ChangeBackupFolderTextbox";
            ChangeBackupFolderTextbox.Padding = new Padding(2);
            ChangeBackupFolderTextbox.Size = new Size(530, 54);
            ChangeBackupFolderTextbox.TabIndex = 4;
            // 
            // BackupFolderLabel
            // 
            BackupFolderLabel.BackColor = SystemColors.ControlLight;
            BackupFolderLabel.BorderStyle = BorderStyle.Fixed3D;
            BackupFolderLabel.Dock = DockStyle.Top;
            BackupFolderLabel.Font = new Font("Bahnschrift", 10F);
            BackupFolderLabel.ForeColor = SystemColors.ControlText;
            BackupFolderLabel.Location = new Point(2, 2);
            BackupFolderLabel.Margin = new Padding(10);
            BackupFolderLabel.MaximumSize = new Size(520, 20);
            BackupFolderLabel.MinimumSize = new Size(520, 18);
            BackupFolderLabel.Name = "BackupFolderLabel";
            BackupFolderLabel.Size = new Size(520, 18);
            BackupFolderLabel.TabIndex = 6;
            BackupFolderLabel.Text = "Backup Folder";
            BackupFolderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupFolderPathTextbox
            // 
            BackupFolderPathTextbox.BackColor = SystemColors.ControlLightLight;
            BackupFolderPathTextbox.DetectUrls = false;
            BackupFolderPathTextbox.Dock = DockStyle.Bottom;
            BackupFolderPathTextbox.EnableAutoDragDrop = true;
            BackupFolderPathTextbox.Font = new Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackupFolderPathTextbox.Location = new Point(2, 22);
            BackupFolderPathTextbox.Margin = new Padding(10);
            BackupFolderPathTextbox.MaximumSize = new Size(520, 26);
            BackupFolderPathTextbox.MinimumSize = new Size(520, 24);
            BackupFolderPathTextbox.Multiline = false;
            BackupFolderPathTextbox.Name = "BackupFolderPathTextbox";
            BackupFolderPathTextbox.ScrollBars = RichTextBoxScrollBars.Horizontal;
            BackupFolderPathTextbox.Size = new Size(520, 26);
            BackupFolderPathTextbox.TabIndex = 4;
            BackupFolderPathTextbox.TabStop = false;
            BackupFolderPathTextbox.Text = "";
            BackupFolderPathTextbox.DoubleClick += BackupFolderPathTextbox_DoubleClick;
            // 
            // BackgroundPanel
            // 
            BackgroundPanel.AutoSize = true;
            BackgroundPanel.BackColor = Color.Transparent;
            BackgroundPanel.BackgroundImageLayout = ImageLayout.Center;
            BackgroundPanel.BorderStyle = BorderStyle.FixedSingle;
            BackgroundPanel.Controls.Add(SelectBackupPanel);
            BackgroundPanel.Controls.Add(SelectSavegamePanel);
            BackgroundPanel.Dock = DockStyle.Fill;
            BackgroundPanel.Font = new Font("Bahnschrift", 9F);
            BackgroundPanel.Location = new Point(5, 5);
            BackgroundPanel.Margin = new Padding(5);
            BackgroundPanel.Name = "BackgroundPanel";
            BackgroundPanel.Padding = new Padding(10);
            BackgroundPanel.Size = new Size(1170, 822);
            BackgroundPanel.TabIndex = 5;
            // 
            // SelectBackupPanel
            // 
            SelectBackupPanel.BackColor = SystemColors.ControlLight;
            SelectBackupPanel.BorderStyle = BorderStyle.FixedSingle;
            SelectBackupPanel.Controls.Add(HalfWindowModeRadioButton);
            SelectBackupPanel.Controls.Add(NormalWindowModeRadioButton);
            SelectBackupPanel.Controls.Add(BackupRestoreTSPanel);
            SelectBackupPanel.Controls.Add(AutoDeleteInfoLabel);
            SelectBackupPanel.Controls.Add(ChangeBackupFolderTextbox);
            SelectBackupPanel.Controls.Add(BackupInfoPanel);
            SelectBackupPanel.Controls.Add(SelectBackupLabel);
            SelectBackupPanel.Controls.Add(ProgressbarPanel);
            SelectBackupPanel.Controls.Add(BackupsPictureBox);
            SelectBackupPanel.Controls.Add(BackupListBox);
            SelectBackupPanel.Controls.Add(SettingsPanelA);
            SelectBackupPanel.Dock = DockStyle.Right;
            SelectBackupPanel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SelectBackupPanel.Location = new Point(598, 10);
            SelectBackupPanel.Margin = new Padding(5);
            SelectBackupPanel.MaximumSize = new Size(560, 800);
            SelectBackupPanel.MinimumSize = new Size(535, 795);
            SelectBackupPanel.Name = "SelectBackupPanel";
            SelectBackupPanel.Padding = new Padding(15, 15, 15, 10);
            SelectBackupPanel.Size = new Size(560, 800);
            SelectBackupPanel.TabIndex = 5;
            // 
            // HalfWindowModeRadioButton
            // 
            HalfWindowModeRadioButton.AutoCheck = false;
            HalfWindowModeRadioButton.AutoSize = true;
            HalfWindowModeRadioButton.Enabled = false;
            HalfWindowModeRadioButton.FlatAppearance.BorderColor = SystemColors.ControlDark;
            HalfWindowModeRadioButton.FlatAppearance.BorderSize = 2;
            HalfWindowModeRadioButton.Location = new Point(368, 122);
            HalfWindowModeRadioButton.MinimumSize = new Size(58, 25);
            HalfWindowModeRadioButton.Name = "HalfWindowModeRadioButton";
            HalfWindowModeRadioButton.Size = new Size(58, 25);
            HalfWindowModeRadioButton.TabIndex = 23;
            HalfWindowModeRadioButton.TabStop = true;
            HalfWindowModeRadioButton.Text = "- 1/2";
            HalfWindowModeRadioButton.TextAlign = ContentAlignment.MiddleCenter;
            MinimizeButtonToolTip.SetToolTip(HalfWindowModeRadioButton, "Hides the left side of this window.");
            HalfWindowModeRadioButton.UseVisualStyleBackColor = false;
            HalfWindowModeRadioButton.Click += HalfWindowModeRadioButton_Click;
            // 
            // NormalWindowModeRadioButton
            // 
            NormalWindowModeRadioButton.AutoCheck = false;
            NormalWindowModeRadioButton.AutoSize = true;
            NormalWindowModeRadioButton.Checked = true;
            NormalWindowModeRadioButton.FlatAppearance.BorderColor = SystemColors.ControlDark;
            NormalWindowModeRadioButton.FlatAppearance.BorderSize = 2;
            NormalWindowModeRadioButton.Location = new Point(293, 122);
            NormalWindowModeRadioButton.MinimumSize = new Size(58, 25);
            NormalWindowModeRadioButton.Name = "NormalWindowModeRadioButton";
            NormalWindowModeRadioButton.RightToLeft = RightToLeft.Yes;
            NormalWindowModeRadioButton.Size = new Size(58, 25);
            NormalWindowModeRadioButton.TabIndex = 22;
            NormalWindowModeRadioButton.TabStop = true;
            NormalWindowModeRadioButton.Text = "- 1";
            NormalWindowModeRadioButton.TextAlign = ContentAlignment.MiddleCenter;
            NormalWindowModeRadioButton.UseVisualStyleBackColor = true;
            NormalWindowModeRadioButton.Click += NormalWindowModeRadioButton_Click;
            // 
            // BackupRestoreTSPanel
            // 
            BackupRestoreTSPanel.BackColor = SystemColors.ControlLight;
            BackupRestoreTSPanel.BackgroundImageLayout = ImageLayout.Center;
            BackupRestoreTSPanel.BorderStyle = BorderStyle.Fixed3D;
            BackupRestoreTSPanel.Controls.Add(BackupRestoreToolStrip);
            BackupRestoreTSPanel.Location = new Point(15, 645);
            BackupRestoreTSPanel.MaximumSize = new Size(530, 74);
            BackupRestoreTSPanel.MinimumSize = new Size(530, 74);
            BackupRestoreTSPanel.Name = "BackupRestoreTSPanel";
            BackupRestoreTSPanel.Padding = new Padding(10, 5, 10, 5);
            BackupRestoreTSPanel.Size = new Size(530, 74);
            BackupRestoreTSPanel.TabIndex = 21;
            // 
            // BackupRestoreToolStrip
            // 
            BackupRestoreToolStrip.AllowMerge = false;
            BackupRestoreToolStrip.AutoSize = false;
            BackupRestoreToolStrip.BackColor = SystemColors.ControlDark;
            BackupRestoreToolStrip.CanOverflow = false;
            BackupRestoreToolStrip.Dock = DockStyle.Fill;
            BackupRestoreToolStrip.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackupRestoreToolStrip.GripMargin = new Padding(5);
            BackupRestoreToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            BackupRestoreToolStrip.ImageScalingSize = new Size(32, 32);
            BackupRestoreToolStrip.Items.AddRange(new ToolStripItem[] { RestoreButton, TSSeparator1, BackupButton, TSSeparator2 });
            BackupRestoreToolStrip.Location = new Point(10, 5);
            BackupRestoreToolStrip.Name = "BackupRestoreToolStrip";
            BackupRestoreToolStrip.Padding = new Padding(0);
            BackupRestoreToolStrip.Size = new Size(506, 60);
            BackupRestoreToolStrip.TabIndex = 0;
            // 
            // RestoreButton
            // 
            RestoreButton.AutoSize = false;
            RestoreButton.BackColor = SystemColors.ControlDarkDark;
            RestoreButton.BackgroundImageLayout = ImageLayout.None;
            RestoreButton.Enabled = false;
            RestoreButton.Font = new Font("Closeness", 9.749999F);
            RestoreButton.ForeColor = Color.White;
            RestoreButton.Image = (Image)resources.GetObject("RestoreButton.Image");
            RestoreButton.ImageScaling = ToolStripItemImageScaling.None;
            RestoreButton.ImageTransparentColor = Color.Magenta;
            RestoreButton.Margin = new Padding(5, 2, 2, 2);
            RestoreButton.MergeAction = MergeAction.MatchOnly;
            RestoreButton.MergeIndex = 1;
            RestoreButton.Name = "RestoreButton";
            RestoreButton.Overflow = ToolStripItemOverflow.Never;
            RestoreButton.Padding = new Padding(5, 1, 1, 1);
            RestoreButton.Size = new Size(72, 58);
            RestoreButton.Text = "Restore";
            RestoreButton.TextImageRelation = TextImageRelation.ImageAboveText;
            RestoreButton.ToolTipText = resources.GetString("RestoreButton.ToolTipText");
            RestoreButton.Click += RestoreButton_Click;
            // 
            // TSSeparator1
            // 
            TSSeparator1.AutoSize = false;
            TSSeparator1.BackColor = Color.White;
            TSSeparator1.ForeColor = SystemColors.AppWorkspace;
            TSSeparator1.Margin = new Padding(5, 0, 5, 0);
            TSSeparator1.MergeAction = MergeAction.MatchOnly;
            TSSeparator1.Name = "TSSeparator1";
            TSSeparator1.Overflow = ToolStripItemOverflow.Never;
            TSSeparator1.Padding = new Padding(5, 0, 5, 0);
            TSSeparator1.Size = new Size(25, 55);
            // 
            // BackupButton
            // 
            BackupButton.Alignment = ToolStripItemAlignment.Right;
            BackupButton.AutoSize = false;
            BackupButton.BackColor = SystemColors.ControlDarkDark;
            BackupButton.Enabled = false;
            BackupButton.Font = new Font("Closeness", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackupButton.ForeColor = Color.White;
            BackupButton.Image = (Image)resources.GetObject("BackupButton.Image");
            BackupButton.ImageScaling = ToolStripItemImageScaling.None;
            BackupButton.ImageTransparentColor = Color.Magenta;
            BackupButton.Margin = new Padding(5, 2, 2, 2);
            BackupButton.MergeAction = MergeAction.MatchOnly;
            BackupButton.MergeIndex = 3;
            BackupButton.Name = "BackupButton";
            BackupButton.Overflow = ToolStripItemOverflow.Never;
            BackupButton.Padding = new Padding(1, 1, 5, 1);
            BackupButton.RightToLeft = RightToLeft.Yes;
            BackupButton.Size = new Size(72, 58);
            BackupButton.Text = "Backup";
            BackupButton.TextAlign = ContentAlignment.BottomLeft;
            BackupButton.TextImageRelation = TextImageRelation.ImageAboveText;
            BackupButton.ToolTipText = "Create New Backup\r\n\r\nCreate a new Backup from thes savegame,\r\nselected on the left side. \r\n(Should be obviously the savegame,\r\nyou are currently playing)";
            BackupButton.Click += BackupButton_Click;
            // 
            // TSSeparator2
            // 
            TSSeparator2.Alignment = ToolStripItemAlignment.Right;
            TSSeparator2.AutoSize = false;
            TSSeparator2.BackColor = Color.DarkGray;
            TSSeparator2.ForeColor = Color.Black;
            TSSeparator2.Margin = new Padding(5, 0, 5, 0);
            TSSeparator2.MergeAction = MergeAction.MatchOnly;
            TSSeparator2.Name = "TSSeparator2";
            TSSeparator2.Overflow = ToolStripItemOverflow.Never;
            TSSeparator2.Padding = new Padding(5, 0, 5, 0);
            TSSeparator2.Size = new Size(25, 55);
            // 
            // AutoDeleteInfoLabel
            // 
            AutoDeleteInfoLabel.BackColor = SystemColors.ControlLight;
            AutoDeleteInfoLabel.BorderStyle = BorderStyle.Fixed3D;
            AutoDeleteInfoLabel.Location = new Point(15, 127);
            AutoDeleteInfoLabel.Margin = new Padding(1);
            AutoDeleteInfoLabel.Name = "AutoDeleteInfoLabel";
            AutoDeleteInfoLabel.Size = new Size(256, 21);
            AutoDeleteInfoLabel.TabIndex = 20;
            AutoDeleteInfoLabel.Text = "Autodelete: [0 / 0] Backups";
            AutoDeleteInfoLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // BackupInfoPanel
            // 
            BackupInfoPanel.BackColor = SystemColors.ControlText;
            BackupInfoPanel.BorderStyle = BorderStyle.Fixed3D;
            BackupInfoPanel.Controls.Add(BackupDataInfoPanel);
            BackupInfoPanel.Location = new Point(289, 150);
            BackupInfoPanel.Name = "BackupInfoPanel";
            BackupInfoPanel.Size = new Size(256, 256);
            BackupInfoPanel.TabIndex = 19;
            // 
            // BackupDataInfoPanel
            // 
            BackupDataInfoPanel.BackColor = SystemColors.ControlDarkDark;
            BackupDataInfoPanel.Controls.Add(HasLooseValuePictureBox);
            BackupDataInfoPanel.Controls.Add(HasLooseTextLabel);
            BackupDataInfoPanel.Controls.Add(HasZipValuePictureBox);
            BackupDataInfoPanel.Controls.Add(HasZipTextLabel);
            BackupDataInfoPanel.Controls.Add(BackupSizeInfoTextLabel);
            BackupDataInfoPanel.Controls.Add(BackupSizeInfoValueLabel);
            BackupDataInfoPanel.Controls.Add(BackupDateInfoTextLabel);
            BackupDataInfoPanel.Controls.Add(BackupTimeInfoTextLabel);
            BackupDataInfoPanel.Controls.Add(BackupTimeInfoValueLabel);
            BackupDataInfoPanel.Controls.Add(BackupDateInfoValueLabel);
            BackupDataInfoPanel.Controls.Add(BackupFolderTextLabel);
            BackupDataInfoPanel.Controls.Add(BackupFolderValueLabel);
            BackupDataInfoPanel.Controls.Add(BackupIndexTextLabel);
            BackupDataInfoPanel.Controls.Add(BackupNameTextLabel);
            BackupDataInfoPanel.Controls.Add(BackupIndexValueLabel);
            BackupDataInfoPanel.Controls.Add(BackupNameValueLabel);
            BackupDataInfoPanel.Location = new Point(1, 3);
            BackupDataInfoPanel.Name = "BackupDataInfoPanel";
            BackupDataInfoPanel.Size = new Size(250, 250);
            BackupDataInfoPanel.TabIndex = 12;
            // 
            // HasLooseValuePictureBox
            // 
            HasLooseValuePictureBox.BackColor = SystemColors.Control;
            HasLooseValuePictureBox.BorderStyle = BorderStyle.FixedSingle;
            HasLooseValuePictureBox.Image = (Image)resources.GetObject("HasLooseValuePictureBox.Image");
            HasLooseValuePictureBox.Location = new Point(218, 110);
            HasLooseValuePictureBox.Name = "HasLooseValuePictureBox";
            HasLooseValuePictureBox.Size = new Size(30, 30);
            HasLooseValuePictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            HasLooseValuePictureBox.TabIndex = 31;
            HasLooseValuePictureBox.TabStop = false;
            // 
            // HasLooseTextLabel
            // 
            HasLooseTextLabel.BackColor = SystemColors.Control;
            HasLooseTextLabel.BorderStyle = BorderStyle.FixedSingle;
            HasLooseTextLabel.Font = new Font("Bahnschrift", 10F);
            HasLooseTextLabel.Location = new Point(125, 110);
            HasLooseTextLabel.Name = "HasLooseTextLabel";
            HasLooseTextLabel.Size = new Size(93, 30);
            HasLooseTextLabel.TabIndex = 30;
            HasLooseTextLabel.Text = "Loose:";
            HasLooseTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HasZipValuePictureBox
            // 
            HasZipValuePictureBox.BackColor = SystemColors.Control;
            HasZipValuePictureBox.BorderStyle = BorderStyle.FixedSingle;
            HasZipValuePictureBox.Image = (Image)resources.GetObject("HasZipValuePictureBox.Image");
            HasZipValuePictureBox.Location = new Point(95, 110);
            HasZipValuePictureBox.Name = "HasZipValuePictureBox";
            HasZipValuePictureBox.Size = new Size(30, 30);
            HasZipValuePictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            HasZipValuePictureBox.TabIndex = 29;
            HasZipValuePictureBox.TabStop = false;
            // 
            // HasZipTextLabel
            // 
            HasZipTextLabel.BackColor = SystemColors.Control;
            HasZipTextLabel.BorderStyle = BorderStyle.FixedSingle;
            HasZipTextLabel.Font = new Font("Bahnschrift", 10F);
            HasZipTextLabel.Location = new Point(1, 110);
            HasZipTextLabel.Name = "HasZipTextLabel";
            HasZipTextLabel.Size = new Size(94, 30);
            HasZipTextLabel.TabIndex = 28;
            HasZipTextLabel.Text = "Zip:";
            HasZipTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupSizeInfoTextLabel
            // 
            BackupSizeInfoTextLabel.BackColor = SystemColors.Control;
            BackupSizeInfoTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupSizeInfoTextLabel.Font = new Font("Bahnschrift", 10F);
            BackupSizeInfoTextLabel.Location = new Point(1, 210);
            BackupSizeInfoTextLabel.Name = "BackupSizeInfoTextLabel";
            BackupSizeInfoTextLabel.Size = new Size(60, 30);
            BackupSizeInfoTextLabel.TabIndex = 26;
            BackupSizeInfoTextLabel.Text = "Size:";
            BackupSizeInfoTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupSizeInfoValueLabel
            // 
            BackupSizeInfoValueLabel.BackColor = SystemColors.Control;
            BackupSizeInfoValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupSizeInfoValueLabel.Font = new Font("Bahnschrift", 10F);
            BackupSizeInfoValueLabel.Location = new Point(60, 210);
            BackupSizeInfoValueLabel.Margin = new Padding(5, 0, 5, 0);
            BackupSizeInfoValueLabel.Name = "BackupSizeInfoValueLabel";
            BackupSizeInfoValueLabel.Size = new Size(188, 30);
            BackupSizeInfoValueLabel.TabIndex = 27;
            BackupSizeInfoValueLabel.Text = "-";
            BackupSizeInfoValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupDateInfoTextLabel
            // 
            BackupDateInfoTextLabel.BackColor = SystemColors.Control;
            BackupDateInfoTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupDateInfoTextLabel.Font = new Font("Bahnschrift", 10F);
            BackupDateInfoTextLabel.Location = new Point(1, 146);
            BackupDateInfoTextLabel.Name = "BackupDateInfoTextLabel";
            BackupDateInfoTextLabel.Size = new Size(60, 30);
            BackupDateInfoTextLabel.TabIndex = 25;
            BackupDateInfoTextLabel.Text = "Date:";
            BackupDateInfoTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupTimeInfoTextLabel
            // 
            BackupTimeInfoTextLabel.BackColor = SystemColors.Control;
            BackupTimeInfoTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupTimeInfoTextLabel.Font = new Font("Bahnschrift", 10F);
            BackupTimeInfoTextLabel.Location = new Point(1, 178);
            BackupTimeInfoTextLabel.Name = "BackupTimeInfoTextLabel";
            BackupTimeInfoTextLabel.Size = new Size(60, 30);
            BackupTimeInfoTextLabel.TabIndex = 23;
            BackupTimeInfoTextLabel.Text = "Time:";
            BackupTimeInfoTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupTimeInfoValueLabel
            // 
            BackupTimeInfoValueLabel.BackColor = SystemColors.Control;
            BackupTimeInfoValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupTimeInfoValueLabel.Font = new Font("Bahnschrift", 10F);
            BackupTimeInfoValueLabel.Location = new Point(60, 178);
            BackupTimeInfoValueLabel.Margin = new Padding(5, 0, 5, 0);
            BackupTimeInfoValueLabel.Name = "BackupTimeInfoValueLabel";
            BackupTimeInfoValueLabel.Size = new Size(188, 30);
            BackupTimeInfoValueLabel.TabIndex = 24;
            BackupTimeInfoValueLabel.Text = "-";
            BackupTimeInfoValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupDateInfoValueLabel
            // 
            BackupDateInfoValueLabel.BackColor = SystemColors.Control;
            BackupDateInfoValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupDateInfoValueLabel.Font = new Font("Bahnschrift", 10F);
            BackupDateInfoValueLabel.Location = new Point(60, 146);
            BackupDateInfoValueLabel.Margin = new Padding(5, 0, 5, 0);
            BackupDateInfoValueLabel.Name = "BackupDateInfoValueLabel";
            BackupDateInfoValueLabel.Size = new Size(188, 30);
            BackupDateInfoValueLabel.TabIndex = 22;
            BackupDateInfoValueLabel.Text = "-";
            BackupDateInfoValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupFolderTextLabel
            // 
            BackupFolderTextLabel.BackColor = SystemColors.Control;
            BackupFolderTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupFolderTextLabel.Font = new Font("Bahnschrift", 10F);
            BackupFolderTextLabel.Location = new Point(1, 73);
            BackupFolderTextLabel.Name = "BackupFolderTextLabel";
            BackupFolderTextLabel.Size = new Size(60, 30);
            BackupFolderTextLabel.TabIndex = 14;
            BackupFolderTextLabel.Text = "Folder:";
            BackupFolderTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupFolderValueLabel
            // 
            BackupFolderValueLabel.BackColor = SystemColors.Control;
            BackupFolderValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupFolderValueLabel.Font = new Font("Bahnschrift", 10F);
            BackupFolderValueLabel.Location = new Point(60, 73);
            BackupFolderValueLabel.Name = "BackupFolderValueLabel";
            BackupFolderValueLabel.Size = new Size(188, 30);
            BackupFolderValueLabel.TabIndex = 15;
            BackupFolderValueLabel.Text = "-";
            BackupFolderValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupIndexTextLabel
            // 
            BackupIndexTextLabel.BackColor = SystemColors.Control;
            BackupIndexTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupIndexTextLabel.Font = new Font("Bahnschrift", 10F);
            BackupIndexTextLabel.Location = new Point(1, 41);
            BackupIndexTextLabel.Name = "BackupIndexTextLabel";
            BackupIndexTextLabel.Size = new Size(60, 30);
            BackupIndexTextLabel.TabIndex = 12;
            BackupIndexTextLabel.Text = "Index";
            BackupIndexTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupNameTextLabel
            // 
            BackupNameTextLabel.BackColor = SystemColors.Control;
            BackupNameTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupNameTextLabel.Font = new Font("Bahnschrift", 10F);
            BackupNameTextLabel.Location = new Point(1, 10);
            BackupNameTextLabel.Name = "BackupNameTextLabel";
            BackupNameTextLabel.Size = new Size(60, 30);
            BackupNameTextLabel.TabIndex = 10;
            BackupNameTextLabel.Text = "Backup:";
            BackupNameTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupIndexValueLabel
            // 
            BackupIndexValueLabel.BackColor = SystemColors.Control;
            BackupIndexValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupIndexValueLabel.Font = new Font("Bahnschrift", 10F);
            BackupIndexValueLabel.Location = new Point(60, 41);
            BackupIndexValueLabel.Name = "BackupIndexValueLabel";
            BackupIndexValueLabel.Size = new Size(188, 30);
            BackupIndexValueLabel.TabIndex = 13;
            BackupIndexValueLabel.Text = "-";
            BackupIndexValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupNameValueLabel
            // 
            BackupNameValueLabel.BackColor = SystemColors.Control;
            BackupNameValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupNameValueLabel.Font = new Font("Bahnschrift", 10F);
            BackupNameValueLabel.Location = new Point(60, 10);
            BackupNameValueLabel.Name = "BackupNameValueLabel";
            BackupNameValueLabel.Size = new Size(188, 30);
            BackupNameValueLabel.TabIndex = 11;
            BackupNameValueLabel.Text = "-";
            BackupNameValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SelectBackupLabel
            // 
            SelectBackupLabel.BackColor = SystemColors.ControlLightLight;
            SelectBackupLabel.BorderStyle = BorderStyle.FixedSingle;
            SelectBackupLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SelectBackupLabel.Location = new Point(15, 416);
            SelectBackupLabel.Name = "SelectBackupLabel";
            SelectBackupLabel.Size = new Size(530, 35);
            SelectBackupLabel.TabIndex = 4;
            SelectBackupLabel.Text = "Select a backup you want to restore:";
            SelectBackupLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupsPictureBox
            // 
            BackupsPictureBox.BorderStyle = BorderStyle.Fixed3D;
            BackupsPictureBox.Image = (Image)resources.GetObject("BackupsPictureBox.Image");
            BackupsPictureBox.Location = new Point(15, 150);
            BackupsPictureBox.Margin = new Padding(129, 3, 3, 3);
            BackupsPictureBox.Name = "BackupsPictureBox";
            BackupsPictureBox.Size = new Size(256, 256);
            BackupsPictureBox.TabIndex = 3;
            BackupsPictureBox.TabStop = false;
            BackupsPictureBox.Click += BackupsPictureBox_Click;
            // 
            // BackupListBox
            // 
            BackupListBox.BackColor = Color.White;
            BackupListBox.ContextMenuStrip = EditBackupsContextMenu;
            BackupListBox.Font = new Font("Bahnschrift", 12F);
            BackupListBox.FormattingEnabled = true;
            BackupListBox.HorizontalExtent = 10;
            BackupListBox.Items.AddRange(new object[] { "Select a savegame first." });
            BackupListBox.Location = new Point(15, 450);
            BackupListBox.Margin = new Padding(15);
            BackupListBox.Name = "BackupListBox";
            BackupListBox.ScrollAlwaysVisible = true;
            BackupListBox.Size = new Size(530, 194);
            BackupListBox.TabIndex = 1;
            BackupListBox.SelectedIndexChanged += BackupListBox_SelectedIndexChanged;
            BackupListBox.MouseDoubleClick += BackupListBox_MouseDoubleClick;
            BackupListBox.MouseDown += BackupListBox_MouseDown;
            BackupListBox.MouseUp += BackupListBox_MouseUp;
            // 
            // SettingsPanelA
            // 
            SettingsPanelA.AutoScroll = true;
            SettingsPanelA.AutoSize = true;
            SettingsPanelA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SettingsPanelA.BackColor = SystemColors.ControlDark;
            SettingsPanelA.BorderStyle = BorderStyle.Fixed3D;
            SettingsPanelA.Controls.Add(Toolstrip1);
            SettingsPanelA.Dock = DockStyle.Top;
            SettingsPanelA.Location = new Point(15, 15);
            SettingsPanelA.Margin = new Padding(6);
            SettingsPanelA.MaximumSize = new Size(530, 48);
            SettingsPanelA.Name = "SettingsPanelA";
            SettingsPanelA.Padding = new Padding(4);
            SettingsPanelA.Size = new Size(528, 48);
            SettingsPanelA.TabIndex = 9;
            // 
            // Toolstrip1
            // 
            Toolstrip1.AllowMerge = false;
            Toolstrip1.BackColor = SystemColors.MenuBar;
            Toolstrip1.BackgroundImageLayout = ImageLayout.Center;
            Toolstrip1.CanOverflow = false;
            Toolstrip1.Font = new Font("Bahnschrift", 12F);
            Toolstrip1.GripStyle = ToolStripGripStyle.Hidden;
            Toolstrip1.ImageScalingSize = new Size(32, 32);
            Toolstrip1.Items.AddRange(new ToolStripItem[] { SettingsDropDownButton, EditSettingsDropDownButton, ToolStripSeparator1, DeleteSelectedToolStripButton, StopMultiSelectToolTipButton, StartMultiSelectToolTipButton, ToolStripSeparator2, ListenToPZToolStripButton });
            Toolstrip1.Location = new Point(4, 4);
            Toolstrip1.MinimumSize = new Size(240, 40);
            Toolstrip1.Name = "Toolstrip1";
            Toolstrip1.Padding = new Padding(1);
            Toolstrip1.Size = new Size(516, 40);
            Toolstrip1.Stretch = true;
            Toolstrip1.TabIndex = 12;
            // 
            // SettingsDropDownButton
            // 
            SettingsDropDownButton.BackColor = SystemColors.Control;
            SettingsDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { GeneralSettingsMenuOption, AutoDeleteBackupMenuOption, ChangeDirectoryMenuOption, DataCleanerMenuOption, SmartBackupMenuOption, ZipSetupMenuOption, AboutToolStripMenuItem });
            SettingsDropDownButton.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SettingsDropDownButton.Image = (Image)resources.GetObject("SettingsDropDownButton.Image");
            SettingsDropDownButton.ImageTransparentColor = Color.Magenta;
            SettingsDropDownButton.Margin = new Padding(5, 0, 0, 0);
            SettingsDropDownButton.Name = "SettingsDropDownButton";
            SettingsDropDownButton.Padding = new Padding(5, 0, 0, 0);
            SettingsDropDownButton.Size = new Size(118, 38);
            SettingsDropDownButton.Text = "Settings";
            SettingsDropDownButton.TextAlign = ContentAlignment.MiddleRight;
            SettingsDropDownButton.Click += SettingsDropDownButton_Click;
            // 
            // GeneralSettingsMenuOption
            // 
            GeneralSettingsMenuOption.BackColor = SystemColors.ControlDarkDark;
            GeneralSettingsMenuOption.DropDown = GeneralSettingsContextMenuStrip;
            GeneralSettingsMenuOption.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GeneralSettingsMenuOption.ForeColor = SystemColors.Control;
            GeneralSettingsMenuOption.Name = "GeneralSettingsMenuOption";
            GeneralSettingsMenuOption.Size = new Size(205, 24);
            GeneralSettingsMenuOption.Text = "General";
            // 
            // GeneralSettingsContextMenuStrip
            // 
            GeneralSettingsContextMenuStrip.BackColor = SystemColors.ControlDark;
            GeneralSettingsContextMenuStrip.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GeneralSettingsContextMenuStrip.Items.AddRange(new ToolStripItem[] { CompressZipSettingMenuOption, KeepFolderSettingMenuOption, AutoSelectSGSettingMenuOption, ShowMsgSettingMenuOption });
            GeneralSettingsContextMenuStrip.Name = "GeneralSettingsContextMenuStrip";
            GeneralSettingsContextMenuStrip.OwnerItem = GeneralSettingsMenuOption;
            GeneralSettingsContextMenuStrip.RightToLeft = RightToLeft.Yes;
            GeneralSettingsContextMenuStrip.ShowCheckMargin = true;
            GeneralSettingsContextMenuStrip.ShowImageMargin = false;
            GeneralSettingsContextMenuStrip.Size = new Size(320, 100);
            // 
            // CompressZipSettingMenuOption
            // 
            CompressZipSettingMenuOption.BackColor = SystemColors.ControlDarkDark;
            CompressZipSettingMenuOption.CheckOnClick = true;
            CompressZipSettingMenuOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            CompressZipSettingMenuOption.Font = new Font("Bahnschrift", 12F);
            CompressZipSettingMenuOption.ForeColor = SystemColors.Control;
            CompressZipSettingMenuOption.MergeAction = MergeAction.MatchOnly;
            CompressZipSettingMenuOption.MergeIndex = 0;
            CompressZipSettingMenuOption.Name = "CompressZipSettingMenuOption";
            CompressZipSettingMenuOption.Size = new Size(319, 24);
            CompressZipSettingMenuOption.Text = "Save backups as .zip file";
            CompressZipSettingMenuOption.CheckedChanged += CompressZipSettingMenuOption_CheckedChanged;
            // 
            // KeepFolderSettingMenuOption
            // 
            KeepFolderSettingMenuOption.BackColor = SystemColors.ControlDarkDark;
            KeepFolderSettingMenuOption.CheckOnClick = true;
            KeepFolderSettingMenuOption.ForeColor = SystemColors.Control;
            KeepFolderSettingMenuOption.MergeAction = MergeAction.MatchOnly;
            KeepFolderSettingMenuOption.MergeIndex = 1;
            KeepFolderSettingMenuOption.Name = "KeepFolderSettingMenuOption";
            KeepFolderSettingMenuOption.Size = new Size(319, 24);
            KeepFolderSettingMenuOption.Text = "Keep backup folder";
            KeepFolderSettingMenuOption.Visible = false;
            KeepFolderSettingMenuOption.CheckedChanged += KeepFolderSettingMenuOption_CheckedChanged;
            // 
            // AutoSelectSGSettingMenuOption
            // 
            AutoSelectSGSettingMenuOption.BackColor = SystemColors.ControlDarkDark;
            AutoSelectSGSettingMenuOption.CheckOnClick = true;
            AutoSelectSGSettingMenuOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            AutoSelectSGSettingMenuOption.Font = new Font("Bahnschrift", 12F);
            AutoSelectSGSettingMenuOption.ForeColor = SystemColors.Control;
            AutoSelectSGSettingMenuOption.MergeAction = MergeAction.MatchOnly;
            AutoSelectSGSettingMenuOption.MergeIndex = 2;
            AutoSelectSGSettingMenuOption.Name = "AutoSelectSGSettingMenuOption";
            AutoSelectSGSettingMenuOption.Size = new Size(319, 24);
            AutoSelectSGSettingMenuOption.Text = "Auto select last loaded state";
            AutoSelectSGSettingMenuOption.CheckedChanged += AutoSelectSGSettingMenuOption_CheckedChanged;
            // 
            // ShowMsgSettingMenuOption
            // 
            ShowMsgSettingMenuOption.BackColor = SystemColors.ControlDarkDark;
            ShowMsgSettingMenuOption.CheckOnClick = true;
            ShowMsgSettingMenuOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ShowMsgSettingMenuOption.Font = new Font("Bahnschrift", 12F);
            ShowMsgSettingMenuOption.ForeColor = SystemColors.Control;
            ShowMsgSettingMenuOption.MergeAction = MergeAction.MatchOnly;
            ShowMsgSettingMenuOption.MergeIndex = 3;
            ShowMsgSettingMenuOption.Name = "ShowMsgSettingMenuOption";
            ShowMsgSettingMenuOption.Size = new Size(319, 24);
            ShowMsgSettingMenuOption.Text = "Show message when action done";
            ShowMsgSettingMenuOption.CheckedChanged += ShowMsgSettingMenuOption_CheckedChanged;
            // 
            // AutoDeleteBackupMenuOption
            // 
            AutoDeleteBackupMenuOption.BackColor = SystemColors.ControlDarkDark;
            AutoDeleteBackupMenuOption.ForeColor = SystemColors.Control;
            AutoDeleteBackupMenuOption.Name = "AutoDeleteBackupMenuOption";
            AutoDeleteBackupMenuOption.Size = new Size(205, 24);
            AutoDeleteBackupMenuOption.Text = "Auto Delete";
            AutoDeleteBackupMenuOption.Click += AutoDeleteBackupMenuOption_Click;
            // 
            // ChangeDirectoryMenuOption
            // 
            ChangeDirectoryMenuOption.BackColor = SystemColors.ControlDarkDark;
            ChangeDirectoryMenuOption.ForeColor = SystemColors.Control;
            ChangeDirectoryMenuOption.Name = "ChangeDirectoryMenuOption";
            ChangeDirectoryMenuOption.Size = new Size(205, 24);
            ChangeDirectoryMenuOption.Text = "Change Directory";
            ChangeDirectoryMenuOption.Click += ChangeDirectoryMenuOption_Click;
            // 
            // DataCleanerMenuOption
            // 
            DataCleanerMenuOption.BackColor = SystemColors.ControlDarkDark;
            DataCleanerMenuOption.ForeColor = SystemColors.Control;
            DataCleanerMenuOption.Name = "DataCleanerMenuOption";
            DataCleanerMenuOption.Size = new Size(205, 24);
            DataCleanerMenuOption.Text = "Data Cleaner";
            DataCleanerMenuOption.ToolTipText = "Cleanup Backup Directory\r\n>---[EXPERIMENTAL]---<\r\n\r\n(This page is for finding &\r\ndeleting unsused, broken &\r\ndeprecated backup data.)\r\n";
            DataCleanerMenuOption.Click += DataCleanerMenuOption_Click;
            // 
            // SmartBackupMenuOption
            // 
            SmartBackupMenuOption.BackColor = SystemColors.ControlDarkDark;
            SmartBackupMenuOption.ForeColor = SystemColors.Control;
            SmartBackupMenuOption.Name = "SmartBackupMenuOption";
            SmartBackupMenuOption.Size = new Size(205, 24);
            SmartBackupMenuOption.Text = "Smart Backup";
            SmartBackupMenuOption.Click += SmartBackupMenuOption_Click;
            // 
            // ZipSetupMenuOption
            // 
            ZipSetupMenuOption.BackColor = SystemColors.ControlDarkDark;
            ZipSetupMenuOption.ForeColor = SystemColors.Control;
            ZipSetupMenuOption.Name = "ZipSetupMenuOption";
            ZipSetupMenuOption.Size = new Size(205, 24);
            ZipSetupMenuOption.Text = "Zip Setup";
            ZipSetupMenuOption.Click += ZipSetupMenuOption_Click;
            // 
            // AboutToolStripMenuItem
            // 
            AboutToolStripMenuItem.BackColor = SystemColors.ControlDarkDark;
            AboutToolStripMenuItem.ForeColor = SystemColors.Control;
            AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            AboutToolStripMenuItem.Padding = new Padding(0);
            AboutToolStripMenuItem.Size = new Size(205, 22);
            AboutToolStripMenuItem.Text = "About";
            AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // EditSettingsDropDownButton
            // 
            EditSettingsDropDownButton.AccessibleRole = AccessibleRole.Cursor;
            EditSettingsDropDownButton.DropDown = EditBackupsToolbarMenu;
            EditSettingsDropDownButton.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            EditSettingsDropDownButton.Image = (Image)resources.GetObject("EditSettingsDropDownButton.Image");
            EditSettingsDropDownButton.ImageTransparentColor = Color.Magenta;
            EditSettingsDropDownButton.Margin = new Padding(0);
            EditSettingsDropDownButton.Name = "EditSettingsDropDownButton";
            EditSettingsDropDownButton.Size = new Size(82, 38);
            EditSettingsDropDownButton.Text = "Edit";
            // 
            // EditBackupsToolbarMenu
            // 
            EditBackupsToolbarMenu.AccessibleRole = AccessibleRole.Cursor;
            EditBackupsToolbarMenu.AllowClickThrough = true;
            EditBackupsToolbarMenu.BackColor = SystemColors.ControlDark;
            EditBackupsToolbarMenu.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditBackupsToolbarMenu.Items.AddRange(new ToolStripItem[] { SelectBackupsToolbarMenuOption, DeleteBackupsToolbarMenuOption, RenameBackupsToolbarMenuOption, StopMultiSelBackupsToolbarMenuOption, EditBackupsToolbarSeparator, CreateZipToolbarMenuOption });
            EditBackupsToolbarMenu.Name = "EditBackupsMenuButton";
            EditBackupsToolbarMenu.OwnerItem = EditSettingsDropDownButton;
            EditBackupsToolbarMenu.ShowImageMargin = false;
            EditBackupsToolbarMenu.Size = new Size(176, 130);
            // 
            // SelectBackupsToolbarMenuOption
            // 
            SelectBackupsToolbarMenuOption.BackColor = SystemColors.ControlDarkDark;
            SelectBackupsToolbarMenuOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SelectBackupsToolbarMenuOption.DropDownItems.AddRange(new ToolStripItem[] { SelectMultiBackupsToolbarOption, SelectAllBackupsToolbarOption });
            SelectBackupsToolbarMenuOption.ForeColor = Color.White;
            SelectBackupsToolbarMenuOption.MergeIndex = 2;
            SelectBackupsToolbarMenuOption.Name = "SelectBackupsToolbarMenuOption";
            SelectBackupsToolbarMenuOption.Overflow = ToolStripItemOverflow.AsNeeded;
            SelectBackupsToolbarMenuOption.Size = new Size(175, 24);
            SelectBackupsToolbarMenuOption.Text = "Select";
            // 
            // SelectMultiBackupsToolbarOption
            // 
            SelectMultiBackupsToolbarOption.BackColor = SystemColors.ControlDarkDark;
            SelectMultiBackupsToolbarOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SelectMultiBackupsToolbarOption.ForeColor = SystemColors.Control;
            SelectMultiBackupsToolbarOption.Name = "SelectMultiBackupsToolbarOption";
            SelectMultiBackupsToolbarOption.Size = new Size(163, 24);
            SelectMultiBackupsToolbarOption.Text = "Select Multi";
            SelectMultiBackupsToolbarOption.Click += SelectMultiOption_Click;
            // 
            // SelectAllBackupsToolbarOption
            // 
            SelectAllBackupsToolbarOption.BackColor = SystemColors.ControlDarkDark;
            SelectAllBackupsToolbarOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SelectAllBackupsToolbarOption.ForeColor = SystemColors.Control;
            SelectAllBackupsToolbarOption.Name = "SelectAllBackupsToolbarOption";
            SelectAllBackupsToolbarOption.Size = new Size(163, 24);
            SelectAllBackupsToolbarOption.Text = "Select All";
            SelectAllBackupsToolbarOption.Click += SelectAllOption_Click;
            // 
            // DeleteBackupsToolbarMenuOption
            // 
            DeleteBackupsToolbarMenuOption.BackColor = SystemColors.ControlDarkDark;
            DeleteBackupsToolbarMenuOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            DeleteBackupsToolbarMenuOption.DropDownItems.AddRange(new ToolStripItem[] { DeleteSelectedToolbarOption, DeleteZipToolbarOption, DeleteLooseToolbarOption });
            DeleteBackupsToolbarMenuOption.ForeColor = Color.White;
            DeleteBackupsToolbarMenuOption.MergeIndex = 1;
            DeleteBackupsToolbarMenuOption.Name = "DeleteBackupsToolbarMenuOption";
            DeleteBackupsToolbarMenuOption.Overflow = ToolStripItemOverflow.AsNeeded;
            DeleteBackupsToolbarMenuOption.Size = new Size(175, 24);
            DeleteBackupsToolbarMenuOption.Text = "Delete";
            DeleteBackupsToolbarMenuOption.Click += DeleteSelected_OnClick;
            // 
            // DeleteSelectedToolbarOption
            // 
            DeleteSelectedToolbarOption.AutoSize = false;
            DeleteSelectedToolbarOption.BackColor = SystemColors.ControlDarkDark;
            DeleteSelectedToolbarOption.ForeColor = SystemColors.Control;
            DeleteSelectedToolbarOption.Name = "DeleteSelectedToolbarOption";
            DeleteSelectedToolbarOption.Size = new Size(175, 25);
            DeleteSelectedToolbarOption.Text = "Delete";
            DeleteSelectedToolbarOption.Click += DeleteSelected_OnClick;
            // 
            // DeleteZipToolbarOption
            // 
            DeleteZipToolbarOption.AutoSize = false;
            DeleteZipToolbarOption.BackColor = SystemColors.ControlDarkDark;
            DeleteZipToolbarOption.ForeColor = SystemColors.Control;
            DeleteZipToolbarOption.Name = "DeleteZipToolbarOption";
            DeleteZipToolbarOption.Size = new Size(175, 25);
            DeleteZipToolbarOption.Text = "Delete Zip";
            // 
            // DeleteLooseToolbarOption
            // 
            DeleteLooseToolbarOption.AutoSize = false;
            DeleteLooseToolbarOption.BackColor = SystemColors.ControlDarkDark;
            DeleteLooseToolbarOption.ForeColor = SystemColors.Control;
            DeleteLooseToolbarOption.Name = "DeleteLooseToolbarOption";
            DeleteLooseToolbarOption.Size = new Size(175, 25);
            DeleteLooseToolbarOption.Text = "Delete Loose";
            // 
            // StopMultiSelBackupsToolbarMenuOption
            // 
            StopMultiSelBackupsToolbarMenuOption.BackColor = SystemColors.ControlDarkDark;
            StopMultiSelBackupsToolbarMenuOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            StopMultiSelBackupsToolbarMenuOption.ForeColor = SystemColors.Control;
            StopMultiSelBackupsToolbarMenuOption.MergeIndex = 3;
            StopMultiSelBackupsToolbarMenuOption.Name = "StopMultiSelBackupsToolbarMenuOption";
            StopMultiSelBackupsToolbarMenuOption.Overflow = ToolStripItemOverflow.AsNeeded;
            StopMultiSelBackupsToolbarMenuOption.Size = new Size(175, 24);
            StopMultiSelBackupsToolbarMenuOption.Text = "Stop Multi Select";
            StopMultiSelBackupsToolbarMenuOption.Visible = false;
            // 
            // EditBackupsToolbarSeparator
            // 
            EditBackupsToolbarSeparator.BackColor = SystemColors.ControlDarkDark;
            EditBackupsToolbarSeparator.ForeColor = SystemColors.ControlDarkDark;
            EditBackupsToolbarSeparator.Name = "EditBackupsToolbarSeparator";
            EditBackupsToolbarSeparator.Overflow = ToolStripItemOverflow.Never;
            EditBackupsToolbarSeparator.Size = new Size(172, 6);
            // 
            // CreateZipToolbarMenuOption
            // 
            CreateZipToolbarMenuOption.BackColor = SystemColors.ControlDarkDark;
            CreateZipToolbarMenuOption.ForeColor = SystemColors.Control;
            CreateZipToolbarMenuOption.Name = "CreateZipToolbarMenuOption";
            CreateZipToolbarMenuOption.Size = new Size(175, 24);
            CreateZipToolbarMenuOption.Text = "Create Zip";
            // 
            // ToolStripSeparator1
            // 
            ToolStripSeparator1.AutoSize = false;
            ToolStripSeparator1.BackColor = SystemColors.HighlightText;
            ToolStripSeparator1.ForeColor = SystemColors.ControlDarkDark;
            ToolStripSeparator1.MergeAction = MergeAction.MatchOnly;
            ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripSeparator1.Overflow = ToolStripItemOverflow.Never;
            ToolStripSeparator1.Size = new Size(60, 36);
            // 
            // DeleteSelectedToolStripButton
            // 
            DeleteSelectedToolStripButton.BackColor = SystemColors.Control;
            DeleteSelectedToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            DeleteSelectedToolStripButton.Enabled = false;
            DeleteSelectedToolStripButton.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteSelectedToolStripButton.Image = (Image)resources.GetObject("DeleteSelectedToolStripButton.Image");
            DeleteSelectedToolStripButton.ImageTransparentColor = Color.Magenta;
            DeleteSelectedToolStripButton.Margin = new Padding(0);
            DeleteSelectedToolStripButton.MergeIndex = 0;
            DeleteSelectedToolStripButton.Name = "DeleteSelectedToolStripButton";
            DeleteSelectedToolStripButton.Overflow = ToolStripItemOverflow.Never;
            DeleteSelectedToolStripButton.Size = new Size(36, 38);
            DeleteSelectedToolStripButton.ToolTipText = "End selecting multiple backups";
            DeleteSelectedToolStripButton.Click += DeleteSelectedToolStripButton_Click;
            // 
            // StopMultiSelectToolTipButton
            // 
            StopMultiSelectToolTipButton.BackColor = SystemColors.Control;
            StopMultiSelectToolTipButton.BackgroundImageLayout = ImageLayout.Stretch;
            StopMultiSelectToolTipButton.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StopMultiSelectToolTipButton.Image = (Image)resources.GetObject("StopMultiSelectToolTipButton.Image");
            StopMultiSelectToolTipButton.ImageTransparentColor = Color.Magenta;
            StopMultiSelectToolTipButton.Margin = new Padding(0);
            StopMultiSelectToolTipButton.MergeAction = MergeAction.Replace;
            StopMultiSelectToolTipButton.MergeIndex = 1;
            StopMultiSelectToolTipButton.Name = "StopMultiSelectToolTipButton";
            StopMultiSelectToolTipButton.Size = new Size(36, 38);
            StopMultiSelectToolTipButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            StopMultiSelectToolTipButton.ToolTipText = "End selecting multiple backups";
            StopMultiSelectToolTipButton.Visible = false;
            StopMultiSelectToolTipButton.Click += StopMultiSelectToolTipButton_Click;
            // 
            // StartMultiSelectToolTipButton
            // 
            StartMultiSelectToolTipButton.BackColor = SystemColors.Control;
            StartMultiSelectToolTipButton.BackgroundImageLayout = ImageLayout.Stretch;
            StartMultiSelectToolTipButton.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StartMultiSelectToolTipButton.Image = (Image)resources.GetObject("StartMultiSelectToolTipButton.Image");
            StartMultiSelectToolTipButton.ImageTransparentColor = Color.Magenta;
            StartMultiSelectToolTipButton.Margin = new Padding(0);
            StartMultiSelectToolTipButton.MergeAction = MergeAction.Replace;
            StartMultiSelectToolTipButton.MergeIndex = 1;
            StartMultiSelectToolTipButton.Name = "StartMultiSelectToolTipButton";
            StartMultiSelectToolTipButton.Size = new Size(36, 38);
            StartMultiSelectToolTipButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            StartMultiSelectToolTipButton.ToolTipText = "Select multiple backups at once\r\n(To delete multiple backups one after another)";
            StartMultiSelectToolTipButton.Click += StartMultiSelectToolTipButton_Click;
            // 
            // ToolStripSeparator2
            // 
            ToolStripSeparator2.AutoSize = false;
            ToolStripSeparator2.BackColor = SystemColors.HighlightText;
            ToolStripSeparator2.ForeColor = SystemColors.ControlDarkDark;
            ToolStripSeparator2.Name = "ToolStripSeparator2";
            ToolStripSeparator2.Overflow = ToolStripItemOverflow.Never;
            ToolStripSeparator2.Size = new Size(30, 36);
            // 
            // ListenToPZToolStripButton
            // 
            ListenToPZToolStripButton.Alignment = ToolStripItemAlignment.Right;
            ListenToPZToolStripButton.BackColor = SystemColors.Control;
            ListenToPZToolStripButton.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ListenToPZToolStripButton.ForeColor = SystemColors.ControlText;
            ListenToPZToolStripButton.Image = (Image)resources.GetObject("ListenToPZToolStripButton.Image");
            ListenToPZToolStripButton.ImageAlign = ContentAlignment.MiddleLeft;
            ListenToPZToolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            ListenToPZToolStripButton.ImageTransparentColor = Color.Transparent;
            ListenToPZToolStripButton.Margin = new Padding(0, 0, 5, 0);
            ListenToPZToolStripButton.MergeIndex = 0;
            ListenToPZToolStripButton.Name = "ListenToPZToolStripButton";
            ListenToPZToolStripButton.Overflow = ToolStripItemOverflow.Never;
            ListenToPZToolStripButton.Size = new Size(96, 38);
            ListenToPZToolStripButton.Text = "Connect";
            ListenToPZToolStripButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            ListenToPZToolStripButton.ToolTipText = "Connect this app with Project Zomboid\r\n(PZBackupManager mod from workshop required!)";
            ListenToPZToolStripButton.Click += ListenToPZToolStripButton_Click;
            // 
            // MainWindow
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1180, 832);
            Controls.Add(BackgroundPanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainWindow";
            Padding = new Padding(5);
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zomboid Backup Manager";
            MinimizeButtonToolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            Load += MainWindow_Load;
            SelectSavegamePanel.ResumeLayout(false);
            SelectSavegamePanel.PerformLayout();
            DatabasePresetTSPanel.ResumeLayout(false);
            DatabaseToolStrip.ResumeLayout(false);
            DatabaseToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ThumbnailPictureBox).EndInit();
            SavegameInfoPanel.ResumeLayout(false);
            BackupModeInfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)HasBaseBackupValuePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)IsDatabaseLoadedValuePictureBox).EndInit();
            BackupCountSubPanel.ResumeLayout(false);
            GamemodeAndSavegameInfoSubPanel.ResumeLayout(false);
            EditBackupsContextMenu.ResumeLayout(false);
            RenameContextMenu.ResumeLayout(false);
            RenameContextMenu.PerformLayout();
            ProgressbarPanel.ResumeLayout(false);
            ChangeBackupFolderTextbox.ResumeLayout(false);
            BackgroundPanel.ResumeLayout(false);
            SelectBackupPanel.ResumeLayout(false);
            SelectBackupPanel.PerformLayout();
            BackupRestoreTSPanel.ResumeLayout(false);
            BackupRestoreToolStrip.ResumeLayout(false);
            BackupRestoreToolStrip.PerformLayout();
            BackupInfoPanel.ResumeLayout(false);
            BackupDataInfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)HasLooseValuePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)HasZipValuePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)BackupsPictureBox).EndInit();
            SettingsPanelA.ResumeLayout(false);
            SettingsPanelA.PerformLayout();
            Toolstrip1.ResumeLayout(false);
            Toolstrip1.PerformLayout();
            GeneralSettingsContextMenuStrip.ResumeLayout(false);
            EditBackupsToolbarMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox GamemodeComboBox;
        private Label SelectSavegameLabel;
        private Panel SelectSavegamePanel;
        private Panel ChangeBackupFolderTextbox;
        private RichTextBox BackupFolderPathTextbox;
        internal Label BackupFolderLabel;
        private Panel BackgroundPanel;
        private PictureBox ThumbnailPictureBox;
        private Panel SelectBackupPanel;
        private ListBox BackupListBox;
        private PictureBox BackupsPictureBox;
        private Label SelectBackupLabel;
        private Label ProgressbarLabel;
        private Panel SettingsPanelA;
        private Label SavgameInfoTextLabel;
        private Panel SavegameInfoPanel;
        private Label SavgameInfoValueLabel;
        private Label GamemodeInfoValueLabel;
        private Label GamemodeInfoTextLabel;
        private Panel GamemodeAndSavegameInfoSubPanel;
        private Label BackupCountValueLabel;
        private Label BackupCountTextLabel;
        private Panel BackupCountSubPanel;
        private Panel ProgressbarPanel;
        private Panel BackupInfoPanel;
        private Label BackupNameValueLabel;
        private Label BackupNameTextLabel;
        private Panel BackupDataInfoPanel;
        private Label BackupIndexTextLabel;
        private Label BackupIndexValueLabel;
        private Label BackupFolderTextLabel;
        private Label BackupFolderValueLabel;
        private ToolTip MinimizeButtonToolTip;
        private ContextMenuStrip EditBackupsContextMenu;
        private ToolStripMenuItem RenameContextMenuItem;
        private ToolStripMenuItem DeleteContextMenuItem;
        private ToolStripMenuItem DeleteSelectedMenuOption;
        private ToolStripMenuItem SelectContextMenuItem;
        private ToolStripMenuItem SelectMultiMenuItem;
        private ToolStripMenuItem SelectAllMenuItem;
        private ContextMenuStrip RenameContextMenu;
        private ToolStripTextBox RenameEnterTextOption;
        private ToolStripSeparator ToolStripSeparatorB;
        private ToolStripMenuItem ConfrimRenameOption;
        private ToolStripTextBox RenameLabelTextItem;
        private ToolStripSeparator ToolStripSeparatorA;
        private ToolStripMenuItem StopMultiSelectMenuItem;
        private ToolStrip Toolstrip1;
        private ToolStripDropDownButton SettingsDropDownButton;
        private ToolStripSeparator ToolStripSeparator1;
        private ToolStripButton ListenToPZToolStripButton;
        private ToolStripDropDownButton EditSettingsDropDownButton;
        private ToolStripMenuItem GeneralSettingsMenuOption;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private ToolStripButton StopMultiSelectToolTipButton;
        private ToolStripButton StartMultiSelectToolTipButton;
        private ToolStripButton DeleteSelectedToolStripButton;
        private ToolStripSeparator ToolStripSeparator2;
        private ContextMenuStrip GeneralSettingsContextMenuStrip;
        private ToolStripMenuItem CompressZipSettingMenuOption;
        private ToolStripMenuItem AutoSelectSGSettingMenuOption;
        private ToolStripMenuItem ShowMsgSettingMenuOption;
        private ToolStripSeparator ToolStripSeparator3;
        private ToolStripMenuItem CreateZipEditBackupMenuOption;
        private ToolStripMenuItem KeepFolderSettingMenuOption;
        private Label HasZipTextLabel;
        private Label BackupSizeInfoTextLabel;
        private Label BackupSizeInfoValueLabel;
        private Label BackupDateInfoTextLabel;
        private Label BackupTimeInfoTextLabel;
        private Label BackupTimeInfoValueLabel;
        private Label BackupDateInfoValueLabel;
        private PictureBox HasZipValuePictureBox;
        private PictureBox HasLooseValuePictureBox;
        private Label HasLooseTextLabel;
        private Label AutoDeleteInfoLabel;
        private ToolStripMenuItem AutoDeleteBackupMenuOption;
        private ToolStripMenuItem ZipSetupMenuOption;
        private ToolStripMenuItem RenameBackupsToolbarMenuOption;
        private ContextMenuStrip EditBackupsToolbarMenu;
        private ToolStripMenuItem SelectBackupsToolbarMenuOption;
        private ToolStripMenuItem SelectMultiBackupsToolbarOption;
        private ToolStripMenuItem SelectAllBackupsToolbarOption;
        private ToolStripMenuItem DeleteBackupsToolbarMenuOption;
        private ToolStripMenuItem DeleteSelectedToolbarOption;
        private ToolStripMenuItem StopMultiSelBackupsToolbarMenuOption;
        private ToolStripSeparator EditBackupsToolbarSeparator;
        private ToolStripMenuItem CreateZipToolbarMenuOption;
        private ToolStripMenuItem DeleteZipToolbarOption;
        private ToolStripMenuItem DeleteLooseToolbarOption;
        private ToolStripMenuItem DeleteZipMenuOption;
        private ToolStripMenuItem DeleteLooseMenuOption;
        private ToolStripMenuItem ChangeDirectoryMenuOption;
        private Panel BackupRestoreTSPanel;
        private ToolStrip BackupRestoreToolStrip;
        private ToolStripButton RestoreButton;
        private ToolStripButton BackupButton;
        private ToolStripSeparator TSSeparator1;
        private ToolStripSeparator TSSeparator2;
        private ProgressBar ProgressBarA;
        private RadioButton HalfWindowModeRadioButton;
        private RadioButton NormalWindowModeRadioButton;
        private Label SavegameHeadlineLabel;
        private ListBox SavegameListBox;
        private ToolStripMenuItem SmartBackupMenuOption;
        private ToolStripMenuItem DataCleanerMenuOption;
        private PictureBox IsDatabaseLoadedValuePictureBox;
        private Label IsDatabaseLoadedTextLabel;
        private Panel BackupModeInfoPanel;
        private Label ActiveBackupModeValueLabel;
        private Label ActiveBackupModeTextLabel;
        private PictureBox HasBaseBackupValuePictureBox;
        private Label HasBaseBackupTextLabel;
        private Panel DatabasePresetTSPanel;
        private ToolStrip DatabaseToolStrip;
        private ToolStripSeparator TSSeparator3;
        private ToolStripSeparator TSSeparator4;
        private ToolStripButton LoadDataBaseButton;
        private ToolStripButton OpenDatabaseSetupTSButton;
    }
}
