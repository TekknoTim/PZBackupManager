using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using static ZomboidBackupManager.Configuration;

namespace ZomboidBackupManager
{
    public class Config
    {
        public string? AbsoluteSavegamePATH { get; set; }
        public string? BaseBackupFolderPATH { get; set; }
        public bool showMessageWhenBackupProcessDone { get; set; }
        public bool SelectLastLoadedOnStart { get; set; }
        public int LastLoadedSavegameIndex { get; set; }
        public int LastLoadedGamemodeIndex { get; set; }
        public string? LastLoadedSavegame { get; set; }
        public string? LastLoadedGamemode { get; set; }

        public Config(string? absSgPATH, string? baseBkpPATH, bool showMsg, bool selectLastLoadedOnStart)
        {
            AbsoluteSavegamePATH = absSgPATH;
            BaseBackupFolderPATH = baseBkpPATH;
            showMessageWhenBackupProcessDone = showMsg;
            SelectLastLoadedOnStart = selectLastLoadedOnStart;
            LastLoadedSavegameIndex = currentLoadedSavegameIndex;
            LastLoadedGamemodeIndex = currentLoadedGamemodeIndex;
            LastLoadedSavegame = currentLoadedSavegame;
            LastLoadedGamemode = currentLoadedGamemode;

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
            Config cfg = new Config(absoluteSavegamePATH, currentBaseBackupFolderPATH, showMsgWhenBackupProcessDone, autoSelectSavegameOnStart);
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
                await WriteCfgToJson();
            }
            string? json = File.ReadAllText(appConfig);
            if (string.IsNullOrEmpty(json))
            {
                PrintDebug("ReadCfgFromJson --> Config file is empty! Writing values..");
                await WriteCfgToJson();
            }
            Config? cfg = JsonConvert.DeserializeObject<Config>(json);
            if (cfg == null)
            {
                PrintDebug("ReadCfgFromJson --> Deserialized Config is null! Writing values..");
                await WriteCfgToJson();
                json = File.ReadAllText(appConfig);
            }
            else
            {
                if (string.IsNullOrEmpty(cfg.AbsoluteSavegamePATH) || string.IsNullOrEmpty(cfg.BaseBackupFolderPATH))
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
                }
            }


        }


        //General Properties:
        private static readonly string appConfig = Application.StartupPath + @"\config.json";
        public static readonly string placeholderThumbnail = Application.StartupPath + @"\placeholder.png";

        //Debug Properties:

        private static readonly string debugInfoLabel = @"[Zomboid Savegame Manager] - [INFO] - ";
        private static readonly string debugWarningLabel = @"[Zomboid Savegame Manager] - [WARNING] - ";
        private static readonly string debugErrorLabel = @"[Zomboid Savegame Manager] - [ERROR] - ";


        //Private Path Properties:
        private static readonly string relativeHookFilePATH = @"\Zomboid\lua\PZBaManagerHook.ini";
        private static readonly string relativeSavegamePATH = @"\Zomboid\Saves\";
        private static readonly string baseBackupDataFile = @"\GeneralBackupData.json";
        private static readonly string baseBackupFolderPATH = Application.StartupPath + @"Backups";

        public static readonly string hookCommand_Backup = @"b";    // Sent by the game, to create a new backup
        public static readonly string hookCommand_Test = @"t";      // Sent by the game, to show the user, the hook connection is established. Will be sent, when ModOption Menu "Test" button was pressed.
        public static readonly string hookCommand_Done = @"d";      // Sent by this program to confirm, backup process is done
        public static readonly string hookCommand_Confirm = @"c";

        //Public Path Properties:

        public static string userProfilePATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static string absoluteSavegamePATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + relativeSavegamePATH;
        public static string absoluteHookFilePATH = userProfilePATH + relativeHookFilePATH;
        public static string currentBaseBackupFolderPATH = Application.StartupPath + @"Backups";

        public static string currentLoadedSavegame = string.Empty;
        public static string currentLoadedGamemode = string.Empty;
        public static string currentLoadedBackupFolderPATH = string.Empty;      // eg. G:\Visual Studio Projects\ZomboidBackupManager\bin\Debug\net9.0-windows\Backups\<SavegameName>
        public static int currentLoadedSavegameIndex = -1;
        public static int currentLoadedGamemodeIndex = -1;
        public static bool showMsgWhenBackupProcessDone = true;
        public static bool autoSelectSavegameOnStart = false;

        //Debug Functions:

        public static void PrintDebug(string msg, int lvl = 0)
        // msg = the debug message, which is printed in console.
        // lvl = the level of the message. 1 = Warning ; 2 = Error ; any other = info
        {
            string label = string.Empty;
            if (lvl > 0)
            {
                label = debugWarningLabel;
            }
            else if (lvl > 1)
            {
                label = debugErrorLabel;
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
            PrintDebug("======================================================");
            PrintDebug("-------------[ Starting Initialization! ]-------------");
            PrintDebug("======================================================");
            PrintDebug("[Initialization] --> Setting Properties:");
            currentBaseBackupFolderPATH = baseBackupFolderPATH;
            absoluteSavegamePATH = userProfilePATH + relativeSavegamePATH;
            CreateDirStructures(currentBaseBackupFolderPATH);
            LoadConfigurationFromJson();
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

        public static bool LoadJustGamemode(string? gamemode, int gamemodeIndex)
        {
            if (gamemode == currentLoadedGamemode || string.IsNullOrEmpty(gamemode))
            {
                PrintDebug("[LoadSavegame] - Savegame already loaded!");
                return false;
            }
            currentLoadedSavegame = string.Empty;
            currentLoadedGamemode = gamemode;
            currentLoadedBackupFolderPATH = string.Empty;
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
            if (name == currentLoadedSavegame && gamemode == currentLoadedGamemode)
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

        public static void CreateBaseBackupFolderJson(string path)
        {
            string p = path + baseBackupDataFile;
            if (!File.Exists(p))
            {
                File.Create(p);
            }
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
