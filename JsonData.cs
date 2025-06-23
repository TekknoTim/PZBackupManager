using System;
using System.IO;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public class JsonData
    {

        public string Name { get; }
        public List<BackupData>? Backups { get; set; }
        public List<SmartBackupData>? SmartBackups { get; set; }

        public JsonData(string name, List<BackupData>? backups, List<SmartBackupData>? smartBackups)
        {
            Name = name;
            Backups = backups ?? null;
            SmartBackups = smartBackups ?? null;
        }

        public static JsonData NewJsonData(string name, bool bAddBackupData = true, bool bAddSmartBackupData = true)
        {
            List<BackupData>? backups = null;
            List<SmartBackupData>? smartBackups = null;
            if (bAddBackupData)
            {
                backups = new List<BackupData>(1);
            }
            if (bAddSmartBackupData)
            {
                smartBackups = new List<SmartBackupData>(1);
            }

            return new JsonData(name, backups, smartBackups);
        }

        public static JsonData AddBackup(JsonData jsonData, BackupData? backupData = null, SmartBackupData? smartBackupData = null)
        {
            string? name = jsonData.Name;
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Name is null or empty");
            }
            List<BackupData>? backups = jsonData.Backups;
            List<SmartBackupData>? smartBackups = jsonData.SmartBackups;
            if (backupData != null)
            {
                if (backups == null)
                {
                    backups = new List<BackupData>();
                }
                backups.Add(backupData);
            }
            if (smartBackupData != null)
            {
                if (smartBackups == null)
                {
                    smartBackups = new List<SmartBackupData>();
                }
                smartBackups.Add(smartBackupData);
            }
            JsonData newJsonData = new JsonData(name, backups, smartBackups);
            return newJsonData;
        }

        public static BackupData NewBackupData(int index, string name, string path = "", string zipPath = "")
        {
            return new BackupData(index, name, path,zipPath , GetCurrentDate(), GetCurrentTime(), GetDirSizeInMegaBytes(path));
        }

        public static SmartBackupData NewSmartBackupData(int index, string name, string path, List<string>? changedFiles = null, string zipPath = "")
        {
            return new SmartBackupData(index, name, path, changedFiles, zipPath);
        }

        public static int GetLastBackupDataIndex(JsonData jsonData, bool bSmart = false)
        {
            if (bSmart)
            {
                List<SmartBackupData>? smartBackups = jsonData.SmartBackups;
                return smartBackups?.Count - 1 ?? 0;
            }
            else
            {
                List<BackupData>? backups = jsonData.Backups;
                return backups?.Count - 1 ?? 0;
            }
        }

        public static int GetBackupDataCount(JsonData jsonData, bool bSmart = false)
        {
            if (bSmart)
            {
                List<SmartBackupData>? smartBackups = jsonData.SmartBackups;
                return smartBackups?.Count ?? 0;
            }
            else
            {
                List<BackupData>? backups = jsonData.Backups;
                return backups?.Count ?? 0;
            }
        }

        public static JsonData AddNewBackup(JsonData jsonData, string path = "", string zipPath = "")
        {
            int i = GetLastBackupDataIndex(jsonData);
            string name = GetDefaultBackupFolderName(GetLastBackupFolderNumber());
            BackupData backupData = NewBackupData(i + 1, name, path, zipPath);
            return AddBackup(jsonData, backupData, null);
        }

        public static JsonData AddNewSmartBackup(JsonData jsonData, List<string> changedFiles, string path = "", string zipPath = "")
        {
            int i = GetLastBackupDataIndex(jsonData, true);
            string name = GetDefaultBackupFolderName(GetLastBackupFolderNumber());
            SmartBackupData smartBackupData = NewSmartBackupData(i + 1, name, path, changedFiles, zipPath);
            return AddBackup(jsonData, null , smartBackupData);
        }

        public static JsonData? ReadJsonDataFromJson(string? path = null)
        {
            string jsonDataFilePath = string.Empty;
            if (string.IsNullOrWhiteSpace(path))
            {
                jsonDataFilePath = GetJsonDataFilePath();
            }
            else
            {
                jsonDataFilePath = path;
            }

            if (string.IsNullOrWhiteSpace(jsonDataFilePath))
            {
                return null;
            }
            string? dir = Path.GetDirectoryName(jsonDataFilePath);
            if (!string.IsNullOrEmpty(dir))
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }

            if (!File.Exists(jsonDataFilePath))
            {
                File.Create(jsonDataFilePath).Close();
            }
            string? json = System.IO.File.ReadAllText(jsonDataFilePath);
            if (string.IsNullOrEmpty(json))
            {
                if (!string.IsNullOrWhiteSpace(currentLoadedSavegame))
                {
                    JsonData jsonData = NewJsonData(currentLoadedSavegame);
                    WriteJsonDataToJson(jsonData);
                    return jsonData;
                }
                else
                {
                    return null;
                }
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JsonData>(json);
        }

        public static void WriteJsonDataToJson(JsonData? jsonData)
        {
            if (jsonData == null)
            {
                MessageBox.Show("[ERROR] - (WriteJsonDataToJson) --> jsonData == 0!");
                return;
            }
            string jsonDataFilePath = GetUnlistedJsonDataFilePath(jsonData.Name);
            if (string.IsNullOrWhiteSpace(jsonDataFilePath))
            {
                MessageBox.Show($"[ERROR] - (WriteJsonDataToJson) - [ERROR] \n--> [jsonDataFilePath (data.json directory)] == null or empty! \n--> [jsonDataFilePath] == {jsonDataFilePath}");
                return;
            }
            //MessageBox.Show("[JsonData.cs] - [WriteJsonDataToJson] - [Fired]");
            PrintDebug($"[WriteJsonDataToJson] - [Savegame = {jsonData.Name}] - [BackupData Length = {jsonData.Backups?.Count ?? null}]");
            PrintDebug($"[WriteJsonDataToJson] - [Savegame = {jsonData.Name}] - [SmartBackupData Length = {jsonData.SmartBackups?.Count ?? null}]");
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonData, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(jsonDataFilePath, json);
        }

        public static void WriteBackupDataToJson(string SavegameName, string fullBackupFolderPath, List<string>? changedFiles)
        {
            JsonData? outputData = null;
            JsonData? data = ReadJsonDataFromJson(GetUnlistedJsonDataFilePath(SavegameName));
            if (data == null)
            {
                //MessageBox.Show("ReadJsonDataFromJson == null");
                data = NewJsonData(SavegameName);
            }

            if(changedFiles == null)
            {
                outputData = AddNewBackup(data, fullBackupFolderPath);
            }
            else
            {
                outputData = AddNewSmartBackup(data, changedFiles, fullBackupFolderPath);
            }
            string jsonDataFilePath = GetUnlistedJsonDataFilePath(SavegameName);
            if (string.IsNullOrWhiteSpace(jsonDataFilePath))
            {
                return;
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(outputData, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(jsonDataFilePath, json);
        }


        //===========================================================================================================================================
        //=========================--------------------------------[ Start Zip Archive Functions ]--------------------------------===================
        //===========================================================================================================================================


        public static bool AddZipPathToBackupData(int idx, string? zipPath, bool addPath = true)
        {
            if ((string.IsNullOrWhiteSpace(zipPath)) && (addPath))
            {
                PrintDebug($"[AddZipPathToBackupData] - [Failed] - [zipPath = {zipPath}] - [addPath = {addPath}]");
                return false;
            }
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null)
            {
                if (string.IsNullOrWhiteSpace(currentLoadedSavegame))
                {
                    PrintDebug($"[AddZipPathToBackupData] - [Failed] - [JsonData = {jsonData}] - [currentLoadedSavegame = {currentLoadedSavegame}]");
                    return false;
                }
                jsonData = NewJsonData(currentLoadedSavegame);
            }
            List<BackupData>? dataList = jsonData.Backups;
            if ((dataList == null) || (idx < 0) || (dataList.Count <= idx))
            {
                PrintDebug($"[AddZipPathToBackupData] - [Failed] - [dataList.count = {dataList?.Count}] - [idx = {idx}]");
                return false;
            }
            BackupData? data = dataList[idx];
            if (data == null)
            {
                PrintDebug($"[AddZipPathToBackupData] - [Failed] - [data (BackupData) = {data}]");
                return false;
            }
            if (addPath)
            {
                PrintDebug($"[AddZipPathToBackupData] - [Adding Path] - [ZipPath = {zipPath}]");
                data.ZipPath = zipPath;
            }
            else
            {
                PrintDebug($"[AddZipPathToBackupData] - [Clearing Path] - [Current ZipPath = {data.ZipPath}]");
                data.ZipPath = string.Empty;
            }
            dataList.RemoveAt(idx);
            dataList.Insert(idx, data);
            jsonData.Backups = dataList;
            WriteJsonDataToJson(jsonData);
            return true;
        }

        //===========================================================================================================================================
        //=========================--------------------------------[ End Zip Archive Functions ]--------------------------------===================
        //===========================================================================================================================================

    }

    public class BackupData
    {

        public int Index { get; set; }
        public string? Name { get; set; }
        public string? Path { get; }
        public string? ZipPath { get; set; }
        public string? Date { get; }
        public string? Time { get; }
        public string? Size { get; }

        public BackupData(int index, string name, string path,string zipPath, string date, string time, string size)
        {
            Index = index;
            Name = name;
            Path = path;
            ZipPath = zipPath;
            Date = date;
            Time = time;
            Size = size;
        }
    }

    public class SmartBackupData
    {

        public int Index { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? ZipPath { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Size { get; set; }
        public List<string>? Files { get; set; }


        public SmartBackupData(int index, string name, string backupDir, List<string>? changedFiles, string zipPath = "")
        {
            //PrintDebug($"[SmartBackupUtil.cs] - [SmartBackupData] - [Created]");
            //PrintDebug($"[SmartBackupUtil.cs] - [SmartBackupData] - [Index = {index}] - [name = {name}] - [backupDir = {backupDir}]");
            //PrintDebug($"[SmartBackupUtil.cs] - [SmartBackupData] - [changedFiles = {changedFiles?.Count ?? 0}] - [zipPath = {zipPath}]");
            Index = index;
            Name = name;
            Path = backupDir;
            ZipPath = zipPath;
            Date = FunctionLibrary.GetCurrentDate();
            Time = FunctionLibrary.GetCurrentTime();
            Size = FunctionLibrary.FilesSize(changedFiles).ToString();
            Files = changedFiles;
        }

    }
}
