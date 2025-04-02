using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;
using System.Reflection.Metadata;

namespace ZomboidBackupManager
{
    public partial class MainWindow : Form
    {
        private Form? PZScriptHookWindow = null;

        public bool isInSelectionMode = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            RefreshCheckboxes();
            ResetBackupThumbnailAndData();
            LoadGamemodes();
            SetBackupFolderPathTextbox();
            SetSavegameRemote();
        }

        private void RefreshCheckboxes()
        {
            ShowMsgSettingMenuOption.Checked = Configuration.showMsgWhenBackupProcessDone;
            AutoSelectSGSettingMenuOption.Checked = Configuration.autoSelectSavegameOnStart;
            CompressZipSettingMenuOption.Checked = Configuration.saveBackupsAsZipFile;


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
            if (IsValidSavegameSelected())
            {
                BackupButton.Enabled = true;
                //MiniWindowButton.Visible = true;
                SelectSavegame();
                LoadSavegameThumbnail();
                LoadAndDisplayBackups();
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
                //MiniWindowButton.Visible = false;
            }
            SetSavegameLabelValues();
            ResetBackupThumbnailAndData();
            SetBackupButtonsEn(false);
        }

        private bool LoadSavegameThumbnail()
        {
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
            Object? rm = Properties.Resources.ResourceManager.GetObject("ThumbnailPlaceholder");
            Image? myImage = (Bitmap?)rm as Image;
            if (myImage != null)
            {
                BackupsPictureBox.Image = myImage;
            }

            BackupNameValueLabel.Text = @" - ";
            BackupIndexValueLabel.Text = @" - ";
            BackupFolderValueLabel.Text = @" - ";
            BackupDateInfoValueLabel.Text = @" - ";
            BackupTimeInfoValueLabel.Text = @" - ";
            BackupSizeInfoValueLabel.Text = @" - ";
        }

        private void ResetSavegameThumbnailAndData()
        {
            Object? rm = Properties.Resources.ResourceManager.GetObject("ThumbnailPlaceholder");
            Image? myImage = (Bitmap?)rm as Image;
            if (myImage != null)
            {
                ThumbnailPictureBox.Image = myImage;
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
            ComboBox.ObjectCollection itemCollection = GamemodeComboBox.Items;
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
            ListBox.ObjectCollection itemCollection = SavegameListBox.Items;
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

        private void SelectBackupFolderButton_Click(object sender, EventArgs e)
        {
            ShowFolderBrowserDialog();
        }

        private void ShowFolderBrowserDialog()
        {
            var dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)  //check for OK...they might press cancel, so don't do anything if they did.
            {
                var path = dialog.SelectedPath;

                if (Directory.Exists(path))
                {
                    Configuration.ChangeBackupFolderPath(path);

                }

                SetBackupFolderPathTextbox();
            }
        }

        private void OpenBackupDirectoryButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Configuration.currentBaseBackupFolderPATH);
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
            if (listBoxIdx < 0 || string.IsNullOrWhiteSpace(currentLoadedSavegame) || string.IsNullOrWhiteSpace(currentLoadedGamemode))
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

        private bool SetBackupFolderPath(string path)
        {
            if (!Directory.Exists(path))
            {
                return false;
            }
            Configuration.currentBaseBackupFolderPATH = path;
            return true;
        }

        private void BackupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void SetBackupButtonsEn(bool val)
        {
            if (isInSelectionMode)
            {
                return;
            }
            RestoreButton.Enabled = val;
            DeleteSelectedToolStripButton.Enabled = val;
        }

        private async void BackupListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!IsValidBackupSelected())
            {
                MessageBox.Show("Can't restore! Please select a valid backup first!");
                return;
            }

            Restore restore = new Restore();
            await restore.DoRestore(currentLoadedSavegame, GetFullLoadedSavegamePath(), BackupListBox.SelectedIndex, ProgressBarA, ProgressbarLabel, ProgressbarPanel);
        }

        private async void RestoreButton_Click(object sender, EventArgs e)
        {

            if (!IsValidBackupSelected())
            {
                MessageBox.Show("Can't restore! Please select a valid backup first!");
                return;
            }

            Restore restore = new Restore();
            await restore.DoRestore(currentLoadedSavegame, GetFullLoadedSavegamePath(), BackupListBox.SelectedIndex, ProgressBarA, ProgressbarLabel, ProgressbarPanel);
        }

        private async void BackupButton_Click(object sender, EventArgs e)
        {
            if (!IsValidSavegameSelected())
            {
                MessageBox.Show("Can't backup! Please load a valid savegame first!");
                return;
            }
            Backup backup = new Backup();
            backup.OnStatusChanged += Backup_OnStatusChanged;
            await backup.DoBackup(currentLoadedSavegame, currentLoadedGamemode, GetFullLoadedSavegamePath(), currentLoadedBackupFolderPATH, GetLastBackupIndexFromJson(), ProgressbarLabel, ProgressBarA, ProgressbarPanel);

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

        private async void SetSaveBackupsAsZipSetting()
        {
            Configuration.saveBackupsAsZipFile = CompressZipSettingMenuOption.Checked;
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
                folderName = Path.GetRelativePath(Configuration.currentLoadedBackupFolderPATH, path);
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
        /*
        private async void DeleteAllBackupsButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (SavegameListBox.SelectedIndex < 0)
            {
                return;
            }
            var name = SavegameListBox.SelectedItem;
            if (name == null)
            {
                return;
            }
            var result = MessageBox.Show($" Are you sure you want to delete ALL backups for this savegame? \n Savegame: {name.ToString()}", "Confirm deletion!", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            result = MessageBox.Show($" Are you really sure you want to DELETE ALL BACKUPs for this savegame? \n SAVEGAME: {name.ToString()}", "Confirm deletion!", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            DeleteAll deleteAll = new DeleteAll();
            await deleteAll.DoDeleteAll(ProgressbarLabel, ProgressBarA, ProgressbarPanel);
            LoadSavegamesInSelectedGamemode();
        }
        */

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

        private async void DeleteSingleBackup(int idx)
        {
            var result = MessageBox.Show($"Are you sure you want to delete this backup? \n Name: {GetBackupDataNameFromJson(idx)} \n Index: {idx} ", "Please confirm deletion!", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
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
                return;
            }
            result = MessageBox.Show($"Are you really sure you want to do that right now? It can take some time, tho!", "Please confirm again!", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
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
                return;
            }
            multiDelete.OnStatusChanged += DeleteMulti_OnStatusChanged;
            this.Enabled = false;
            multiDelete.StartDeleteMultiple();
        }

        private void DeleteMulti_OnStatusChanged(object? sender, Status s)
        {
            PrintDebug($"[DeleteMulti] - [OnStatusChanged] - [To = {s.ToString()}]");
            if (s == Status.FAILED)
            {
                MessageBox.Show($"DEBUG - DeleteMulti_OnStatusChanged - Status = {s.ToString()} ");

            }
            else if (s == Status.DONE)
            {
                this.Enabled = true;
                LoadAndDisplayBackups();
                SetSavegameLabelValues();
                SetBackupLabelValues();
            }

        }

        private async void Backup_OnStatusChanged(object? sender, Status s)
        {
            PrintDebug($"[Backup] - [OnStatusChanged] - [To = {s.ToString()}]");
            if (s == Status.FAILED)
            {
                MessageBox.Show($"DEBUG - Backup_OnStatusChanged - Status = {s.ToString()} ");

            }
            else if (s == Status.DONE)
            {
                if (saveBackupsAsZipFile)
                {
                    Compress compress = new Compress();
                    await compress.DoCompress(GetDefaultBackupFolderName(GetLastBackupFolderNumber()), currentLoadedBackupFolderPATH, ProgressbarLabel);
                }
                LoadAndDisplayBackups();
                SetSavegameLabelValues();
                SetBackupLabelValues();
            }

        }

        private void SelectMultiOption_Click(object sender, EventArgs e)
        {
            SetSelectionMode(true);
        }

        private void SelectAllOption_Click(object sender, EventArgs e)
        {
            SetSelectionMode(true);
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
            form.FormClosing += new FormClosingEventHandler(OnHookWindowClosing);
            PZScriptHookWindow = form;
            form.myParentForm = this;
            form.Show();
            this.Hide();


        }

        public void OnHookWindowClosing(object? sender, EventArgs e)
        {
            if (PZScriptHookWindow != null)
            {
                PZScriptHookWindow.FormClosing -= OnHookWindowClosing;

                PZScriptHookWindow = null;
            }
            UnhideForm();
        }

        private void SettingsDropDownButton_Click(object sender, EventArgs e)
        {
            AboutInfoVersionTextBox.Text = appVersion;
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

        private void CompressZipSettingMenuOption_Click(object sender, EventArgs e)
        {

        }

        private void AutoSelectSGSettingMenuOption_Click(object sender, EventArgs e)
        {

        }
    }
}
