using System.IO;

using static System.Windows.Forms.Label;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;
using static ZomboidBackupManager.JsonData;
using static ZomboidBackupManager.SmartBackupUtil;

namespace ZomboidBackupManager
{
    internal class BackupProcess
    {
        public async Task BackupDirectoryAsync(string sourceDir, string destinationDir, IProgress<int> progress)
        {
            if (!Directory.Exists(sourceDir))
                throw new DirectoryNotFoundException($"Das Quellverzeichnis '{sourceDir}' wurde nicht gefunden.");

            if (!Directory.Exists(destinationDir))
                Directory.CreateDirectory(destinationDir);

            // Alle Dateien und Verzeichnisse zählen für die Fortschrittsanzeige
            var allFiles = Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories);
            int totalFiles = allFiles.Length;
            int copiedFiles = 0;

            foreach (var file in allFiles)
            {
                string relativePath = file.Substring(sourceDir.Length + 1);
                string destFile = Path.Combine(destinationDir, relativePath);
                var combPath = Path.GetDirectoryName(destFile);
                if (combPath != null)
                {
                    Directory.CreateDirectory(combPath); // Sicherstellen, dass das Verzeichnis existiert

                    await Task.Run(() => File.Copy(file, destFile, true));

                    copiedFiles++;
                    int percentComplete = (int)((double)copiedFiles / totalFiles * 100);
                    progress.Report(percentComplete);
                }
                else
                {
                    Console.WriteLine($"[ERROR] - [ZOMBOID SAVE MANAGER] - [Backup.cs] -> combPath = {combPath}");
                    MessageBox.Show($"[ERROR] - [ZOMBOID SAVE MANAGER] - [Backup.cs] -> combPath = {combPath}");
                    progress.Report(0);
                }
            }
        }

        public async Task<bool> BackupFilesAsync(List<string> allFiles, string destinationDir, IProgress<int> progress)
        {
            if (allFiles == null || allFiles.Count <= 0)
            {
                PrintDebug($"[Backup.cs] - [BackupFilesAsync] - [allFiles = null or empty]",2);
                return false;
            }
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);

            }
            int totalFiles = allFiles.Count;
            int copiedFiles = 0;
            PrintDebug($"[Backup.cs] - [BackupFilesAsync] - [Starting to copy {totalFiles} files.]");
            PrintDebug($"[Backup.cs] - [BackupFilesAsync] - [destinationDir = {destinationDir}]");
            PrintDebug($"[Backup.cs] - [BackupFilesAsync] - [allFiles[0] {allFiles[0]}]");

            foreach (var file in allFiles)
            {
                string? sourceDir = Path.GetDirectoryName(file);
                string relativePath = file.Substring(sourceDir!.Length + 1);
                string destFile = Path.Combine(destinationDir, relativePath);
                var combPath = Path.GetDirectoryName(destFile);
                PrintDebug($"[Backup.cs] - [BackupFilesAsync] - [sourceDir = {sourceDir}]");
                PrintDebug($"[Backup.cs] - [BackupFilesAsync] - [relativePath = {relativePath}]");
                PrintDebug($"[Backup.cs] - [BackupFilesAsync] - [destFile = {destFile}]");
                PrintDebug($"[Backup.cs] - [BackupFilesAsync] - [combPath = {combPath}]");
                if (combPath != null)
                {
                   

                    await Task.Run(() => Directory.CreateDirectory(combPath));

                    await Task.Run(() => File.Copy(file, destFile, true));

                    copiedFiles++;
                    int percentComplete = (int)((double)copiedFiles / totalFiles * 100);
                    progress.Report(percentComplete);
                }
                else
                {
                    PrintDebug($"[Backup.cs] - [BackupFilesAsync] - [combPath = null]", 2);
                    MessageBox.Show($"<--->ERROR<--->ERROR<-->ERROR<--->ERROR<---> \n\n<------------>combPath = null<------------>");
                    progress.Report(0);
                    return false;
                }
            }
            return true;
        }
    }

    public class Backup
    {

        private Status status;
        public Status Status { get { return status; } }

        public event EventHandler<Status>? OnStatusChanged;
        public event EventHandler<Status>? OnDone;

        private void ChangeCurrentStatus(Status s)
        {
            status = s;
            if (s == Status.DONE) { OnDone?.Invoke(this, s); }
            OnStatusChanged?.Invoke(this, s);
        }

        public async Task DoBackup(string savegameName, string gamemode, string savegamePath, string path, int index, System.Windows.Forms.Label statusLabel, System.Windows.Forms.ProgressBar progressBar)
        {
            ChangeCurrentStatus(Status.BUSY);
            BackupProcess backupProcess = new BackupProcess();
            var progress = new Progress<int>(percent =>
            {
                statusLabel.Text = $"Creating Backup... {percent}%";
                progressBar.Value = percent;
            });

            string backupFolderPath = path + @"\" + GetDefaultBackupFolderName(GetLastBackupFolderNumber() + 1);

            await backupProcess.BackupDirectoryAsync(savegamePath, backupFolderPath, progress);

            statusLabel.Text = "Copying Files Done!";
            await Task.Delay(1000);
            statusLabel.Text = "Writing JSON File...";
            WriteBackupDataToJson(savegameName, backupFolderPath, null);
            await Task.Delay(500);
            statusLabel.Text = "Done!";

            await Task.Delay(100);

            if (showMsgWhenBackupProcessDone)
            {
                MessageBox.Show($"Backup No.{index + 1} successfully created!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            await Task.Delay(500);

            ChangeCurrentStatus(Status.DONE);
        }

        public async Task DoBackupFromRemote(ListBox statusLog, PZScriptHook scriptHook)
        {
            ChangeCurrentStatus(Status.BUSY);
            BackupProcess backupProcess = new BackupProcess();
            int i = 0;
            var progress = new Progress<int>(percent =>
            {

                if ((percent % 10) == 0 && (percent / 10) > i)
                {
                    i++;
                    if (i == 5)
                    {
                        scriptHook.SendProcessCommand(50);
                    }
                    PrintStatusLog(statusLog, $"Creating Backup... {percent}%");
                }

            });

            string backupFolderPath = currentLoadedBackupFolderPATH + @"\" + GetDefaultBackupFolderName(GetLastBackupFolderNumber() + 1);

            await backupProcess.BackupDirectoryAsync(GetFullLoadedSavegamePath(), backupFolderPath, progress);

            PrintStatusLog(statusLog, "Copying Files Done!");
            await Task.Delay(1000);
            PrintStatusLog(statusLog, "Writing JSON File...");
            WriteBackupDataToJson(currentLoadedSavegame, backupFolderPath, null);
            await Task.Delay(500);

            PrintStatusLog(statusLog, "Backup Process Finished!");

            ChangeCurrentStatus(Status.DONE);
        }


        private void PrintStatusLog(ListBox statusLog, string txt = "")
        {
            int i = statusLog.Items.Count;
            statusLog.Items.Add($"[{i.ToString()}] - " + txt);
            statusLog.SelectionMode = SelectionMode.One;
            statusLog.SetSelected(i, true);
        }

        public async Task<bool> DoInitialBaseBackup(DatabaseData data, System.Windows.Forms.Label? statusLabel = null, System.Windows.Forms.ProgressBar? progressBar = null, ToolStripProgressBar? tsProgressBar = null)
        {
            ChangeCurrentStatus(Status.BUSY);
            BackupProcess backupProcess = new BackupProcess();
            var progress = new Progress<int>(percent =>
            {
                if (statusLabel != null)
                {
                    statusLabel.Text = $"Creating Initial Base Backup... {percent}%";
                }
                if (progressBar != null)
                {
                    progressBar.Value = percent;
                }
                if (tsProgressBar != null)
                {
                    tsProgressBar.Value = percent;
                }
            });
            string backupFolderPath = Configuration.GetInitialBaseBackupPath(data.Savegame);
            await backupProcess.BackupDirectoryAsync(data.SavegamePath, backupFolderPath, progress);
            if (statusLabel != null)
            {
                statusLabel.Text = "Copying Files Done!";
            }
            await Task.Delay(500);
            data.HasBaseBackup = true;
            if (statusLabel != null)
            {
                statusLabel.Text = "Initial Base Backup Created!";
            }
            await Task.Delay(100);
            ChangeCurrentStatus(Status.DONE);
            return true;
        }

        public async Task<bool> DoSmartBackup(string savegame, List<string> allFiles, System.Windows.Forms.Label? statusLabel = null, System.Windows.Forms.ProgressBar? progressBar = null, ToolStripProgressBar? tsProgressBar = null)
        {
            BackupProcess backupProcess = new BackupProcess();
            var progress = new Progress<int>(percent =>
            {
                if (statusLabel != null)
                {
                    statusLabel.Text = $"Creating Initial Base Backup... {percent}%";
                }
                if (progressBar != null)
                {
                    progressBar.Value = percent;
                }
                if (tsProgressBar != null)
                {
                    tsProgressBar.Value = percent;
                }
            });
            string backupFolderPath = currentBaseBackupFolderPATH + @"\" + savegame + @"\" + GetDefaultBackupFolderName(GetLastBackupFolderNumber() + 1);
            await backupProcess.BackupFilesAsync( allFiles, backupFolderPath, progress);
            if (statusLabel != null)
            {
                statusLabel.Text = "Copying Files Done!";
            }
            await Task.Delay(1000);
            if (statusLabel != null)
            {
                statusLabel.Text = $"Writing JSON File For Savegame = {savegame}";
            }

            WriteBackupDataToJson(savegame, backupFolderPath, allFiles);
            await Task.Delay(500);
            if (statusLabel != null)
            {
                statusLabel.Text = "Done!";
            }
            await Task.Delay(100);
            return true;
        }
    }
}
