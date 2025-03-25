﻿using static ZomboidBackupManager.FunctionLibrary;

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
            List<BackupData> backups = new List<BackupData>();
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

        public static BackupData NewBackupData(int index, string name, string path)
        {
            return new BackupData(index, name, path, GetCurrentDate(), GetCurrentTime(), GetDirSizeInMegaBytes(path));
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

        public static JsonData AddNewBackup(JsonData jsonData, string path)
        {
            int i = GetLastBackupDataIndex(jsonData);
            string name = GetDefaultBackupFolderName(GetLastBackupFolderNumber());
            BackupData backupData = NewBackupData(i + 1, name, path);
            return AddBackup(jsonData, backupData);
        }

        public static JsonData? ReadJsonDataFromJson()
        {
            string backupJson = GetJsonDataFilePath();
            string? backupPath = Path.GetDirectoryName(backupJson);
            if (string.IsNullOrEmpty(backupPath))
            {
                return null;
            }
            if (!System.IO.Directory.Exists(backupPath))
            {
                Directory.CreateDirectory(backupPath);
            }
            if (!System.IO.File.Exists(backupJson))
            {
                FileStream stream = System.IO.File.Create(backupJson);
                stream.Close();
            }
            string? json = System.IO.File.ReadAllText(backupJson);
            if (string.IsNullOrEmpty(json))
            {
                return null;
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
            if (jsonData == null)
            {
                MessageBox.Show("[ERROR] - (WriteJsonDataToJson) --> jsonData == 0!");
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonData, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(GetJsonDataFilePath(), json);
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


            string json = Newtonsoft.Json.JsonConvert.SerializeObject(outputData, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(GetJsonDataFilePath(), json);
        }
    }

    public class BackupData
    {

        public int Index { get; set; }
        public string? Name { get; set; }
        public string? Path { get; }
        public string? Date { get; }
        public string? Time { get; }
        public string? Size { get; }

        public BackupData(int index, string name, string path, string date, string time, string size)
        {
            Index = index;
            Name = name;
            Path = path;
            Date = date;
            Time = time;
            Size = size;
        }

    }
}
