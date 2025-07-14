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

        /*
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
        */

        public static bool RestoreBackup(List<string> backupChain, string liveSaveGamePath)
        {
            PrintDebug($"[SmartBackupUtil.cs] - [RestoreBackup] - [Restoring backup with {backupChain.Count} steps!]");
            backupChain.ForEach(b => PrintDebug($"[{Path.GetFileName(b)}]"));
            if (Directory.Exists(liveSaveGamePath))
            {
                string backupOfLivePath = $"{liveSaveGamePath}_backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";
                PrintDebug($"Sichere aktuellen Spielstand nach: {backupOfLivePath}");
                Directory.Move(liveSaveGamePath, backupOfLivePath);
            }
            PrintDebug($"[SmartBackupUtil.cs] - [RestoreBackup] - [Creating empty directory @ -> {liveSaveGamePath}] ");
            Directory.CreateDirectory(liveSaveGamePath);

            foreach (string backupPath in backupChain)
            {
                PrintDebug($"Handle: {Path.GetFileName(backupPath)}");
                CopyDirectoryRecursively(backupPath, liveSaveGamePath);
            }

            PrintDebug($"[SmartBackupUtil.cs] - [RestoreBackup] - [Restore finished] ");
            return true;
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

    public class SmartRestoreProcess
    {
        string BaseBackupPath;

        List<SmartBackupData> smartBackupData;

        public event EventHandler<Status>? SmartRestoreProcessStatus;

        public SmartRestoreProcess(List<SmartBackupData> SBData, string baseBackupPath)
        {
            this.BaseBackupPath = baseBackupPath;
            this.smartBackupData = SBData;
        }

        public async void StartSmartBackupProcess(string liveSaveGamePath, int backupIndex)
        {
            PrintDebug($"[SmartRestoreUtil.cs] - [SmartRestoreProcess] - [Starting Smart restore process -> backupIndex = {backupIndex}]");

            List<string> backupChain = GetAllNeededBackupFolders(backupIndex);
            await Task.Run(() => (RestoreHelper.RestoreBackup(backupChain, liveSaveGamePath)));
            SmartRestoreProcessStatus?.Invoke(this, Status.DONE);
        }

        private List<string> GetAllNeededBackupFolders(int backupIndex)
        {
            List<string> outputList = new List<string>();
            outputList.Add(BaseBackupPath);
            for (int i = 0; i < backupIndex; i++)
            {
                SmartBackupData? data = smartBackupData[i];
                if (data != null)
                {
                    outputList.Add(data.Path ?? string.Empty);
                    PrintDebug($"[SmartRestoreUtil.cs] - [SmartRestoreProcess] - [GetAllNeededBackupFolders] - [Adding path to list]");
                    PrintDebug($"[GetAllNeededBackupFolders] - [Adding path no.{i + 1} / path = {data.Path}]");
                }
            }
            return outputList;
        }
    }
}
