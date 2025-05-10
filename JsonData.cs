using System;
using System.IO;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public class JsonData
    {

        public string? Name { get; }
        public List<BackupData> Backups { get; set; }

        public JsonData(string name, List<BackupData> backups)
        {
            Name = name;
            Backups = backups;
        }

        public static JsonData NewJsonData(string name)
        {
            List<BackupData> backups = new List<BackupData>(1);
            return new JsonData(name, backups);
        }

        public static JsonData AddBackup(JsonData jsonData, BackupData backupData)
        {
            string? name = jsonData.Name;
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Name is null or empty");
            }
            List<BackupData> backups = jsonData.Backups;
            backups.Add(backupData);
            JsonData newJsonData = new JsonData(name, backups);
            return newJsonData;
        }

        public static BackupData NewBackupData(int index, string name, string path = "", string zipPath = "")
        {
            return new BackupData(index, name, path,zipPath , GetCurrentDate(), GetCurrentTime(), GetDirSizeInMegaBytes(path));
        }

        public static int GetLastBackupDataIndex(JsonData jsonData)
        {
            List<BackupData> backups = jsonData.Backups;
            return backups.Count - 1;
        }

        public static int GetBackupDataCount(JsonData jsonData)
        {
            List<BackupData> backups = jsonData.Backups;
            return backups.Count;
        }

        public static JsonData AddNewBackup(JsonData jsonData, string path = "", string zipPath = "")
        {
            int i = GetLastBackupDataIndex(jsonData);
            string name = GetDefaultBackupFolderName(GetLastBackupFolderNumber());
            BackupData backupData = NewBackupData(i + 1, name, path, zipPath);
            return AddBackup(jsonData, backupData);
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
            JsonData? data = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonData>(json);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public static void WriteJsonDataToJson(JsonData? jsonData)
        {
            string jsonDataFilePath = GetJsonDataFilePath();
            if (jsonData == null)
            {
                MessageBox.Show("[ERROR] - (WriteJsonDataToJson) --> jsonData == 0!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(jsonDataFilePath))
            {
                MessageBox.Show($"[ERROR] - (WriteJsonDataToJson) - [ERROR] \n--> [jsonDataFilePath (data.json directory)] == null or empty! \n--> [jsonDataFilePath] == {jsonDataFilePath}");
                return;
            }
            PrintDebug($"[WriteJsonDataToJson] - [Savegame = {jsonData.Name}] - [BackupData Length = {jsonData.Backups.Count}]");
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonData, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(jsonDataFilePath, json);
        }

        public static void WriteBackupDataToJson(string SavegameName, string fullBackupFolderPath)
        {
            JsonData? outputData = null;
            JsonData? data = ReadJsonDataFromJson();
            if (data == null)
            {
                //MessageBox.Show("ReadJsonDataFromJson == null");
                data = NewJsonData(SavegameName);
            }

            outputData = AddNewBackup(data, fullBackupFolderPath);

            string jsonDataFilePath = GetJsonDataFilePath();
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
}
