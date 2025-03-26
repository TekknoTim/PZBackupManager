using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public partial class MainWindow : Form
    {
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
            ShowMessageBoxBackupCheckbox.Checked = Configuration.showMsgWhenBackupProcessDone;
            LoadSavegameOnLoadCheckbox.Checked = Configuration.autoSelectSavegameOnStart;
        }

        private void LoadGamemodes()
        {
            GamemodeComboBox.Items.Clear();
            GamemodeComboBox.Items.AddRange(GetGamemodes().ToArray());
        }

        private void GamemodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBackupButtonsEn(false);
            DeleteAllBackupsButton.Enabled = false;
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
            if (IsValidSavegameSelected())
            {
                BackupButton.Enabled = true;
                //MiniWindowButton.Visible = true;
                DeleteAllBackupsButton.Enabled = true;
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
                DeleteAllBackupsButton.Enabled = false;
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
            var selBackup = BackupListBox.SelectedItem;
            if (selBackup == null)
            {
                return false;
            }

            string? selBackupName = selBackup.ToString();
            if (string.IsNullOrEmpty(selBackupName))
            {
                return false;
            }
            string imageName = @"thumb.png";
            string fullBackupPATH = Configuration.currentLoadedBackupFolderPATH;
            string tmp = Path.Combine(fullBackupPATH, selBackupName);
            string thumbnailPATH = Path.Combine(tmp, imageName);
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
            GamemodeComboBox.SelectedIndex = indexGamemode;
            LoadSavegamesInSelectedGamemode();
            int indexSavegame = FindSavegameListIndexByName(savegame);
            if (indexSavegame < 0)
            {
                PrintDebug($"[SetSavegameRemote] - [Aborted] - A value is < 0 \n indexSavegame = [{indexSavegame}] \n indexGamemode = [{indexGamemode}]");
                return;
            }
            SavegameListBox.SelectedIndex = indexSavegame;
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
            int ComboBoxIdx = GamemodeComboBox.SelectedIndex;
            if (ComboBoxIdx < 0)
            {
                return false;

            }
            else
            {
                return true;
            }
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

        private void ThumbnailPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void BackgroundPanel_Paint(object sender, PaintEventArgs e)
        {

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
            RestoreButton.Enabled = val;
            DeleteBackupButton.Enabled = val;
            RenameBackupButton.Enabled = val;
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
            await backup.DoBackup(currentLoadedSavegame, currentLoadedGamemode, GetFullLoadedSavegamePath(), currentLoadedBackupFolderPATH, GetLastBackupIndexFromJson(), ProgressbarLabel, ProgressBarA, ProgressbarPanel);
            LoadAndDisplayBackups();
            SetSavegameLabelValues();
            SetBackupLabelValues();
        }

        private void ShowMessageBoxBackupCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SetShowMessageboxWhenBackupDone();
        }

        private async void SetShowMessageboxWhenBackupDone()
        {
            if (ShowMessageBoxBackupCheckbox.Checked)
            {
                Configuration.showMsgWhenBackupProcessDone = true;
            }
            else
            {
                Configuration.showMsgWhenBackupProcessDone = false;
            }
            await Configuration.WriteCfgToJson();
        }

        private void LoadSavegameOnLoadCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SetAutoSelectSavegameOnStart();
        }

        private async void SetAutoSelectSavegameOnStart()
        {
            if (LoadSavegameOnLoadCheckbox.Checked)
            {
                Configuration.autoSelectSavegameOnStart = true;
            }
            else
            {
                Configuration.autoSelectSavegameOnStart = false;
            }
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

        private void RenameBackupButton_Click(object sender, EventArgs e)
        {
            if (BackupListBox.SelectedIndex < 0 || BackupListBox.SelectedIndex >= BackupListBox.Items.Count)
            {
                MessageBox.Show($"Please select a valid backup first! Selected Index = [{BackupListBox.SelectedIndex}]");
                return;
            }
            LoadRenameBackupWindow();
        }

        private void LoadRenameBackupWindow()
        {
            var backupItem = BackupListBox.SelectedItem;
            if (backupItem == null)
            {
                return;
            }
            string? backupName = backupItem.ToString();
            if (backupName == null)
            {
                return;
            }
            var form = new RenameBackupWindow(backupName);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                RenameBackup(BackupListBox.SelectedIndex, form.InputText);
                LoadAndDisplayBackups();
                return;
            }
        }

        private async void DeleteBackupButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to delete this backup? \n Name: {GetBackupDataNameFromJson(BackupListBox.SelectedIndex)} \n Index: {BackupListBox.SelectedIndex} ", "Confirm deletion!", MessageBoxButtons.YesNo);
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

        private void MiniWindowButton_Click(object sender, EventArgs e)
        {
            LoadMiniWindow();
        }

        private void LoadMiniWindow()
        {
            var form = new MiniBackupWindow();
            this.Hide();
            form.ShowDialog();
            this.Show();
            LoadAndDisplayBackups();
        }

        private void StartHookButton_Click(object sender, EventArgs e)
        {
            LoadHookWindow();
        }

        private void LoadHookWindow()
        {
            var form = new PZScriptHook();
            this.Hide();
            form.ShowDialog();
            this.Show();
            GamemodeComboBox.SelectedIndex = currentLoadedGamemodeIndex;
            LoadSavegamesInSelectedGamemode();
            SavegameListBox.SelectedIndex = currentLoadedSavegameIndex;
            LoadAndDisplayBackups();
        }

        private async void DeleteAllBackupsButton_Click(object sender, EventArgs e)
        {
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
    }
}
