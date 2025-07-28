using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public class BackupHistoryImporter
    {
        public string FilePath { get { return Configuration.absoluteBackupHistoryFilePATH; } }
        public string Savegame { get; set; }

        private const int maxValues = 7; // Maximum number of values expected in a line

        public BackupHistoryImporter(string savegame)
        {
            Savegame = savegame;
        }

        public List<string> Import()
        {
            List<string> history = new List<string>();
            try
            {
                if (File.Exists(FilePath))
                {
                    string[] lines = File.ReadAllLines(FilePath);
                    foreach (string line in lines)
                    {
                        if (line.Split(',')[0].Equals(Savegame))
                        {
                            Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [Import] - [Adding Line] - [Line = {line}]");
                            history.Add(line);
                        }
                    }
                }
                else
                {
                    Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [Import] - [Backup_History.csv not found!]", 1);
                    throw new FileNotFoundException($"Backup history file not found at {FilePath}");
                }
            }
            catch (Exception ex)
            {
                Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [Import] - [Message: {ex}]", 2);
            }
            return history;
        }

        public bool DataExists()
        {
            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);
                foreach (string line in lines)
                {
                    if (line.Split(',')[0].Equals(Savegame))
                    {
                        Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [DataExists] - [Data exists for {Savegame}]");
                        return true;
                    }
                    else
                    {
                        Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [DataExists] - [Data doesn't exist for {Savegame}]",1);
                    }
                }
            }
            else
            {
                Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [DataExists] - [Backup_History.csv not found!]", 1);
            }
            return false;
        }

        public void SetTargetSavegame(string savegame)
        {
            Savegame = savegame;
            Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [SetTargetSavegame] - [New savegame set to = {savegame}]");
        }

        public int FindIDAndGetRowIndex(string idToFind)
        {
            List<string> lines = this.Import();
            foreach (string line in lines)
            {
                string id = GetIDFromLine(line);
                int count = 0;
                if (!string.IsNullOrEmpty(id))
                { 
                    if (id.Equals(idToFind))
                    {
                        Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [FindID] - [Found ID: {id}] - [In Line No. {count + 1}]");
                        return count;
                    }
                    else
                    {
                        Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [FindID] - [ID {id} does not match {idToFind} in line no. {count + 1}]",1);
                    }
                    count++;
                }
            }
            return -1; // Return -1 if ID is not found
        }

        private string GetIDFromLine(string line)
        {
            string folderAndID = line.Split(new[] { ',' }, StringSplitOptions.None)[5]; 
            if (string.IsNullOrEmpty(folderAndID))
            {
                Configuration.PrintDebug($"[BackupHistoryImporter.cs] - [GetID] - [Folder and ID is empty for line: {line}]", 2);
                return string.Empty;
            }
            string? id = null;
            string[] splitted = folderAndID.Split('|');
            if (splitted.Length > 1)
            {
                id = splitted[1];
            }
            else
            {
                id = string.Empty;
            }
            return id;
        }
    }
}
