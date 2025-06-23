using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ZomboidBackupManager.Configuration;

namespace ZomboidBackupManager
{
    public static class SmartBackupUtil
    {
        //===========================================================================================================================================
        //==========================-----------------------[ SmartBackupUtil - Json & File Handline Helpers]--------------------------===============
        //===========================================================================================================================================

        public static List<string> FindChangedFiles(string liveDirectoryPath, Dictionary<string, FileRecord> database)
        {
            var changedFiles = new List<string>();
            string rootPath = Path.GetFullPath(liveDirectoryPath).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            string[] currentFiles = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);

            foreach (string currentFilePath in currentFiles)
            {
                var currentFileInfo = new FileInfo(currentFilePath);
                string relativePath = currentFilePath.Substring(rootPath.Length);

                if (database.TryGetValue(relativePath, out FileRecord? recordFromDb))
                {
                    if (currentFileInfo.Length != recordFromDb.Size ||
                        currentFileInfo.LastWriteTimeUtc != recordFromDb.LastModifiedUtc)
                    {
                        changedFiles.Add(currentFilePath);
                    }
                }
                else
                {
                    changedFiles.Add(currentFilePath);
                }

            }
            return changedFiles;
        }
    }

    /*
    G:\ZomboidBackupsNG\SmartBackup\Savegame\Database\
    |
    +--- 2025-06-16_10-00-00_Full\      <-- Initiales Voll-Backup (Backup 0)
    |    +--- maps\
    |    +--- players.db
    |
    +--- 2025-06-16_11-00-00_Inc\       <-- Backup 1
    |    +--- maps\muldraugh\map_1_2.bin
    |
    +--- 2025-06-16_12-00-00_Inc\       <-- Backup 2
    |    +--- players.db
    |
    +--- 2025-06-16_13-00-00_Inc\       <-- Backup 3
    |    +--- maps\riverside\map_5_6.bin
    |
    +--- 2025-06-16_14-00-00_Inc\       <-- Backup 4
    |    ...
    |
    +--- Database.json
    */
}
