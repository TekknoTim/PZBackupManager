using System.Resources;
using ZomboidBackupManager.Properties;

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
            StartHookButton = new Button();
            SettingsPanelB = new Panel();
            LoadSavegameOnLoadCheckbox = new CheckBox();
            ShowMessageBoxBackupCheckbox = new CheckBox();
            ProgressbarLabel = new Label();
            BackupButton = new Button();
            SelectBackupLabel = new Label();
            BackupsPictureBox = new PictureBox();
            BackupListBox = new ListBox();
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
            SettingsPanelB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BackupsPictureBox).BeginInit();
            EditBackupsContextMenu.SuspendLayout();
            RenameContextMenu.SuspendLayout();
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
            ThumbnailPictureBox.Click += ThumbnailPictureBox_Click;
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
            BackgroundPanel.Paint += BackgroundPanel_Paint;
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
            SettingsPanelA.BackColor = SystemColors.Control;
            SettingsPanelA.Controls.Add(StartHookButton);
            SettingsPanelA.Controls.Add(SettingsPanelB);
            SettingsPanelA.Dock = DockStyle.Top;
            SettingsPanelA.Location = new Point(0, 0);
            SettingsPanelA.Name = "SettingsPanelA";
            SettingsPanelA.Size = new Size(560, 77);
            SettingsPanelA.TabIndex = 9;
            // 
            // StartHookButton
            // 
            StartHookButton.BackColor = Color.LightYellow;
            StartHookButton.FlatAppearance.BorderColor = Color.White;
            StartHookButton.Location = new Point(414, 5);
            StartHookButton.Margin = new Padding(5);
            StartHookButton.Name = "StartHookButton";
            StartHookButton.Size = new Size(141, 28);
            StartHookButton.TabIndex = 11;
            StartHookButton.Text = "Listen to PZ";
            MinimizeButtonToolTip.SetToolTip(StartHookButton, "Opens a window to listen to the project zomboid mod (reqires the Project Zomboid Backup Manager Mod from the Workshop)");
            StartHookButton.UseVisualStyleBackColor = false;
            StartHookButton.Click += StartHookButton_Click;
            // 
            // SettingsPanelB
            // 
            SettingsPanelB.BackColor = SystemColors.ControlLightLight;
            SettingsPanelB.BorderStyle = BorderStyle.FixedSingle;
            SettingsPanelB.Controls.Add(LoadSavegameOnLoadCheckbox);
            SettingsPanelB.Controls.Add(ShowMessageBoxBackupCheckbox);
            SettingsPanelB.Location = new Point(16, 5);
            SettingsPanelB.Margin = new Padding(5);
            SettingsPanelB.Name = "SettingsPanelB";
            SettingsPanelB.Size = new Size(392, 67);
            SettingsPanelB.TabIndex = 10;
            // 
            // LoadSavegameOnLoadCheckbox
            // 
            LoadSavegameOnLoadCheckbox.AutoSize = true;
            LoadSavegameOnLoadCheckbox.Font = new Font("Bahnschrift SemiCondensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoadSavegameOnLoadCheckbox.Location = new Point(12, 32);
            LoadSavegameOnLoadCheckbox.Margin = new Padding(50, 10, 50, 10);
            LoadSavegameOnLoadCheckbox.Name = "LoadSavegameOnLoadCheckbox";
            LoadSavegameOnLoadCheckbox.Size = new Size(300, 23);
            LoadSavegameOnLoadCheckbox.TabIndex = 9;
            LoadSavegameOnLoadCheckbox.Text = "Auto select last loaded savegame on start?";
            LoadSavegameOnLoadCheckbox.UseVisualStyleBackColor = true;
            LoadSavegameOnLoadCheckbox.CheckedChanged += LoadSavegameOnLoadCheckbox_CheckedChanged;
            // 
            // ShowMessageBoxBackupCheckbox
            // 
            ShowMessageBoxBackupCheckbox.AutoSize = true;
            ShowMessageBoxBackupCheckbox.Font = new Font("Bahnschrift SemiCondensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ShowMessageBoxBackupCheckbox.Location = new Point(12, 6);
            ShowMessageBoxBackupCheckbox.Margin = new Padding(50, 10, 50, 50);
            ShowMessageBoxBackupCheckbox.Name = "ShowMessageBoxBackupCheckbox";
            ShowMessageBoxBackupCheckbox.Size = new Size(373, 23);
            ShowMessageBoxBackupCheckbox.TabIndex = 8;
            ShowMessageBoxBackupCheckbox.Text = "Show messagebox when backup process has finished?";
            ShowMessageBoxBackupCheckbox.UseVisualStyleBackColor = true;
            ShowMessageBoxBackupCheckbox.CheckedChanged += ShowMessageBoxBackupCheckbox_CheckedChanged;
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
            // EditBackupsContextMenu
            // 
            EditBackupsContextMenu.BackColor = SystemColors.ControlLight;
            EditBackupsContextMenu.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditBackupsContextMenu.Items.AddRange(new ToolStripItem[] { SelectContextMenuItem, DeleteContextMenuItem, RenameContextMenuItem, StopMultiSelectMenuItem });
            EditBackupsContextMenu.Name = "EditBackupsMenuButton";
            EditBackupsContextMenu.ShowImageMargin = false;
            EditBackupsContextMenu.Size = new Size(176, 122);
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
            RenameContextMenu.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
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
            RenameLabelTextItem.Text = "Savegame:";
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
            ConfrimRenameOption.Margin = new Padding(6, 0, 0, 0);
            ConfrimRenameOption.Name = "ConfrimRenameOption";
            ConfrimRenameOption.Overflow = ToolStripItemOverflow.AsNeeded;
            ConfrimRenameOption.Padding = new Padding(5);
            ConfrimRenameOption.Size = new Size(265, 30);
            ConfrimRenameOption.Text = "Rename";
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
            ClientSize = new Size(1175, 849);
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
            SettingsPanelB.ResumeLayout(false);
            SettingsPanelB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BackupsPictureBox).EndInit();
            EditBackupsContextMenu.ResumeLayout(false);
            RenameContextMenu.ResumeLayout(false);
            RenameContextMenu.PerformLayout();
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
        private CheckBox ShowMessageBoxBackupCheckbox;
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
        private Panel SettingsPanelB;
        private ToolTip MinimizeButtonToolTip;
        private CheckBox LoadSavegameOnLoadCheckbox;
        private Button StartHookButton;
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
    }
}
