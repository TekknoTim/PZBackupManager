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
using System.Reflection;
using SharpCompress.Compressors.Xz;
using System.Diagnostics;


namespace ZomboidBackupManager
{
    public static class FunctionLibrary
    {
        //===========================================================================================================================================
        //=====================================-----------------------[ Status Log Functions & Helperts ]-------------------------===================
        //===========================================================================================================================================

        public static string AddSideSeparators(string str, char sideChar = '║', bool addStart = true, bool addEnd = true)
        {
            if (addStart)
            {
                str = str.Remove(0, 1);
                str = sideChar.ToString() + str;
            }
            if (addEnd)
            {
                str = str.Remove(str.Length - 2, 1);
                str = str + sideChar.ToString();
            }
            return str;
        }

        public static string CenterText(string text, int totalLength, char fillChar = '*', bool lineNumeration = false)
        {
            if (text.Length >= totalLength)
            {
                return text.Substring(0, totalLength);
            }
            int paddingTotal = totalLength - text.Length;
            int padLeft = paddingTotal / 2;
            if (lineNumeration) { padLeft += GetNumStringLength() / 2; }
            int padRight = paddingTotal - padLeft;

            return new string(fillChar, padLeft) + text + new string(fillChar, padRight);
        }

        public static string GetFullNumString(string num = "XXX")
        {
            return $"[{num}] - ";
        }

        public static int GetNumStringLength()
        {
            return GetFullNumString().Length;
        }

        //===========================================================================================================================================
        //=========================-----------------------[ Start Loose & Depricated Backup Functions ]-------------------------=====================
        //===========================================================================================================================================
        public static List<string> GetUnlistedSavegames()
        {
            List<string> unlisted = new List<string>();
            string[] backups = GetAllBackupFolders();
            string[] savegames = GetAllSavegamesInAllGamemodes().ToArray();

            foreach (string backup in backups)
            {
                if (!savegames.Contains(backup) && (backup != @"None"))
                {
                    unlisted.Add(backup);
                }
            }
            return unlisted;
        }

        public static List<string> GetUnlistedSavegamePaths()
        {
            List<string> paths = new List<string>();
            List<string> unlisted = GetUnlistedSavegames();
            foreach (string name in unlisted)
            {
                paths.Add(currentBaseBackupFolderPATH + @"\" + name);
            }
            return paths;
        }

        public static List<string> GetBackupsInUnlistedSavegameFromJson()
        {
            List<string> unlisted = new List<string>();
            string[] backups = GetAllBackupFolders();
            string[] savegames = GetAllSavegamesInAllGamemodes().ToArray();

            foreach (string backup in backups)
            {
                if (!savegames.Contains(backup) && (backup != @"None"))
                {
                    unlisted.Add(backup);
                }
            }
            return unlisted;
        }

        public static string GetUnlistedFolderPathFromJson(int index, string savegame)
        {
            BackupData? data = GetUnlistedDataFromJson(index , savegame);
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

        public static BackupData? GetUnlistedDataFromJson(int index, string savegame)
        {
            List<BackupData>? dataList = GetÚnlistedDataListFromJson(savegame);
            int lastIndex = GetLastBackupIndexFromJson(dataList);
            if (dataList == null || dataList.Count <= 0)
            {
                return null;
            }
            BackupData? bData = dataList.Find(x => x.Index == index);
            return bData;
        }

        public static List<BackupData>? GetÚnlistedDataListFromJson(string? savegame = null , string? path = null)
        {
            string p = string.Empty;
            if (savegame != null)
            {
                p = GetUnlistedJsonDataFilePath(savegame);
            }
            else if (path != null)
            {
                p = path;
            }
            JsonData? jsonData = ReadJsonDataFromJson(p);
            if (jsonData == null)
            {
                return null;
            }
            return jsonData.Backups;
        }

        public static string[] GetAllUnlistedBackupNamesNamesFromJson(string savegame)
        {
            List<BackupData>? backupDataList = GetÚnlistedDataListFromJson(savegame);
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

        public static bool DirectoryHasJsonFile(string savegame)
        {
            string path = GetUnlistedJsonDataFilePath(savegame);
            return File.Exists(path);
        }

        public static bool DirectoryHasValidJsonFile(string savegame)
        {
            if(DirectoryHasJsonFile(savegame))
            {
                List<BackupData>? backupData = GetÚnlistedDataListFromJson(savegame);
                if (backupData != null && backupData.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<BackupData>? TryToGetBackupDataListFromJson(string path)
        {
            string filePath = path + @"\" + @"data.json";
            if (File.Exists(filePath))
            {
                List<BackupData>? backupData = GetÚnlistedDataListFromJson(null, filePath);
                if (backupData != null && backupData.Count > 0)
                {
                    return backupData;
                }
            }
            return null;
        }


        //===========================================================================================================================================
        //=========================------------------------[ End Loose & Depricated Backup Functions ]--------------------------=====================
        //===========================================================================================================================================

        //-------------------------------------------------------------------------------------------------------------------------------------------

        //===========================================================================================================================================
        //=========================--------------------------------[ Start Zip Archive Functions ]--------------------------------===================
        //===========================================================================================================================================

        public static bool IsBackupZipped(int index)
        {
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null)
            {
                PrintDebug($"[IsBackupZipped] - [jsonData was null!]",2);
                return false;
            }
            List<BackupData>? dataList = jsonData.Backups;
            if (dataList == null || dataList.Count <= index)
            {
                PrintDebug($"[IsBackupZipped] - [dataList (backupDataList) was null!]", 2);
                return false;
            }
            return !string.IsNullOrWhiteSpace(dataList[index].ZipPath);
        }

        public static bool IsSmartBackupZipped(int index)
        {
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null)
            {
                PrintDebug($"[IsSmartBackupZipped] - [jsonData was null!]", 2);
                return false;
            }
            List<SmartBackupData>? dataList = jsonData.SmartBackups;
            if (dataList == null || dataList.Count <= index)
            {
                PrintDebug($"[IsSmartBackupZipped] - [smartDataList (backupDataList) was null!]", 2);
                return false;
            }
            return !string.IsNullOrWhiteSpace(dataList[index].ZipPath);
        }

        public static string? GetBackupZipPathFromJson(int index)
        {
            //MessageBox.Show($"[GetBackupZipPathFromJson] - [index = {index}] - [currentLoadedBackupFolderPATH = {currentLoadedBackupFolderPATH}]", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null)
            {
                PrintDebug($"[IsBackupZipped] - [jsonData was null!]", 2);
                return null;
            }
            List<BackupData>? dataList = jsonData.Backups;
            if (dataList == null || dataList.Count <= index)
            {
                PrintDebug($"[IsBackupZipped] - [dataList (backupDataList) was null!]", 2);
                return null;
            }
            return dataList[index].ZipPath;
        }

        public static string? GetSmartBackupZipPathFromJson(int index)
        {
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null)
            {
                PrintDebug($"[IsSmartBackupZipped] - [jsonData was null!]", 2);
                return null;
            }
            List<SmartBackupData>? dataList = jsonData.SmartBackups;
            if (dataList == null || dataList.Count <= index)
            {
                PrintDebug($"[IsSmartBackupZipped] - [dataList (backupDataList) was null!]", 2);
                return null;
            }
            return dataList[index].ZipPath;
        }


        //===========================================================================================================================================
        //=========================--------------------------------[ End Zip Archive Functions ]--------------------------------=====================
        //===========================================================================================================================================

        //-------------------------------------------------------------------------------------------------------------------------------------------

        //===========================================================================================================================================
        //=========================----------------------------------[ Start General Functions ]----------------------------------===================
        //===========================================================================================================================================

        public static bool IsBackupSavedLoose(int index)
        {
            BackupData? data = GetBackupDataFromJson(index);
            if (data == null)
            {
                return false;
            }
            string? fullPath = data.Path;
            if (string.IsNullOrWhiteSpace(fullPath))
            {
                return false;
            }
            return true;
        }

        public static bool IsSmartBackupSavedLoose(int index)
        {
            SmartBackupData? data = GetSmartBackupDataFromJson(index);
            if (data == null)
            {
                return false;
            }
            string? fullPath = data.Path;
            if (string.IsNullOrWhiteSpace(fullPath))
            {
                return false;
            }
            return true;
        }


        //===========================================================================================================================================
        //=========================-----------------------------------[ End General Functions ]-----------------------------------===================
        //===========================================================================================================================================

        public static Dictionary<string, string> GetAllSavegamesAndGamemode()
        {
            List<string> gamemodes = GetGamemodes();
            Dictionary<string, string> savegamesInGamemodes = new Dictionary<string, string>();
            foreach (string mode in gamemodes)
            {
                List<string> savegames = new List<string>();
                savegames = GetSavegamesInGamemode(mode);
                foreach (string savegame in savegames)
                {
                    savegamesInGamemodes.Add(savegame, mode);
                }
            }
            return savegamesInGamemodes;
        }


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
        
        public static string GetGamemodeFromSavegameName(string savegame)
        {
            List<string> gamemodes = GetGamemodes();
            foreach (string mode in gamemodes)
            {
                if (GamemodeContainsSavegame(mode, savegame))
                {
                    return mode;
                }
            }
            return string.Empty;
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

        public static bool DeleteBackupFromJson(int index, bool reOrder = true)
        {
            if (Configuration.smartBackupModeEnabled)
            {
                PrintDebug($"[DeleteBackupFromJson] - [SmartBackupMode is enabled] - [Aborting]");
                MessageBox.Show("You cannot delete smartBackups yet! \nAt the moment, you only be able to delete all backups in this mode!");
                return false;
            }
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null)
            {
                return false;
            }
            List<BackupData>? dataList = jsonData.Backups;
            if (dataList == null || dataList.Count <= index)
            {
                return false;
            }
            PrintDebug($"[DeleteBackupFromJson] - [index = {index}] - [BackupData = {dataList[index].Name}] - [dataList[index].Index = {dataList[index].Index}]");
            dataList.RemoveAt(index);
			if (reOrder)
			{
                dataList = SortBackupDataList(dataList);
            }
            jsonData.Backups = dataList;
            WriteJsonDataToJson(jsonData);
            return true;
        }

        public static bool SortCurrentLoadedJsonData()
        {
            JsonData? jData = ReadJsonDataFromJson();
            if (jData == null)
            {
                return false;
            }
            List<BackupData> d = SortBackupDataList(jData.Backups);
            jData.Backups = d;
            WriteJsonDataToJson(jData);
            return true;
        }

        public static List<BackupData> SortBackupDataList(List<BackupData>? backupData)
        {
            if (backupData == null || backupData.Count < 0)
            {
                PrintDebug($" - [SortBackupDataList Aborted] - [BackupDataList was null or empty]", 2);
                return new List<BackupData>();
            }
            int i = 0;
            foreach (var item in backupData)
            {
                PrintDebug($"[FunctionLibrary.cs] - [SortBackupDataList] - Backup [{item.Name}] - Changing index from [{item.Index.ToString()}] to [{i.ToString()}]");
                item.Index = i;
                i++;
            }
            return backupData;
        }

        public static List<SmartBackupData>? SortSmartBackupDataList(List<SmartBackupData>? backupData)
        {
            if (backupData == null || backupData.Count < 0)
            {
                return new List<SmartBackupData>();
            }
            int i = 0;
            foreach (var item in backupData)
            {
                PrintDebug($"[FunctionLibrary.cs] - [SortSmartBackupDataList] - SmartBackup [{item.Name}] - Changing index from [{item.Index.ToString()}] to [{i.ToString()}]");
                item.Index = i;
                i++;
            }
            return backupData;
        }

        public static void RenameBackup(int index, string? newName, bool bSmart = false)
        {
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null || string.IsNullOrEmpty(newName))
            {
                return;
            }
            BackupData? data = null;
            SmartBackupData? smartData = null;

            List<BackupData>? dataList = jsonData.Backups;
            List<SmartBackupData>? smartDataList = jsonData.SmartBackups;

            if (bSmart)
            {
                if (smartDataList != null && smartDataList.Count >= 0)
                {
                    if (index >= 0 || smartDataList.Count > index)
                    {
                        smartData = smartDataList[index];
                        if (data != null)
                        {
                            smartData.Name = newName;
                            smartDataList.RemoveAt(index);
                            smartDataList.Insert(index, smartData);
                            jsonData.SmartBackups = smartDataList;
                        }
                    }
                }
            }
            else
            {
                if (dataList != null && dataList.Count >= 0)
                {
                    if (index >= 0 || dataList.Count > index)
                    {
                        data = dataList[index];
                        if (data != null)
                        {
                            data.Name = newName;
                            dataList.RemoveAt(index);
                            dataList.Insert(index, data);
                            jsonData.Backups = dataList;
                        }
                    }
                }
            }
            WriteJsonDataToJson(jsonData);
        }


        public static string GetGamemodeByIndex(int index)
        {
            
            List<string> gamemodes = GetGamemodes();
            if (index < 0 && index >= gamemodes.Count)
            {
                return string.Empty;
            }
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

        public static int GetBackupDataPosInList(int index)
        {
            List<BackupData>? dataList = GetBackupDataListFromJson();
            if (dataList == null || dataList.Count < 0)
            {
                return -1;
            }
            int pos = dataList.FindIndex(0, x => x.Index == index);
            if (pos < 0)
            {
                PrintDebug($"[GetBackupDataPosInList] - [index = {index}] - [pos = {pos}] - [name = {dataList[pos].Name}]");
                return -1;
            }
            return pos;
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

        public static string GetSmartBackupFolderPathFromJson(int index)
        {
            SmartBackupData? data = GetSmartBackupDataFromJson(index);
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

        public static int GetBackupCountFromJson(bool bSmart = false)
        {
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null)
            {
                return 0;
            }
            return GetBackupDataCount(jsonData, bSmart);
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


        public static List<SmartBackupData>? GetSmartBackupDataListFromJson()
        {
            JsonData? jsonData = ReadJsonDataFromJson();
            if (jsonData == null)
            {
                return null;
            }
            return jsonData.SmartBackups;
        }

        public static SmartBackupData? GetSmartBackupDataFromJson(int index)
        {
            List<SmartBackupData>? dataList = GetSmartBackupDataListFromJson();

            int lastIndex = GetLastSmartBackupIndexFromJson(dataList);
            if (dataList == null || dataList.Count <= 0 || index < 0 || index > lastIndex || lastIndex < 0)
            {
                PrintDebug($"[FunctionLibrary.cs] - [GetSmartBackupDataFromJson] - [dataList = {dataList}]",1);
                return null;
            }
            //smartBackupData? bData = dataList.Find(x => x.Index == index);
            SmartBackupData? bData = null;
            if (index >= 0 && index < dataList.Count)
            {
                bData = dataList[index];
            }
            return bData;
        }

        public static BackupData? GetBackupDataFromJson(int index)
        {
            List<BackupData>? dataList = GetBackupDataListFromJson();
            int lastIndex = GetLastBackupIndexFromJson(dataList);
            if (dataList == null || dataList.Count <= 0 || index < 0 || index > lastIndex || lastIndex < 0)
            {
                return null;
            }
            BackupData? bData = dataList.Find(x => x.Index == index);
            return bData;
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

        public static string[] GetAllSmartBackupDataNamesFromJson()
        {
            List<SmartBackupData>? smartBackupDataList = GetSmartBackupDataListFromJson();
            if (smartBackupDataList == null || smartBackupDataList.Count <= 0)
            {
                return Array.Empty<string>();
            }
            List<string> outputList = new List<string>();
            foreach (var item in smartBackupDataList)
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
            List<BackupData>? dataList = GetBackupDataListFromJson();
            if (dataList == null)
            {
                return string.Empty;
            }
            BackupData? bData = dataList.Find(x => x.Index == index);
            if (bData == null)
            {
                return string.Empty;
            }
            return bData.Name;
        }

        public static string? GetSmartBackupDataNameFromJson(int index)
        {
            List<SmartBackupData>? smartDataList = GetSmartBackupDataListFromJson();
            if (smartDataList == null)
            {
                return string.Empty;
            }
            SmartBackupData? sBData = smartDataList.Find(x => x.Index == index);
            if (sBData == null)
            {
                return string.Empty;
            }
            return sBData.Name;
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
            int i = backupDataList.Count - 1;
            if (i > 0) { return backupDataList[i].Index; } else { return 0; }
        }

        public static int GetLastSmartBackupIndexFromJson(List<SmartBackupData>? smartBackupDataList = null)
        {
            if (smartBackupDataList == null)
            {
                smartBackupDataList = GetSmartBackupDataListFromJson();
            }
            if (smartBackupDataList == null)
            {
                return -1;
            }
            int i = smartBackupDataList.Count - 1;
            if (i > 0) { return smartBackupDataList[i].Index; } else { return 0; }
        }

        public static int GetBackupCount()
        {
            string[] backupFolders = GetBackups();
            return backupFolders.Length;
        }

        public static string[] GetBackups(string? path = null)
        {
            string p = string.Empty;
            if (string.IsNullOrWhiteSpace(path))
            {
                p = currentLoadedBackupFolderPATH;
            }
            else
            {
                p = path;
            }
            string[] fullPathList = Directory.GetDirectories(p);

            List<string> outputList = new List<string>();
            int i = 1;
            foreach (var item in fullPathList)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(p + item);
                outputList.Add(dirInfo.Name);
                i++;
            }
            return outputList.ToArray();
        }

        public static string[] GetAllBackupFolders()
        {
            string[] fullPathList = Directory.GetDirectories(currentBaseBackupFolderPATH);

            List<string> outputList = new List<string>();
            int i = 1;
            foreach (var item in fullPathList)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(currentBaseBackupFolderPATH + item);
                if (dirInfo.Name.Equals("Database", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                outputList.Add(dirInfo.Name);
                i++;
            }
            return outputList.ToArray();
        }

        public static List<string> GetAllFolderPathsInBackupDir()
        {
            string[] paths = Directory.GetDirectories(currentBaseBackupFolderPATH);

            List<string> outputList = new List<string>();
            foreach (var path in paths)
            {
                outputList.Add(path);
            }
            return outputList;
        }

        public static List<string> GetAllBackupFolderPathsContainingBackupFiles()
        {
            List<string> outputList = new List<string>();
            List<string> paths = GetAllFolderPathsInBackupDir();

            foreach (string path in paths)
            {
                int dirCount = Directory.GetDirectories(path).Length;
                if (dirCount > 0)
                {
                    PrintDebug($"[FunctionLibrary.cs] - [GetAllBackupFolderPathsContainingBackupFiles] - [Found dir containing {dirCount} folders] - [path = {path}]");
                    outputList.Add(path);
                }
            }
            return outputList;
        }

        public static List<string> GetFolderNamesFromDirectoryPaths(List<string> paths)
        {
            List<string> outputList = new List<string>();

            foreach (string path in paths)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(currentBaseBackupFolderPATH + path);
                outputList.Add(dirInfo.Name);
            }
            return outputList;
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

        public static long FilesSize(List<string>? files)
        {
            if (files == null || files.Count <= 0)
            {
                return 0;
            }
            long size = 0;
            FileInfo[] fis = new FileInfo[files.Count];
            int i = 0;
            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    FileInfo fi = new FileInfo(file);
                    fis[i] = fi;
                    i++;
                }
            }
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            return size;
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

        public static string FormatStringBytesToDynamicSizeString(string bytesString)
        {
            if (string.IsNullOrWhiteSpace(bytesString))
            {
                return "0 B";
            }
            if (long.TryParse(bytesString, out long bytes))
            {
                if (bytes < 1024)
                {
                    return $"{bytes} B";
                }
                else if (bytes < 1048576)
                {
                    return $"{ConvertBytesToKB(bytes):F2} KB";
                }
                else
                {
                    return $"{ConvertBytesToMB(bytes):F2} MB";
                }
            }
            return "Invalid Size";
        }

        public static string GetUnlistedJsonDataFilePath(string savegame)
        {
            return currentBaseBackupFolderPATH + @"\" + savegame + @"\data.json";
        }

        public static string GetJsonDataFilePath()
        {
            string filePath = currentLoadedBackupFolderPATH + @"\data.json";

            if (string.IsNullOrEmpty(currentLoadedBackupFolderPATH))
            {
                filePath = currentBaseBackupFolderPATH + @"\None" + @"\data.json";
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
            //return @"Backup_9";
            return @"Backup_" + (index).ToString();
        }
    }
}
