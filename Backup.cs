using System.IO;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;
using static ZomboidBackupManager.JsonData;

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

        public async Task DoBackup(string savegameName, string gamemode, string savegamePath, string path, int index, Label statusLabel, System.Windows.Forms.ProgressBar progressBar)
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
            WriteBackupDataToJson(savegameName, backupFolderPath);
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
            WriteBackupDataToJson(currentLoadedSavegame, backupFolderPath);
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
    }
}
