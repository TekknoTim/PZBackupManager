using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.JsonData;


namespace ZomboidBackupManager
{
    public static class FunctionLibrary
    {
        public static List<string> GetAllSavegamesInAllGamemodes()
        {
            List<string> gamemodes = GetGamemodes();
            List<string> allSavegamesInAllGamemodes = new List<string>();
            foreach (string mode in gamemodes)
            {
                List<string> savegames = new List<string>();
                savegames = GetSavegamesInGamemode(mode);
                foreach (string savegame in savegames)
                {
                    allSavegamesInAllGamemodes.Add(savegame);
                }
            }
            return allSavegamesInAllGamemodes;
        }

        public static bool GamemodeContainsSavegame(string gamemode, string savegame)
        {
            List<string> savegameList = GetSavegamesInGamemode(gamemode);
            bool result = savegameList.Contains(savegame);
            //MessageBox.Show($"Gamemode = {gamemode} \n\nContains? \n\nSavegame = {savegame} \n\nResult? \n\n[{result.ToString()}]");
            return result;
        }

        public static List<string> GetSavegamesInGamemode(string gamemode)
        {
            if (string.IsNullOrWhiteSpace(gamemode))
            {
                return new List<string>();
            }

            string fullSavegamePath = Configuration.GetFullSavegamesPath(gamemode);

            string[] savegameFolderList = Directory.GetDirectories(fullSavegamePath);

            List<string> outputList = new List<string>();

            foreach (var savegame in savegameFolderList)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(fullSavegamePath + savegame);
                outputList.Add(dirInfo.Name);
            }

            return outputList;

        }

        public static void DeleteSingleBackup(int index)
        {
            string? path = GetBackupFolderPathFromJson(index);
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            if (System.IO.Directory.Exists(path))
            {
                System.IO.Directory.Delete(path, true);
            }
            else
            {
                MessageBox.Show($"[ERROR] - The selected backup folder directory wasn't found! \n Path: {path}");
            }
        }

        public static void DeleteAllBackupsFromJson()
        {
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null)
            {
                return;
            }
            jsonData.Backups = new List<BackupData>();
            WriteJsonDataToJson(jsonData);
        }

        public static void DeleteBackupFromJson(int index)
        {
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null)
            {
                return;
            }
            List<BackupData> dataList = jsonData.Backups;
            if (dataList.Count <= index)
            {
                return;
            }
            dataList.RemoveAt(index);
            int i = 0;
            foreach (var item in dataList)
            {
                PrintDebug($" - [DeleteBackupFromJson] - Backup [{item.Name}] - Changing index from [{item.Index.ToString()}] to [{i.ToString()}]");
                item.Index = i;
                i++;
            }
            jsonData.Backups = dataList;
            WriteJsonDataToJson(jsonData);
        }

        public static void RenameBackup(int index, string? newName)
        {
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null || string.IsNullOrEmpty(newName))
            {
                return;
            }
            List<BackupData>? dataList = jsonData.Backups;
            if (dataList == null || index < 0)
            {
                return;
            }
            if (dataList.Count <= index)
            {
                return;
            }
            BackupData? data = dataList[index];
            if (data == null)
            {
                return;
            }
            data.Name = newName;
            dataList.RemoveAt(index);
            dataList.Insert(index, data);
            jsonData.Backups = dataList;
            WriteJsonDataToJson(jsonData);
        }


        public static string GetGamemodeByIndex(int index)
        {
            List<string> gamemodes = GetGamemodes();
            return gamemodes[index];
        }

        public static List<string> GetGamemodes()
        {
            string[] modes = Directory.GetDirectories(absoluteSavegamePATH);
            List<string> outputList = new List<string>();
            int i = 1;
            foreach (var item in modes)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(currentLoadedBackupFolderPATH + item);
                outputList.Add(dirInfo.Name);
                i++;
            }

            return outputList;
        }

        public static string GetBackupFolderPathFromJson(int index)
        {
            BackupData? data = GetBackupDataFromJson(index);
            if (data == null)
            {
                return currentLoadedBackupFolderPATH + GetDefaultBackupFolderName(index);
            }
            string? fullPath = data.Path;
            if (string.IsNullOrEmpty(fullPath))
            {
                return currentLoadedBackupFolderPATH + GetDefaultBackupFolderName(index);
            }
            return fullPath;
        }

        public static int GetBackupCountFromJson()
        {
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null)
            {
                return 0;
            }
            return GetBackupDataCount(jsonData);
        }

        public static List<BackupData>? GetBackupDataListFromJson()
        {
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null)
            {
                return null;
            }
            return jsonData.Backups;
        }

        public static BackupData? GetBackupDataFromJson(int index)
        {
            List<BackupData>? backupDataList = GetBackupDataListFromJson();
            int lastIndex = GetLastBackupIndexFromJson(backupDataList);
            if (backupDataList == null || backupDataList.Count <= 0 || index < 0 || index > lastIndex || lastIndex < 0)
            {
                return null;
            }
            BackupData data = backupDataList[index];
            return data;
        }

        public static string[] GetAllBackupDataNamesFromJson()
        {
            List<BackupData>? backupDataList = GetBackupDataListFromJson();
            if (backupDataList == null || backupDataList.Count <= 0)
            {
                return Array.Empty<string>();
            }
            List<string> outputList = new List<string>();
            foreach (var item in backupDataList)
            {
                string? name = item.Name;
                if (string.IsNullOrEmpty(name))
                {
                    name = @"ERROR - Name Not Found!";
                }
                outputList.Add(name);
            }
            return outputList.ToArray();
        }

        public static string? GetBackupDataNameFromJson(int index)
        {
            List<BackupData>? backupDataList = GetBackupDataListFromJson();
            if (backupDataList == null)
            {
                return string.Empty;
            }
            return backupDataList[index].Name;
        }

        public static int GetLastBackupIndexFromJson(List<BackupData>? backupDataList = null)
        {
            if (backupDataList == null)
            {
                backupDataList = GetBackupDataListFromJson();
            }
            if (backupDataList == null)
            {
                return -1;
            }
            BackupData data = backupDataList[backupDataList.Count - 1];
            return data.Index;
        }

        public static int GetBackupCount()
        {
            string[] backupFolders = GetBackups();
            return backupFolders.Length;
        }

        public static string[] GetBackups()
        {
            string[] fullPathList = Directory.GetDirectories(currentLoadedBackupFolderPATH);

            List<string> outputList = new List<string>();
            int i = 1;
            foreach (var item in fullPathList)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(currentLoadedBackupFolderPATH + item);
                outputList.Add(dirInfo.Name);
                i++;
            }

            return outputList.ToArray();

        }

        //==========================================================================================================
        //-----------------------------------------[ General Functions ]--------------------------------------------
        //==========================================================================================================

        public static string GetCurrentTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public static string GetCurrentDate()
        {
            return DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }

        public static string GetDirSizeInMegaBytes(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            long l = DirSize(dirInfo);
            double d = ConvertBytesToMB(l);
            return d.ToString();
        }

        public static double ConvertBytesToKB(long bytes)
        {
            return bytes / 1024f;
        }

        public static double ConvertBytesToMB(long bytes)
        {
            return ConvertBytesToKB(bytes) / 1024f;
        }

        public static string GetJsonDataFilePath()
        {
            string filePath = currentLoadedBackupFolderPATH + @"\data.json";

            if (string.IsNullOrEmpty(currentLoadedBackupFolderPATH))
            {
                //MessageBox.Show(@"[GetJsonDataFilePath] - [currentLoadedBackupFolderPATH was null or empty!]");
                return currentBaseBackupFolderPATH + @"\None" + @"\data.json";
            }
            if (!System.IO.File.Exists(filePath))
            {
                string? dirPath = Path.GetDirectoryName(filePath);
                if (string.IsNullOrWhiteSpace(dirPath))
                {
                    dirPath = currentBaseBackupFolderPATH + @"\None";
                    filePath = dirPath + @"\data.json";
                }

                if (!System.IO.Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);

                }
                FileStream stream = System.IO.File.Create(filePath);
                stream.Close();
            }
            return filePath;
        }

        public static int GetLastBackupFolderNumber()
        {
            string[] folderNames = GetBackups();
            if (folderNames.Length <= 0)
            {
                return 0;
            }
            List<int> numbers = new List<int>();
            foreach (var name in folderNames)
            {
                if (name.Contains("Backup_"))
                {
                    string[] split = name.Split('_');
                    if (split.Length > 1)
                    {
                        string number = split[1];
                        if (int.TryParse(number, out int result))
                        {
                            numbers.Add(result);
                        }
                    }
                }
            }
            if (numbers.Count <= 0)
            {
                return 0;
            }
            return numbers.Max();
        }

        public static string GetDefaultBackupFolderName(int index)
        {
            return @"Backup_" + (index).ToString();
        }
    }
}
