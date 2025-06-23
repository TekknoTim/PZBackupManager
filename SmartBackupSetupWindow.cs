using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public partial class SmartBackupSetupWindow : Form
    {
        private bool wasSmartModeEnabled;

        private List<string> gamemodes;
        private List<string> savegames;

        private Dictionary<string, DatabaseData>? dBList;
        public Dictionary<string, DatabaseData>? DBList { get { return dBList; } }

        private int maxDataGridRows = 50;

        private int currentPage = 1;

        public bool WasSmartModeEnabled { get { return wasSmartModeEnabled; } }
        public event EventHandler<int>? OnChangeDataGridViewMode;

        public SmartBackupSetupWindow(List<string> gm, List<string> sg, Dictionary<string, DatabaseData>? db)
        {
            InitializeComponent();
            gamemodes = gm;
            savegames = sg;
            GamemodeComboBox.DataSource = gamemodes;
            LoadSavegamesInSelectedGamemode();
            wasSmartModeEnabled = Configuration.smartBackupModeEnabled;
            SetGridViewRadioButtonsEnabled(Configuration.smartBackupModeEnabled);
            SetRadioButtonsState(Configuration.smartBackupModeEnabled);
            SetAutoSetupRadioButtonsState(Configuration.databaseGridViewMode);
            SetPanelsVisibile(Configuration.smartBackupModeEnabled);
            SetSmartBackupAutoload(Configuration.smartBackupAutoLoadEnabled, false);
            if (db == null || db.Count <= 0)
            {
                ImportDatabaseDataList();
            }
            else
            {
                dBList = db;
                RefreshDatabaseListbox();
            }
        }

        private void LoadSavegamesInSelectedGamemode()
        {
            var savegameList = GetSavegamesInSelectedGamemode();
            SavegameComboBox.Items.Clear();
            SavegameComboBox.Items.AddRange(savegameList);
            currentLoadedGamemodeIndex = GamemodeComboBox.SelectedIndex;
        }

        private string[] GetSavegamesInSelectedGamemode()
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

        private void SetPanelsVisibile(bool bSet)
        {
            TopRightMainPanel.Visible = bSet;
            DatabaseSetupPanel.Visible = bSet;
        }

        private void SetRadioButtonsState(bool bSet)
        {
            EnableSmartBackupRadioButton.Checked = bSet;
            DisableSmartBackupRadioButton.Checked = !bSet;
        }

        private void SetAutoSetupRadioButtonsState(int id)
        {

            if (id == 0)
            {
                DisableGridViewButton.Checked = true;
                EnableGridViewMode1Button.Checked = false;
                EnableGridViewMode2Button.Checked = false;
            }
            else if (id == 1)
            {
                DisableGridViewButton.Checked = false;
                EnableGridViewMode1Button.Checked = true;
                EnableGridViewMode2Button.Checked = false;
            }
            else if (id == 2)
            {
                DisableGridViewButton.Checked = false;
                EnableGridViewMode1Button.Checked = false;
                EnableGridViewMode2Button.Checked = true;
            }
            else
            {
                DisableGridViewButton.Checked = true;
                EnableGridViewMode1Button.Checked = false;
                EnableGridViewMode2Button.Checked = false;
            }
            OnChangeDataGridViewMode?.Invoke(this, id);
        }

        private void SetGridViewRadioButtonsEnabled(bool bEnabled)
        {
            DisableGridViewButton.Enabled = bEnabled;
            EnableGridViewMode1Button.Enabled = bEnabled;
            EnableGridViewMode2Button.Enabled = bEnabled;
        }

        private bool ToggleSmartBackupMode()
        {
            bool smartModeEnabled = Configuration.smartBackupModeEnabled;
            smartModeEnabled = !smartModeEnabled;
            Configuration.SetSmartBackupMode(smartModeEnabled);
            SetRadioButtonsState(smartModeEnabled);
            return smartModeEnabled;
        }

        private void DisableSmartBackupRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            bool bEnabled = ToggleSmartBackupMode();
            SetGridViewRadioButtonsEnabled(bEnabled);
            //MessageBox.Show($"Smart Backup Mode Enabled = {bEnabled}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EnableSmartBackupRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            bool bEnabled = ToggleSmartBackupMode();
            SetGridViewRadioButtonsEnabled(bEnabled);
            //MessageBox.Show($"Smart Backup Mode Enabled = {bEnabled}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DisableAutoCreateDBRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            SetAutoSetupRadioButtonsState(0);
        }

        private void EnableAutoCreateSemiDBRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            SetAutoSetupRadioButtonsState(1);
        }

        private void EnableAutoCreateAllDBRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            SetAutoSetupRadioButtonsState(2);
        }

        private void GamemodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSavegamesInSelectedGamemode();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (!IsValidSavegameSelected()) { return; }
            DatabaseData? data = GetNewDatabaseData(SavegameComboBox.SelectedItem?.ToString() ?? null, GamemodeComboBox.SelectedItem?.ToString() ?? null);
            if (data == null)
            {
                PrintDebug("[MainWindow] - [CreateButton_Click] - [Aborted] - Data is null!");
                return;
            }
            if (dBList == null)
            {
                dBList = new Dictionary<string, DatabaseData>();
            }
            if (string.IsNullOrWhiteSpace(data.Savegame) || string.IsNullOrWhiteSpace(data.Gamemode))
            {
                PrintDebug("[MainWindow] - [CreateButton_Click] - [Aborted] - Savegame was null or empty!");
                return;
            }
            bool bResult = dBList.TryAdd(data.Savegame, data);
            if (!bResult)
            {
                DialogResult dialogRes = MessageBox.Show($"Database for [{data.Savegame}] already exists in the list! \n\nDo you want to override this preset?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogRes == DialogResult.Yes)
                {
                    dBList[data.Savegame] = data; // Override existing entry
                }
                else
                {
                    PrintDebug("[MainWindow] - [CreateButton_Click] - [Aborted] - User chose not to override existing database entry.");
                    return;
                }
            }
            PrintDebug($"[MainWindow] - [CreateButton_Click] - [New DatabaseData created for {data.Savegame} in {data.Gamemode}]");
            ExportDatabaseDataList();
            RefreshDatabaseListbox();
        }

        private bool IsValidSavegameSelected()
        {
            return (GamemodeComboBox.SelectedItem != null && SavegameComboBox.SelectedItem != null);
        }

        private DatabaseData? GetNewDatabaseData(string? savegame, string? gamemode)
        {
            if (string.IsNullOrWhiteSpace(savegame) || string.IsNullOrWhiteSpace(gamemode)) { return null; }
            DatabaseData data = new DatabaseData(savegame, gamemode, Configuration.GetFullSavegameFolderPath(gamemode, savegame), currentBaseBackupFolderPATH + @"\" + savegame, Configuration.GetDatabasePath(savegame));
            return data;
        }

        private void WriteDatabaseDataToJson(Dictionary<string, DatabaseData>? data)
        {
            if (data == null)
            {
                //PrintDebug("[MainWindow] - [WriteDatabaseDataToJson] - [Aborted] - Data is null!");
                data = new Dictionary<string, DatabaseData>();
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
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

        private void RefreshDatabaseListbox()
        {
            if (dBList == null || dBList.Count == 0)
            {
                PrintDebug("[MainWindow] - [ImportDatabaseDataList] - [No data found in json file or file is empty]", 1);
                return;
            }
            DatabaseListBox.Items.Clear();
            DatabaseListBox.Items.AddRange(dBList.Keys.ToArray());
        }

        private void ExportDatabaseDataList()
        {
            if (dBList == null)
            {
                PrintDebug($"[MainWindow] - [ExportDatabaseDataList] - [Can't export empty list to json file]", 1);
                return;
            }
            WriteDatabaseDataToJson(dBList);
        }

        private void ImportDatabaseDataList()
        {
            dBList = ReadDatabaseDataFromJson();
            RefreshDatabaseListbox();
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

        private void SetupDataGridView(DatabaseData data)
        {
            string databasePath = GetDatabasePath(currentLoadedSavegame);
            bool bDBExists = File.Exists(databasePath);
            DatabaseGridView dbGridView = new DatabaseGridView(data);
            Dictionary<string, string> gridviewList = dbGridView.GetStringList();
            List<string> pNames = gridviewList.Keys.ToList();
            List<string> pValues = gridviewList.Values.ToList();


            DatabaseDisplayGridView.SendToBack();
            DatabaseDisplayGridView.Visible = false;
            DatabaseInfoGridView.BringToFront();
            DatabaseInfoGridView.Visible = true;
            DatabaseInfoGridView.Rows.Clear();
            DatabaseInfoGridView.Columns.Clear();

            DatabaseInfoGridView.ColumnCount = 1;
            DatabaseInfoGridView.Columns[0].Name = "Value";

            string[] rowA = new string[] { pValues[0] };
            string[] rowB = new string[] { pValues[1] };
            string[] rowC = new string[] { pValues[2] };
            string[] rowD = new string[] { pValues[3] };
            string[] rowE = new string[] { pValues[4] };
            string[] rowF = new string[] { pValues[5] };
            string[] rowG = new string[] { pValues[6] };
            string[] rowH = new string[] { pValues[7] };
            string[] rowI = new string[] { pValues[8] };
            string[] rowJ = new string[] { pValues[9] };
            string[] rowK = new string[] { pValues[10] };

            DatabaseInfoGridView.Rows.Add(rowA);
            DatabaseInfoGridView.Rows.Add(rowB);
            DatabaseInfoGridView.Rows.Add(rowC);
            DatabaseInfoGridView.Rows.Add(rowD);
            DatabaseInfoGridView.Rows.Add(rowE);
            DatabaseInfoGridView.Rows.Add(rowF);
            DatabaseInfoGridView.Rows.Add(rowG);
            DatabaseInfoGridView.Rows.Add(rowH);
            DatabaseInfoGridView.Rows.Add(rowI);
            DatabaseInfoGridView.Rows.Add(rowJ);
            DatabaseInfoGridView.Rows.Add(rowK);

            DatabaseInfoGridView.TopLeftHeaderCell.Value = "Property";
            foreach (DataGridViewRow row in DatabaseInfoGridView.Rows)
            {
                row.HeaderCell.Value = pNames[row.Index];
            }
            DatabaseInfoGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            DatabaseInfoGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            DatabaseInfoGridView.Invalidate();
        }

        private void SetupDataBaseGridView(DatabaseData data)
        {
            if (!data.DatabaseLoaded)
            {
                data.LoadDatabase(false);
            }
            Dictionary<string, FileRecord>? database = data.Database;
            if (database == null || database.Count == 0 || DatabaseDisplayGridView.Columns == null)
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [SetupDataBaseGridView] - [No database found]", 1);
                return;
            }
            DatabaseInfoGridView.SendToBack();
            DatabaseInfoGridView.Visible = false;
            DatabaseDisplayGridView.BringToFront();
            DatabaseDisplayGridView.Visible = true;
            DatabaseDisplayGridView.AutoGenerateColumns = false;
            DatabaseDisplayGridView.Columns.Clear();
            DatabaseDisplayGridView.Rows.Clear();
            DatabaseDisplayGridView.Columns.Add("Key", "Schlüssel");
            DatabaseDisplayGridView.Columns.Add("FilePath", "Dateipfad");
            DatabaseDisplayGridView.Columns.Add("Size", "Größe (Bytes)");
            DatabaseDisplayGridView.Columns.Add("LastModifiedUtc", "Zuletzt geändert (UTC)");
            var sizeColumn = DatabaseDisplayGridView.Columns["Size"];
            if (sizeColumn != null)
            {
                sizeColumn.DefaultCellStyle.Format = "N0";
            }
            var lastModifiedColumn = DatabaseDisplayGridView.Columns["LastModifiedUtc"];
            if (lastModifiedColumn != null)
            {
                lastModifiedColumn.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            }
            DatabaseDisplayGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DatabaseDisplayGridView.SuspendLayout();
            try
            {
                int pageCount = GetPageCount(database.Count);
                int j = GetGridViewStartIndexOfPage(currentPage, maxDataGridRows, database.Count);
                int count = 0;
                for (int i = j; i < maxDataGridRows * currentPage; i++)
                {
                    var kvp = database.ElementAtOrDefault(i);
                    if (count >= maxDataGridRows)
                    {
                        break;
                    }
                    DatabaseDisplayGridView.Rows.Add(kvp.Key, kvp.Value.FilePath ?? "ERROR", kvp.Value.Size.ToString() ?? "ERROR", kvp.Value.LastModifiedUtc.ToString() ?? "ERROR");
                    count++;
                }
            }
            finally
            {
                DatabaseDisplayGridView.ResumeLayout();
            }

            DatabaseDisplayGridView.Refresh();
        }

        private void SetCurrentPageTextLabel(int pageCount)
        {
            if (pageCount <= 0)
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [SetCurrentPageTextLabel] - [No pages available]", 1);
                GridViewPageLabel.Text = $"[0/0]";
                return;
            }
            GridViewPageLabel.Text = $"[{currentPage}/{pageCount - 1}]";
        }

        private int GetGridViewStartIndexOfPage(int iPage, int iEntriesPerPage, int iAllEntries)
        {
            int iPageIdx = iPage - 1; // Convert to zero-based index
            int pageCount = GetPageCount(iAllEntries);
            if (iPageIdx < 0 || iPageIdx >= pageCount)
            {
                PrintDebug($"[SmartBackupSetupWindow.cs] - [GetGridViewStartIndexOfPage] - [Invalid page index: {iPageIdx}]", 1);
                return 0;
            }
            int startIndex = iPageIdx * iEntriesPerPage;
            if (startIndex <= 0)
            {
                startIndex = 1;
            }
            if (startIndex >= iAllEntries)
            {
                PrintDebug($"[SmartBackupSetupWindow.cs] - [GetGridViewStartIndexOfPage] - [Start index {startIndex} exceeds total entries {iAllEntries}]", 1);
                return 0;
            }
            PrintDebug($"[SmartBackupSetupWindow.cs] - [GetGridViewStartIndexOfPage] - [Start index for page {iPage} is {startIndex}]");
            return startIndex;
        }

        private int GetPageCount(int iAllEntries)
        {
            return (int)Math.Ceiling((double)iAllEntries / maxDataGridRows);
        }

        private void DatabaseListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DatabaseInfoGridView.Visible)
            {
                ReloadDatabaseGridView();
            }
        }

        private void LoadDatabaseToGridView()
        {
            DatabaseData? data = GetSelectedDatabaseData();
            if (data == null)
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [DatabaseListBox_SelectedIndexChanged] - [No data found for selected database]", 1);
                return;
            }
            SetCurrentPageTextLabel(GetPageCount(data.DBSize));
            SetupDataBaseGridView(data);
        }

        private void ReloadDatabaseGridView()
        {
            DatabaseData? data = GetSelectedDatabaseData();
            if (data == null)
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [DatabaseListBox_SelectedIndexChanged] - [No data found for selected database]", 1);
                return;
            }
            SetupDataGridView(data);
        }

        private DatabaseData? GetSelectedDatabaseData()
        {
            if (dBList != null && dBList.Count > 0)
            {
                if (DatabaseListBox.SelectedItem != null && DatabaseListBox.SelectedItem.ToString() != null)
                {
                    string itemName = GetSelectedDatabaseName();
                    if (dBList.TryGetValue(itemName, out DatabaseData? data))
                    {
                        PrintDebug("[SmartBackupSetupWindow.cs] - [DatabaseListBox_SelectedIndexChanged] - [Data Grid View Loaded]");
                        return data;
                    }
                    else
                    {
                        PrintDebug("[SmartBackupSetupWindow.cs] - [DatabaseListBox_SelectedIndexChanged] - [Database not found in list]", 1);
                    }
                }
                else
                {
                    PrintDebug("[SmartBackupSetupWindow.cs] - [DatabaseListBox_SelectedIndexChanged] - [No valid item selected]", 1);
                }
            }
            return null;
        }

        private string GetSelectedDatabaseName()
        {
            if (DatabaseListBox.SelectedItem == null || string.IsNullOrEmpty(DatabaseListBox.SelectedItem.ToString()))
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [GetSelectedDatabaseName] - [No item selected in DatabaseListBox]", 1);
                return string.Empty;
            }
            string? itemName = DatabaseListBox.SelectedItem.ToString();
            if (string.IsNullOrEmpty(itemName))
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [GetSelectedDatabaseName] - [itemName empty]", 1);
                return string.Empty;
            }
            else
            {
                PrintDebug($"[SmartBackupSetupWindow.cs] - [GetSelectedDatabaseName] - [itemName = {itemName}]");
                return itemName;
            }
        }

        private void DatabaseDisplayGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            object? clickedCellValue = DatabaseDisplayGridView[0, e.RowIndex].Value;
            if (clickedCellValue != null)
            {
                if (e.RowIndex == 0)
                {
                    ReloadDatabaseGridView();
                }
            }
        }

        private void SmartBackupDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            string? valueString;
            object? clickedCellValue = DatabaseInfoGridView[0, e.RowIndex].Value;
            if (clickedCellValue != null)
            {
                if (e.RowIndex == 0)
                {

                }
                else if (e.RowIndex == 2 || e.RowIndex == 3)
                {
                    string? path = clickedCellValue.ToString();
                    if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                    {
                        Process.Start("explorer.exe", path);
                    }
                    else
                    {
                        MessageBox.Show($"can't open directory: {path}");
                    }
                }
                else if (e.RowIndex == 4)
                {
                    valueString = clickedCellValue.ToString();
                    string? path = Path.GetDirectoryName(valueString);
                    if (path != null)
                    {
                        Process.Start("explorer.exe", path);
                    }
                    else
                    {
                        MessageBox.Show($"can't open directory: {valueString}");
                    }
                }
                else if (e.RowIndex == 5)
                {
                    if (clickedCellValue.Equals("True"))
                    {
                        DialogResult result = MessageBox.Show("Do you want to delete this database?", "Delete Database", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            DatabaseData? data = GetSelectedDatabaseData();
                            if (data != null)
                            {
                                data.DBSize = 0;
                                data.DBDateCreated = DateTime.MinValue;
                                data.DBDateEdited = DateTime.MinValue;
                                data.ClearDatabase();
                                PrintDebug($"[SmartBackupDataGridView_CellClick] - [Database deleted]");
                                WriteDatabaseDataToJson(dBList);
                                SetupDataGridView(data);
                            }
                            else
                            {
                                MessageBox.Show("DatabaseData not found for current savegame.");
                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show($"Do you want to create a database for this savegame? \n\nSavegame = {GetSelectedDatabaseName()}", "Create Database", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            DatabaseData? data = GetSelectedDatabaseData();
                            if (data != null)
                            {
                                string sResult = data.LoadDatabase(true);
                                PrintDebug($"[SmartBackupDataGridView_CellClick] - [Database {sResult}]");
                                WriteDatabaseDataToJson(dBList);
                                SetupDataGridView(data);
                            }
                            else
                            {
                                MessageBox.Show("DatabaseData not found for current savegame.");
                            }
                        }
                    }
                }

                else if (e.RowIndex == 6)
                {
                    if (clickedCellValue.Equals("False"))
                    {
                        DialogResult result = MessageBox.Show("Do you want to load this database?", "Load Database", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            DatabaseData? data = GetSelectedDatabaseData();
                            if (data != null)
                            {
                                data.LoadDatabase(false);
                                PrintDebug($"[SmartBackupDataGridView_CellClick] - [Database loaded = {data.DatabaseLoaded}]");
                                WriteDatabaseDataToJson(dBList);
                                SetupDataGridView(data);
                            }
                            else
                            {
                                MessageBox.Show("DatabaseData not found for current savegame.");
                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Do you want to delete this database?", "Delete Database", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            bool success = dBList!.TryGetValue(currentLoadedSavegame, out DatabaseData? data);
                            if (success && data != null)
                            {
                                data.DBSize = 0;
                                data.DBDateCreated = DateTime.MinValue;
                                data.DBDateEdited = DateTime.MinValue;
                                data.ClearDatabase();
                                PrintDebug($"[SmartBackupDataGridView_CellClick] - [Database deleted]");
                                WriteDatabaseDataToJson(dBList);
                                SetupDataGridView(data);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("DatabaseData not found for current savegame.");
                            }
                        }
                    }
                }
                else if (e.RowIndex == 11)
                {
                    DisplayDatabase();
                    return;
                }
            }

            bool isLoaded = SelectedSavegameHasDatabaseAndIsLoaded();
            ReloadDatabaseGridView();
        }

        private void DisplayDatabase()
        {
            DatabaseData? data = GetSelectedDatabaseData();
            if (data != null)
            {
                if (data.HasDatabase)
                {
                    if (data.DatabaseLoaded)
                    {
                        LoadDatabaseToGridView();
                    }
                }
            }
        }

        private bool SelectedSavegameHasDatabaseAndIsLoaded()
        {
            if (dBList == null || dBList.Count == 0)
            {
                PrintDebug("[MainWindow] - [SelectedSavegameHasDatabaseAndIsLoaded] - [No databases loaded]");
                return false;
            }
            DatabaseData? data = GetSelectedDatabaseData();
            if (data != null)
            {
                bool bLoaded = data.DatabaseLoaded;
                if (!bLoaded)
                {
                    string sResult = data.LoadDatabase(false);
                    if (sResult.Equals("Loaded"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CreateNewDatabaseForSelectedItem()
        {
            DialogResult result = MessageBox.Show($"Do you want to create a database for this savegame? \n\nSavegame = {GetSelectedDatabaseName()}", "Create Database", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DatabaseData? data = GetSelectedDatabaseData();
                if (data != null)
                {
                    string sResult = data.LoadDatabase(true);
                    PrintDebug($"[SmartBackupDataSetupWindow.cs] - [SmartBackupDataGridView_CellClick] - [LoadDatabase(true)] - [Database {sResult}]");
                    if (sResult.Equals("Created"))
                    {
                        sResult = data.LoadDatabase(false);
                    }
                    PrintDebug($"[SmartBackupDataSetupWindow.cs] - [SmartBackupDataGridView_CellClick] - [LoadDatabase(false)] - [Database {sResult}]");
                    if (dBList != null)
                    {
                        WriteDatabaseDataToJson(dBList);
                    }
                    SetupDataGridView(data);
                    return true;
                }
            }
            return false;
        }

        private async Task<bool> CreateInitialBaseBackupForSelectedSavegame()
        {
            DatabaseData? data = GetSelectedDatabaseData();
            if (data != null)
            {
                TSProgressbar.Visible = true;
                bool bResult = await data.CreateInitialBaseBackup(null, null, TSProgressbar);
                PrintDebug("[MainWindow] - [CreateInitialBaseBackupForSelectedSavegame] - [Done] - [bResult = " + bResult + "]");
                ExportDatabaseDataList();
                ReloadDatabaseGridView();
                TSProgressbar.Visible = false;
                return bResult;
            }
            return false;
        }

        private async void SetupButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Setup Information: ");
            sb.AppendLine();
            bool bResult = CreateNewDatabaseForSelectedItem();
            if (!bResult)
            {
                sb.AppendLine($"[STEP 1][FAILED] - DatabaseData not found!");
                MessageBox.Show(sb.ToString(), "Setup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sb.AppendLine($"[STEP 1][SUCCESS] - DatabaseData not found!");
            sb.AppendLine();
            Thread.Sleep(1000);
            bResult = await CreateInitialBaseBackupForSelectedSavegame();
            if (!bResult)
            {
                sb.AppendLine($"[STEP 2][FAILED] - Initial Base Backup Failed");
                MessageBox.Show(sb.ToString(), "Setup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sb.AppendLine($"[STEP 2][SUCCESS] - Initial Base Backup Created");
            sb.AppendLine();
            sb.AppendLine($"[DONE] - >[SUCCESS] - Smart Backup Setup Completed");
            MessageBox.Show(sb.ToString(), "Setup Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AutoLoadDatabaseMenuOption_Click(object sender, EventArgs e)
        {
            SetSmartBackupAutoload(!Configuration.smartBackupAutoLoadEnabled, true);
        }

        private void SetSmartBackupAutoload(bool bEnable, bool bSaveCfg = false)
        {
            Configuration.smartBackupAutoLoadEnabled = bEnable;
            AutoLoadDatabaseMenuOption.Checked = bEnable;
            PrintDebug($"[SmartBackupSetupWindow.cs] - [AutoLoadDatabaseMenuOption_Click] - [Smart Backup Auto Load Enabled = {bEnable}]");
            if (bSaveCfg)
            {
                Configuration.SaveConfig();
            }
        }

        private void MaxDataGridRowsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMaxDataGridRowsButton();
        }

        private void SetMaxDataGridRowsButton()
        {
            if (int.TryParse(MaxDataGridRowsComboBox.Text, out int maxRows))
            {
                maxDataGridRows = maxRows;
                PrintDebug($"[SmartBackupSetupWindow.cs] - [setMaxDataGridRowsButton_Click] - [Max Data Grid Rows set to {maxDataGridRows}]");
            }
            else
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [setMaxDataGridRowsButton_Click] - [Invalid number of rows. Please enter a valid integer]", 2);
            }
        }

        private void SetDatabaseViewMode()
        {
            if (!DatabaseDisplayGridView.Visible)
            {
                ShowDatabaseButton.Visible = true;
                ShowDatabaseInfoButton.Visible = false;
            }
            else
            {
                ShowDatabaseInfoButton.Visible = true;
                ShowDatabaseButton.Visible = false;
            }
        }

        private void ShowDatabaseButton_Click(object sender, EventArgs e)
        {
            LoadDatabaseToGridView();
            SetDatabaseViewMode();
        }

        private void ShowDatabaseInfoButton_Click(object sender, EventArgs e)
        {
            ReloadDatabaseGridView();
            SetDatabaseViewMode();
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            NextPage();
        }

        private void PreviousPageButton_Click(object sender, EventArgs e)
        {
            PrevPage();
        }

        private void NextPage()
        {
            if (dBList == null || dBList.Count == 0)
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [NextPage] - [No databases loaded]", 1);
                return;
            }
            DatabaseData? data = GetSelectedDatabaseData();
            if (data == null)
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [NextPage] - [No data found for selected database]", 1);
                return;
            }
            int pageCount = GetPageCount(data.DBSize);
            currentPage++;
            if (currentPage < pageCount)
            {
                SetCurrentPageTextLabel(pageCount);
                LoadDatabaseToGridView();
            }
            else
            {
                currentPage = 1;
                SetCurrentPageTextLabel(pageCount);
                LoadDatabaseToGridView();
                PrintDebug("[SmartBackupSetupWindow.cs] - [NextPage] - [Already on last page]", 1);
            }
        }

        private void PrevPage()
        {
            if (dBList == null || dBList.Count == 0)
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [PrevPage] - [No databases loaded]", 1);
                return;
            }
            DatabaseData? data = GetSelectedDatabaseData();
            if (data == null)
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [NextPage] - [No data found for selected database]", 1);
                return;
            }
            int pageCount = GetPageCount(data.DBSize);
            currentPage--;
            if (currentPage > 0)
            {
                SetCurrentPageTextLabel(pageCount);
                LoadDatabaseToGridView();
            }
            else
            {
                currentPage = pageCount - 1;
                SetCurrentPageTextLabel(pageCount);
                LoadDatabaseToGridView();
                PrintDebug("[SmartBackupSetupWindow.cs] - [PrevPage] - [Already on last page]", 1);
            }
        }
    }

    public class FileRecord
    {
        public string? FilePath { get; set; } // relative path to file
        public long? Size { get; set; } // file size in bytes
        public DateTime? LastModifiedUtc { get; set; } // UTC-timestamp of latest change
    }

    public class FileRecordViewModel
    {
        public string? Key { get; set; }
        public string? FilePath { get; set; }
        public long? Size { get; set; }
        public DateTime? LastModifiedUtc { get; set; }
    }

    public class DatabaseGridView
    {
        public string? Savegame { get; set; }
        public string? Gamemode { get; set; }
        public string? SavegamePath { get; set; }
        public string? BackupFolderPath { get; set; }
        public string? DatabasePath { get; set; }
        public string? HasDatabase { get; set; }
        public string? IsLoaded { get; set; }
        public string? HasBaseBackup { get; set; }
        public string? DatabaseSize { get; set; }
        public string? DateCreated { get; set; }
        public string? DateEdited { get; set; }
        public Dictionary<string, FileRecord>? Database { get; set; }

        public DatabaseGridView(DatabaseData data)
        {
            Savegame = data.Savegame;
            Gamemode = data.Gamemode;
            SavegamePath = data.SavegamePath;
            BackupFolderPath = data.BackupFolderPath;
            DatabasePath = data.DatabasePath;
            HasDatabase = data.HasDatabase.ToString();
            IsLoaded = data.DatabaseLoaded.ToString();
            HasBaseBackup = data.HasBaseBackup.ToString();
            DatabaseSize = data.DBSize.ToString();
            DateCreated = data.DBDateCreated.ToString();
            DateEdited = data.DBDateEdited.ToString();
        }

        public DatabaseGridView(Dictionary<string, FileRecord> database)
        {
            Database = database;
        }

        public Dictionary<string, string> GetStringList()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Savegame", Savegame ?? "ERROR");
            dict.Add("Gamemode", Gamemode ?? "ERROR");
            dict.Add("Savegame Path", SavegamePath ?? "ERROR");
            dict.Add("Backup Path", BackupFolderPath ?? "ERROR");
            dict.Add("Database Path", DatabasePath ?? "ERROR");
            dict.Add("Has Database", HasDatabase ?? "False");
            dict.Add("Is Loaded", IsLoaded ?? "False");
            dict.Add("Has Base Backup", HasBaseBackup ?? "False");
            dict.Add("File Count", DatabaseSize ?? "0");
            dict.Add("Date Created", DateCreated ?? "Unknown");
            dict.Add("Date Edited", DateEdited ?? "Unknown");
            return dict;
        }
    }
}
