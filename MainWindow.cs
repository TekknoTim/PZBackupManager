using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Newtonsoft.Json;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;
using static ZomboidBackupManager.JsonData;
using static ZomboidBackupManager.SmartBackupProcess;
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
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text;
using SharpCompress.Common;
using ZomboidBackupManager;
using System.Xml.Linq;
using System.Collections;

namespace ZomboidBackupManager
{
    public partial class MainWindow : Form
    {
        public System.Windows.Forms.ComboBox? SavegameTestComboBox;

        public bool isInSelectionMode = false;

        public Dictionary<string, DatabaseData>? databaseDataList;

        private float ListBoxFontSize = 12f;
        private bool ListBoxFontsBolt = true;

        private string currentLoadedDataGridViewSavegame = string.Empty;

        private Dictionary<string, List<BackupStatistics>> savegameToBackupStatisticsList = [];

        public MainWindow(float fListBoxFontSize = 12f, bool bListBoxFontsBolt = true)
        {
            InitializeComponent();
            ListBoxFontSize = fListBoxFontSize;
            ListBoxFontsBolt = bListBoxFontsBolt;
            SelectSavegameLabel.Font = FontLoader.GetStyleFont(40f);
            SavegameListBox.Font = FontLoader.GetMonoFont(ListBoxFontSize, ListBoxFontsBolt);
            BackupListBox.Font = FontLoader.GetMonoFont(ListBoxFontSize, ListBoxFontsBolt);
        }

        private void SelectSavegameLabel_Click(object sender, EventArgs e)
        {
            Configuration.OnInitDone += MainWindow_OnInitDone;
            Configuration.Init();
        }

        private void ReloadForm()
        {
            PrintDebug("[MainWindow] - [ReloadingForm] - [Reloading form now...]");
            this.Hide();
            //Configuration.LoadConfigurationFromJson();
            var newForm = new MainWindow(ListBoxFontSize, ListBoxFontsBolt);
            newForm.FormClosed += (s, e) => this.Close(); // alte Form schließen, wenn neue fertig
            newForm.Show();
            PrintDebug("[MainWindow] - [ReloadingForm] - [Form Reloaded]");
        }

        private void MainWindow_OnInitDone(object? sender, string s)
        {
            PrintDebug("[MainWindow] - [OnInitDone] - [Configuration Init done!]");
            this.Invoke(new Action(() =>
            {
                ReloadForm();
                Configuration.OnInitDone -= MainWindow_OnInitDone;
            }));
        }

        private bool SelectedSavegameHasDatabaseAndIsLoaded()
        {
            if (databaseDataList == null || databaseDataList.Count == 0)
            {
                PrintDebug("[MainWindow] - [SelectedSavegameHasDatabaseAndIsLoaded] - [No databases loaded]");
                return false;
            }
            DatabaseData? data = GetSelectedDatabaseData();
            if (data != null)
            {
                PrintDebug($"[MainWindow] - [SelectedSavegameHasDatabaseAndIsLoaded] - [Loaded = {data.DatabaseLoaded}]");
                return data.DatabaseLoaded;
            }
            return false;
        }

        private bool CreateIfNotExistsAndLoadDatabase()
        {
            DatabaseData? data = GetSelectedDatabaseData();
            if (data != null)
            {
                string sResult = data.LoadDatabase(true);
                if (sResult.Equals("Created"))
                {
                    data.LoadDatabase(false);
                }
                return data.DatabaseLoaded;
            }
            return false;
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
            SetupSavegameLabelsAndBoxes();
            SetupBackupModeInfoPanel();
            if (!Configuration.smartBackupModeEnabled)
            {
                AutoDeleteBackupMenuOption.Visible = true;
                GamemodeComboBox.Visible = true;
                SetSavegameRemote();
                SetAutoDeleteInfoLabelEn(autoDeleteEnabled);
            }
            else
            {
                AutoDeleteBackupMenuOption.Visible = false;
                GamemodeComboBox.Visible = false;
                ImportDatabaseDataList();
                LoadDatabaseDataNames();
            }
            HandleSmartBackupModeElements();
            EnableExperimentalFeatures(expFeaturesEnabled);
            ShowUpdateInfoWindow();

        }

        private void SetupBackupModeInfoPanel()
        {
            SetDatabaseInfoLabelsEnabled(Configuration.smartBackupModeEnabled);
            if (Configuration.smartBackupModeEnabled)
            {
                ActiveBackupModeValueLabel.Text = "Smart";
                IsDatabaseLoadedTextLabel.Text = "Database Loaded:";
                HasBaseBackupTextLabel.Text = "Base Backup Exists";
                DatabaseData? data = GetSelectedDatabaseData();
                if (data != null)
                {
                    SetDatabasePictureBoxIcons(data.DatabaseLoaded, data.HasBaseBackup);
                }
                else
                {
                    SetDatabasePictureBoxIcons(false, false);
                }
            }
            else
            {
                ActiveBackupModeValueLabel.Text = "Default";
                IsDatabaseLoadedTextLabel.Text = "Disabled";
                HasBaseBackupTextLabel.Text = "Disabled";
                SetDatabasePictureBoxIcons(false, false, true);
            }
        }

        private void SetDatabasePictureBoxIcons(bool bLoaded, bool bHasBaseBackup, bool bClearIcons = false)
        {
            if (bClearIcons)
            {
                IsDatabaseLoadedValuePictureBox.Image = null;
                HasBaseBackupValuePictureBox.Image = null;
                return;
            }
            IsDatabaseLoadedValuePictureBox.Image = bLoaded ? Properties.Resources.CheckmarkFilled24 : Properties.Resources.Checkmark24;
            HasBaseBackupValuePictureBox.Image = bHasBaseBackup ? Properties.Resources.CheckmarkFilled24 : Properties.Resources.Checkmark24;
        }

        private void SetDatabaseInfoLabelsEnabled(bool bEnabled)
        {
            IsDatabaseLoadedTextLabel.Enabled = bEnabled;
            IsDatabaseLoadedValuePictureBox.Enabled = bEnabled;
            HasBaseBackupTextLabel.Enabled = bEnabled;
            HasBaseBackupValuePictureBox.Enabled = bEnabled;
        }

        private void SetupSavegameLabelsAndBoxes()
        {
            if (Configuration.smartBackupModeEnabled)
            {
                SavegameHeadlineLabel.Text = "Select Preset";
                SavegameListBox.Text = "Create a database preset first!";
            }
            else
            {
                SavegameHeadlineLabel.Text = "Select Savegame";
                SavegameListBox.Text = "Select a gamemode first";
            }
        }

        private void HandleSmartBackupModeElements()
        {
            if (!Configuration.smartBackupModeEnabled)
            {
                if (LoadDataBaseButton.Visible)
                {
                    LoadDataBaseButton.Visible = false;
                }
                if (OpenDatabaseSetupTSButton.Visible)
                {
                    OpenDatabaseSetupTSButton.Visible = false;
                }
                return;
            }
            if (!LoadDataBaseButton.Visible)
            {
                LoadDataBaseButton.Visible = true;
            }
            if (OpenDatabaseSetupTSButton.Visible)
            {
                OpenDatabaseSetupTSButton.Visible = true;
            }
            bool bEnabled;
            string itemName = GetSelectedDatabaseName();
            if (!string.IsNullOrWhiteSpace(itemName))
            {
                Configuration.SetLoadedBackupFolder(itemName);
                bEnabled = SelectedSavegameHasDatabaseAndIsLoaded();
                BackupButton.Enabled = bEnabled;
                LoadDataBaseButton.Enabled = !bEnabled;
                SetupBackupModeInfoPanel();
            }
            else
            {
                LoadDataBaseButton.Enabled = false;
            }
            SetupBackupModeInfoPanel();
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

        private void EnableExperimentalFeatures(bool bEnable)
        {
            SmartBackupMenuOption.Visible = bEnable;
            EnableZipCompressExpFeatures(bEnable && Configuration.saveBackupsAsZipFile);
        }

        private void EnableZipCompressExpFeatures(bool enable)
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
            if (!Configuration.smartBackupModeEnabled)
            {
                LoadSavegamesInSelectedGamemode();
                SetSavegameLabelValues();
            }
            ResetSavegameThumbnailAndData();
            ResetBackupThumbnailAndData();
            BackupListBox.Items.Clear();
        }

        private void LoadDatabaseDataNames()
        {
            if (databaseDataList != null && databaseDataList.Count > 0)
            {
                List<string> databases = databaseDataList.Keys.ToList();
                SavegameListBox.Items.Clear();
                SavegameListBox.Items.AddRange(databases.ToArray());
                PrintDebug($"[MainWindow.cs] - [LoadDatabaseDataNames] - [{databases.Count} databases loaded]");
            }
            else
            {
                PrintDebug("[MainWindow.cs] - [LoadDatabaseDataNames] - [No databases loaded]");
            }
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
            string sg = currentLoadedSavegame;
            if (Configuration.smartBackupModeEnabled)
            {
                sg = GetSelectedDatabaseName();
            }

            foreach (var backup in backupFolderList)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(currentLoadedBackupFolderPATH + sg);
                outputList.Add(dirInfo.Name);
            }

            return outputList.ToArray();

        }

        private void LoadAndDisplayBackups()
        {
            string[] backupList;
            if (Configuration.smartBackupModeEnabled)
            {
                backupList = GetAllSmartBackupDataNamesFromJson();
            }
            else
            {
                backupList = GetAllBackupDataNamesFromJson();
            }
            BackupListBox.Items.Clear();
            BackupListBox.Items.AddRange(backupList);
        }

        private void TestSwitchListBoxToComboBox()
        {
            Rectangle bounds = SavegameListBox.Bounds;

            System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox
            {
                Name = "SavegameComboBox",
                Location = bounds.Location,
                Size = bounds.Size,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = SavegameListBox.Font

            };
            comboBox.BringToFront();
            comboBox.SelectedIndexChanged += SavegameTestComboBox_SelectedIndexChanged;
            Panel? subPanel = SavegameListBox.Parent as Panel;
            if (subPanel != null)
            {
                subPanel.Controls.Add(comboBox);
            }
            else
            {
                this.Controls.Add(comboBox);
            }
            //comboBox.SelectedIndex = 0;
            comboBox.Items.AddRange(GetSavegamesInSelectedGamemode());
            comboBox.Visible = true;
            SavegameTestComboBox = comboBox;
            SavegameListBox.Visible = false;
        }

        private void SavegameTestComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (SavegameTestComboBox == null) { return; }
            SavegameListBox.SetSelected(SavegameTestComboBox.SelectedIndex, true);

        }

        private void SavegameListBox_SelectedIndexChanged(object? sender, EventArgs e)
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
            if (Configuration.smartBackupModeEnabled)
            {
                HandleSmartBackupModeElements();
                SetSavegameLabelValues();
                ResetBackupThumbnailAndData();
                return;
            }

            SetSavegameLabelValues();
            ResetBackupThumbnailAndData();
            SetBackupButtonsEn(false);
            if (Configuration.enableBackupHistory)
            {
                if (BackupHistoryDataGridView.Visible)
                {
                    LoadBackupHistoryGridView(true);
                }
                SetBackupHistoryCheckBox();
            }
            else
            {
                BackupHistoryCheckBox.Enabled = false;
            }
        }

        private void SetBackupHistoryCheckBox()
        {
            if (Configuration.currentLoadedSavegame == null || string.IsNullOrWhiteSpace(Configuration.currentLoadedSavegame))
            {
                if (BackupHistoryCheckBox.Checked)
                {
                    BackupHistoryCheckBox.Checked = false;
                }
                if (BackupHistoryCheckBox.Enabled)
                {
                    BackupHistoryCheckBox.Enabled = false;
                }
                Configuration.PrintDebug($"[MainWindow.cs] - [SetBackupHistoryCheckBox] - [Disabling CheckBox - no savegame selected/loaded]", 1);
                return;
            }
            if (BackupHistoryUtil.BackupHistoryDataExists(Configuration.currentLoadedSavegame))
            {
                if (!BackupHistoryCheckBox.Enabled)
                {
                    BackupHistoryCheckBox.Enabled = true;
                }
            }
            else
            {
                if (BackupHistoryCheckBox.Checked)
                {
                    BackupHistoryCheckBox.Checked = false;
                }
                if (BackupHistoryCheckBox.Enabled)
                {
                    BackupHistoryCheckBox.Enabled = false;
                }
            }
            Configuration.PrintDebug($"[MainWindow.cs] - [SetBackupHistoryCheckBox] - [CheckBox got enabled = {BackupHistoryCheckBox.Enabled}]");
        }

        private void SelectDatabaseData()
        {
            DatabaseData? data = GetSelectedDatabaseData();
            if (data == null)
            {
                PrintDebug("[MainWindow.cs] - [SelectDatabaseData] - [No data selected]");
                return;
            }
            string? savegame = data.Savegame;
            string? gamemode = data.Gamemode;

            bool bResult = LoadDatabaseData(savegame, gamemode);
            PrintDebug($"[MainWindow.cs] - [SelectDatabaseData] - [LoadDatabaseData bResult = {bResult}]");

            if (Configuration.smartBackupAutoLoadEnabled && !data.DatabaseLoaded)
            {
                PrintDebug("[MainWindow.cs] - [SelectDatabaseData] - [Autoloading database]");
                string sResult = data.LoadDatabase(true);
                if (sResult.Equals("Created"))
                {
                    data.LoadDatabase(false);
                }
            }
            else
            {
                return;
            }
            if (data.DatabaseLoaded)
            {
                PrintDebug($"[MainWindow.cs] - [SelectDatabaseData] - [Database loaded successfully for savegame: {savegame}, gamemode: {gamemode}]");
                Configuration.SetLoadedBackupFolder(savegame);
                LoadAndDisplayBackups();
                SetSavegameLabelValues();
            }
            else
            {
                PrintDebug("[MainWindow.cs] - [SelectDatabaseData] - [Failed to load database]");
            }
        }

        private void SelectSavegame()
        {
            if (Configuration.smartBackupModeEnabled)
            {
                SelectDatabaseData();
                return;
            }
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

        private bool LoadSavegameThumbnail()
        {
            if (GamemodeComboBox.SelectedIndex < 0)
            {
                if (!Configuration.smartBackupModeEnabled)
                {
                    return false;
                }
            }
            if (SavegameListBox.SelectedIndex < 0)
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
            string mode = GetGamemodeFromSavegameName(selSavegameName);
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
            SetBackupHistoryCheckBox();
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
            if ((listBoxIdx < 0) || (listBoxIdx > listBoxMax))
            {
                PrintDebug($"[MainWindow.cs] - [IsValidBackupSelected] - [Index out of range!] - [listBoxIdx = {listBoxIdx}] - [listBoxMax = {listBoxMax}]");
                return false;
            }
            else
            {
                PrintDebug($"[MainWindow.cs] - [IsValidBackupSelected] - [Index is in range!] - [listBoxIdx = {listBoxIdx}] - [listBoxMax = {listBoxMax}]");
                return true;
            }
        }

        private void SetBackupFolderPathTextbox()
        {
            BackupFolderPathTextbox.Text = Configuration.currentBaseBackupFolderPATH;
        }

        private void BackupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Configuration.smartBackupModeEnabled)
            {
                DatabaseData? data = GetSelectedDatabaseData();
                if (data != null)
                {
                    string? sg = data.Savegame;
                    string? gm = data.Gamemode;
                    if (string.IsNullOrEmpty(sg))
                    {
                        sg = GetSelectedDatabaseName();
                    }
                    if (string.IsNullOrEmpty(gm))
                    {
                        gm = GetSelectedDatabaseGamemode();
                    }
                    PrintDebug($"[MainWindow.cs] - [BackupListBox_SelectedIndexChanged] - [sg = {sg}] - [gm = {gm}]");
                    Configuration.LoadDatabaseData(sg, gm);
                }
            }
            else
            {
                Configuration.LoadSavegame(SavegameListBox.SelectedItem?.ToString() ?? string.Empty, GamemodeComboBox.SelectedItem?.ToString() ?? string.Empty, SavegameListBox.SelectedIndex, GamemodeComboBox.SelectedIndex);
            }
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
            if (BackupHistoryDataGridView.Visible)
            {
                SetGridViewSelectionOnListBoxSelectionChanged();
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
            bool hasLoose = false;
            bool hasZip = false;
            if (!Configuration.smartBackupModeEnabled)
            {
                hasLoose = string.IsNullOrWhiteSpace(GetBackupFolderPathFromJson(idx));
                //hasZip = string.IsNullOrWhiteSpace(GetBackupZipPathFromJson(idx));
            }
            else
            {
                hasLoose = string.IsNullOrWhiteSpace(GetSmartBackupFolderPathFromJson(idx));
                //hasZip = string.IsNullOrWhiteSpace(GetSmartBackupZipPathFromJson(idx));
            }


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
            if (Configuration.smartBackupModeEnabled)
            {
                if (databaseDataList != null && databaseDataList.Count > 0)
                {
                    DatabaseData? data = GetSelectedDatabaseData();
                    if (data != null)
                    {
                        List<SmartBackupData>? smartDataList = GetSmartBackupDataListFromJson() ?? null;
                        if (smartDataList == null || smartDataList.Count == 0)
                        {
                            return;
                        }
                        SmartRestoreProcess process = new SmartRestoreProcess(smartDataList, data.BaseBackupDir);
                        process.SmartRestoreProcessStatus += MainWindow_OnSmartRestoreProcessStatus;
                        process.StartSmartBackupProcess(data.SavegamePath, BackupListBox.SelectedIndex);
                    }
                }
            }
            else
            {
                ProgressbarPanel.Visible = true;
                SetInteractablesEnabled(false);
                Restore restore = new Restore();
                restore.OnStatusChanged += Restore_OnStatusChanged;
                await restore.DoRestore(currentLoadedSavegame, GetFullLoadedSavegamePath(), BackupListBox.SelectedIndex, ProgressBarA, ProgressbarLabel);
            }
        }

        public void MainWindow_OnSmartRestoreProcessStatus(object? sender, Status e)
        {
            if (Configuration.showMsgWhenBackupProcessDone)
            {
                MessageBox.Show($"SmartBackupProcessStatus Changed To = {e}");
            }
            LoadAndDisplayBackups();
            SetBackupLabelValues();
            ProgressbarPanel.Visible = false;
            SetInteractablesEnabled(true);
        }

        private void MainWindow_SmartBackupProcessDone(object? sender, string s)
        {
            if (Configuration.showMsgWhenBackupProcessDone)
            {
                MessageBox.Show(s);
            }
            LoadAndDisplayBackups();
            SetBackupLabelValues();
            ProgressbarPanel.Visible = false;
            SetInteractablesEnabled(true);
        }

        private async void BackupButton_Click(object sender, EventArgs e)
        {
            if (!IsValidSavegameSelected())
            {
                MessageBox.Show("Can't backup! Please load a valid savegame first!");
                return;
            }
            if (Configuration.smartBackupModeEnabled)
            {
                if (databaseDataList != null && databaseDataList.Count > 0)
                {
                    DatabaseData? data = GetSelectedDatabaseData();
                    if (data != null)
                    {
                        ProgressbarPanel.Visible = true;
                        Backup backup = new Backup();
                        backup.OnStatusChanged += SmartBackup_OnStatusChanged;
                        SmartBackupProcess.StartSmartBackupProcess(backup, data, ProgressbarLabel, ProgressBarA);
                    }
                }
            }
            else
            {
                ProgressbarPanel.Visible = true;
                SetInteractablesEnabled(false);
                Backup backup = new Backup();
                backup.OnStatusChanged += Backup_OnStatusChanged;
                await backup.DoBackup(currentLoadedSavegame, currentLoadedGamemode, GetFullLoadedSavegamePath(), currentLoadedBackupFolderPATH, GetBackupCount(), ProgressbarLabel, ProgressBarA);
            }
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
            if (!Configuration.smartBackupModeEnabled)
            {
                SavgameInfoValueLabel.Text = currentLoadedSavegame;
                GamemodeInfoValueLabel.Text = currentLoadedGamemode;
                BackupCountValueLabel.Text = GetBackupCountFromJson(false).ToString();
            }
            else
            {
                SavgameInfoTextLabel.Text = "Database/Savegame:";
                DatabaseData? data = GetSelectedDatabaseData();
                if (data == null)
                {
                    return;
                }

                SavgameInfoValueLabel.Text = data.Savegame;
                GamemodeInfoValueLabel.Text = data.Gamemode;
                BackupCountValueLabel.Text = GetBackupCountFromJson(true).ToString();
            }
        }

        private void SetBackupLabelValues()
        {
            string path;
            BackupData? data = null;
            SmartBackupData? smartData = null;

            if (Configuration.smartBackupModeEnabled)
            {
                smartData = FunctionLibrary.GetSmartBackupDataFromJson(BackupListBox.SelectedIndex);
                if (smartData == null)
                {
                    PrintDebug($"[MainWindow.cs] - [SetBackupLabelValue] - [smartData == null]", 1);
                    return;
                }
                path = smartData.Path ?? string.Empty;
            }
            else
            {
                data = FunctionLibrary.GetBackupDataFromJson(BackupListBox.SelectedIndex);
                if (data == null)
                {
                    PrintDebug($"[MainWindow.cs] - [SetBackupLabelValue] - [data == null]", 1);
                    return;
                }
                path = data.Path ?? string.Empty;
            }
            string folderName = string.Empty;
            string? s = null;
            string size = string.Empty;
            if (!Configuration.smartBackupModeEnabled)
            {
                if (string.IsNullOrEmpty(path))
                {
                    folderName = @"[ERROR]";
                }
                else
                {
                    DirectoryInfo dirData = new DirectoryInfo(path);
                    folderName = dirData.Name;
                    //folderName = Path.GetRelativePath(Configuration.currentBaseBackupFolderPATH, path);
                }
                s = data?.Size;
                if (string.IsNullOrEmpty(s))
                {
                    size = @"[ERROR]";
                }
                else
                {
                    size = s.Substring(0, 5);
                    size += @" MB";
                }
            }
            else
            {
                if (string.IsNullOrEmpty(path))
                {
                    folderName = @"[ERROR]";
                }
                else
                {
                    folderName = Path.GetRelativePath(Configuration.currentBaseBackupFolderPATH, path);
                }
                s = smartData?.Size;
                if (!string.IsNullOrWhiteSpace(s))
                {
                    size = FunctionLibrary.FormatStringBytesToDynamicSizeString(s);
                }
            }

            if (!Configuration.smartBackupModeEnabled)
            {
                BackupNameValueLabel.Text = data?.Name ?? "[Unknown]";
                BackupIndexValueLabel.Text = data?.Index.ToString() ?? "[Unknown]";
                BackupFolderValueLabel.Text = folderName;
                HasZipValuePictureBox.Image = IsBackupZipped(BackupListBox.SelectedIndex) ? Properties.Resources.CheckmarkFilled : Properties.Resources.Checkmark;
                HasLooseValuePictureBox.Image = IsBackupSavedLoose(BackupListBox.SelectedIndex) ? Properties.Resources.CheckmarkFilled : Properties.Resources.Checkmark;
                BackupDateInfoValueLabel.Text = data?.Date ?? "[Unknown]";
                BackupTimeInfoValueLabel.Text = data?.Time ?? "[Unknown]";
                BackupSizeInfoValueLabel.Text = size;
            }
            else
            {
                BackupNameValueLabel.Text = smartData?.Name ?? "[Unknown]";
                BackupIndexValueLabel.Text = smartData?.Index.ToString() ?? "[Unknown]";
                BackupFolderValueLabel.Text = folderName;
                HasZipValuePictureBox.Image = IsSmartBackupZipped(BackupListBox.SelectedIndex) ? Properties.Resources.CheckmarkFilled : Properties.Resources.Checkmark;
                HasLooseValuePictureBox.Image = IsSmartBackupSavedLoose(BackupListBox.SelectedIndex) ? Properties.Resources.CheckmarkFilled : Properties.Resources.Checkmark;
                BackupDateInfoValueLabel.Text = smartData?.Date ?? "[Unknown]";
                BackupTimeInfoValueLabel.Text = smartData?.Time ?? "[Unknown]";
                BackupSizeInfoValueLabel.Text = size;
            }
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
            RenameBackup(BackupListBox.SelectedIndex, newName, Configuration.smartBackupModeEnabled);
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
            string id = string.Empty;
            if (Configuration.enableBackupHistory)
            {
                id = FunctionLibrary.GetIDFromBackupData(idx);
            }
            Configuration.PrintDebug($"[MainWindow.cs] - [DeleteSingleBackup] - [GetIDFromBackupData] - [id = {id}]");
            Delete delete = new Delete();
            await delete.DoDelete(idx, ProgressbarLabel, ProgressBarA, ProgressbarPanel);
            if (!string.IsNullOrEmpty(id))
            {
                BackupHistoryUtil.RemoveBackupHistoryEntry(Configuration.currentLoadedSavegame, id, !Configuration.removeBackupFromHistoryOnDelete);
            }
            LoadAndDisplayBackups();
            SetSavegameLabelValues();
            SetBackupLabelValues();
            if (BackupHistoryDataGridView.Visible)
            {
                LoadBackupHistoryGridView(true);
                SetGridViewSelectionOnListBoxSelectionChanged();
            }
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
                if (BackupHistoryDataGridView.Visible)
                {
                    LoadBackupHistoryGridView(true);
                    SetGridViewSelectionOnListBoxSelectionChanged();
                }
            }

        }


        private void SmartBackup_OnStatusChanged(object? sender, Status s)
        {
            PrintDebug($"[MainWindow.cs] - [SmartBackup_OnStatusChanged] - [To = {s.ToString()}]");
            if (s == Status.FAILED)
            {
                PrintDebug($"[MainWindow.cs] - [SmartBackup_OnStatusChanged] - [Status = {s.ToString()}] ", 2);

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
            else if (s == Status.DONE || s == Status.CANCELED)
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
            CompressZipSettingMenuOption.Checked = Configuration.saveBackupsAsZipFile;
            ToggleBackupHistoryMenuOption.Checked = Configuration.enableBackupHistory;
            EnableLogMenuOption.Checked = Configuration.enableDebugLog;
            SetRemoveOnDeleteMenuOption();
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

        private void DataCleanerMenuOption_Click(object sender, EventArgs e)
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
        //--------------------------------------------[ Zip Archive Functions ]--------------------------------------------
        //=================================================================================================================


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
        //----------------------------------[ Smart Backup & DatabaseData Functions ]--------------------------------------
        //=================================================================================================================


        private DatabaseData? GetSelectedDatabaseData()
        {
            if (databaseDataList != null && databaseDataList.Count > 0)
            {
                if (SavegameListBox.SelectedItem != null && SavegameListBox.SelectedItem.ToString() != null)
                {
                    string itemName = GetSelectedDatabaseName();
                    if (databaseDataList.TryGetValue(itemName, out DatabaseData? data))
                    {
                        PrintDebug("[MainWindow.cs] - [DatabaseListBox_SelectedIndexChanged] - [Data Grid View Loaded]");
                        return data;
                    }
                    else
                    {
                        PrintDebug("[MainWindow.cs] - [DatabaseListBox_SelectedIndexChanged] - [Database not found in list]", 1);
                    }
                }
                else
                    PrintDebug("[MainWindow.cs] - [DatabaseListBox_SelectedIndexChanged] - [No valid item selected]", 1);
            }
            return null;
        }

        private string GetSelectedDatabaseName()
        {
            if (SavegameListBox.SelectedItem == null || string.IsNullOrEmpty(SavegameListBox.SelectedItem.ToString()))
            {
                PrintDebug("[MainWindow.cs] - [GetSelectedDatabaseName] - [No item selected in DatabaseListBox]", 1);
                return string.Empty;
            }
            string? itemName = SavegameListBox.SelectedItem.ToString();
            if (string.IsNullOrEmpty(itemName))
            {
                PrintDebug("[MainWindow.cs] - [GetSelectedDatabaseName] - [itemName empty]", 1);
                return string.Empty;
            }
            else
            {
                PrintDebug($"[MainWindow.cs] - [GetSelectedDatabaseName] - [itemName = {itemName}]");
                return itemName;
            }
        }

        private string GetSelectedDatabaseGamemode()
        {
            if (databaseDataList != null && databaseDataList.Count > 0)
            {
                if (SavegameListBox.SelectedItem != null && SavegameListBox.SelectedItem.ToString() != null)
                {
                    DatabaseData? data = GetSelectedDatabaseData();
                    if (data != null)
                    {
                        PrintDebug($"[MainWindow.cs] - [GetSelectedDatabaseGamemode] - [Gamemode = {data.Gamemode}]");
                        return data.Gamemode;
                    }
                    else
                    {
                        PrintDebug($"[MainWindow.cs] - [GetSelectedDatabaseGamemode] - [Database = null]", 1);
                    }
                }
                else
                {
                    PrintDebug($"[MainWindow.cs] - [GetSelectedDatabaseGamemode] - [No valid item selected]", 1);
                }
            }
            return string.Empty;
        }

        private (bool, string) LoadOrCreateDatabase(string savegame)
        {
            Thread.Sleep(500);
            if (databaseDataList == null || databaseDataList.Count == 0)
            {
                MessageBox.Show("DatabaseList Empty");
                Thread.Sleep(100);
                return (false, "List ERROR");
            }
            bool result = databaseDataList.TryGetValue(savegame, out DatabaseData? data);
            if (!result)
            {
                Thread.Sleep(100);
                return (false, "GetValue ERROR");
            }
            if (data == null)
            {
                Thread.Sleep(100);
                return (false, "data null ERROR");
            }
            string strResult = data.LoadDatabase(true);
            WriteDatabaseDataToJson(databaseDataList);
            Thread.Sleep(100);
            return (true, strResult);
        }

        private void WriteDatabaseDataToJson(Dictionary<string, DatabaseData> data)
        {
            if (data == null)
            {
                PrintDebug("[MainWindow] - [WriteDatabaseDataToJson] - [Aborted] - Data is null!");
                return;
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Formatting.Indented);
            string filePath = Configuration.databaseDataListFile;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                PrintDebug("[MainWindow] - [WriteDatabaseDataToJson] - [Aborted] - Database path is null or empty!", 2);
                return;
            }
            if (!File.Exists(filePath))
            {
                PrintDebug($"[MainWindow] - [WriteDatabaseDataToJson] - [Creating new file at {filePath}]");
                File.Create(filePath).Close();
            }

            File.WriteAllText(filePath, json);
            PrintDebug($"[MainWindow] - [WriteDatabaseDataToJson] - [Data written to {filePath}]");
        }


        private void ExportDatabaseDataList()
        {
            if (databaseDataList == null)
            {
                PrintDebug($"[MainWindow.cs] - [ExportDatabaseDataList] - [Can't export empty list to json file]", 1);
                return;
            }
            WriteDatabaseDataToJson(databaseDataList);
        }

        private void ImportDatabaseDataList()
        {
            databaseDataList = ReadDatabaseDataFromJson();
        }

        private Dictionary<string, DatabaseData>? ReadDatabaseDataFromJson()
        {
            if (!File.Exists(Configuration.databaseDataListFile))
            {
                File.Create(Configuration.databaseDataListFile).Close();
            }
            string jsonData = File.ReadAllText(Configuration.databaseDataListFile);
            Dictionary<string, DatabaseData>? dataList = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, DatabaseData>>(jsonData);
            return dataList;
        }



        private void SmartBackupMenuOption_Click(object sender, EventArgs e)
        {
            List<string> gamemodes = GamemodeComboBox.Items.Cast<string>().ToList();
            List<string> savegames = SavegameListBox.Items.Cast<string>().ToList();
            SmartBackupSetupWindow smartBackWin = new SmartBackupSetupWindow(gamemodes, savegames, databaseDataList);
            DialogResult dResult = smartBackWin.ShowDialog();
            if (dResult == DialogResult.Cancel)
            {
                PrintDebug($"[MainWindow] - [SmartBackupMenuOption_Click] - [DialogResult was = {dResult.ToString()}]");
                return;
            }
            databaseDataList = smartBackWin.DBList;
            bool modeChanged = smartBackWin.WasSmartModeEnabled != Configuration.smartBackupModeEnabled;
            if (modeChanged)
            {
                PrintDebug($"[MainWindow] - [SmartBackupMenuOption_Click] - [DialogResult was = {dResult.ToString()}] - [modeChanged = {modeChanged}] - [Doing ReInit]");
                ReloadForm();
                return;
            }
            LoadDatabaseDataNames();
            HandleSmartBackupModeElements();
        }

        private void BackupsPictureBox_Click(object sender, EventArgs e)
        {
            //TestSwitchListBoxToComboBox();
        }

        private void SmartBackupDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadDataBaseButton_Click(object sender, EventArgs e)
        {
            HandleLoadDatabaseButton();
        }

        private void HandleLoadDatabaseButton()
        {
            DatabaseData? data = GetSelectedDatabaseData();
            if (data == null)
            {
                PrintDebug("[MainWindow.cs] - [LoadDataBaseButton_Click] - [data is null]", 1);
                return;
            }
            string sResult = data.LoadDatabase(false);
            if (!sResult.Equals("Loaded"))
            {
                PrintDebug($"[MainWindow.cs] - [LoadDataBaseButton_Click] - [Failed to load database: {sResult}]", 1);
                DialogResult dialogResult = MessageBox.Show("Database loaded!\n" + sResult, "Information", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Retry)
                {
                    PrintDebug("[MainWindow.cs] - [LoadDataBaseButton_Click] - [Retrying to load database]");
                    HandleLoadDatabaseButton(); // Retry loading the database
                }
                else
                {
                    PrintDebug("[MainWindow.cs] - [LoadDataBaseButton_Click] - [User canceled loading database]");
                    return; // User canceled, do not proceed
                }
            }
            else
            {
                PrintDebug("[MainWindow.cs] - [LoadDataBaseButton_Click] - [Database loaded successfully]");
                HandleSmartBackupModeElements();
                SetSavegameLabelValues();
                ResetBackupThumbnailAndData();
            }
        }

        private void OpenDatabaseSetupTSButton_Click(object sender, EventArgs e)
        {
            SmartBackupMenuOption_Click(sender, e);
        }

        private void BackupHistoryCheckBox_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Configuration.absoluteBackupHistoryFilePATH))
            {
                BackupHistoryDataGridView.Visible = false;
                BackupHistoryCheckBox.Enabled = false;
                PrintDebug("[MainWindow.cs] - [BackupHistoryCheckBox_CheckedChanged] - [Backup history file not found!] - [Checkbox disabled]", 1);
                MessageBox.Show($"Backup history file not found! \nMake sure, following file is existing! \n{Configuration.absoluteBackupHistoryFilePATH}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Configuration.enableBackupHistory)
            {
                if (BackupHistoryCheckBox.Checked)
                {
                    PrintDebug("[MainWindow.cs] - [BackupHistoryCheckBox_CheckedChanged] - [Checkbox checked]");
                    BackupHistoryDataGridView.Visible = true;
                    LoadBackupHistoryGridView(true);
                }
                else
                {
                    PrintDebug("[MainWindow.cs] - [BackupHistoryCheckBox_CheckedChanged] - [Checkbox unchecked]");
                    BackupHistoryDataGridView.Visible = false;
                }
            }
            else
            {
                PrintDebug("[MainWindow.cs] - [BackupHistoryCheckBox_CheckedChanged] - [Backup history disabled in config]");
                if (BackupHistoryCheckBox.Checked)
                {
                    BackupHistoryCheckBox.Checked = false;
                }
                if (BackupHistoryCheckBox.Enabled)
                {
                    BackupHistoryCheckBox.Enabled = false;
                }
                if (BackupHistoryDataGridView.Visible)
                {
                    BackupHistoryDataGridView.Visible = false;
                }
                MessageBox.Show("Statistics are currently disabled. \nYou can enable this feature via the settings drop down menu. \n(Settings -> Statistics -> Load Backup History)", "Feature Disabled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BackupHistoryDataGridView_VisibleChanged(object sender, EventArgs e)
        {
            if (BackupHistoryDataGridView.Visible)
            {
                LoadBackupHistoryGridView(false);
            }
        }

        private void LoadBackupHistoryGridView(bool forceReload = false)
        {
            if (currentLoadedSavegame == null)
            {
                PrintDebug("[MainWindow.cs] - [BackupHistoryDataGridView_VisibleChanged] - [currentLoadedSavegame is null]", 1);
                currentLoadedDataGridViewSavegame = string.Empty;
                return;
            }
            if (currentLoadedDataGridViewSavegame.Equals(currentLoadedSavegame) && !forceReload)
            {
                PrintDebug("[MainWindow.cs] - [BackupHistoryDataGridView_VisibleChanged] - [currentLoadedDataGridViewSavegame is already loaded]");
                return;
            }
            List<BackupStatistics> statisticsList = BackupHistoryUtil.ImportAndBuildBackupStatisticsList(currentLoadedSavegame);
            if (statisticsList == null || statisticsList.Count == 0)
            {
                PrintDebug("[MainWindow.cs] - [BackupHistoryDataGridView_VisibleChanged] - [No backup history data found for current savegame]", 1);
                BackupHistoryDataGridView.Rows.Clear();
                BackupHistoryCheckBox.Checked = false;
                BackupHistoryDataGridView.Visible = false;
                return;
            }
            if (savegameToBackupStatisticsList.ContainsKey(currentLoadedSavegame))
            {
                PrintDebug($"[MainWindow.cs] - [BackupHistoryDataGridView_VisibleChanged] - [Dictionary already contains key = {currentLoadedSavegame}]");
                bool result = savegameToBackupStatisticsList.Remove(currentLoadedSavegame);
                PrintDebug($"[MainWindow.cs] - [BackupHistoryDataGridView_VisibleChanged] - [Removing {currentLoadedSavegame} from dictionary was successful = {result}]");
                if (!result)
                {
                    return;
                }
            }
            savegameToBackupStatisticsList.Add(currentLoadedSavegame, statisticsList);
            BackupHistoryUtil.SetupBackupHistoryGridView(statisticsList, BackupHistoryDataGridView);
            currentLoadedDataGridViewSavegame = currentLoadedSavegame;
            BackupHistoryDataGridView.Refresh();
        }

        //========================================================================================================================================
        //----------------------------------------------[ Set ListBox When GridView Selection Changes ]-------------------------------------------
        //========================================================================================================================================
        private void BackupHistoryDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (BackupHistoryDataGridView.SelectedRows.Count == 0)
            {
                PrintDebug("[MainWindow.cs] - [BackupHistoryDataGridView_SelectionChanged] - [No rows selected]", 1);
                return;
            }
            int selIndex = BackupHistoryDataGridView.SelectedRows[0].Index;
            if (selIndex < 0)
            {
                PrintDebug($"[MainWindow.cs] - [BackupHistoryDataGridView_SelectionChanged] - [Invalid selection index: {selIndex}]", 1);
                BackupListBox.SelectedItem = null;
                return;
            }
            string id = BackupHistoryUtil.GetIdAtIndex(savegameToBackupStatisticsList[currentLoadedSavegame], selIndex);
            int idx = GetBackupDataIndexByID(id);
            if (idx < 0)
            {
                PrintDebug($"[MainWindow.cs] - [BackupHistoryDataGridView_SelectionChanged] - [ID not found: {id}]", 1);
                BackupListBox.SelectedItem = null;
                return;
            }
            BackupListBox.SelectedIndex = idx;
        }


        //========================================================================================================================================
        //---------------------------------------------[ Set GridView When ListBox Selection Changes ]-------------------------------------------
        //========================================================================================================================================

        private void SetGridViewSelectionOnListBoxSelectionChanged()
        {
            if (!Configuration.enableBackupHistory)
            {
                PrintDebug($"[MainWindow.cs] - [SetGridViewSelectionOnListBoxSelectionChanged] - [Aborting - backup statistics disabled]");
                if (BackupHistoryDataGridView.Visible)
                {
                    BackupHistoryDataGridView.Visible = false;
                }
                return;
            }
            if (BackupListBox.SelectedIndex < 0 || BackupListBox.SelectedIndex >= BackupListBox.Items.Count)
            {
                PrintDebug($"[MainWindow.cs] - [SetGridViewSelectionOnListBoxSelectionChanged] - [Invalid selected index: {BackupListBox.SelectedIndex}]", 1);
                BackupHistoryDataGridView.ClearSelection();
                return;
            }
            string id = GetIDFromBackupData(BackupListBox.SelectedIndex);
            if (string.IsNullOrEmpty(id))
            {
                PrintDebug("[MainWindow.cs] - [SetGridViewSelectionOnListBoxSelectionChanged] - [ID is null or empty]", 1);
                BackupHistoryDataGridView.ClearSelection();
                return;
            }
            int idx = BackupHistoryUtil.GetGridViewRowIndexByID(savegameToBackupStatisticsList[currentLoadedSavegame], id);
            if (idx < 0)
            {
                PrintDebug($"[MainWindow.cs] - [SetGridViewSelectionOnListBoxSelectionChanged] - [ID not found: {id}]", 1);
                BackupHistoryDataGridView.ClearSelection();
                return;
            }
            BackupHistoryDataGridView.ClearSelection();
            BackupHistoryDataGridView.Rows[idx].Selected = true;

        }

        private void ToggleBackupHistoryMenuOption_Click(object sender, EventArgs e)
        {
            Configuration.enableBackupHistory = !Configuration.enableBackupHistory;
            ToggleBackupHistoryMenuOption.Checked = Configuration.enableBackupHistory;
            Configuration.SaveConfig();
            if (Configuration.enableBackupHistory)
            {
                SetBackupHistoryCheckBox();
            }
            else
            {
                BackupHistoryCheckBox.Checked = false;
                BackupHistoryCheckBox.Enabled = false;
                if (BackupHistoryDataGridView.Visible)
                {
                    BackupHistoryDataGridView.Visible = false;
                }
            }
        }

        private void RemoveOnDeleteMenuOption_Click(object sender, EventArgs e)
        {
            Configuration.removeBackupFromHistoryOnDelete = !Configuration.removeBackupFromHistoryOnDelete;
            Configuration.SaveConfig();
            SetRemoveOnDeleteMenuOption();
        }

        private void SetRemoveOnDeleteMenuOption()
        {
            if (!Configuration.enableBackupHistory)
            {
                if (RemoveOnDeleteMenuOption.Enabled)
                {
                    RemoveOnDeleteMenuOption.Enabled = false;
                    return;
                }
            }
            if (!RemoveOnDeleteMenuOption.Enabled)
            {
                RemoveOnDeleteMenuOption.Enabled = true;
            }
            RemoveOnDeleteMenuOption.Checked = Configuration.removeBackupFromHistoryOnDelete;
        }

        private void EnableLogMenuOption_Click(object sender, EventArgs e)
        {
            bool wasEnabled = Configuration.enableDebugLog;
            Configuration.enableDebugLog = !Configuration.enableDebugLog;
            EnableLogMenuOption.Checked = Configuration.enableDebugLog;
            Configuration.SaveConfig();
            if (Configuration.enableDebugLog && Configuration.enableDebugLog != wasEnabled)
            {
                DialogResult result = MessageBox.Show("Debug log enabled! \nPlease restart the manager, \nto start logging debug informations. \nDo you want to close the app now?", "Please Restart Application!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void DeleteRowMenuOption_Click(object sender, EventArgs e)
        {
            if (BackupHistoryDataGridView.SelectedRows.Count == 0)
            {
                PrintDebug("[MainWindow.cs] - [DeleteRowMenuOption_Click] - [No rows selected]", 1);
                return;
            }
            int selIndex = BackupHistoryDataGridView.SelectedRows[0].Index;
            if (selIndex < 0 || selIndex >= BackupHistoryDataGridView.Rows.Count)
            {
                PrintDebug($"[MainWindow.cs] - [DeleteRowMenuOption_Click] - [Invalid selection index: {selIndex}]", 1);
                return;
            }
            DialogResult result = MessageBox.Show("Do you really want to delete the selected row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                PrintDebug("[MainWindow.cs] - [DeleteRowMenuOption_Click] - [User canceled deletion]");
                return;
            }
            BackupHistoryUtil.DeleteBackupHistoryEntryAtIndex(currentLoadedSavegame, selIndex);
            LoadBackupHistoryGridView(true);
        }

        private void BackupHistoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}