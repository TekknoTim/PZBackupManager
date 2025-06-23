using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.JsonData;


namespace ZomboidBackupManager
{
    public class DatabaseData
    {
        // Auto - Properties:
        [JsonIgnore]
        public bool DatabaseLoaded { get { return Database != null; } }
        [JsonIgnore]
        public bool HasDatabase { get { return File.Exists(DatabasePath); } }
        [JsonIgnore]
        public string BaseBackupDir { get { return Path.GetDirectoryName(DatabasePath) ?? string.Empty; } }
        // Public - Properties:
        public string Savegame { get; set; }
        public string Gamemode { get; set; }
        public string SavegamePath { get; set; }
        public string BackupFolderPath { get; set; }
        public string DatabasePath { get; set; }
        public bool HasBaseBackup { get; set; }
        // MetaData - Properties:
        public int DBSize { get; set; }
        public DateTime? DBDateCreated { get; set; }
        public DateTime? DBDateEdited { get; set; }

        [JsonIgnore]
        private Dictionary<string, FileRecord>? database;
        [JsonIgnore]
        public Dictionary<string, FileRecord>? Database { get { return database; } }

        public DatabaseData(string savegame, string gamemode, string savegamePath, string backupPath, string databasePath)
        {
            Savegame = savegame;
            Gamemode = gamemode;
            SavegamePath = savegamePath;
            BackupFolderPath = backupPath;
            DatabasePath = databasePath;
            HasBaseBackup = false;
            DBSize = 0;
            DBDateCreated = null;
            DBDateEdited = null;
            database = null;
        }

        public bool UpdateDatabase(List<string> copiedFilePaths)
        {
            if (!HasDatabase || !DatabaseLoaded)
            {
                MessageBox.Show($"Database not loaded or does not exist for savegame: {Savegame}");
                return false;
            }
            string liveDirectoryPath = SavegamePath;
            string rootPath = Path.GetFullPath(liveDirectoryPath).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;

            foreach (string filePath in copiedFilePaths)
            {
                var fileInfo = new FileInfo(filePath);
                if (!fileInfo.Exists) continue;

                string relativePath = filePath.Substring(rootPath.Length);

                database![relativePath] = new FileRecord
                {
                    FilePath = relativePath,
                    Size = fileInfo.Length,
                    LastModifiedUtc = fileInfo.LastWriteTimeUtc
                };
            }
            return SaveData();
        }

        public async Task<bool> CreateInitialBaseBackup(System.Windows.Forms.Label? statusLabel = null, System.Windows.Forms.ProgressBar? progressBar = null, ToolStripProgressBar? tsProgressBar = null)
        {
            Backup backup = new Backup();
            bool bResult = await backup.DoInitialBaseBackup(this, statusLabel, progressBar, tsProgressBar);
            HasBaseBackup = bResult;
            return bResult;
        }

        public void ClearDatabase()
        {
            PrintDebug($"[DatabaseData] - [ClearDatabase] - [Clearing database for savegame = {Savegame}]");
            database = null;
            HasBaseBackup = false;
            DBSize = 0;
            DBDateCreated = DateTime.MinValue;
            DBDateEdited = DateTime.MinValue;
            DeleteDatabase(DatabasePath);
        }

        public Dictionary<string, FileRecord>? GetDatabase()
        {
            if (!DatabaseLoaded)
            {
                PrintDebug($"[DatabaseData] - [GetDatabase] - [Database is null for savegame = {Savegame}]");
                string sResult = LoadDatabase(false);
                if (sResult.Equals("Loading Failed"))
                {
                    PrintDebug($"[DatabaseData] - [GetDatabase] - [Failed to load database] - [sResult = {sResult}]", 2);
                    return null;
                }
                PrintDebug($"[DatabaseData] - [GetDatabase] - [Database loaded successfully] - [sResult = {sResult}]");
                if (DatabaseLoaded) { return Database!; }
                return null;
            }
            else
            {
                PrintDebug($"[DatabaseData] - [GetDatabase] - [Database already loaded]");
                if (DatabaseLoaded) { return Database!; }
                return null;
            }
        }

        public bool SaveData()
        {
            bool bSaved = SaveDatabaseAsJson();
            if (bSaved)
            {
                PrintDebug($"[DatabaseData] - [SaveData] - [Database saved successfully]");
            }
            else
            {
                PrintDebug($"[DatabaseData] - [SaveData] - [Failed to save database]");
            }
            return bSaved;
        }

        private bool SaveDatabaseAsJson()
        {
            if (Database == null || Database.Count == 0)
            {
                PrintDebug($"[DatabaseData] - [SaveDatabaseAsJson] - [Database is empty for savegame = {Savegame}]", 2);
                return false;
            }
            WriteDatabaseToJson(DatabasePath, Database);
            DBDateEdited = DateTime.Now;
            PrintDebug($"[DatabaseData] - [SaveDatabaseAsJson] - [Database saved to JSON at path = {DatabasePath}]");
            return true;
        }

        public string LoadDatabase(bool bCreateNew = false)
        {
            bool result = TryToLoadDatabase();
            if (!result || !DatabaseLoaded)
            {
                if (bCreateNew)
                {
                    PrintDebug($"[DatabaseData] - [LoadDatabase failed] - [No Database loaded] - [Creating new database at path = {DatabasePath}]");
                    CreateDataBase();
                    return "Created";
                }
                else
                {
                    PrintDebug($"[DatabaseData] - [LoadDatabase] - [Failed to load or create database]");
                    return "Loading Failed";
                }
            }
            else
            {
                PrintDebug($"[DatabaseData] - [LoadDatabase] - [Database loaded successfully] - [DBSize = {DBSize}]");
                return "Loaded";
            }
        }

        private void CreateDataBase()
        {
            if (string.IsNullOrWhiteSpace(SavegamePath))
            {
                PrintDebug($"[DatabaseData.cs] - [CreateDataBase] - [Invalid Path!] - [SavegamePath = {SavegamePath}]");
                return;
            }
            Dictionary<string, FileRecord> db = BuildFileDatabase(SavegamePath);
            DBSize = db.Count;
            DBDateCreated = DateTime.Now;
            DBDateEdited = DateTime.Now;
            WriteDatabaseToJson(DatabasePath, db);
            database = db;
        }

        private bool TryToLoadDatabase()
        {
            PrintDebug($"[DatabaseData] - [LoadDatabase] - [DatabasePath = {DatabasePath}]");
            if (string.IsNullOrEmpty(DatabasePath) || !File.Exists(DatabasePath))
            {
                PrintDebug($"[DatabaseData] - [LoadDatabase] - [Database does not exist at path = {DatabasePath}]");
                return false;
            }
            Dictionary<string, FileRecord>? dbContent = GetDatabaseFromJson();
            if (dbContent == null)
            {
                PrintDebug($"[DatabaseData] - [LoadDatabase] - [Failed to load database from JSON]");
                return false;
            }
            database = dbContent;
            DBSize = database.Count;
            PrintDebug($"[DatabaseData] - [LoadDatabase] - [Loaded database with {DBSize} records]");
            return true;
        }

        private Dictionary<string, FileRecord>? GetDatabaseFromJson()
        {
            string? dirPath = Path.GetDirectoryName(DatabasePath);
            if (string.IsNullOrEmpty(dirPath))
            {
                MessageBox.Show($"Invalid dir path = [{dirPath}]");
                return null;
            }
            if (!File.Exists(DatabasePath))
            {
                PrintDebug($"[DatabaseData] - [GetDatabaseFromJson] - [Database not existing at path = {DatabasePath}]");
                return null;
            }
            PrintDebug($"[DatabaseData] - [GetDatabaseFromJson] - [backupFolderPath = {Configuration.currentBaseBackupFolderPATH}]");
            PrintDebug($"[DatabaseData] - [GetDatabaseFromJson] - [jsonPath = {DatabasePath}]");
            string json = File.ReadAllText(DatabasePath);
            Dictionary<string, FileRecord>? content = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, FileRecord>>(json);
            return content;
        }

        private void WriteDatabaseToJson(string path, Dictionary<string, FileRecord> database)
        {
            string? dirPath = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(dirPath)) { MessageBox.Show($"Invalid dir path = [{dirPath}]"); return; }
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            PrintDebug($"[FileDatabaseInfo] - [WriteDatabaseToJson] - [backupFolderPath = {Configuration.currentBaseBackupFolderPATH}]");
            PrintDebug($"[FileDatabaseInfo] - [WriteDatabaseToJson] - [path = {path}]");

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(database, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(path, json);
        }

        private bool DeleteDatabase(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }

        private Dictionary<string, FileRecord> BuildFileDatabase(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                return new Dictionary<string, FileRecord>(); 
            }
            PrintDebug($"[FileDatabaseInfo] - [BuildFileDatabase] - [directoryPath = {directoryPath}]");
            var database = new Dictionary<string, FileRecord>();

            string rootPath = Path.GetFullPath(directoryPath).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;

            string[] allFiles = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);


            foreach (string filePath in allFiles)
            {
                var fileInfo = new FileInfo(filePath);

                string relativePath = filePath.Substring(rootPath.Length);

                database[relativePath] = new FileRecord
                {
                    FilePath = relativePath,
                    Size = fileInfo.Length,
                    LastModifiedUtc = fileInfo.LastWriteTimeUtc
                };
            }
            return database;
        }
    }
}
