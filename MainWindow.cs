using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;
using static ZomboidBackupManager.JsonData;
using System.Reflection.Metadata;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime;
using System.IO.Compression;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Policy;
using System.Drawing.Text;
using System.Reflection.Emit;
using System.Collections.Generic;

namespace ZomboidBackupManager
{
    public partial class MainWindow : Form
    {
        private ZipWatcher? Watcher;

        public bool isInSelectionMode = false;

        private event EventHandler<string> OnSkip;

        public List<ZipData> ZipDataCache = new List<ZipData>();

        private float ListBoxFontSize = 12f;
        private bool ListBoxFontsBolt = true;

        public MainWindow(float fListBoxFontSize = 12f, bool bListBoxFontsBolt = true)
        {
            InitializeComponent();
            ListBoxFontSize = fListBoxFontSize;
            ListBoxFontsBolt = bListBoxFontsBolt;
            SelectSavegameLabel.Font = FontLoader.GetStyleFont(40f);
            SavegameListBox.Font = FontLoader.GetMonoFont(ListBoxFontSize, ListBoxFontsBolt);
            BackupListBox.Font = FontLoader.GetMonoFont(ListBoxFontSize, ListBoxFontsBolt);
            this.OnSkip += OnSkipCompressToZip;
        }

        private void SelectSavegameLabel_Click(object sender, EventArgs e)
        {
            ReloadForm();
        }

        private void ReloadForm()
        {
            this.Hide();
            //ListBoxFontsBolt = !ListBoxFontsBolt;
            var newForm = new MainWindow(ListBoxFontSize, ListBoxFontsBolt);
            newForm.FormClosed += (s, e) => this.Close(); // alte Form schlieﬂen, wenn neue fertig
            newForm.Show();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered(true);
            ThumbnailPictureBox.DoubleBuffered(true);
            BackupsPictureBox.DoubleBuffered(true);

            RefreshCheckboxes();
            ResetBackupThumbnailAndData();
            LoadGamemodes();
            SetBackupFolderPathTextbox();
            SetSavegameRemote();
            SetAutoDeleteInfoLabelEn(autoDeleteEnabled);
            EnableExperimentalFeatures(expFeaturesEnabled);
            ShowUpdateInfoWindow();
            initRunning = false;
        }

        private void SetInteractablesEnabled(bool bSet = true)
        {
            Toolstrip1.Enabled = bSet;
            BackupRestoreToolStrip.Enabled = bSet;
            GamemodeComboBox.Enabled = bSet;
            SavegameListBox.Enabled = bSet;
            BackupListBox.Enabled = bSet;
            HalfWindowModeRadioButton.Enabled = bSet;
            NormalWindowModeRadioButton.Enabled = bSet;
            ChangeBackupFolderTextbox.Enabled = bSet;
        }

        private void ShowUpdateInfoWindow()
        {
            if (showUpdateInfoWindow)
            {
                showUpdateInfoWindow = false;
                UpdateInfoWindow updateInfo = new UpdateInfoWindow();
                updateInfo.ShowDialog();
            }
        }

        private void EnableExperimentalFeatures(bool enable)
        {
            HasZipTextLabel.Visible = enable;
            HasZipValuePictureBox.Visible = enable;
            HasLooseTextLabel.Visible = enable;
            HasLooseValuePictureBox.Visible = enable;
            ZipSetupMenuOption.Visible = enable;
            CreateZipEditBackupMenuOption.Visible = enable;
            CreateZipToolbarMenuOption.Visible = enable;
            CompressZipSettingMenuOption.Visible = enable;
            DeleteZipToolbarOption.Visible = enable;
            DeleteZipMenuOption.Visible = enable;
            DeleteLooseToolbarOption.Visible = enable;
            DeleteLooseMenuOption.Visible = enable;
        }

        private void RefreshCheckboxes()
        {
            ShowMsgSettingMenuOption.Checked = Configuration.showMsgWhenBackupProcessDone;
            AutoSelectSGSettingMenuOption.Checked = Configuration.autoSelectSavegameOnStart;
            CompressZipSettingMenuOption.Checked = Configuration.saveBackupsAsZipFile;
            KeepFolderSettingMenuOption.Checked = Configuration.keepBackupFolderAfterZip;

        }

        private void LoadGamemodes()
        {
            GamemodeComboBox.Items.Clear();
            GamemodeComboBox.Items.AddRange(GetGamemodes().ToArray());
        }

        private void GamemodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show($"GamemodeComboBox_SelectedIndexChanged fired! [sender = {sender.ToString()}] - [EventArgs = {e.ToString()}]");
            if (indexChangeEventsSuspended)
            {
                PrintDebug("[MainWindow] - [GamemodeComboBox] - Selected Index Changed aborted - Index change events are suspended!");
                return;
            }
            SetBackupButtonsEn(false);
            BackupButton.Enabled = false;
            HalfWindowModeRadioButton.Enabled = false;
            var item = GamemodeComboBox.SelectedItem;
            if (item != null)
            {
                LoadJustGamemode(item.ToString(), GamemodeComboBox.SelectedIndex);
            }
            LoadSavegamesInSelectedGamemode();
            SetSavegameLabelValues();
            ResetSavegameThumbnailAndData();
            ResetBackupThumbnailAndData();
            BackupListBox.Items.Clear();
        }

        private void LoadSavegamesInSelectedGamemode()
        {
            var savegameList = GetSavegamesInSelectedGamemode();
            SavegameListBox.Items.Clear();
            SavegameListBox.Items.AddRange(savegameList);
            currentLoadedGamemodeIndex = GamemodeComboBox.SelectedIndex;
        }

        public string[] GetSavegamesInSelectedGamemode()
        {
            var cBoxItem = GamemodeComboBox.SelectedItem;
            if (cBoxItem == null)
            {
                return Array.Empty<string>();
            }
            string? gamemode = cBoxItem.ToString();
            if (string.IsNullOrEmpty(gamemode))
            {
                return Array.Empty<string>();
            }

            string fullSavegamePath = Configuration.GetFullSavegamesPath(gamemode);

            string[] savegameFolderList = Directory.GetDirectories(fullSavegamePath);

            List<string> outputList = new List<string>();

            foreach (var savegame in savegameFolderList)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(fullSavegamePath + savegame);
                outputList.Add(dirInfo.Name);
            }

            return outputList.ToArray();

        }

        private void LoadBackupInSelectedGamemode()
        {
            var backupList = GetBackupsOfSelectedSavegame();
            BackupListBox.Items.Clear();
            BackupListBox.Items.AddRange(backupList);
        }

        private string[] GetBackupsOfSelectedSavegame()
        {
            string[] backupFolderList = GetBackups();

            if (backupFolderList.Length == 0 || backupFolderList == null)
            {
                return Array.Empty<string>();
            }

            List<string> outputList = new List<string>();

            foreach (var backup in backupFolderList)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(currentLoadedBackupFolderPATH + currentLoadedSavegame);
                outputList.Add(dirInfo.Name);
            }

            return outputList.ToArray();

        }

        private void LoadAndDisplayBackups()
        {
            string[] backupList = GetAllBackupDataNamesFromJson();
            BackupListBox.Items.Clear();
            BackupListBox.Items.AddRange(backupList);
        }

        private void SavegameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (indexChangeEventsSuspended)
            {
                PrintDebug("[MainWindow] - [GamemodeComboBox] - Selected Index Changed aborted - Index change events are suspended!");
                return;
            }
            if (SavegameListBox.SelectedIndex < 0) { return; }
            if (IsValidSavegameSelected())
            {
                BackupButton.Enabled = true;
                HalfWindowModeRadioButton.Enabled = true;
                SelectSavegame();
                LoadSavegameThumbnail();
                LoadAndDisplayBackups();
                SetAutoDeleteInfoLabelEn(true);
            }
            else
            {
                var item = GamemodeComboBox.SelectedItem;
                if (item != null)
                {
                    string? itemName = item.ToString();
                    LoadJustGamemode(itemName, GamemodeComboBox.SelectedIndex);
                }
                BackupButton.Enabled = false;
                SetAutoDeleteInfoLabelEn(false);
            }
            SetSavegameLabelValues();
            ResetBackupThumbnailAndData();
            SetBackupButtonsEn(false);
        }

        private bool LoadSavegameThumbnail()
        {
            if (GamemodeComboBox.SelectedIndex < 0 || SavegameListBox.SelectedIndex < 0)
            {
                return false;
            }
            var selSavegame = SavegameListBox.SelectedItem;
            if (selSavegame == null)
            {
                return false;
            }

            string? selSavegameName = selSavegame.ToString();
            if (string.IsNullOrEmpty(selSavegameName))
            {
                return false;
            }
            string imageName = @"thumb.png";
            string mode = GetGamemodeByIndex(GamemodeComboBox.SelectedIndex);
            string fullSavegamePATH = Configuration.GetFullSavegamesPath(mode);
            string tmp = Path.Combine(fullSavegamePATH, selSavegameName);
            string thumbnailPATH = Path.Combine(tmp, imageName);
            //MessageBox.Show(@"THUMBNAIL PATH --> " + thumbnailPATH);
            if (!File.Exists(thumbnailPATH))
            {
                return false;
            }
            ThumbnailPictureBox.ImageLocation = thumbnailPATH;
            return true;
        }

        private void ResetBackupThumbnailAndData()
        {
            Bitmap imgThumbnail = Properties.Resources.ThumbnailPlaceholder;
            Bitmap imgDataIcon = Properties.Resources.Checkmark;



            BackupsPictureBox.Image = imgThumbnail;

            BackupNameValueLabel.Text = @" - ";
            BackupIndexValueLabel.Text = @" - ";
            BackupFolderValueLabel.Text = @" - ";
            HasZipValuePictureBox.Image = imgDataIcon;
            HasLooseValuePictureBox.Image = imgDataIcon;
            BackupDateInfoValueLabel.Text = @" - ";
            BackupTimeInfoValueLabel.Text = @" - ";
            BackupSizeInfoValueLabel.Text = @" - ";
        }

        private void ResetSavegameThumbnailAndData()
        {
            Bitmap img = Properties.Resources.ThumbnailPlaceholder;
            if (img != null)
            {
                ThumbnailPictureBox.Image = img;
            }

            SavgameInfoValueLabel.Text = @" - ";
            BackupCountValueLabel.Text = @" - ";

        }
        private bool LoadBackupThumbnail()
        {
            string backupPATH = GetBackupFolderPathFromJson(BackupListBox.SelectedIndex);
            string imageName = @"thumb.png";
            string thumbnailPATH = Path.Combine(backupPATH, imageName);
            //MessageBox.Show(@"THUMBNAIL PATH --> " + thumbnailPATH);
            if (!File.Exists(thumbnailPATH))
            {
                return false;
            }
            BackupsPictureBox.ImageLocation = thumbnailPATH;
            return true;
        }

        private void SetSavegameRemote()
        {
            if (!Configuration.autoSelectSavegameOnStart)
            {
                PrintDebug($"[SetSavegameRemote] - [Aborted] - autoSelectSavegameOnStart = [{Configuration.autoSelectSavegameOnStart}]");
                return;
            }
            string? savegame = currentLoadedSavegame;
            string? gamemode = currentLoadedGamemode;
            if (string.IsNullOrEmpty(savegame) || string.IsNullOrEmpty(gamemode) || !GamemodeContainsSavegame(gamemode, savegame))
            {
                PrintDebug($"[SetSavegameRemote] - [Aborted] - A value is null or empty! \n Savegame = [{savegame}] \n Gamemode = [{gamemode}]");
                return;
            }
            int indexGamemode = FindGamemodeListIndexByName(gamemode);
            if (indexGamemode < 0)
            {
                PrintDebug($"[SetSavegameRemote] - [Aborted] - indexGamemode < 0 \n indexGamemode = [{indexGamemode}]");
                return;
            }
            SetIndexChangeEventsSuspended(this, true);
            GamemodeComboBox.SelectedIndex = indexGamemode;
            GamemodeComboBox.Focus();
            LoadSavegamesInSelectedGamemode();
            int indexSavegame = FindSavegameListIndexByName(savegame);
            if (indexSavegame < 0)
            {
                PrintDebug($"[SetSavegameRemote] - [Aborted] - A value is < 0 \n indexSavegame = [{indexSavegame}] \n indexGamemode = [{indexGamemode}]");
                SetIndexChangeEventsSuspended(this, false);
                return;
            }
            SavegameListBox.SelectedIndex = indexSavegame;
            if (IsValidSavegameSelected())
            {
                BackupButton.Enabled = true;
                HalfWindowModeRadioButton.Enabled = true;
                //MiniWindowButton.Visible = true;
                SelectSavegame();
                LoadSavegameThumbnail();
                LoadAndDisplayBackups();
                SetSavegameLabelValues();
            }
            SetIndexChangeEventsSuspended(this, false);
            PrintDebug($"[SetSavegameRemote] - Savegame [{savegame}] in Gamemode [{gamemode}] successfully loaded!");
        }

        private int FindGamemodeListIndexByName(string itemName)
        {
            System.Windows.Forms.ComboBox.ObjectCollection itemCollection = GamemodeComboBox.Items;
            foreach (var item in itemCollection)
            {
                if (item.ToString() == itemName)
                {
                    return itemCollection.IndexOf(item);
                }
            }
            return -1;
        }

        private int FindSavegameListIndexByName(string itemName)
        {
            System.Windows.Forms.ListBox.ObjectCollection itemCollection = SavegameListBox.Items;
            foreach (var item in itemCollection)
            {
                if (item.ToString() == itemName)
                {
                    return itemCollection.IndexOf(item);
                }
            }
            return -1;
        }

        private void SelectSavegame()
        {
            var v1 = GamemodeComboBox.SelectedItem;
            if (v1 == null)
            {
                return;
            }
            var v2 = SavegameListBox.SelectedItem;
            if (v2 == null)
            {
                return;
            }
            string? gamemodeName = v1.ToString();
            string? savegameName = v2.ToString();



            if (!string.IsNullOrEmpty(gamemodeName) && !string.IsNullOrEmpty(savegameName))
            {
                if (!GamemodeContainsSavegame(gamemodeName, savegameName))
                {
                    ResetBackupThumbnailAndData();
                    ResetSavegameThumbnailAndData();
                    LoadSavegamesInSelectedGamemode();
                    return;
                }
                Configuration.LoadSavegame(savegameName, gamemodeName, SavegameListBox.SelectedIndex, GamemodeComboBox.SelectedIndex);
                LoadAndDisplayBackups();

                //MessageBox.Show($"Savegame [{savegameName}] successfully loaded!");
            }
            ResetBackupThumbnailAndData();
            ResetSavegameThumbnailAndData();
        }

        private bool IsValidSavegameSelected()
        {
            var item = SavegameListBox.SelectedItem;
            if (item != null)
            {
                return true;

            }
            return false;
        }

        private bool IsValidBackupSelected()
        {
            int listBoxIdx = BackupListBox.SelectedIndex;
            int listBoxMax = BackupListBox.Items.Count - 1;
            if ((listBoxIdx < 0) || (listBoxIdx > listBoxMax) || (string.IsNullOrWhiteSpace(currentLoadedSavegame)) || (string.IsNullOrWhiteSpace(currentLoadedGamemode)))
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        private void SetBackupFolderPathTextbox()
        {
            BackupFolderPathTextbox.Text = Configuration.currentBaseBackupFolderPATH;
        }

        private void BackupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProgressbarPanel.Visible)
            {
                ProgressbarPanel.Visible = false;
            }
            SetDeleteMenuOptions();
            if (IsValidBackupSelected())
            {
                SetBackupButtonsEn(true);
                LoadBackupThumbnail();
                SetBackupLabelValues();
            }
            else
            {
                SetBackupButtonsEn(false);
            }
        }

        private void SetAutoDeleteInfoLabelVal()
        {
            int bCount = GetBackupCountFromJson();
            if (bCount > autoDelBackupCountUserSet)
            {
                autoDeleteKeepBackupsCount = bCount;
            }
            else
            {
                autoDeleteKeepBackupsCount = autoDelBackupCountUserSet;
            }
            AutoDeleteInfoLabel.Text = $"Autodelete: [{BackupListBox.Items.Count} / {autoDeleteKeepBackupsCount}] Backups";
        }

        private void SetAutoDeleteInfoLabelEn(bool val)
        {
            if (autoDeleteEnabled)
            {
                AutoDeleteInfoLabel.Visible = val;
                if (val)
                {
                    SetAutoDeleteInfoLabelVal();
                }
            }
            else
            {
                AutoDeleteInfoLabel.Visible = false;
            }
        }

        private void SetBackupButtonsEn(bool val)
        {
            if (isInSelectionMode)
            {
                return;
            }
            RestoreButton.Enabled = val;
            DeleteSelectedToolStripButton.Enabled = val;
        }

        private void SetDeleteMenuOptions()
        {
            int idx = BackupListBox.SelectedIndex;
            if (idx < 0)
            {
                PrintDebug($"[MainWindow.cs] - [SetDeleteMenuOptions] - [Index out of range!] - [idx = {idx}]");
                return;
            }
            bool hasLoose = string.IsNullOrWhiteSpace(GetBackupFolderPathFromJson(idx));
            bool hasZip = string.IsNullOrWhiteSpace(GetBackupZipPathFromJson(idx));
            if (hasLoose && hasZip)
            {
                DeleteLooseToolbarOption.Enabled = true;
                DeleteLooseMenuOption.Enabled = true;
                DeleteZipToolbarOption.Enabled = true;
                DeleteZipMenuOption.Enabled = true;
            }
            else
            {
                DeleteLooseToolbarOption.Enabled = false;
                DeleteLooseMenuOption.Enabled = false;
                DeleteZipToolbarOption.Enabled = false;
                DeleteZipMenuOption.Enabled = false;
            }
        }

        private async void BackupListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!IsValidBackupSelected())
            {
                MessageBox.Show("Can't restore! Please select a valid backup first!");
                return;
            }

            Restore restore = new Restore();
            await restore.DoRestore(currentLoadedSavegame, GetFullLoadedSavegamePath(), BackupListBox.SelectedIndex, ProgressBarA, ProgressbarLabel);
        }

        private async void RestoreButton_Click(object sender, EventArgs e)
        {
            if (!IsValidBackupSelected())
            {
                MessageBox.Show("Can't restore! Please select a valid backup first!");
                return;
            }
            ProgressbarPanel.Visible = true;
            SetInteractablesEnabled(false);
            Restore restore = new Restore();
            restore.OnStatusChanged += Restore_OnStatusChanged;
            await restore.DoRestore(currentLoadedSavegame, GetFullLoadedSavegamePath(), BackupListBox.SelectedIndex, ProgressBarA, ProgressbarLabel);
        }

        private async void BackupButton_Click(object sender, EventArgs e)
        {
            if (!IsValidSavegameSelected())
            {
                MessageBox.Show("Can't backup! Please load a valid savegame first!");
                return;
            }
            ProgressbarPanel.Visible = true;
            SetInteractablesEnabled(false);
            Backup backup = new Backup();
            backup.OnStatusChanged += Backup_OnStatusChanged;
            await backup.DoBackup(currentLoadedSavegame, currentLoadedGamemode, GetFullLoadedSavegamePath(), currentLoadedBackupFolderPATH, GetBackupCount(), ProgressbarLabel, ProgressBarA);
        }

        private async void SetSaveBackupsAsZipSetting()
        {
            if (CompressZipSettingMenuOption.Checked)
            {
                if (!initRunning)
                {
                    MessageBox.Show("Warning! This feature is experimental,\nbecause at the moment it can take up to minutes to compress a backup into a  zip archive.");
                }
                KeepFolderSettingMenuOption.Visible = true;
            }
            else
            {
                KeepFolderSettingMenuOption.Visible = false;
            }
            Configuration.saveBackupsAsZipFile = CompressZipSettingMenuOption.Checked;
            await Configuration.WriteCfgToJson();
        }

        private async void SetKeepBackupFolderSetting()
        {
            Configuration.keepBackupFolderAfterZip = KeepFolderSettingMenuOption.Checked;
            await Configuration.WriteCfgToJson();
        }

        private async void SetShowMessageboxWhenBackupDone()
        {
            Configuration.showMsgWhenBackupProcessDone = ShowMsgSettingMenuOption.Checked;
            await Configuration.WriteCfgToJson();
        }

        private async void SetAutoSelectSavegameOnStart()
        {
            Configuration.autoSelectSavegameOnStart = AutoSelectSGSettingMenuOption.Checked;
            await Configuration.WriteCfgToJson();
        }
        private void SetSavegameLabelValues()
        {
            SavgameInfoValueLabel.Text = currentLoadedSavegame;
            GamemodeInfoValueLabel.Text = currentLoadedGamemode;
            BackupCountValueLabel.Text = GetBackupCountFromJson().ToString();
        }

        private void SetBackupLabelValues()
        {
            BackupData? data = GetBackupDataFromJson(BackupListBox.SelectedIndex);
            if (data == null)
            {
                return;
            }
            string? path = data.Path;
            string folderName = string.Empty;
            if (string.IsNullOrEmpty(path))
            {
                folderName = @"[ERROR]";
            }
            else
            {
                folderName = Path.GetRelativePath(Configuration.currentBaseBackupFolderPATH, path);
            }
            string? s = data.Size;
            string size = string.Empty;
            if (string.IsNullOrEmpty(s))
            {
                size = @"[ERROR]";
            }
            else
            {
                size = s.Substring(0, 5);
                size = size + @" MB";
            }


            BackupNameValueLabel.Text = data.Name;
            BackupIndexValueLabel.Text = data.Index.ToString();
            BackupFolderValueLabel.Text = folderName;
            if (IsBackupZipped(BackupListBox.SelectedIndex)) { HasZipValuePictureBox.Image = Properties.Resources.CheckmarkFilled; } else { HasZipValuePictureBox.Image = Properties.Resources.Checkmark; }

            if (IsBackupSavedLoose(BackupListBox.SelectedIndex)) { HasLooseValuePictureBox.Image = Properties.Resources.CheckmarkFilled; } else { HasLooseValuePictureBox.Image = Properties.Resources.Checkmark; }

            BackupDateInfoValueLabel.Text = data.Date;
            BackupTimeInfoValueLabel.Text = data.Time;
            BackupSizeInfoValueLabel.Text = size;
        }


        private void EditBackupButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.EditBackupsContextMenu.Show();
        }

        //private void LoadMiniWindow()
        //{
        //    var form = new MiniBackupWindow();
        //    this.Hide();
        //    form.ShowDialog();
        //   this.Show();
        //    LoadAndDisplayBackups();
        //}

        private void UnhideForm()
        {
            this.Show();
            GamemodeComboBox.SelectedIndex = currentLoadedGamemodeIndex;
            LoadSavegamesInSelectedGamemode();
            SavegameListBox.SelectedIndex = currentLoadedSavegameIndex;
            LoadAndDisplayBackups();
        }


        private void ConfirmRenameBackup()
        {
            var backupItem = BackupListBox.SelectedItem;
            if (backupItem == null)
            {
                MessageBox.Show("Please enter a backup to before you try to rename a backup!");
                return;
            }
            string? backupName = backupItem.ToString();
            if (string.IsNullOrWhiteSpace(backupName))
            {
                return;
            }
            string newName = RenameEnterTextOption.Text;
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Please enter a name to rename a backup!");
                return;
            }
            RenameBackup(BackupListBox.SelectedIndex, newName);
            LoadAndDisplayBackups();
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------[  Edit Backup Menu  ]---------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------


        private void DeleteSelected_OnClick(object sender, EventArgs e)
        {
            if (BackupListBox.SelectedIndex < 0 || BackupListBox.SelectedIndex >= BackupListBox.Items.Count)
            {
                PrintDebug($"[Error] - [DeleteSelected_OnClick] - [BackupListBox.SelectedIndex = {BackupListBox.SelectedIndex}]");
                return;
            }
            if (BackupListBox.SelectedItems.Count == 1)
            {
                DeleteSingleBackup(BackupListBox.SelectedIndex);
            }
            else if (BackupListBox.SelectedItems.Count > 1)
            {
                DeleteMultipleBackups();
            }
            else
            {
                return;
            }
        }

        private async void DeleteSingleBackup(int idx, bool ask = true)
        {
            if (ask)
            {
                var result = MessageBox.Show($"Are you sure you want to delete this backup? \n Name: {GetBackupDataNameFromJson(idx)} \n Index: {idx} ", "Please confirm deletion!", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            Delete delete = new Delete();
            await delete.DoDelete(BackupListBox.SelectedIndex, ProgressbarLabel, ProgressBarA, ProgressbarPanel);
            LoadAndDisplayBackups();
            SetSavegameLabelValues();
            SetBackupLabelValues();
        }

        private void DeleteMultipleBackups()
        {
            List<string> u = new List<string>();
            foreach (var item in BackupListBox.SelectedItems)
            {
                if (item != null)
                {
                    string? name = item.ToString();
                    if (!string.IsNullOrEmpty(name))
                    {
                        u.Add(name);
                    }
                }
            }

            string[] s = u.ToArray();
            BackupListBox.SelectedItems.CopyTo(s, 0);
            string strList = string.Join("\n", s);
            var result = MessageBox.Show($"Are you sure you want to delete the {BackupListBox.SelectedItems.Count} selected backups? \n {strList}", "Please confirm!", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                SetSelectionMode(false);
                return;
            }
            result = MessageBox.Show($"Are you really sure you want to do that right now? It can take some time, tho!", "Please confirm again!", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                SetSelectionMode(false);
                return;
            }
            ListBox.SelectedIndexCollection col = BackupListBox.SelectedIndices;
            List<string> paths = new List<string>();
            Dictionary<string, int> keys = new Dictionary<string, int>();
            foreach (int index in col)
            {
                string? path = GetBackupFolderPathFromJson(index);
                PrintDebug($"[DeleteMultipleBackups] - [index = {index}] - [path = {path}]");
                if (path != null)
                {
                    paths.Add(path);
                    keys.Add(path, index);
                }
            }
            if (isInSelectionMode)
            {
                SetSelectionMode(false);
            }
            DeleteMulti multiDelete = new DeleteMulti(paths, keys);
            if (multiDelete.Status == Status.FAILED)
            {
                MessageBox.Show("Failed to init DeleteMulti.cs. Creation returned - STATUS.FAILED!");
                SetSelectionMode(false);
                return;
            }
            multiDelete.OnStatusChanged += DeleteMulti_OnStatusChanged;
            SetInteractablesEnabled(false);
            multiDelete.StartDeleteMultiple();
        }

        private void DeleteMulti_OnStatusChanged(object? sender, Status s)
        {
            PrintDebug($"[DeleteMulti] - [OnStatusChanged] - [To = {s.ToString()}]");
            if (s == Status.FAILED)
            {
                MessageBox.Show($"DEBUG - DeleteMulti_OnStatusChanged - Status = {s.ToString()} ");

            }
            else if ((s == Status.DONE) || (s == Status.CANCELED))
            {
                SetInteractablesEnabled(true);
                this.WindowState = FormWindowState.Normal;
                SetSelectionMode(false);
                LoadAndDisplayBackups();
                SetSavegameLabelValues();
                SetBackupLabelValues();
            }

        }

        private void Backup_OnStatusChanged(object? sender, Status s)
        {
            PrintDebug($"[MainWindow.cs] - [Backup_OnStatusChanged] - [To = {s.ToString()}]");
            if (s == Status.FAILED)
            {
                PrintDebug($"[MainWindow.cs] - [Backup_OnStatusChanged] - [Status = {s.ToString()}] ", 2);

            }
            else if (s == Status.DONE)
            {
                if (autoDeleteEnabled)
                {
                    if (BackupListBox.Items.Count > autoDeleteKeepBackupsCount)
                    {
                        DeleteSingleBackup(0, false);
                    }

                }
                if (saveBackupsAsZipFile)
                {

                    CompressBackupToZip(GetLastBackupIndexFromJson());
                }
                else
                {
                    LoadAndDisplayBackups();
                    SetSavegameLabelValues();
                    SetBackupLabelValues();
                    ProgressBarA.Value = 0;
                    ProgressbarLabel.Text = @" - ";
                    ProgressbarPanel.Visible = false;
                    SetInteractablesEnabled(true);
                }

            }

        }

        private void Restore_OnStatusChanged(object? sender, Status s)
        {
            PrintDebug($"[MainWindow.cs] - [Restore_OnStatusChanged] - [To = {s.ToString()}]");
            if (s == Status.FAILED)
            {
                PrintDebug($"[MainWindow.cs] - [Restore_OnStatusChanged] - [Status = {s.ToString()}] ", 2);

            }
            else if (s == Status.DONE)
            {
                LoadAndDisplayBackups();
                SetSavegameLabelValues();
                SetBackupLabelValues();
                ProgressBarA.Value = 0;
                ProgressbarLabel.Text = @" - ";
                ProgressbarPanel.Visible = false;
                SetInteractablesEnabled(true);
            }
        }

        private void SelectMultiOption_Click(object sender, EventArgs e)
        {
            SetSelectionMode(true);
        }

        private void SelectAllOption_Click(object sender, EventArgs e)
        {
            SetSelectionMode(true);
            SetAllBackupsSelected();
        }

        private void SetAllBackupsSelected()
        {
            int itemCount = BackupListBox.Items.Count;
            for (int i = 0; i < itemCount; i++)
            {
                BackupListBox.SelectedItems.Add(BackupListBox.Items[i]);
            }
        }

        private void SetBackupsSelected(int endIdx)
        {
            int itemCount = BackupListBox.Items.Count;
            if ((endIdx < 0) || endIdx > itemCount)
            {
                PrintDebug($"[MainWindow] - [SetBackupsSelected] - [itemCount = {itemCount}] - [endIdx = {endIdx}]", 2);
            }
            SetSelectionMode(true);
            BackupListBox.SelectedItems.Clear();
            for (int i = 0; i < endIdx; i++)
            {
                BackupListBox.SelectedItems.Add(BackupListBox.Items[i]);
            }
        }

        private void SetSelectionMode(bool multi)
        {
            if (multi)
            {
                isInSelectionMode = true;
                RestoreButton.Enabled = false;
                BackupButton.Enabled = false;
                ListenToPZToolStripButton.Enabled = false;
                GamemodeComboBox.Enabled = false;
                SavegameListBox.Enabled = false;
                RenameContextMenuItem.Visible = false;
                SelectContextMenuItem.Visible = false;
                StopMultiSelectMenuItem.Visible = true;
                StartMultiSelectToolTipButton.Visible = false;
                StopMultiSelectToolTipButton.Visible = true;
                BackupListBox.SelectionMode = SelectionMode.MultiExtended;
            }
            else
            {
                isInSelectionMode = false;
                RestoreButton.Enabled = true;
                BackupButton.Enabled = true;
                ListenToPZToolStripButton.Enabled = true;
                GamemodeComboBox.Enabled = true;
                SavegameListBox.Enabled = true;
                RenameContextMenuItem.Visible = true;
                SelectContextMenuItem.Visible = true;
                StopMultiSelectMenuItem.Visible = false;
                StartMultiSelectToolTipButton.Visible = true;
                StopMultiSelectToolTipButton.Visible = false;
                BackupListBox.SelectionMode = SelectionMode.One;
            }
        }

        private void SetRenameLabelTextItem()
        {
            var backup = BackupListBox.SelectedItem;
            if (backup == null)
            {
                return;
            }
            string? backupName = backup.ToString();
            if (string.IsNullOrWhiteSpace(backupName))
            {
                return;
            }
            RenameLabelTextItem.Text = $"Backup: {backupName}";
        }

        private void RenameEnterTextOption_Click(object sender, EventArgs e)
        {
            RenameEnterTextOption.Text = string.Empty;
        }

        private void ConfrimRenameOption_Click(object sender, EventArgs e)
        {
            ConfirmRenameBackup();
        }

        private void EditBackupsContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetRenameLabelTextItem();
            if (isInSelectionMode)
            {
                SelectContextMenuItem.Visible = false;
                StopMultiSelectMenuItem.Visible = true;
            }
        }

        private void StopMultiSelectMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            SetSelectionMode(false);
        }

        private void CompressZipSettingMenuOption_CheckedChanged(object sender, EventArgs e)
        {
            SetSaveBackupsAsZipSetting();
        }

        private void KeepFolderSettingMenuOption_CheckedChanged(object sender, EventArgs e)
        {
            SetKeepBackupFolderSetting();
        }

        private void AutoSelectSGSettingMenuOption_CheckedChanged(object sender, EventArgs e)
        {
            SetAutoSelectSavegameOnStart();
        }

        private void ShowMsgSettingMenuOption_CheckedChanged(object sender, EventArgs e)
        {
            SetShowMessageboxWhenBackupDone();
        }

        private void ListenToPZToolStripButton_Click(object sender, EventArgs e)
        {
            LoadHookWindow();
        }

        private void LoadHookWindow()
        {
            var form = new PZScriptHook();
            this.Hide();
            form.myParentForm = this;
            form.ShowDialog();
            if (!form.IsDisposed) { form.Dispose(); }
            UnhideForm();
        }

        private void SettingsDropDownButton_Click(object sender, EventArgs e)
        {
            CompressZipSettingMenuOption.Checked = saveBackupsAsZipFile;
        }

        private void StartMultiSelectToolTipButton_Click(object sender, EventArgs e)
        {
            SetSelectionMode(true);
        }

        private void StopMultiSelectToolTipButton_Click(object sender, EventArgs e)
        {
            SetSelectionMode(false);
        }

        private void DeleteSelectedToolStripButton_Click(object sender, EventArgs e)
        {
            if (BackupListBox.SelectedIndex < 0 || BackupListBox.SelectedIndex >= BackupListBox.Items.Count)
            {
                PrintDebug($"[Error] - [DeleteSelected_OnClick] - [BackupListBox.SelectedIndex = {BackupListBox.SelectedIndex}]");
                return;
            }
            if (BackupListBox.SelectedItems.Count == 1)
            {
                DeleteSingleBackup(BackupListBox.SelectedIndex);
            }
            else if (BackupListBox.SelectedItems.Count > 1)
            {
                DeleteMultipleBackups();
            }
            else
            {
                return;
            }
        }
        private void BackupListBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                EditBackupsContextMenu.Show(BackupListBox, new System.Drawing.Point(e.Location.X, e.Location.Y));
            }
        }

        private void BackupListBox_MouseDown(object sender, MouseEventArgs e)
        {
            BackupListBox.SelectedIndex = BackupListBox.IndexFromPoint(e.X, e.Y);
        }

        private async void AutoDeleteBackupMenuOption_Click(object sender, EventArgs e)
        {
            AutoDeleteSetupWindow autoDelWin = new AutoDeleteSetupWindow();
            autoDelWin.ShowDialog();
            autoDeleteEnabled = autoDelWin.CheckBoxValue;
            autoDelBackupCountUserSet = autoDelWin.TrackBarValue;
            autoDeleteKeepBackupsCount = autoDelBackupCountUserSet;
            await WriteCfgToJson();
            if (autoDeleteEnabled)
            {
                int bCount = GetBackupCountFromJson();
                if (bCount > autoDelBackupCountUserSet)
                {
                    int sel = bCount - autoDeleteKeepBackupsCount;
                    DialogResult result = MessageBox.Show($"Found {bCount} backups on your current selected savegame.\nYou have set a maximum of {autoDeleteKeepBackupsCount} which is less!\nDo you want to delete the first {sel} backups?\n(If you select no, the maximum will be increased to {bCount})", "Please confirm!", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        SetBackupsSelected(sel);
                        DeleteMultipleBackups();
                    }
                    else if (result == DialogResult.No)
                    {
                        autoDeleteKeepBackupsCount = bCount;
                    }
                    else
                    {
                        autoDeleteEnabled = false;
                        await WriteCfgToJson();
                    }
                }
            }
            SetAutoDeleteInfoLabelEn(autoDeleteEnabled);
        }

        private async void ZipSetupMenuOption_Click(object sender, EventArgs e)
        {
            ZipArchiveSetup zipSetup = new ZipArchiveSetup();
            DialogResult result = zipSetup.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            saveBackupsAsZipFile = zipSetup.CreateZipCB;
            keepBackupFolderAfterZip = zipSetup.KeepLooseCB;
            usedZipArchiver = zipSetup.ArchiverID;
            zipArchiverExePath = zipSetup.ArchiverPath;
            await WriteCfgToJson();
        }

        //=================================================================================================================
        //--------------------------------------[ Start Zip Archive Functions ]--------------------------------------------
        //=================================================================================================================
        // ZipWatcher:


        private void InitWatcher(string path)
        {
            Watcher = new ZipWatcher();
            Watcher.ZipFileReady += OnZipFileReady;
            Watcher.StartWatching(path);
        }

        private void EndWatcher()
        {
            Watcher?.StopWatching();
        }

        // Main:

        private void CreateZipEditBackupMenuOption_Click(object sender, EventArgs e)
        {
            if (IsValidBackupSelected())
            {
                ToggleProgressBarPanel(true);
                if (BackupListBox.SelectedItems.Count > 1)
                {
                    CompressMultiToZip();
                }
                else
                {
                    CompressBackupToZip(BackupListBox.SelectedIndex);
                }
            }
            else
            {
                MessageBox.Show("No backup selected. Please select a backup first!");
            }
        }

        private async void CompressBackupToZip(int idx)
        {
            var result = MessageBox.Show($"Are you sure you want to create a zip archive for this backup? \n Name: {GetBackupDataNameFromJson(idx)} \n Index: {idx} ", "Please confirm action!", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            if (usedZipArchiver == 0)
            {
                result = MessageBox.Show($"WARNING! This feature is currently WIP & can take up to minutes to complete even a single archive!\nAre you really sure, you want to continue?", "Please confirm again!", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            if (IsBackupZipped(idx))
            {
                result = MessageBox.Show($"It looks like there is a zip for this file already!\n\nDo you want to overwrite it?", "Please confirm again!", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
                string? delPath = GetBackupZipPathFromJson(idx);
                if (!string.IsNullOrWhiteSpace(delPath))
                {
                    await Task.Run(() => File.Delete(delPath));
                }
            }
            Compress comp = new Compress();
            DirectoryInfo dirInfo = new DirectoryInfo(GetBackupFolderPathFromJson(idx));
            string backupName = dirInfo.Name;

            ZipData zipData = new ZipData(idx, backupName, currentLoadedBackupFolderPATH);
            ZipDataCache.Add(zipData);
            InitWatcher(currentLoadedBackupFolderPATH);
            if (usedZipArchiver == 0)
            {
                await comp.SimpleCompress(ZipDataCache[0]);
            }
            else
            {
                await comp.ExternCompress(ZipDataCache[0]);
            }

        }

        private async void CompressMultiToZip()
        {
            await CacheBackupZipData();

            var result = MessageBox.Show($"Are you sure you want to create a zip archive for those {ZipDataCache.Count} backups?", "Please confirm action!", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                PrintDebug($"[MainWindow.cs] - [CompressMultiToZip] - [Aborted by user] - [clearing ZipData cache...]");
                ZipDataCache.Clear();
                return;
            }

            CompressBackupToZipLoop();
        }

        private async Task CacheBackupZipData()
        {
            ListBox.SelectedIndexCollection col = BackupListBox.SelectedIndices;
            List<ZipData> data = new List<ZipData>();
            PrintDebug($"[MainWindow.cs] - [CacheBackupZipData] - [col.Count = {col.Count}] - [sourcePath = {currentLoadedBackupFolderPATH}] - [Caching started!]");
            PrintDebug($"[MainWindow.cs] - [CacheBackupZipData] - [Caching started!]");
            foreach (int index in col)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(GetBackupFolderPathFromJson(index));
                string backupName = dirInfo.Name;
                ZipData zData = new ZipData(index, backupName, currentLoadedBackupFolderPATH);
                PrintDebug($"[MainWindow.cs] - [CacheBackupZipData] - [index = {index}] - [backupName = {backupName}] - [name = {GetBackupDataNameFromJson(index)}]");
                await Task.Delay(50);
                data.Add(zData);
            }
            PrintDebug($"[MainWindow.cs] - [CacheBackupZipData] - [Caching done!]");
            PrintDebug($"[MainWindow.cs] - [CacheBackupZipData] - [data.Count = {data.Count}]");
            ZipDataCache.AddRange(data);
        }

        private async void CompressBackupToZipLoop()
        {
            ToggleProgressBarPanel(true);
            ZipData data = ZipDataCache[0];
            if (data == null)
            {
                PrintDebug($"[MainWindow.cs] - [CompressBackupToZipLoop] - [data = {data}] - [ZipDataCache.Count = {ZipDataCache.Count}]", 2);
                return;
            }
            if (IsBackupZipped(data.Index))
            {
                PrintDebug($"[MainWindow.cs] - [CompressBackupToZipLoop] - [Backup = {data.BackupName}] - [already has a zip archive] - [Skipping!]", 1);
                this.OnSkip.Invoke(this, data.BackupName);
            }
            Compress comp = new Compress();
            PrintDebug($"[MainWindow.cs] - [CompressBackupToZipLoop] - [ZipDataCache.Count = {ZipDataCache.Count}]");
            InitWatcher(currentLoadedBackupFolderPATH);
            if (usedZipArchiver == 0)
            {
                await comp.SimpleCompress(data);
            }
            else
            {
                await comp.ExternCompress(data);
            }
            await Task.Delay(500);
        }

        private async void MoveZipArchive(ZipData data)
        {
            try
            {
                string? path = Path.GetDirectoryName(data.ZipDestPath);
                if (string.IsNullOrWhiteSpace(path))
                {
                    throw new Exception();
                }
                await Task.Delay(1500);
                PrintDebug($"[DoCompress] - [Start moving Zip archive] - [ZipFilePath = {data.ZipFilePath}] - [ZipDestPath = {data.ZipDestPath}]");
                await Task.Run(() => Directory.Move(data.ZipFilePath, data.ZipDestPath));
                PrintDebug($"[DoCompress] - [Done moving Zip archive]");
                await Task.Delay(500);
            }
            catch (Exception e)
            {
                MessageBox.Show($"[ERROR] - [MoveArchive] - [ERROR] \n\n[Message: {e}]");
            }
        }

        private void RefreshBackups(int i)
        {
            LoadAndDisplayBackups();
            SetSavegameLabelValues();
            SetBackupLabelValues();
            BackupListBox.SelectedItems.Clear();
            BackupListBox.SetSelected(i, true);

        }

        private void ToggleProgressBarPanel(bool bOn)
        {
            ProgressBarA.Value = 0;
            ProgressbarLabel.Text = @" - ";
            ProgressbarPanel.Visible = bOn;
            ProgressBarA.Visible = bOn;
            ProgressbarLabel.Visible = bOn;
        }

        // Events:

        private void OnZipFileReady(object? sender, string fullPath)
        {
            EndWatcher();
            this.Invoke((MethodInvoker)(() =>
            {
                PrintDebug($"[OnZipFileReady] - [ZIP - File is ready] - [fullPath = {fullPath}]");
                ProgressBarA.Value = 50;
                ProgressbarLabel.Text = "Zip file successfully created!";
                ZipData? data = ZipDataCache[0];
                if (data == null)
                {
                    return;
                }
                MoveZipArchive(data);
                string name = data.BackupName;
                bool result = AddZipPathToBackupData(data.Index, data.ZipDestPath, true);
                ProgressBarA.Value = 80;
                ProgressbarLabel.Text = "Zip Moved & Registered in jsonData";
                PrintDebug($"[MainWindow.cs] - [OnZipFileReady] - [Done Added Path to Json] - [result = {result}]");

                RefreshBackups(ZipDataCache[0].Index);
                ZipDataCache.RemoveAt(0);
                PrintDebug($"[MainWindow.cs] - [OnZipFileReady] - [Done Added Path to Json] - [ZipDataCache.Count = {ZipDataCache.Count}]");
                Watcher?.StopWatching();
                Thread.Sleep(500);
                ProgressBarA.Value = 100;
                ProgressbarLabel.Text = $"Backup [{name}] [successfull archived]";
                Thread.Sleep(500);
                if (ZipDataCache.Count > 0)
                {
                    CompressBackupToZipLoop();
                    return;
                }
                ToggleProgressBarPanel(false);

            }));
        }

        private void OnSkipCompressToZip(object? sender, string backup)
        {
            PrintDebug($"[MainWindow.cs] - [OnSkipCompressToZip] - [Skipping backup = {backup}]");
            ProgressBarA.Value = 50;
            ProgressbarLabel.Text = $"Skipping backup [{backup}] ! Zip archive already present!";
            ZipData? data = ZipDataCache[0];
            if (data == null)
            {
                return;
            }
            ProgressBarA.Value = 100;
            ProgressbarLabel.Text = "Zip Moved & Registered in jsonData";
            RefreshBackups(ZipDataCache[0].Index);
            ZipDataCache.RemoveAt(0);
            PrintDebug($"[MainWindow.cs] - [OnZipFileReady] - [Done Added Path to Json] - [ZipDataCache.Count = {ZipDataCache.Count}]");
            Watcher?.StopWatching();
            Thread.Sleep(500);
            if (ZipDataCache.Count > 0)
            {
                CompressBackupToZipLoop();
                return;
            }
            ToggleProgressBarPanel(false);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutInfoWindow aboutInfoWindow = new AboutInfoWindow();
            aboutInfoWindow.ShowDialog();
        }

        private void ChangeDirectoryMenuOption_Click(object sender, EventArgs e)
        {
            ChangeDirectoryWindow changeDir = new ChangeDirectoryWindow();
            DialogResult result = changeDir.ShowDialog();
            if (result == DialogResult.OK)
            {
                Configuration.ChangeBackupFolderPath(changeDir.CurrentPath);
            }
            SetBackupFolderPathTextbox();
        }

        private void BackupFolderPathTextbox_DoubleClick(object sender, EventArgs e)
        {
            ChangeDirectoryWindow changeDir = new ChangeDirectoryWindow();
            DialogResult result = changeDir.ShowDialog();
            if (result == DialogResult.OK)
            {
                Configuration.ChangeBackupFolderPath(changeDir.CurrentPath);
            }
            SetBackupFolderPathTextbox();
        }

        private void NormalWindowModeRadioButton_Click(object sender, EventArgs e)
        {
            SetWindowModeNormal();
        }

        private void HalfWindowModeRadioButton_Click(object sender, EventArgs e)
        {
            SetWindowModeHalf();
        }

        private void SetWindowModeNormal()
        {
            NormalWindowModeRadioButton.Checked = true;
            HalfWindowModeRadioButton.Checked = false;
            this.Size = new Size(1200, 875);
            SelectSavegamePanel.Visible = true;
        }

        private void SetWindowModeHalf()
        {
            NormalWindowModeRadioButton.Checked = false;
            HalfWindowModeRadioButton.Checked = true;
            SelectSavegamePanel.Visible = false;
            this.Size = new Size(600, 875);

        }

        private void SearchForUnlistedBackupsToolStripButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            BackupDataCleanerWindow backupDataCleanerWin = new BackupDataCleanerWindow();
            backupDataCleanerWin.ShowDialog();
            if (!backupDataCleanerWin.IsDisposed) { backupDataCleanerWin.Dispose(); } 
            this.Show();
            this.WindowState = FormWindowState.Normal;
            LoadAndDisplayBackups();
            SetSavegameLabelValues();
            SetBackupLabelValues();
        }

        private void BackupCountValueLabel_Click(object sender, EventArgs e)
        {

        }

        //=================================================================================================================
        //----------------------------------------[ End Zip Archive Functions ]--------------------------------------------
        //=================================================================================================================
    }


    public class ZipData
    {
        public int Index { get; set; }              // e.g. 5
        public string BackupName { get; set; }      // e.g. Backup_6
        public string SourcePath { get; set; }      // e.g. G:\ProjectZomboidBackups\Save01
        public string DestPath { get; set; }        // e.g. G:\ProjectZomboidBackups\Save01\Backup_6
        public string ZipFilePath { get; set; }     // e.g. G:\ProjectZomboidBackups\Save01\Backup_6.zip
        public string ZipDestPath { get; set; }     // e.g. G:\ProjectZomboidBackups\Save01\Backup_6\Backup_6.zip

        string fileExt = @".zip";

        public ZipData(int idx, string backupName, string sourcePath)
        {
            Index = idx;
            BackupName = backupName;
            SourcePath = sourcePath;
            DestPath = Path.Combine(sourcePath, backupName);
            ZipFilePath = DestPath + fileExt;
            ZipDestPath = Path.Combine(DestPath, backupName) + fileExt;
        }

    }

    public static class ControlExtensions
    {
        public static void DoubleBuffered(this Control control, bool enable)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { enable });
        }
    }
}
