﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

using static ZomboidBackupManager.Configuration;
using SharpCompress.Common;

namespace ZomboidBackupManager
{
    public class Config
    {
        public float ConfigVersion { get; set; }
        public string? AbsoluteSavegamePATH { get; set; }
        public string? BaseBackupFolderPATH { get; set; }
        public bool showMessageWhenBackupProcessDone { get; set; }
        public bool SelectLastLoadedOnStart { get; set; }
        public bool SaveBackupsAsZip {  get; set; }
        public bool KeepBackupFolder { get; set; }
        public int LastLoadedSavegameIndex { get; set; }
        public int LastLoadedGamemodeIndex { get; set; }
        public string? LastLoadedSavegame { get; set; }
        public string? LastLoadedGamemode { get; set; }
        public int AutoDeleteKeepBackupsCount { get; set; }
        public bool AutoDeleteFeatureEnabled { get; set; }
        public int UsedZipArchiverID { get; set; }
        public string ZipArchiverExePath { get; set; }
        public  bool ExperimentalFeatures {  get; set; }

        public Config(float ver, string? absSgPATH, string? baseBkpPATH, bool showMsg, bool selectLastLoadedOnStart, bool saveAsZip, bool keepBackupFolder, int autoDelKeepBackupsCount, bool autoDeleteFeatureEnabled, int zipArchiver, string archiverExe, bool expFeatures)
        {
            ConfigVersion = ver;
            AbsoluteSavegamePATH = absSgPATH;
            BaseBackupFolderPATH = baseBkpPATH;
            showMessageWhenBackupProcessDone = showMsg;
            SelectLastLoadedOnStart = selectLastLoadedOnStart;
            SaveBackupsAsZip = saveAsZip;
            KeepBackupFolder = keepBackupFolder;
            if (currentLoadedSavegameIndex >= 0) { LastLoadedSavegameIndex = currentLoadedSavegameIndex; } else { LastLoadedSavegameIndex = -1; }
            if (currentLoadedGamemodeIndex >= 0) { LastLoadedGamemodeIndex = currentLoadedGamemodeIndex; } else {  LastLoadedGamemodeIndex = -1; }
            if (!string.IsNullOrWhiteSpace(currentLoadedSavegame)) { LastLoadedSavegame = currentLoadedSavegame; } else { LastLoadedSavegame = string.Empty; }
            if (!string.IsNullOrWhiteSpace(currentLoadedGamemode)) { LastLoadedGamemode = currentLoadedGamemode; } else { LastLoadedGamemode = string.Empty; }
            AutoDeleteKeepBackupsCount = autoDelKeepBackupsCount;
            AutoDeleteFeatureEnabled = autoDeleteFeatureEnabled;
            UsedZipArchiverID = zipArchiver;
            ZipArchiverExePath = archiverExe;
            ExperimentalFeatures = expFeatures;
        }
    }

    public class Configuration
    {
        public static async Task GenerateEmptyConfigFile()
        {
            if (File.Exists(appConfig))
            {
                return;
            }

            FileStream stream = File.Create(appConfig);
            await Task.Run(stream.Close);
        }

        public static async Task WriteCfgToJson()
        {
            await GenerateEmptyConfigFile();
            Config cfg = new Config(version, absoluteSavegamePATH, currentBaseBackupFolderPATH, showMsgWhenBackupProcessDone, autoSelectSavegameOnStart, saveBackupsAsZipFile, keepBackupFolderAfterZip, autoDeleteKeepBackupsCount, autoDeleteEnabled, usedZipArchiver, zipArchiverExePath, expFeaturesEnabled);
            string? json = JsonConvert.SerializeObject(cfg, Formatting.Indented);
            File.WriteAllText(appConfig, json);
            PrintDebug("[Config] - [WriteConfigToJson] --> Done!");
            //MessageBox.Show("Setting written to json!");
        }

        public static async void LoadConfigurationFromJson()
        {
            await ReadCfgFromJson();
        }

        public static bool LoadLastLoadedSavegame()
        {
            if (!File.Exists(appConfig))
            {
                PrintDebug("LoadLastLoadedSavegame --> Config file not found!", 2);
                return false;
            }
            string? json = File.ReadAllText(appConfig);
            if (string.IsNullOrEmpty(json))
            {
                PrintDebug("LoadLastLoadedSavegame --> Config file is empty!", 2);
                return false;
            }
            Config? cfg = JsonConvert.DeserializeObject<Config>(json);
            if (cfg == null)
            {
                PrintDebug("LoadLastLoadedSavegame --> Deserialized Config is null!", 2);
                return false;
            }
            if (string.IsNullOrEmpty(cfg.LastLoadedSavegame) || string.IsNullOrEmpty(cfg.LastLoadedGamemode))
            {
                PrintDebug("LoadLastLoadedSavegame --> LastLoadedSavegame or LastLoadedGamemode is null!", 2);
                return false;
            }
            PrintDebug($"[LoadLastLoadedSavegame] --> Found: LastLoadedSavegame = [{cfg.LastLoadedSavegame}] - LastLoadedGamemode = [{cfg.LastLoadedGamemode}]");
            return LoadSavegame(cfg.LastLoadedSavegame, cfg.LastLoadedGamemode, cfg.LastLoadedSavegameIndex, cfg.LastLoadedGamemodeIndex);
        }

        public static async Task ReadCfgFromJson()
        {
            if (!File.Exists(appConfig))
            {
                PrintDebug("ReadCfgFromJson --> Config file not found! Creating a new one.");
                showUpdateInfoWindow = true;
                await WriteCfgToJson();
            }
            string? json = File.ReadAllText(appConfig);
            if (string.IsNullOrEmpty(json))
            {
                PrintDebug("ReadCfgFromJson --> Config file is empty! Writing values..");
                showUpdateInfoWindow = true;
                await WriteCfgToJson();
            }
            Config? cfg = JsonConvert.DeserializeObject<Config>(json);
            if (cfg == null)
            {
                PrintDebug("ReadCfgFromJson --> Deserialized Config is null! Writing values..");
                showUpdateInfoWindow = true;
                await WriteCfgToJson();
            }
            else
            {
                if (cfg.ConfigVersion < version)
                {
                    PrintDebug($"[Configuration] - [ReadCfgFromJson] - [Config file outdated!] - [cfg.ConfigVersion = {cfg.ConfigVersion}] - [version = {version}] Writing values..");
                    DoUpdate(cfg.ConfigVersion);

                    await WriteCfgToJson();

                }
                else if (string.IsNullOrEmpty(cfg.AbsoluteSavegamePATH) || string.IsNullOrEmpty(cfg.BaseBackupFolderPATH))
                {
                    PrintDebug("ReadCfgFromJson --> Deserialized Config has null values! Writing values..");
                    await WriteCfgToJson();
                }
                else
                {
                    absoluteSavegamePATH = cfg.AbsoluteSavegamePATH;
                    currentBaseBackupFolderPATH = cfg.BaseBackupFolderPATH;
                    showMsgWhenBackupProcessDone = cfg.showMessageWhenBackupProcessDone;
                    autoSelectSavegameOnStart = cfg.SelectLastLoadedOnStart;
                    saveBackupsAsZipFile = cfg.SaveBackupsAsZip;
                    keepBackupFolderAfterZip = cfg.KeepBackupFolder;
                    autoDeleteKeepBackupsCount = cfg.AutoDeleteKeepBackupsCount;
                    autoDeleteEnabled = cfg.AutoDeleteFeatureEnabled;
                    usedZipArchiver = cfg.UsedZipArchiverID;
                    zipArchiverExePath = cfg.ZipArchiverExePath;
                    expFeaturesEnabled = cfg.ExperimentalFeatures;

                }
            }
        }

        private static void DoUpdate(float oldVersion)
        {
            PrintDebug($"[Configuration] - [DoUpdate] - [Starting Update] - [Old Version = {oldVersion}] -> [New Version = {version}]");
            showUpdateInfoWindow = true;
            
            PrintDebug($"[Configuration] - [DoUpdate] - [Update done]");
        }

        private static void WriteModVersionFile()
        {
            string? dirPath = Path.GetDirectoryName(absoluteModVersionFilePATH);
            if (string.IsNullOrWhiteSpace(dirPath))
            {
                dirPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Zomboid\lua\PZBackupManager\";
            }
            if (!System.IO.Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);

            }
            if (!File.Exists(absoluteModVersionFilePATH))
            {
                FileStream stream = System.IO.File.Create(absoluteModVersionFilePATH);
                stream.Close();
            }
            if (!File.Exists(absoluteHookStatsFilePATH))
            {
                FileStream stream = System.IO.File.Create(absoluteHookStatsFilePATH);
                stream.Close();
            }
            string[] data = new string[2];
            string[] lines = File.ReadAllLines(absoluteModVersionFilePATH);
            if (lines.Length < 1 || string.IsNullOrWhiteSpace(lines[0]))
            {
                data[0] = string.Empty;
            }
            else
            {
                data[0] = lines[0];
            }
            
            data[1] = @"app=" + version.ToString();
            File.WriteAllLines(absoluteModVersionFilePATH, data);
        }

        //General Properties:
        private static readonly float version = 2505.15f;
        public static readonly string appVersion = "v0.0.62";
        public static bool initRunning = false;
        
        private static readonly string appConfig = Application.StartupPath + @"\config.json";
        public static readonly string cleanUpHelperFile = Application.StartupPath + @"\AutoCleanupHelp.txt";
        public static readonly string placeholderThumbnail = Application.StartupPath + @"\placeholder.png";

        //Debug Properties:

        private static readonly string debugInfoLabel = @"[Zomboid Savegame Manager] - [INFO] - ";
        private static readonly string debugWarningLabel = @"[Zomboid Savegame Manager] - [WARNING] - ";
        private static readonly string debugErrorLabel = @"[Zomboid Savegame Manager] - [ERROR] - ";


        //Private Path Properties:
        private static readonly string relativeHookFilePATH = @"\Zomboid\lua\PZBaManagerHook.ini";
        private static readonly string relativeHookStatsFilePATH = @"\Zomboid\lua\PZBackupManager\PZBaManagerStatusData.txt";
        private static readonly string relativeModVersionFilePATH = @"\Zomboid\lua\PZBackupManager\version.txt";
        private static readonly string relativeSavegamePATH = @"\Zomboid\Saves\";
        private static readonly string baseBackupFolderPATH = Application.StartupPath + @"Backups";

        public static readonly string hookCommand_Backup = @"b";    // Sent by the game, to create a new backup
        public static readonly string hookCommand_Test = @"t";      // Sent by the game, to show the user, the hook connection is established. Will be sent, when ModOption Menu "Test" button was pressed.
        public static readonly string hookCommand_Done = @"d";      // Sent by this program to confirm, backup process is done
        public static readonly string hookCommand_Confirm = @"c";

        //Public Path Properties:

        public static string userProfilePATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static string absoluteSavegamePATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + relativeSavegamePATH;
        public static string absoluteHookFilePATH = userProfilePATH + relativeHookFilePATH;
        public static string absoluteHookStatsFilePATH = userProfilePATH + relativeHookStatsFilePATH;
        public static string absoluteModVersionFilePATH = userProfilePATH + relativeModVersionFilePATH;
        public static string currentBaseBackupFolderPATH = Application.StartupPath + @"Backups";

        public static string currentLoadedSavegame = string.Empty;
        public static string currentLoadedGamemode = string.Empty;
        public static string currentLoadedBackupFolderPATH = currentBaseBackupFolderPATH + @"\None";      // eg. G:\Visual Studio Projects\ZomboidBackupManager\bin\Debug\net9.0-windows\Backups\<SavegameName>
        public static int currentLoadedSavegameIndex = -1;
        public static int currentLoadedGamemodeIndex = -1;
        public static bool showMsgWhenBackupProcessDone = true;
        public static bool autoSelectSavegameOnStart = false;
        public static bool saveBackupsAsZipFile = false;
        public static bool keepBackupFolderAfterZip = true;
        public static bool autoDeleteEnabled = false;
        public static bool expFeaturesEnabled = false;

        public static int autoDeleteKeepBackupsCount = 5;
        public static int autoDelBackupCountUserSet = 5;
        public static readonly int autoDeleteKeepBackupsMax = 40;

        public static int usedZipArchiver = 0; // 0 = intern (slowest) ; 1 = WinRar (faster) ; 1 = 7Zip (fastest)
        public static string zipArchiverExePath = string.Empty;

        public static bool indexChangeEventsSuspended = false;

        public static bool showUpdateInfoWindow = false;

        //Debug Functions:

        public static void PrintDebug(string msg, int lvl = 0)
        // msg = the debug message, which is printed in console.
        // lvl = the level of the message. 1 = Warning ; 2 = Error ; any other = info
        {
            string label = string.Empty;
            if (lvl == 2)
            {
                label = debugErrorLabel;
            }
            else if (lvl == 1)
            {
                label = debugWarningLabel;
            }
            else
            {
                label = debugInfoLabel;
            }
            string fullMessage = label + msg;
            Debug.WriteLine(fullMessage);
        }

        //Initialization
        public static void Init()
        {
            initRunning = true;
            PrintDebug("======================================================");
            PrintDebug("-------------[ Starting Initialization! ]-------------");
            PrintDebug("======================================================");
            PrintDebug("[Initialization] --> Setting Properties:");
            currentBaseBackupFolderPATH = baseBackupFolderPATH;
            absoluteSavegamePATH = userProfilePATH + relativeSavegamePATH;
            CreateDirStructures(currentBaseBackupFolderPATH);
            LoadConfigurationFromJson();
            WriteModVersionFile();
            PrintDebug($"userProfilePATH = [{userProfilePATH}] \n absoluteSavegamePATH = [{absoluteSavegamePATH}] \n currentBaseBackupFolderPATH = [{currentBaseBackupFolderPATH}]");
            PrintDebug("[Initialization] --> Setting Properties Done! --> Loading last loaded savegame");
            if (autoSelectSavegameOnStart)
            {
                bool res = LoadLastLoadedSavegame();
                if (res)
                {
                    PrintDebug("[Initialization] --> Last loaded savegame loaded successfully!");
                }
                else
                {
                    PrintDebug("[Initialization] --> Last loaded savegame could not be loaded!", 2);
                }
            }
            else
            {
                PrintDebug("[Initialization] --> Load Last loaded savegame aborted! -> Feature disabled");
            }
            PrintDebug("======================================================");
            PrintDebug("--------------------[ Init Done! ]--------------------");
            PrintDebug("======================================================");
        }

        public static void CreateDirStructures(string backupFolderPATH)
        {
            PrintDebug("CreateDirStructures --> Creating directory @ = " + backupFolderPATH);
            if (!Directory.Exists(backupFolderPATH))
            {
                Directory.CreateDirectory(backupFolderPATH);
            }
            else
            {
                PrintDebug("CreateDirStructures --> backupsFolderPATH already existed @ = " + backupFolderPATH);
            }
            //CreateBaseBackupFolderJson(backupFolderPATH);
        }

        public static async void SaveConfig()
        {
            await WriteCfgToJson();
        }

        public static bool IsAnySavegameLoadedCurrently()
        {
            if (string.IsNullOrWhiteSpace(currentLoadedSavegame) || currentLoadedSavegameIndex < 0)
            {
                return false;
            }
            return true;
        }

        public static void SetIndexChangeEventsSuspended(Object sender, bool isSuspended)
        {
            indexChangeEventsSuspended = isSuspended;
            PrintDebug($"[Configuration] - [SetIndexChangeEventsSuspended] - [indexEventsSuspended = {indexChangeEventsSuspended}] - [sender = [{sender.ToString()}]");
        }

        public static void UnloadCurrentLoadedSavegame()
        {
            PrintDebug($"[Configuration] - [UnloadSavegame] - Unloading savegame --> [Savegame = {currentLoadedSavegame}] - [SavegameIndex = {currentLoadedSavegameIndex}]");
            currentLoadedSavegame = string.Empty;
            currentLoadedSavegameIndex = -1;
        }

        public static bool LoadJustGamemode(string? gamemode, int gamemodeIndex)
        {
            if (string.IsNullOrWhiteSpace(gamemode))
            {
                PrintDebug($"[Configuration] - [LoadJustGamemode] - Failed to load gamemode because it was null, empty or whitspaced - [gamemode = {gamemode}]");
                return false;
            }
            currentLoadedSavegame = string.Empty;
            currentLoadedGamemode = gamemode;
            currentLoadedBackupFolderPATH = currentBaseBackupFolderPATH + @"\None";
            currentLoadedGamemodeIndex = gamemodeIndex;
            currentLoadedSavegameIndex = -1;
            SaveConfig();
            return true;
        }

        public static bool LoadSavegame(string name, string gamemode, int savegameIndex, int gamemodeIndex)
        {
            string path = currentBaseBackupFolderPATH + @"\" + name;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if ((name == currentLoadedSavegame) && (savegameIndex == currentLoadedSavegameIndex) && (gamemode == currentLoadedGamemode) && (gamemodeIndex == currentLoadedGamemodeIndex))
            {
                PrintDebug("[LoadSavegame] - Savegame already loaded!");
                return false;
            }
            currentLoadedSavegame = name;
            currentLoadedGamemode = gamemode;
            currentLoadedBackupFolderPATH = path;
            currentLoadedGamemodeIndex = gamemodeIndex;
            currentLoadedSavegameIndex = savegameIndex;
            SaveConfig();
            return true;
        }

        public static async void ChangeBackupFolderPath(string newPATH)
        {
            currentBaseBackupFolderPATH = newPATH;
            await WriteCfgToJson();
        }

        public static string GetFullSavegamesPath(string gamemode)
        {
            return @"" + absoluteSavegamePATH + gamemode;
        }

        public static string GetFullLoadedSavegamePath()
        {
            if (string.IsNullOrEmpty(currentLoadedGamemode) || string.IsNullOrEmpty(currentLoadedSavegame))
            {
                PrintDebug("[GetFullLoadedSavegamePath] - a variable was 0 or an empty string!", 2);
                PrintDebug($"[currentLoadedGamemode = {currentLoadedGamemode}]", 2);
                PrintDebug($"[currentLoadedSavegame = {currentLoadedSavegame}]", 2);
                return string.Empty;
            }
            return absoluteSavegamePATH + currentLoadedGamemode + @"\" + currentLoadedSavegame;
        }
    }
}
