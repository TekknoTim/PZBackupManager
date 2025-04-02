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
            ThumbnailPictureBox = new PictureBox();
            SelectGamemodeLabel = new Label();
            SavegameListBox = new ListBox();
            SavegameInfoPanel = new Panel();
            BackupCountSubPanel = new Panel();
            BackupCountValueLabel = new Label();
            BackupCountTextLabel = new Label();
            GamemodeInfoSubPanel = new Panel();
            GamemodeInfoValueLabel = new Label();
            GamemodeInfoTextLabel = new Label();
            SavegameInfoSubPanel = new Panel();
            SavgameInfoValueLabel = new Label();
            SavgameInfoTextLabel = new Label();
            SelectBackupFolderButton = new Button();
            ChangeBackupFolderTextbox = new Panel();
            ChangeBackupFolderLabel = new Label();
            OpenBackupDirectoryButton = new Button();
            BackupFolderPathTextbox = new RichTextBox();
            BackgroundPanel = new Panel();
            SelectBackupPanel = new Panel();
            BackupInfoPanel = new Panel();
            BackupMetaDataInfoPanel = new Panel();
            BackupSizeInfoTextLabel = new Label();
            BackupSizeInfoValueLabel = new Label();
            BackupDateInfoTextLabel = new Label();
            BackupTimeInfoTextLabel = new Label();
            BackupTimeInfoValueLabel = new Label();
            BackupDateInfoValueLabel = new Label();
            BackupDataInfoPanel = new Panel();
            BackupFolderTextLabel = new Label();
            BackupFolderValueLabel = new Label();
            BackupIndexTextLabel = new Label();
            BackupNameTextLabel = new Label();
            BackupIndexValueLabel = new Label();
            BackupNameValueLabel = new Label();
            SettingsPanelA = new Panel();
            Toolstrip1 = new ToolStrip();
            SettingsDropDownButton = new ToolStripDropDownButton();
            GeneralSettingsMenuOption = new ToolStripMenuItem();
            GeneralSettingsContextMenuStrip = new ContextMenuStrip(components);
            CompressZipSettingMenuOption = new ToolStripMenuItem();
            AutoSelectSGSettingMenuOption = new ToolStripMenuItem();
            ShowMsgSettingMenuOption = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            AboutInfoLabelTextBox = new ToolStripTextBox();
            AboutInfoVersionTextBox = new ToolStripTextBox();
            AboutInfoAuthorTextBox = new ToolStripTextBox();
            AboutInfoAuthorNameTextBox = new ToolStripTextBox();
            AboutInfoGithubTextBox = new ToolStripTextBox();
            AboutInfoGithubLinkTextBox = new ToolStripTextBox();
            EditSettingsDropDownButton = new ToolStripDropDownButton();
            EditBackupsContextMenu = new ContextMenuStrip(components);
            SelectContextMenuItem = new ToolStripMenuItem();
            SelectMultiMenuItem = new ToolStripMenuItem();
            SelectAllMenuItem = new ToolStripMenuItem();
            DeleteContextMenuItem = new ToolStripMenuItem();
            DeleteBackupsEditMenuItem = new ToolStripMenuItem();
            RenameContextMenuItem = new ToolStripMenuItem();
            RenameContextMenu = new ContextMenuStrip(components);
            RenameLabelTextItem = new ToolStripTextBox();
            ToolStripSeparatorA = new ToolStripSeparator();
            RenameEnterTextOption = new ToolStripTextBox();
            ToolStripSeparatorB = new ToolStripSeparator();
            ConfrimRenameOption = new ToolStripMenuItem();
            StopMultiSelectMenuItem = new ToolStripMenuItem();
            ToolStripSeparator1 = new ToolStripSeparator();
            DeleteSelectedToolStripButton = new ToolStripButton();
            StopMultiSelectToolTipButton = new ToolStripButton();
            StartMultiSelectToolTipButton = new ToolStripButton();
            ToolStripSeparator2 = new ToolStripSeparator();
            ListenToPZToolStripButton = new ToolStripButton();
            ProgressbarLabel = new Label();
            BackupButton = new Button();
            SelectBackupLabel = new Label();
            BackupsPictureBox = new PictureBox();
            BackupListBox = new ListBox();
            RestoreButton = new Button();
            ProgressbarPanel = new Panel();
            ProgressBarA = new ProgressBar();
            MinimizeButtonToolTip = new ToolTip(components);
            SelectSavegamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ThumbnailPictureBox).BeginInit();
            SavegameInfoPanel.SuspendLayout();
            BackupCountSubPanel.SuspendLayout();
            GamemodeInfoSubPanel.SuspendLayout();
            SavegameInfoSubPanel.SuspendLayout();
            ChangeBackupFolderTextbox.SuspendLayout();
            BackgroundPanel.SuspendLayout();
            SelectBackupPanel.SuspendLayout();
            BackupInfoPanel.SuspendLayout();
            BackupMetaDataInfoPanel.SuspendLayout();
            BackupDataInfoPanel.SuspendLayout();
            SettingsPanelA.SuspendLayout();
            Toolstrip1.SuspendLayout();
            GeneralSettingsContextMenuStrip.SuspendLayout();
            EditBackupsContextMenu.SuspendLayout();
            RenameContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BackupsPictureBox).BeginInit();
            ProgressbarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // GamemodeComboBox
            // 
            GamemodeComboBox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GamemodeComboBox.Location = new Point(25, 101);
            GamemodeComboBox.Name = "GamemodeComboBox";
            GamemodeComboBox.Size = new Size(516, 27);
            GamemodeComboBox.TabIndex = 0;
            GamemodeComboBox.Text = "Select Gamemode";
            GamemodeComboBox.SelectedIndexChanged += GamemodeComboBox_SelectedIndexChanged;
            // 
            // SelectSavegameLabel
            // 
            SelectSavegameLabel.BackColor = SystemColors.ControlLightLight;
            SelectSavegameLabel.BorderStyle = BorderStyle.FixedSingle;
            SelectSavegameLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SelectSavegameLabel.Location = new Point(18, 416);
            SelectSavegameLabel.Name = "SelectSavegameLabel";
            SelectSavegameLabel.Size = new Size(523, 35);
            SelectSavegameLabel.TabIndex = 1;
            SelectSavegameLabel.Text = "Select a savegame you want to backup:";
            SelectSavegameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SelectSavegamePanel
            // 
            SelectSavegamePanel.AutoSize = true;
            SelectSavegamePanel.BackColor = SystemColors.ControlLight;
            SelectSavegamePanel.BorderStyle = BorderStyle.FixedSingle;
            SelectSavegamePanel.Controls.Add(SelectSavegameLabel);
            SelectSavegamePanel.Controls.Add(ThumbnailPictureBox);
            SelectSavegamePanel.Controls.Add(SelectGamemodeLabel);
            SelectSavegamePanel.Controls.Add(GamemodeComboBox);
            SelectSavegamePanel.Controls.Add(SavegameListBox);
            SelectSavegamePanel.Controls.Add(SavegameInfoPanel);
            SelectSavegamePanel.Location = new Point(10, 10);
            SelectSavegamePanel.Margin = new Padding(10);
            SelectSavegamePanel.Name = "SelectSavegamePanel";
            SelectSavegamePanel.Size = new Size(560, 705);
            SelectSavegamePanel.TabIndex = 2;
            // 
            // ThumbnailPictureBox
            // 
            ThumbnailPictureBox.Image = Resources.ThumbnailPlaceholder;
            ThumbnailPictureBox.InitialImage = Resources.ThumbnailPlaceholder;
            ThumbnailPictureBox.Location = new Point(18, 150);
            ThumbnailPictureBox.Name = "ThumbnailPictureBox";
            ThumbnailPictureBox.Size = new Size(256, 256);
            ThumbnailPictureBox.TabIndex = 8;
            ThumbnailPictureBox.TabStop = false;
            // 
            // SelectGamemodeLabel
            // 
            SelectGamemodeLabel.BackColor = SystemColors.Control;
            SelectGamemodeLabel.BorderStyle = BorderStyle.Fixed3D;
            SelectGamemodeLabel.Dock = DockStyle.Top;
            SelectGamemodeLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SelectGamemodeLabel.Location = new Point(0, 0);
            SelectGamemodeLabel.Margin = new Padding(10, 8, 10, 8);
            SelectGamemodeLabel.Name = "SelectGamemodeLabel";
            SelectGamemodeLabel.Size = new Size(558, 77);
            SelectGamemodeLabel.TabIndex = 7;
            SelectGamemodeLabel.Text = "1. Select the gamemode of your savegame.\r\n2. Select the savegame you want to create backups for.";
            SelectGamemodeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SavegameListBox
            // 
            SavegameListBox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SavegameListBox.FormattingEnabled = true;
            SavegameListBox.Items.AddRange(new object[] { "No Savegames Found In Selected Gamemode... " });
            SavegameListBox.Location = new Point(18, 450);
            SavegameListBox.Name = "SavegameListBox";
            SavegameListBox.ScrollAlwaysVisible = true;
            SavegameListBox.Size = new Size(523, 194);
            SavegameListBox.TabIndex = 2;
            SavegameListBox.SelectedIndexChanged += SavegameListBox_SelectedIndexChanged;
            // 
            // SavegameInfoPanel
            // 
            SavegameInfoPanel.BackColor = SystemColors.ControlLightLight;
            SavegameInfoPanel.Controls.Add(BackupCountSubPanel);
            SavegameInfoPanel.Controls.Add(GamemodeInfoSubPanel);
            SavegameInfoPanel.Controls.Add(SavegameInfoSubPanel);
            SavegameInfoPanel.Location = new Point(285, 150);
            SavegameInfoPanel.Name = "SavegameInfoPanel";
            SavegameInfoPanel.Size = new Size(256, 256);
            SavegameInfoPanel.TabIndex = 12;
            // 
            // BackupCountSubPanel
            // 
            BackupCountSubPanel.BackColor = SystemColors.ControlDark;
            BackupCountSubPanel.Controls.Add(BackupCountValueLabel);
            BackupCountSubPanel.Controls.Add(BackupCountTextLabel);
            BackupCountSubPanel.Location = new Point(5, 172);
            BackupCountSubPanel.Name = "BackupCountSubPanel";
            BackupCountSubPanel.Size = new Size(246, 75);
            BackupCountSubPanel.TabIndex = 18;
            // 
            // BackupCountValueLabel
            // 
            BackupCountValueLabel.BackColor = SystemColors.Control;
            BackupCountValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupCountValueLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackupCountValueLabel.Location = new Point(23, 37);
            BackupCountValueLabel.Margin = new Padding(23, 0, 23, 8);
            BackupCountValueLabel.Name = "BackupCountValueLabel";
            BackupCountValueLabel.Size = new Size(200, 30);
            BackupCountValueLabel.TabIndex = 17;
            BackupCountValueLabel.Text = "-";
            BackupCountValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupCountTextLabel
            // 
            BackupCountTextLabel.BackColor = SystemColors.Control;
            BackupCountTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupCountTextLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackupCountTextLabel.Location = new Point(23, 8);
            BackupCountTextLabel.Margin = new Padding(23, 8, 23, 0);
            BackupCountTextLabel.Name = "BackupCountTextLabel";
            BackupCountTextLabel.Size = new Size(200, 30);
            BackupCountTextLabel.TabIndex = 16;
            BackupCountTextLabel.Text = "Backups:";
            BackupCountTextLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // GamemodeInfoSubPanel
            // 
            GamemodeInfoSubPanel.BackColor = SystemColors.ControlDark;
            GamemodeInfoSubPanel.Controls.Add(GamemodeInfoValueLabel);
            GamemodeInfoSubPanel.Controls.Add(GamemodeInfoTextLabel);
            GamemodeInfoSubPanel.Location = new Point(5, 8);
            GamemodeInfoSubPanel.Name = "GamemodeInfoSubPanel";
            GamemodeInfoSubPanel.Size = new Size(246, 75);
            GamemodeInfoSubPanel.TabIndex = 15;
            // 
            // GamemodeInfoValueLabel
            // 
            GamemodeInfoValueLabel.BackColor = SystemColors.Control;
            GamemodeInfoValueLabel.BorderStyle = BorderStyle.FixedSingle;
            GamemodeInfoValueLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GamemodeInfoValueLabel.Location = new Point(23, 37);
            GamemodeInfoValueLabel.Margin = new Padding(23, 0, 23, 8);
            GamemodeInfoValueLabel.Name = "GamemodeInfoValueLabel";
            GamemodeInfoValueLabel.Size = new Size(200, 30);
            GamemodeInfoValueLabel.TabIndex = 14;
            GamemodeInfoValueLabel.Text = "-";
            GamemodeInfoValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GamemodeInfoTextLabel
            // 
            GamemodeInfoTextLabel.BackColor = SystemColors.Control;
            GamemodeInfoTextLabel.BorderStyle = BorderStyle.FixedSingle;
            GamemodeInfoTextLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GamemodeInfoTextLabel.Location = new Point(23, 8);
            GamemodeInfoTextLabel.Margin = new Padding(23, 8, 23, 0);
            GamemodeInfoTextLabel.Name = "GamemodeInfoTextLabel";
            GamemodeInfoTextLabel.Size = new Size(200, 30);
            GamemodeInfoTextLabel.TabIndex = 13;
            GamemodeInfoTextLabel.Text = "Gamemode:";
            GamemodeInfoTextLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // SavegameInfoSubPanel
            // 
            SavegameInfoSubPanel.BackColor = SystemColors.ControlDark;
            SavegameInfoSubPanel.Controls.Add(SavgameInfoValueLabel);
            SavegameInfoSubPanel.Controls.Add(SavgameInfoTextLabel);
            SavegameInfoSubPanel.Location = new Point(5, 90);
            SavegameInfoSubPanel.Name = "SavegameInfoSubPanel";
            SavegameInfoSubPanel.Size = new Size(246, 75);
            SavegameInfoSubPanel.TabIndex = 12;
            // 
            // SavgameInfoValueLabel
            // 
            SavgameInfoValueLabel.BackColor = SystemColors.Control;
            SavgameInfoValueLabel.BorderStyle = BorderStyle.FixedSingle;
            SavgameInfoValueLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SavgameInfoValueLabel.Location = new Point(23, 37);
            SavgameInfoValueLabel.Margin = new Padding(23, 0, 23, 8);
            SavgameInfoValueLabel.Name = "SavgameInfoValueLabel";
            SavgameInfoValueLabel.Size = new Size(200, 30);
            SavgameInfoValueLabel.TabIndex = 11;
            SavgameInfoValueLabel.Text = "-";
            SavgameInfoValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SavgameInfoTextLabel
            // 
            SavgameInfoTextLabel.BackColor = SystemColors.Control;
            SavgameInfoTextLabel.BorderStyle = BorderStyle.FixedSingle;
            SavgameInfoTextLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SavgameInfoTextLabel.Location = new Point(23, 8);
            SavgameInfoTextLabel.Margin = new Padding(23, 8, 23, 0);
            SavgameInfoTextLabel.Name = "SavgameInfoTextLabel";
            SavgameInfoTextLabel.Size = new Size(200, 30);
            SavgameInfoTextLabel.TabIndex = 10;
            SavgameInfoTextLabel.Text = "Savegame:";
            SavgameInfoTextLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // SelectBackupFolderButton
            // 
            SelectBackupFolderButton.BackColor = SystemColors.Control;
            SelectBackupFolderButton.Font = new Font("Bahnschrift", 10F);
            SelectBackupFolderButton.Location = new Point(370, 60);
            SelectBackupFolderButton.Margin = new Padding(3, 3, 30, 10);
            SelectBackupFolderButton.Name = "SelectBackupFolderButton";
            SelectBackupFolderButton.Size = new Size(157, 36);
            SelectBackupFolderButton.TabIndex = 3;
            SelectBackupFolderButton.Text = "Change Directory";
            SelectBackupFolderButton.UseVisualStyleBackColor = false;
            SelectBackupFolderButton.Click += SelectBackupFolderButton_Click;
            // 
            // ChangeBackupFolderTextbox
            // 
            ChangeBackupFolderTextbox.AutoSize = true;
            ChangeBackupFolderTextbox.BackColor = SystemColors.ControlLightLight;
            ChangeBackupFolderTextbox.BorderStyle = BorderStyle.FixedSingle;
            ChangeBackupFolderTextbox.Controls.Add(ChangeBackupFolderLabel);
            ChangeBackupFolderTextbox.Controls.Add(OpenBackupDirectoryButton);
            ChangeBackupFolderTextbox.Controls.Add(BackupFolderPathTextbox);
            ChangeBackupFolderTextbox.Controls.Add(SelectBackupFolderButton);
            ChangeBackupFolderTextbox.Location = new Point(11, 713);
            ChangeBackupFolderTextbox.Margin = new Padding(10);
            ChangeBackupFolderTextbox.Name = "ChangeBackupFolderTextbox";
            ChangeBackupFolderTextbox.Size = new Size(559, 110);
            ChangeBackupFolderTextbox.TabIndex = 4;
            // 
            // ChangeBackupFolderLabel
            // 
            ChangeBackupFolderLabel.BackColor = SystemColors.Control;
            ChangeBackupFolderLabel.BorderStyle = BorderStyle.FixedSingle;
            ChangeBackupFolderLabel.Font = new Font("Bahnschrift", 10F);
            ChangeBackupFolderLabel.Location = new Point(30, 5);
            ChangeBackupFolderLabel.Margin = new Padding(30, 5, 30, 10);
            ChangeBackupFolderLabel.Name = "ChangeBackupFolderLabel";
            ChangeBackupFolderLabel.Size = new Size(497, 20);
            ChangeBackupFolderLabel.TabIndex = 6;
            ChangeBackupFolderLabel.Text = "Change Backup Folder";
            ChangeBackupFolderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // OpenBackupDirectoryButton
            // 
            OpenBackupDirectoryButton.BackColor = SystemColors.Control;
            OpenBackupDirectoryButton.Font = new Font("Bahnschrift", 10F);
            OpenBackupDirectoryButton.Location = new Point(30, 60);
            OpenBackupDirectoryButton.Margin = new Padding(30, 3, 3, 10);
            OpenBackupDirectoryButton.Name = "OpenBackupDirectoryButton";
            OpenBackupDirectoryButton.Size = new Size(157, 36);
            OpenBackupDirectoryButton.TabIndex = 5;
            OpenBackupDirectoryButton.Text = "Open Directory";
            OpenBackupDirectoryButton.UseVisualStyleBackColor = false;
            OpenBackupDirectoryButton.Click += OpenBackupDirectoryButton_Click;
            // 
            // BackupFolderPathTextbox
            // 
            BackupFolderPathTextbox.BackColor = SystemColors.Control;
            BackupFolderPathTextbox.DetectUrls = false;
            BackupFolderPathTextbox.EnableAutoDragDrop = true;
            BackupFolderPathTextbox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackupFolderPathTextbox.Location = new Point(30, 30);
            BackupFolderPathTextbox.Margin = new Padding(30, 3, 30, 3);
            BackupFolderPathTextbox.Multiline = false;
            BackupFolderPathTextbox.Name = "BackupFolderPathTextbox";
            BackupFolderPathTextbox.ScrollBars = RichTextBoxScrollBars.Horizontal;
            BackupFolderPathTextbox.Size = new Size(497, 27);
            BackupFolderPathTextbox.TabIndex = 4;
            BackupFolderPathTextbox.TabStop = false;
            BackupFolderPathTextbox.Text = "";
            // 
            // BackgroundPanel
            // 
            BackgroundPanel.AutoSize = true;
            BackgroundPanel.BackColor = SystemColors.ControlDark;
            BackgroundPanel.Controls.Add(SelectBackupPanel);
            BackgroundPanel.Controls.Add(ChangeBackupFolderTextbox);
            BackgroundPanel.Controls.Add(SelectSavegamePanel);
            BackgroundPanel.Location = new Point(9, 9);
            BackgroundPanel.Margin = new Padding(15, 0, 15, 0);
            BackgroundPanel.Name = "BackgroundPanel";
            BackgroundPanel.Size = new Size(1158, 834);
            BackgroundPanel.TabIndex = 5;
            // 
            // SelectBackupPanel
            // 
            SelectBackupPanel.AutoSize = true;
            SelectBackupPanel.BackColor = SystemColors.ControlLight;
            SelectBackupPanel.Controls.Add(BackupInfoPanel);
            SelectBackupPanel.Controls.Add(SettingsPanelA);
            SelectBackupPanel.Controls.Add(ProgressbarLabel);
            SelectBackupPanel.Controls.Add(BackupButton);
            SelectBackupPanel.Controls.Add(SelectBackupLabel);
            SelectBackupPanel.Controls.Add(BackupsPictureBox);
            SelectBackupPanel.Controls.Add(BackupListBox);
            SelectBackupPanel.Controls.Add(RestoreButton);
            SelectBackupPanel.Controls.Add(ProgressbarPanel);
            SelectBackupPanel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SelectBackupPanel.Location = new Point(583, 11);
            SelectBackupPanel.Margin = new Padding(10);
            SelectBackupPanel.Name = "SelectBackupPanel";
            SelectBackupPanel.Size = new Size(560, 812);
            SelectBackupPanel.TabIndex = 5;
            // 
            // BackupInfoPanel
            // 
            BackupInfoPanel.BackColor = SystemColors.ControlText;
            BackupInfoPanel.Controls.Add(BackupMetaDataInfoPanel);
            BackupInfoPanel.Controls.Add(BackupDataInfoPanel);
            BackupInfoPanel.Location = new Point(289, 150);
            BackupInfoPanel.Name = "BackupInfoPanel";
            BackupInfoPanel.Size = new Size(256, 256);
            BackupInfoPanel.TabIndex = 19;
            // 
            // BackupMetaDataInfoPanel
            // 
            BackupMetaDataInfoPanel.BackColor = SystemColors.ControlDarkDark;
            BackupMetaDataInfoPanel.Controls.Add(BackupSizeInfoTextLabel);
            BackupMetaDataInfoPanel.Controls.Add(BackupSizeInfoValueLabel);
            BackupMetaDataInfoPanel.Controls.Add(BackupDateInfoTextLabel);
            BackupMetaDataInfoPanel.Controls.Add(BackupTimeInfoTextLabel);
            BackupMetaDataInfoPanel.Controls.Add(BackupTimeInfoValueLabel);
            BackupMetaDataInfoPanel.Controls.Add(BackupDateInfoValueLabel);
            BackupMetaDataInfoPanel.Location = new Point(5, 134);
            BackupMetaDataInfoPanel.Name = "BackupMetaDataInfoPanel";
            BackupMetaDataInfoPanel.Size = new Size(246, 113);
            BackupMetaDataInfoPanel.TabIndex = 20;
            // 
            // BackupSizeInfoTextLabel
            // 
            BackupSizeInfoTextLabel.BackColor = SystemColors.Control;
            BackupSizeInfoTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupSizeInfoTextLabel.Font = new Font("Bahnschrift", 10F);
            BackupSizeInfoTextLabel.Location = new Point(5, 75);
            BackupSizeInfoTextLabel.Name = "BackupSizeInfoTextLabel";
            BackupSizeInfoTextLabel.Size = new Size(69, 30);
            BackupSizeInfoTextLabel.TabIndex = 20;
            BackupSizeInfoTextLabel.Text = "Size:";
            BackupSizeInfoTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupSizeInfoValueLabel
            // 
            BackupSizeInfoValueLabel.BackColor = SystemColors.Control;
            BackupSizeInfoValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupSizeInfoValueLabel.Font = new Font("Bahnschrift", 10F);
            BackupSizeInfoValueLabel.Location = new Point(73, 75);
            BackupSizeInfoValueLabel.Margin = new Padding(5, 0, 5, 0);
            BackupSizeInfoValueLabel.Name = "BackupSizeInfoValueLabel";
            BackupSizeInfoValueLabel.Size = new Size(170, 30);
            BackupSizeInfoValueLabel.TabIndex = 21;
            BackupSizeInfoValueLabel.Text = "-";
            BackupSizeInfoValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupDateInfoTextLabel
            // 
            BackupDateInfoTextLabel.BackColor = SystemColors.Control;
            BackupDateInfoTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupDateInfoTextLabel.Font = new Font("Bahnschrift", 10F);
            BackupDateInfoTextLabel.Location = new Point(5, 5);
            BackupDateInfoTextLabel.Name = "BackupDateInfoTextLabel";
            BackupDateInfoTextLabel.Size = new Size(69, 30);
            BackupDateInfoTextLabel.TabIndex = 19;
            BackupDateInfoTextLabel.Text = "Date:";
            BackupDateInfoTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupTimeInfoTextLabel
            // 
            BackupTimeInfoTextLabel.BackColor = SystemColors.Control;
            BackupTimeInfoTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupTimeInfoTextLabel.Font = new Font("Bahnschrift", 10F);
            BackupTimeInfoTextLabel.Location = new Point(5, 40);
            BackupTimeInfoTextLabel.Name = "BackupTimeInfoTextLabel";
            BackupTimeInfoTextLabel.Size = new Size(69, 30);
            BackupTimeInfoTextLabel.TabIndex = 12;
            BackupTimeInfoTextLabel.Text = "Time:";
            BackupTimeInfoTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupTimeInfoValueLabel
            // 
            BackupTimeInfoValueLabel.BackColor = SystemColors.Control;
            BackupTimeInfoValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupTimeInfoValueLabel.Font = new Font("Bahnschrift", 10F);
            BackupTimeInfoValueLabel.Location = new Point(73, 40);
            BackupTimeInfoValueLabel.Margin = new Padding(5, 0, 5, 0);
            BackupTimeInfoValueLabel.Name = "BackupTimeInfoValueLabel";
            BackupTimeInfoValueLabel.Size = new Size(170, 30);
            BackupTimeInfoValueLabel.TabIndex = 13;
            BackupTimeInfoValueLabel.Text = "-";
            BackupTimeInfoValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupDateInfoValueLabel
            // 
            BackupDateInfoValueLabel.BackColor = SystemColors.Control;
            BackupDateInfoValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupDateInfoValueLabel.Font = new Font("Bahnschrift", 10F);
            BackupDateInfoValueLabel.Location = new Point(73, 5);
            BackupDateInfoValueLabel.Margin = new Padding(5, 0, 5, 0);
            BackupDateInfoValueLabel.Name = "BackupDateInfoValueLabel";
            BackupDateInfoValueLabel.Size = new Size(170, 30);
            BackupDateInfoValueLabel.TabIndex = 11;
            BackupDateInfoValueLabel.Text = "-";
            BackupDateInfoValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupDataInfoPanel
            // 
            BackupDataInfoPanel.BackColor = SystemColors.ControlDarkDark;
            BackupDataInfoPanel.Controls.Add(BackupFolderTextLabel);
            BackupDataInfoPanel.Controls.Add(BackupFolderValueLabel);
            BackupDataInfoPanel.Controls.Add(BackupIndexTextLabel);
            BackupDataInfoPanel.Controls.Add(BackupNameTextLabel);
            BackupDataInfoPanel.Controls.Add(BackupIndexValueLabel);
            BackupDataInfoPanel.Controls.Add(BackupNameValueLabel);
            BackupDataInfoPanel.Location = new Point(5, 12);
            BackupDataInfoPanel.Name = "BackupDataInfoPanel";
            BackupDataInfoPanel.Size = new Size(246, 113);
            BackupDataInfoPanel.TabIndex = 12;
            // 
            // BackupFolderTextLabel
            // 
            BackupFolderTextLabel.BackColor = SystemColors.Control;
            BackupFolderTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupFolderTextLabel.Font = new Font("Bahnschrift", 10F);
            BackupFolderTextLabel.Location = new Point(5, 75);
            BackupFolderTextLabel.Name = "BackupFolderTextLabel";
            BackupFolderTextLabel.Size = new Size(69, 30);
            BackupFolderTextLabel.TabIndex = 14;
            BackupFolderTextLabel.Text = "Folder:";
            BackupFolderTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupFolderValueLabel
            // 
            BackupFolderValueLabel.BackColor = SystemColors.Control;
            BackupFolderValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupFolderValueLabel.Font = new Font("Bahnschrift", 10F);
            BackupFolderValueLabel.Location = new Point(73, 75);
            BackupFolderValueLabel.Name = "BackupFolderValueLabel";
            BackupFolderValueLabel.Size = new Size(170, 30);
            BackupFolderValueLabel.TabIndex = 15;
            BackupFolderValueLabel.Text = "-";
            BackupFolderValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupIndexTextLabel
            // 
            BackupIndexTextLabel.BackColor = SystemColors.Control;
            BackupIndexTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupIndexTextLabel.Font = new Font("Bahnschrift", 10F);
            BackupIndexTextLabel.Location = new Point(5, 40);
            BackupIndexTextLabel.Name = "BackupIndexTextLabel";
            BackupIndexTextLabel.Size = new Size(69, 30);
            BackupIndexTextLabel.TabIndex = 12;
            BackupIndexTextLabel.Text = "Index";
            BackupIndexTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupNameTextLabel
            // 
            BackupNameTextLabel.BackColor = SystemColors.Control;
            BackupNameTextLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupNameTextLabel.Font = new Font("Bahnschrift", 10F);
            BackupNameTextLabel.Location = new Point(5, 5);
            BackupNameTextLabel.Name = "BackupNameTextLabel";
            BackupNameTextLabel.Size = new Size(69, 30);
            BackupNameTextLabel.TabIndex = 10;
            BackupNameTextLabel.Text = "Backup:";
            BackupNameTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupIndexValueLabel
            // 
            BackupIndexValueLabel.BackColor = SystemColors.Control;
            BackupIndexValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupIndexValueLabel.Font = new Font("Bahnschrift", 10F);
            BackupIndexValueLabel.Location = new Point(73, 40);
            BackupIndexValueLabel.Name = "BackupIndexValueLabel";
            BackupIndexValueLabel.Size = new Size(170, 30);
            BackupIndexValueLabel.TabIndex = 13;
            BackupIndexValueLabel.Text = "-";
            BackupIndexValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupNameValueLabel
            // 
            BackupNameValueLabel.BackColor = SystemColors.Control;
            BackupNameValueLabel.BorderStyle = BorderStyle.FixedSingle;
            BackupNameValueLabel.Font = new Font("Bahnschrift", 10F);
            BackupNameValueLabel.Location = new Point(73, 5);
            BackupNameValueLabel.Name = "BackupNameValueLabel";
            BackupNameValueLabel.Size = new Size(170, 30);
            BackupNameValueLabel.TabIndex = 11;
            BackupNameValueLabel.Text = "-";
            BackupNameValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SettingsPanelA
            // 
            SettingsPanelA.BackColor = SystemColors.ControlDark;
            SettingsPanelA.BorderStyle = BorderStyle.Fixed3D;
            SettingsPanelA.Controls.Add(Toolstrip1);
            SettingsPanelA.Dock = DockStyle.Top;
            SettingsPanelA.Location = new Point(0, 0);
            SettingsPanelA.Name = "SettingsPanelA";
            SettingsPanelA.Size = new Size(560, 42);
            SettingsPanelA.TabIndex = 9;
            // 
            // Toolstrip1
            // 
            Toolstrip1.BackColor = SystemColors.MenuBar;
            Toolstrip1.Dock = DockStyle.Fill;
            Toolstrip1.Font = new Font("Bahnschrift", 12F);
            Toolstrip1.GripMargin = new Padding(0);
            Toolstrip1.GripStyle = ToolStripGripStyle.Hidden;
            Toolstrip1.ImageScalingSize = new Size(32, 32);
            Toolstrip1.Items.AddRange(new ToolStripItem[] { SettingsDropDownButton, EditSettingsDropDownButton, ToolStripSeparator1, DeleteSelectedToolStripButton, StopMultiSelectToolTipButton, StartMultiSelectToolTipButton, ToolStripSeparator2, ListenToPZToolStripButton });
            Toolstrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            Toolstrip1.Location = new Point(0, 0);
            Toolstrip1.Name = "Toolstrip1";
            Toolstrip1.Padding = new Padding(0);
            Toolstrip1.Size = new Size(556, 38);
            Toolstrip1.Stretch = true;
            Toolstrip1.TabIndex = 12;
            // 
            // SettingsDropDownButton
            // 
            SettingsDropDownButton.BackColor = SystemColors.ButtonFace;
            SettingsDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { GeneralSettingsMenuOption, aboutToolStripMenuItem });
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
            GeneralSettingsMenuOption.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GeneralSettingsMenuOption.ForeColor = SystemColors.Info;
            GeneralSettingsMenuOption.Name = "GeneralSettingsMenuOption";
            GeneralSettingsMenuOption.Size = new Size(180, 24);
            GeneralSettingsMenuOption.Text = "General";
            // 
            // GeneralSettingsContextMenuStrip
            // 
            GeneralSettingsContextMenuStrip.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GeneralSettingsContextMenuStrip.Items.AddRange(new ToolStripItem[] { CompressZipSettingMenuOption, AutoSelectSGSettingMenuOption, ShowMsgSettingMenuOption });
            GeneralSettingsContextMenuStrip.Name = "GeneralSettingsContextMenuStrip";
            GeneralSettingsContextMenuStrip.OwnerItem = GeneralSettingsMenuOption;
            GeneralSettingsContextMenuStrip.RightToLeft = RightToLeft.Yes;
            GeneralSettingsContextMenuStrip.ShowCheckMargin = true;
            GeneralSettingsContextMenuStrip.ShowImageMargin = false;
            GeneralSettingsContextMenuStrip.Size = new Size(320, 76);
            // 
            // CompressZipSettingMenuOption
            // 
            CompressZipSettingMenuOption.BackColor = SystemColors.ControlDarkDark;
            CompressZipSettingMenuOption.CheckOnClick = true;
            CompressZipSettingMenuOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            CompressZipSettingMenuOption.Font = new Font("Bahnschrift", 12F);
            CompressZipSettingMenuOption.ForeColor = SystemColors.Info;
            CompressZipSettingMenuOption.Name = "CompressZipSettingMenuOption";
            CompressZipSettingMenuOption.Size = new Size(319, 24);
            CompressZipSettingMenuOption.Text = "Save backups as .zip file";
            CompressZipSettingMenuOption.CheckedChanged += CompressZipSettingMenuOption_CheckedChanged;
            CompressZipSettingMenuOption.Click += CompressZipSettingMenuOption_Click;
            // 
            // AutoSelectSGSettingMenuOption
            // 
            AutoSelectSGSettingMenuOption.BackColor = SystemColors.ControlDarkDark;
            AutoSelectSGSettingMenuOption.CheckOnClick = true;
            AutoSelectSGSettingMenuOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            AutoSelectSGSettingMenuOption.Font = new Font("Bahnschrift", 12F);
            AutoSelectSGSettingMenuOption.ForeColor = SystemColors.Info;
            AutoSelectSGSettingMenuOption.Name = "AutoSelectSGSettingMenuOption";
            AutoSelectSGSettingMenuOption.Size = new Size(319, 24);
            AutoSelectSGSettingMenuOption.Text = "Auto select last loaded state";
            AutoSelectSGSettingMenuOption.CheckedChanged += AutoSelectSGSettingMenuOption_CheckedChanged;
            AutoSelectSGSettingMenuOption.Click += AutoSelectSGSettingMenuOption_Click;
            // 
            // ShowMsgSettingMenuOption
            // 
            ShowMsgSettingMenuOption.BackColor = SystemColors.ControlDarkDark;
            ShowMsgSettingMenuOption.CheckOnClick = true;
            ShowMsgSettingMenuOption.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ShowMsgSettingMenuOption.Font = new Font("Bahnschrift", 12F);
            ShowMsgSettingMenuOption.ForeColor = SystemColors.Info;
            ShowMsgSettingMenuOption.Name = "ShowMsgSettingMenuOption";
            ShowMsgSettingMenuOption.Size = new Size(319, 24);
            ShowMsgSettingMenuOption.Text = "Show message when action done";
            ShowMsgSettingMenuOption.CheckedChanged += ShowMsgSettingMenuOption_CheckedChanged;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.BackColor = SystemColors.ControlDarkDark;
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AboutInfoLabelTextBox, AboutInfoVersionTextBox, AboutInfoAuthorTextBox, AboutInfoAuthorNameTextBox, AboutInfoGithubTextBox, AboutInfoGithubLinkTextBox });
            aboutToolStripMenuItem.ForeColor = SystemColors.Info;
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Padding = new Padding(0);
            aboutToolStripMenuItem.Size = new Size(180, 22);
            aboutToolStripMenuItem.Text = "About";
            // 
            // AboutInfoLabelTextBox
            // 
            AboutInfoLabelTextBox.AutoSize = false;
            AboutInfoLabelTextBox.BackColor = SystemColors.ControlLightLight;
            AboutInfoLabelTextBox.BorderStyle = BorderStyle.FixedSingle;
            AboutInfoLabelTextBox.Font = new Font("Bahnschrift", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            AboutInfoLabelTextBox.ForeColor = SystemColors.ControlText;
            AboutInfoLabelTextBox.Margin = new Padding(5);
            AboutInfoLabelTextBox.Name = "AboutInfoLabelTextBox";
            AboutInfoLabelTextBox.ReadOnly = true;
            AboutInfoLabelTextBox.Size = new Size(350, 27);
            AboutInfoLabelTextBox.Text = "About:";
            AboutInfoLabelTextBox.TextBoxTextAlign = HorizontalAlignment.Center;
            // 
            // AboutInfoVersionTextBox
            // 
            AboutInfoVersionTextBox.AutoSize = false;
            AboutInfoVersionTextBox.BackColor = Color.White;
            AboutInfoVersionTextBox.BorderStyle = BorderStyle.FixedSingle;
            AboutInfoVersionTextBox.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AboutInfoVersionTextBox.ForeColor = Color.Black;
            AboutInfoVersionTextBox.Margin = new Padding(5);
            AboutInfoVersionTextBox.Name = "AboutInfoVersionTextBox";
            AboutInfoVersionTextBox.Overflow = ToolStripItemOverflow.Never;
            AboutInfoVersionTextBox.ReadOnly = true;
            AboutInfoVersionTextBox.Size = new Size(350, 23);
            AboutInfoVersionTextBox.TextBoxTextAlign = HorizontalAlignment.Center;
            // 
            // AboutInfoAuthorTextBox
            // 
            AboutInfoAuthorTextBox.AutoSize = false;
            AboutInfoAuthorTextBox.BackColor = Color.White;
            AboutInfoAuthorTextBox.BorderStyle = BorderStyle.None;
            AboutInfoAuthorTextBox.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            AboutInfoAuthorTextBox.ForeColor = Color.Black;
            AboutInfoAuthorTextBox.Margin = new Padding(5);
            AboutInfoAuthorTextBox.Name = "AboutInfoAuthorTextBox";
            AboutInfoAuthorTextBox.Overflow = ToolStripItemOverflow.Never;
            AboutInfoAuthorTextBox.ReadOnly = true;
            AboutInfoAuthorTextBox.Size = new Size(350, 30);
            AboutInfoAuthorTextBox.Text = "Author:";
            AboutInfoAuthorTextBox.TextBoxTextAlign = HorizontalAlignment.Center;
            // 
            // AboutInfoAuthorNameTextBox
            // 
            AboutInfoAuthorNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            AboutInfoAuthorNameTextBox.Font = new Font("Bahnschrift", 10F);
            AboutInfoAuthorNameTextBox.Margin = new Padding(5);
            AboutInfoAuthorNameTextBox.Name = "AboutInfoAuthorNameTextBox";
            AboutInfoAuthorNameTextBox.Size = new Size(350, 24);
            AboutInfoAuthorNameTextBox.Text = "TekknoTim";
            AboutInfoAuthorNameTextBox.TextBoxTextAlign = HorizontalAlignment.Center;
            // 
            // AboutInfoGithubTextBox
            // 
            AboutInfoGithubTextBox.AutoSize = false;
            AboutInfoGithubTextBox.BackColor = Color.White;
            AboutInfoGithubTextBox.BorderStyle = BorderStyle.None;
            AboutInfoGithubTextBox.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            AboutInfoGithubTextBox.ForeColor = Color.Black;
            AboutInfoGithubTextBox.Margin = new Padding(5);
            AboutInfoGithubTextBox.Name = "AboutInfoGithubTextBox";
            AboutInfoGithubTextBox.Overflow = ToolStripItemOverflow.Never;
            AboutInfoGithubTextBox.ReadOnly = true;
            AboutInfoGithubTextBox.Size = new Size(350, 30);
            AboutInfoGithubTextBox.Text = "GitHub:";
            AboutInfoGithubTextBox.TextBoxTextAlign = HorizontalAlignment.Center;
            // 
            // AboutInfoGithubLinkTextBox
            // 
            AboutInfoGithubLinkTextBox.AutoSize = false;
            AboutInfoGithubLinkTextBox.BackColor = Color.White;
            AboutInfoGithubLinkTextBox.BorderStyle = BorderStyle.FixedSingle;
            AboutInfoGithubLinkTextBox.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AboutInfoGithubLinkTextBox.ForeColor = Color.Black;
            AboutInfoGithubLinkTextBox.Margin = new Padding(5);
            AboutInfoGithubLinkTextBox.Name = "AboutInfoGithubLinkTextBox";
            AboutInfoGithubLinkTextBox.Overflow = ToolStripItemOverflow.Never;
            AboutInfoGithubLinkTextBox.ReadOnly = true;
            AboutInfoGithubLinkTextBox.Size = new Size(350, 23);
            AboutInfoGithubLinkTextBox.Text = "https://github.com/TekknoTim/PZBackupManager";
            AboutInfoGithubLinkTextBox.TextBoxTextAlign = HorizontalAlignment.Center;
            // 
            // EditSettingsDropDownButton
            // 
            EditSettingsDropDownButton.DropDown = EditBackupsContextMenu;
            EditSettingsDropDownButton.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            EditSettingsDropDownButton.Image = (Image)resources.GetObject("EditSettingsDropDownButton.Image");
            EditSettingsDropDownButton.ImageTransparentColor = Color.Magenta;
            EditSettingsDropDownButton.Margin = new Padding(0);
            EditSettingsDropDownButton.Name = "EditSettingsDropDownButton";
            EditSettingsDropDownButton.Size = new Size(82, 38);
            EditSettingsDropDownButton.Text = "Edit";
            // 
            // EditBackupsContextMenu
            // 
            EditBackupsContextMenu.BackColor = SystemColors.ControlLight;
            EditBackupsContextMenu.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditBackupsContextMenu.Items.AddRange(new ToolStripItem[] { SelectContextMenuItem, DeleteContextMenuItem, RenameContextMenuItem, StopMultiSelectMenuItem });
            EditBackupsContextMenu.Name = "EditBackupsMenuButton";
            EditBackupsContextMenu.ShowImageMargin = false;
            EditBackupsContextMenu.Size = new Size(176, 100);
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
            DeleteContextMenuItem.DropDownItems.AddRange(new ToolStripItem[] { DeleteBackupsEditMenuItem });
            DeleteContextMenuItem.ForeColor = Color.White;
            DeleteContextMenuItem.MergeIndex = 1;
            DeleteContextMenuItem.Name = "DeleteContextMenuItem";
            DeleteContextMenuItem.Overflow = ToolStripItemOverflow.AsNeeded;
            DeleteContextMenuItem.Size = new Size(175, 24);
            DeleteContextMenuItem.Text = "Delete";
            // 
            // DeleteBackupsEditMenuItem
            // 
            DeleteBackupsEditMenuItem.AutoSize = false;
            DeleteBackupsEditMenuItem.BackColor = SystemColors.ControlDarkDark;
            DeleteBackupsEditMenuItem.ForeColor = SystemColors.Control;
            DeleteBackupsEditMenuItem.Name = "DeleteBackupsEditMenuItem";
            DeleteBackupsEditMenuItem.Size = new Size(175, 25);
            DeleteBackupsEditMenuItem.Text = "Delete";
            DeleteBackupsEditMenuItem.Click += DeleteSelected_OnClick;
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
            // ToolStripSeparator1
            // 
            ToolStripSeparator1.AutoSize = false;
            ToolStripSeparator1.BackColor = SystemColors.HighlightText;
            ToolStripSeparator1.ForeColor = SystemColors.ControlDarkDark;
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
            StartMultiSelectToolTipButton.ToolTipText = "End selecting multiple backups";
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
            ListenToPZToolStripButton.Image = Resources.RadiowaveIconImage;
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
            ListenToPZToolStripButton.Click += ListenToPZToolStripButton_Click;
            // 
            // ProgressbarLabel
            // 
            ProgressbarLabel.BackColor = SystemColors.Control;
            ProgressbarLabel.BorderStyle = BorderStyle.Fixed3D;
            ProgressbarLabel.Font = new Font("Bahnschrift", 10F);
            ProgressbarLabel.Location = new Point(15, 760);
            ProgressbarLabel.Name = "ProgressbarLabel";
            ProgressbarLabel.Size = new Size(250, 25);
            ProgressbarLabel.TabIndex = 7;
            ProgressbarLabel.Text = "-";
            ProgressbarLabel.TextAlign = ContentAlignment.MiddleCenter;
            ProgressbarLabel.Visible = false;
            // 
            // BackupButton
            // 
            BackupButton.BackColor = SystemColors.Control;
            BackupButton.Enabled = false;
            BackupButton.Location = new Point(405, 656);
            BackupButton.Name = "BackupButton";
            BackupButton.Size = new Size(140, 35);
            BackupButton.TabIndex = 5;
            BackupButton.Text = "Backup";
            BackupButton.UseVisualStyleBackColor = false;
            BackupButton.Click += BackupButton_Click;
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
            BackupsPictureBox.Image = Resources.ThumbnailPlaceholder;
            BackupsPictureBox.Location = new Point(15, 150);
            BackupsPictureBox.Margin = new Padding(129, 3, 3, 3);
            BackupsPictureBox.Name = "BackupsPictureBox";
            BackupsPictureBox.Size = new Size(256, 256);
            BackupsPictureBox.TabIndex = 3;
            BackupsPictureBox.TabStop = false;
            // 
            // BackupListBox
            // 
            BackupListBox.ContextMenuStrip = EditBackupsContextMenu;
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
            // 
            // RestoreButton
            // 
            RestoreButton.BackColor = SystemColors.Control;
            RestoreButton.Enabled = false;
            RestoreButton.Location = new Point(15, 656);
            RestoreButton.Name = "RestoreButton";
            RestoreButton.Size = new Size(140, 35);
            RestoreButton.TabIndex = 0;
            RestoreButton.Text = "Restore";
            RestoreButton.UseVisualStyleBackColor = false;
            RestoreButton.Click += RestoreButton_Click;
            // 
            // ProgressbarPanel
            // 
            ProgressbarPanel.BackColor = SystemColors.ControlLightLight;
            ProgressbarPanel.BorderStyle = BorderStyle.FixedSingle;
            ProgressbarPanel.Controls.Add(ProgressBarA);
            ProgressbarPanel.Dock = DockStyle.Bottom;
            ProgressbarPanel.Location = new Point(0, 702);
            ProgressbarPanel.Name = "ProgressbarPanel";
            ProgressbarPanel.Size = new Size(560, 110);
            ProgressbarPanel.TabIndex = 10;
            ProgressbarPanel.Visible = false;
            // 
            // ProgressBarA
            // 
            ProgressBarA.BackColor = SystemColors.Control;
            ProgressBarA.Location = new Point(15, 22);
            ProgressBarA.MarqueeAnimationSpeed = 5;
            ProgressBarA.Name = "ProgressBarA";
            ProgressBarA.Size = new Size(530, 36);
            ProgressBarA.Step = 15;
            ProgressBarA.Style = ProgressBarStyle.Continuous;
            ProgressBarA.TabIndex = 6;
            ProgressBarA.Visible = false;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1180, 850);
            Controls.Add(BackgroundPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zomboid Backup Manager";
            Load += MainWindow_Load;
            SelectSavegamePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ThumbnailPictureBox).EndInit();
            SavegameInfoPanel.ResumeLayout(false);
            BackupCountSubPanel.ResumeLayout(false);
            GamemodeInfoSubPanel.ResumeLayout(false);
            SavegameInfoSubPanel.ResumeLayout(false);
            ChangeBackupFolderTextbox.ResumeLayout(false);
            BackgroundPanel.ResumeLayout(false);
            BackgroundPanel.PerformLayout();
            SelectBackupPanel.ResumeLayout(false);
            BackupInfoPanel.ResumeLayout(false);
            BackupMetaDataInfoPanel.ResumeLayout(false);
            BackupDataInfoPanel.ResumeLayout(false);
            SettingsPanelA.ResumeLayout(false);
            SettingsPanelA.PerformLayout();
            Toolstrip1.ResumeLayout(false);
            Toolstrip1.PerformLayout();
            GeneralSettingsContextMenuStrip.ResumeLayout(false);
            EditBackupsContextMenu.ResumeLayout(false);
            RenameContextMenu.ResumeLayout(false);
            RenameContextMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BackupsPictureBox).EndInit();
            ProgressbarPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox GamemodeComboBox;
        private Label SelectSavegameLabel;
        private Panel SelectSavegamePanel;
        private ListBox SavegameListBox;
        private Panel ChangeBackupFolderTextbox;
        private RichTextBox BackupFolderPathTextbox;
        internal Label ChangeBackupFolderLabel;
        internal Button SelectBackupFolderButton;
        internal Button OpenBackupDirectoryButton;
        internal Label SelectGamemodeLabel;
        private Panel BackgroundPanel;
        private PictureBox ThumbnailPictureBox;
        private Panel SelectBackupPanel;
        private Button RestoreButton;
        private ListBox BackupListBox;
        private PictureBox BackupsPictureBox;
        private Label SelectBackupLabel;
        private Button BackupButton;
        private Label ProgressbarLabel;
        private ProgressBar ProgressBarA;
        private Panel SettingsPanelA;
        private Label SavgameInfoTextLabel;
        private Panel SavegameInfoPanel;
        private Label SavgameInfoValueLabel;
        private Panel SavegameInfoSubPanel;
        private Label GamemodeInfoValueLabel;
        private Label GamemodeInfoTextLabel;
        private Panel GamemodeInfoSubPanel;
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
        private Panel BackupMetaDataInfoPanel;
        private Label BackupDateInfoTextLabel;
        private Label BackupTimeInfoTextLabel;
        private Label BackupTimeInfoValueLabel;
        private Label BackupDateInfoValueLabel;
        private Label BackupSizeInfoTextLabel;
        private Label BackupSizeInfoValueLabel;
        private Label BackupFolderTextLabel;
        private Label BackupFolderValueLabel;
        private ToolTip MinimizeButtonToolTip;
        private ContextMenuStrip EditBackupsContextMenu;
        private ToolStripMenuItem RenameContextMenuItem;
        private ToolStripMenuItem DeleteContextMenuItem;
        private ToolStripMenuItem DeleteBackupsEditMenuItem;
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
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripTextBox AboutInfoLabelTextBox;
        private ToolStripTextBox AboutInfoVersionTextBox;
        private ToolStripTextBox AboutInfoAuthorTextBox;
        private ToolStripTextBox AboutInfoGithubTextBox;
        private ToolStripTextBox AboutInfoGithubLinkTextBox;
        private ToolStripTextBox AboutInfoAuthorNameTextBox;
        private ToolStripButton StopMultiSelectToolTipButton;
        private ToolStripButton StartMultiSelectToolTipButton;
        private ToolStripButton DeleteSelectedToolStripButton;
        private ToolStripSeparator ToolStripSeparator2;
        private ContextMenuStrip GeneralSettingsContextMenuStrip;
        private ToolStripMenuItem CompressZipSettingMenuOption;
        private ToolStripMenuItem AutoSelectSGSettingMenuOption;
        private ToolStripMenuItem ShowMsgSettingMenuOption;
    }
}
