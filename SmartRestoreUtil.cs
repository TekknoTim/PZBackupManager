using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;
namespace ZomboidBackupManager
{


    public static class RestoreHelper
    {
        public static void RestoreBackup(string backupBaseFolder, string selectedBackupFolder, string liveSaveGamePath)
        {
            var allBackups = Directory.GetDirectories(backupBaseFolder).OrderBy(d => d).ToList();
            int targetIndex = allBackups.IndexOf(selectedBackupFolder);
            if (targetIndex == -1)
            {
                throw new DirectoryNotFoundException("Der ausgewählte Backup-Ordner wurde nicht gefunden.");
            }

            List<string> backupChain = allBackups.Take(targetIndex + 1).ToList();

            PrintDebug($"Stelle Kette mit {backupChain.Count} Schritten wieder her:");
            backupChain.ForEach(b => PrintDebug($"- {Path.GetFileName(b)}"));
            if (Directory.Exists(liveSaveGamePath))
            {
                string backupOfLivePath = $"{liveSaveGamePath}_backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";
                PrintDebug($"Sichere aktuellen Spielstand nach: {backupOfLivePath}");
                Directory.Move(liveSaveGamePath, backupOfLivePath);
            }
            PrintDebug($"Erstelle leeren Zielordner: {liveSaveGamePath}");
            Directory.CreateDirectory(liveSaveGamePath);

            foreach (string backupPath in backupChain)
            {
                PrintDebug($"Wende an: {Path.GetFileName(backupPath)}");
                CopyDirectoryRecursively(backupPath, liveSaveGamePath);
            }

            PrintDebug("Wiederherstellung erfolgreich abgeschlossen!");
        }


        private static void CopyDirectoryRecursively(string sourceDir, string destinationDir)
        {

            var dir = new DirectoryInfo(sourceDir);
            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(destinationDir);
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath, true); // true = overwrite
            }

            foreach (DirectoryInfo subDir in dirs)
            {
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                CopyDirectoryRecursively(subDir.FullName, newDestinationDir);
            }
        }
    }
}
