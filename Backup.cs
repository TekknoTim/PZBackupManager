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
        public async Task DoBackup(string savegameName, string gamemode, string savegamePath, string path, int index, Label statusLabel, ProgressBar progressBar, Panel? panel = null)
        {
            BackupProcess backupProcess = new BackupProcess();
            if (panel != null)
            {
                panel.Visible = true;
            }
            progressBar.Visible = true;
            statusLabel.Visible = true;
            var progress = new Progress<int>(percent =>
            {
                statusLabel.Text = $"Creating Backup... {percent}%";
                progressBar.Value = percent;
            });

            string backupFolderPath = path + @"\" + GetDefaultBackupFolderName(GetLastBackupFolderNumber() + 1);

            await backupProcess.BackupDirectoryAsync(savegamePath, backupFolderPath, progress);

            statusLabel.Text = "Copying Files Done!";
            Thread.Sleep(1000);
            statusLabel.Text = "Writing JSON File...";
            WriteBackupDataToJson(savegameName, backupFolderPath);
            Thread.Sleep(500);
            statusLabel.Text = "Done!";

            Thread.Sleep(100);

            if (showMsgWhenBackupProcessDone)
            {
                MessageBox.Show($"Backup No.{index + 1} successfully created!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Thread.Sleep(500);

            progressBar.Visible = false;
            progressBar.Value = 0;
            statusLabel.Visible = false;
            if (panel != null)
            {
                panel.Visible = false;
            }
            statusLabel.Text = @" - ";
        }

        public async Task DoBackupFromRemote(ListBox statusLog, PZScriptHook scriptHook)
        {
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
            Thread.Sleep(1000);
            PrintStatusLog(statusLog, "Writing JSON File...");
            WriteBackupDataToJson(currentLoadedSavegame, backupFolderPath);
            Thread.Sleep(500);

            PrintStatusLog(statusLog, "Backup Process Finished!");

            Thread.Sleep(500);

            //scriptHook.ExecuteDoneCommand();
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
