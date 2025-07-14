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
        private bool isEditingCurrentPage = false;

        private bool wasSmartModeEnabled;
        public bool WasSmartModeEnabled { get { return wasSmartModeEnabled; } }

        private List<string> gamemodes;
        private List<string> savegames;

        private Dictionary<string, DatabaseData>? dBList;
        public Dictionary<string, DatabaseData>? DBList { get { return dBList; } }

        private int maxDataGridRows = 50;

        private int currentPage = 1;

        public SmartBackupSetupWindow(List<string> gm, List<string> sg, Dictionary<string, DatabaseData>? db)
        {
            InitializeComponent();
            gamemodes = gm;
            savegames = sg;
            GamemodeComboBox.DataSource = gamemodes;
            LoadSavegamesInSelectedGamemode();
            wasSmartModeEnabled = Configuration.smartBackupModeEnabled;
            SetRadioButtonsState(Configuration.smartBackupModeEnabled);
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
            SetupButton.Enabled = false;
            CreateButton.Enabled = false;
            DeletePresetButton.Visible = false;
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
            ControlAreaSubPanel.Visible = bSet;
        }

        private void SetRadioButtonsState(bool bSet)
        {
            EnableSmartBackupRadioButton.Checked = bSet;
            DisableSmartBackupRadioButton.Checked = !bSet;
        }

        private bool ToggleSmartBackupMode()
        {
            bool smartModeEnabled = Configuration.smartBackupModeEnabled;
            smartModeEnabled = !smartModeEnabled;
            Configuration.SetSmartBackupMode(smartModeEnabled);
            SetRadioButtonsState(smartModeEnabled);
            return smartModeEnabled;
        }

        private void ClearComboBoxes()
        {
            GamemodeComboBox.SelectedItem = null;
            SavegameComboBox.SelectedItem = null;
            SwitchCreateButton(false);
        }

        private void ClearDatabaseListBox()
        {
            DatabaseListBox.SelectedItem = null;
            SwitchCreateButton(true);
        }

        private void SwitchCreateButton(bool bDefault = false)
        {
            CreateButton.Visible = bDefault;
            DeletePresetButton.Visible = !bDefault;
        }

        private void DisableSmartBackupRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            bool bEnabled = ToggleSmartBackupMode();
            //MessageBox.Show($"Smart Backup Mode Enabled = {bEnabled}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EnableSmartBackupRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            bool bEnabled = ToggleSmartBackupMode();
            //MessageBox.Show($"Smart Backup Mode Enabled = {bEnabled}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GamemodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GamemodeComboBox.SelectedItem == null)
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [GamemodeComboBox_SelectedIndexChanged] - [Selected Item = null]", 1);
                return;
            }
            ClearDatabaseListBox();
            LoadSavegamesInSelectedGamemode();
            CreateButton.Enabled = false;
            SetupButton.Enabled = false;
        }

        private void SavegameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SavegameComboBox.SelectedItem == null)
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [SavegameComboBox_SelectedIndexChanged] - [Selected Item = null]", 1);
                return;
            }
            SetupButton.Enabled = false;
            CreateButton.Enabled = true;
            ClearDatabaseListBox();
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
            dBList ??= new Dictionary<string, DatabaseData>();
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
            DatabaseListBox.SelectedIndex = DatabaseListBox.Items.Count - 1; // Select the last added item
            DatabaseListBox.Select();
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

        private bool RemoveDataFromDatabaseDataList(string savegame)
        {
            if (dBList == null || dBList.Count == 0)
            {
                PrintDebug("[MainWindow.cs] - [RemoveDataFromDatabaseDataList] - [No data found in json file or file is empty]", 1);
                return false;
            }
            bool bResult = dBList.TryGetValue(savegame, out DatabaseData? data);
            if (bResult && data != null)
            {
                return dBList.Remove(savegame);
            }
            return bResult;
        }


        private void ExportDatabaseDataList()
        {
            if (dBList == null)
            {
                PrintDebug($"[MainWindow.cs][ExportDatabaseDataList] - [Can't export empty list to json file]", 1);
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
                for (int i = j; i <= maxDataGridRows * currentPage; i++)
                {
                    var kvp = database.ElementAtOrDefault(i);
                    if (count >= maxDataGridRows)
                    {
                        break;
                    }
                    DatabaseDisplayGridView.Rows.Add(kvp.Key, kvp.Value.FilePath ?? "ERROR", kvp.Value.Size.ToString() ?? "ERROR", kvp.Value.LastModifiedUtc.ToString() ?? "ERROR");
                    DatabaseDisplayGridView.Rows[count].HeaderCell.Value = i.ToString();
                    count++;
                }
            }
            finally
            {

                DatabaseDisplayGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                DatabaseDisplayGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                DatabaseDisplayGridView.ResumeLayout();
            }

            DatabaseDisplayGridView.Refresh();
        }

        private void SetCurrentPageTextLabelToDefault()
        {
            GridViewPageTextBox.Text = $" 1 / 1 ";
        }

        private void SetCurrentPageTextLabel(int pageCount)
        {
            if (pageCount <= 0)
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [SetCurrentPageTextLabel] - [No pages available]", 1);
                GridViewPageTextBox.Text = $"[0/0]";
                return;
            }
            GridViewPageTextBox.Text = $" {currentPage} / {pageCount - 1} ";
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
            if (DatabaseListBox.SelectedItem == null)
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [DatabaseListBox_SelectedIndexChanged] - [No valid item selected]", 1);
                return;
            }
            ClearComboBoxes();
            SelectDatabaseData();
            ReloadCurrentGridView();
            CreateButton.Enabled = false;
            SetupButton.Enabled = true;
        }

        private void ReloadCurrentGridView()
        {
            if (DisplayDatabaseDataInfoRadioButton.Checked)
            {
                ReloadDatabaseGridView();
            }
            else
            {
                LoadDatabaseToGridView();
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
            SetCurrentPageTextLabelToDefault();
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
                        PrintDebug("[SmartBackupSetupWindow.cs] - [GetSelectedDatabaseData] - [Data Grid View Loaded]");
                        return data;
                    }
                    else
                    {
                        PrintDebug("[SmartBackupSetupWindow.cs] - [GetSelectedDatabaseData] - [Database not found in list]", 1);
                        if (DatabaseInfoGridView.Visible && DatabaseInfoGridView.Rows.Count > 0)
                        {
                            string? SavegameValue = DatabaseInfoGridView[0, 0].Value?.ToString() ?? string.Empty;
                            if (string.IsNullOrEmpty(SavegameValue))
                            {
                                PrintDebug($"[SmartBackupSetupWindow.cs] - [GetSelectedDatabaseData] - [Got Savegamename from GridView = {SavegameValue}]", 1);

                                if (dBList.TryGetValue(SavegameValue, out data))
                                {
                                    PrintDebug("[SmartBackupSetupWindow.cs] - [GetSelectedDatabaseData] - [Data Grid View Loaded]");
                                    return data;
                                }
                            }
                            
                        }
                    }
                }
                else
                {
                    PrintDebug("[SmartBackupSetupWindow.cs] - [GetSelectedDatabaseData] - [No valid item selected]", 1);
                }
            }
            return null;
        }

        private string GetSelectedDatabaseName()
        {
            if (DatabaseListBox.SelectedItem == null || string.IsNullOrEmpty(DatabaseListBox.SelectedItem.ToString()))
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [GetSelectedDatabaseName] - [No item selected in DatabaseListBox]", 1);
                if (DatabaseListBox.Items.Count > 0)
                {
                    PrintDebug("[SmartBackupSetupWindow.cs] - [GetSelectedDatabaseName] - [Items available in DatabaseListBox]");
                    DatabaseListBox.SelectedIndex = 0; // Select the first item if available
                }
                else
                {
                    PrintDebug("[SmartBackupSetupWindow.cs] - [GetSelectedDatabaseName] - [No items available in DatabaseListBox]", 1);
                }
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
            }

            bool isLoaded = SelectedSavegameHasDatabaseAndIsLoaded();
            ReloadDatabaseGridView();
        }

        private bool SelectedSavegameHasDatabaseAndIsLoaded(bool bTryLoad = true)
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
                if (!bLoaded && bTryLoad)
                {
                    string sResult = data.LoadDatabase(false);
                    if (sResult.Equals("Loaded"))
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        private bool CreateNewDatabaseForSelectedItem(bool bSkipMsgBox = false)
        {
            DialogResult result = DialogResult.Continue;
            if (!bSkipMsgBox)
            {
                result = MessageBox.Show($"Do you want to create a database for this savegame? \n\nSavegame = {GetSelectedDatabaseName()}", "Create Database", MessageBoxButtons.YesNo);
            }
            if (result == DialogResult.Yes || result == DialogResult.Continue)
            {
                DatabaseData? data = GetSelectedDatabaseData();
                if (data != null)
                {
                    if (data.HasDatabase)
                    {
                        data.ClearDatabase();
                    }
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
            bool bOverride = false;
            if (SelectedSavegameHasDatabaseAndIsLoaded(false))
            {
                sb.AppendLine($"[STEP 1] - [FAILED] - DatabaseData already exists for selected savegame!");
                sb.AppendLine();
                sb.AppendLine($"Do you want to override the existing preset?");
                DialogResult dResult = MessageBox.Show(sb.ToString(), "Database Already Exists!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dResult != DialogResult.Yes)
                {
                    PrintDebug("[SmartBackupSetupWindow.cs] - [SetupButton_Click] - [User chose NOT to override existing database entry]"); 
                    return;
                }
                else
                {
                    PrintDebug("[SmartBackupSetupWindow.cs] - [SetupButton_Click] - [User chose to override existing database entry]");
                    bOverride = true;
                }
            }
            bool bResult = CreateNewDatabaseForSelectedItem(bOverride);
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
            ExportDatabaseDataList();
            MessageBox.Show(sb.ToString(), "Setup Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReloadCurrentGridView();
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
                ReloadCurrentGridView();
            }
            else
            {
                PrintDebug("[SmartBackupSetupWindow.cs] - [setMaxDataGridRowsButton_Click] - [Invalid number of rows. Please enter a valid integer]", 2);
            }
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
            if (DatabaseDisplayGridView.Visible)
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
        }

        private void PrevPage()
        {
            if (DatabaseDisplayGridView.Visible)
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

        private void SetGridViewModeRadioButtons()
        {
            DisplayDatabaseRadioButton.Checked = !DisplayDatabaseRadioButton.Checked;
            DisplayDatabaseDataInfoRadioButton.Checked = !DisplayDatabaseDataInfoRadioButton.Checked;
        }

        private void DisplayDatabaseDataInfoRadioButton_Click(object sender, EventArgs e)
        {
            SetGridViewModeRadioButtons();
            ReloadCurrentGridView();
        }

        private void DisplayDatabaseRadioButton_Click(object sender, EventArgs e)
        {
            SetGridViewModeRadioButtons();
            ReloadCurrentGridView();
        }

        private void GridViewPageTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isEditingCurrentPage = true;
                GridViewPageTextBox.Text = string.Empty; // Clear the text box on left click
                GridViewPageTextBox.Select();
            }
        }

        private void GridViewPageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (isEditingCurrentPage)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true; // Prevent the beep sound
                    if (int.TryParse(GridViewPageTextBox.Text, out int newPage))
                    {
                        DatabaseData? data = GetSelectedDatabaseData();
                        if (data != null)
                        {
                            int pageCount = GetPageCount(data.DBSize);
                            if (newPage > 0 && newPage < pageCount)
                            {
                                currentPage = newPage;
                                SetCurrentPageTextLabel(pageCount);
                                LoadDatabaseToGridView();
                            }
                            else
                            {
                                MessageBox.Show($"Invalid page number. Please enter a number between 1 and {pageCount - 1}.");
                            }
                        }
                        isEditingCurrentPage = false;
                    }
                }

            }
        }

        private void GridViewPageTextBox_Leave(object sender, EventArgs e)
        {
            isEditingCurrentPage = false;
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
            }
            else
            {
                PrintDebug("[MainWindow.cs] - [SelectDatabaseData] - [Failed to load database]");
            }
        }

        private async void DeletePresetButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogRes = MessageBox.Show("This will delete the database and the initial base backup, as well as ALL SmartBackups for this savegame. \n\nDo you really want to continue?", "Delete Preset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogRes != DialogResult.Yes)
            {
                PrintDebug("[MainWindow.cs] - [DeletePresetButton_Click] - [User cancelled the deletion]");
                return;
            }
            DatabaseData? data = GetSelectedDatabaseData();
            if (data == null)
            {
                PrintDebug("[MainWindow.cs] - [DeletePresetButton_Click] - [No data selected]");
                return;
            }
            bool bResult = false;
            PrintDebug($"[SmartBackupSetupWindow.cs] - [DeletePresetButton_Click] - [HasDatabase = {data.HasDatabase}] - [HasBaseBackup = {data.HasBaseBackup}]");
            if (data.HasDatabase)
            {
                bResult = data.ClearDatabase();
                if (!bResult)
                {
                    if (data.HasDatabase)
                    {
                        MessageBox.Show("Failed to clear the database! \n\nDo you want to continue though?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    }
                }
                bResult = false;
            }
            PrintDebug($"[SmartBackupSetupWindow.cs] - [DeletePresetButton_Click] - [HasBaseBackup = {data.HasBaseBackup}]");
            if (data.HasBaseBackup)
            {
                TSProgressbar.Visible = true;
                bResult = await data.DisposeInitialBaseBackup(null, null, TSProgressbar);
                if (!bResult)
                {
                    PrintDebug("[SmartBackupSetupWindow.cs] - [DeletePresetButton_Click] - [User cancelled the deletion after failed initial backup disposal]");
                    dialogRes = MessageBox.Show("Failed to dispose the initial backup! Do you want to continue though?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogRes != DialogResult.Yes)
                    {
                        PrintDebug("[SmartBackupSetupWindow.cs] - [DeletePresetButton_Click] - [User cancelled the deletion after failed initial backup disposal]");
                        ExportDatabaseDataList();
                        RefreshDatabaseListbox();
                        ReloadCurrentGridView();
                        TSProgressbar.Visible = false;
                        return;
                    }
                }
                bResult = false;
            }
            MessageBox.Show($"Delete results: \n\n1. Database Deleted = {!data.HasDatabase} \n2.Base Backup Deleted = {!data.HasBaseBackup}", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!data.HasDatabase && !data.HasBaseBackup)
            {
                dialogRes = MessageBox.Show($"Everything got deleted successfully! \n\nDo you want to remove this preset from the list as well?", "Delete All?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogRes != DialogResult.Yes)
                {
                    PrintDebug("[SmartBackupSetupWindow.cs] - [DeletePresetButton_Click] - [User cancelled the deletion before deleting the preset as well.]");
                    ExportDatabaseDataList();
                    RefreshDatabaseListbox();
                    ReloadCurrentGridView();
                    TSProgressbar.Visible = false;
                    return;
                }
                bResult = false;
                bResult = RemoveDataFromDatabaseDataList(data.Savegame);
                if (!bResult)
                {
                    MessageBox.Show($"Failed to remove [Savegame = {data.Savegame}] the database from the list!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ExportDatabaseDataList();
                    PrintDebug("[MainWindow.cs] - [DeletePresetButton_Click] - [Preset deleted successfully]");
                    MessageBox.Show("Preset & all Data deleted successfully?", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearDatabaseListBox();
                    ClearComboBoxes();
                    SetCurrentPageTextLabelToDefault();
                }
                RefreshDatabaseListbox();
                ReloadCurrentGridView();
                if (DatabaseListBox.Items.Count > 0)
                {
                    DatabaseListBox.SelectedIndex = 0;
                }
                DatabaseListBox.Select();
                TSProgressbar.Visible = false;
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
