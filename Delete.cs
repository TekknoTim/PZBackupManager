using System.IO;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public class DeleteProcess
    {
        public async Task DeleteDirectoryAsync(string directoryPath, IProgress<int> progress)
        {
            if (!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException($"Das Quellverzeichnis '{directoryPath}' wurde nicht gefunden.");

            // Alle Dateien und Verzeichnisse zählen für die Fortschrittsanzeige
            var allFiles = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
            int totalFiles = allFiles.Length;
            int deletedFiles = 0;

            foreach (var file in allFiles)
            {
                string relativePath = file.Substring(directoryPath.Length + 1);
                string destFile = Path.Combine(directoryPath, relativePath);
                var combPath = Path.GetDirectoryName(destFile);
                if (combPath != null)
                {
                    Directory.CreateDirectory(combPath); // Sicherstellen, dass das Verzeichnis existiert

                    await Task.Run(() => File.Delete(file));

                    deletedFiles++;
                    int percentComplete = (int)((double)deletedFiles / totalFiles * 100);
                    progress.Report(percentComplete);
                }
                else
                {
                    PrintDebug($"[Delete.cs] - [DeleteDirectoryAsync] -> [combPath = {combPath}]", 2);
                    MessageBox.Show($"ERROR! --> [Delete.cs] \n\n [combPath = {combPath}]");
                    progress.Report(0);
                }
            }
            Directory.Delete(directoryPath, true);
        }
    }

    public class Delete
    {
        public async Task DoDelete(int index, Label statusLabel, ProgressBar progressBar, Panel panel)
        {
            string? path = GetBackupFolderPathFromJson(index);
            DeleteProcess deleteProcess = new DeleteProcess();
            panel.Visible = true;
            var progress = new Progress<int>(percent =>
            {
                statusLabel.Text = $"Deleting Backup... {percent}%";
                progressBar.Value = percent;
            });

            await deleteProcess.DeleteDirectoryAsync(path, progress);

            statusLabel.Text = "Deleting Files Done!";
            Thread.Sleep(500);
            statusLabel.Text = "Modifying JSON File...";
            DeleteBackupFromJson(index);
            Thread.Sleep(500);
            statusLabel.Text = "Done!";

            Thread.Sleep(500);

            progressBar.Value = 0;
            panel.Visible = false;
            statusLabel.Text = @" - ";
        }
    

        public async Task DoDeleteFromRemote(ListBox statusLog, int index)
        {
            PrintStatusLog(statusLog, "Auto delete enabled. Deleting last listed backup -> Start!");
            string path = GetBackupFolderPathFromJson(index);
            DeleteProcess deleteProcess = new DeleteProcess();
            int i = 0;
            var progress = new Progress<int>(percent =>
            {
                if ((percent % 10) == 0 && (percent / 10) > i)
                {
                    i++;
                    PrintStatusLog(statusLog, $"Deleting Backup... {percent}%");
                }
            });

            await deleteProcess.DeleteDirectoryAsync(path, progress);

            PrintStatusLog(statusLog, "Deleting last listed backup -> Done!");
            Thread.Sleep(500);
            PrintStatusLog(statusLog, "Modifying JSON File...");
            DeleteBackupFromJson(index);
            Thread.Sleep(500);
            PrintStatusLog(statusLog, "Modifying JSON File --> Done!");
        }

        private void PrintStatusLog(ListBox statusLog, string txt = "")
        {
            int i = statusLog.Items.Count;
            statusLog.Items.Add($"[{i.ToString()}] - " + txt);
            statusLog.SelectionMode = SelectionMode.One;
            statusLog.SetSelected(i, true);
        }

        public async Task DoDeleteBaseSmartBackup(DatabaseData data, System.Windows.Forms.Label? statusLabel = null, System.Windows.Forms.ProgressBar? progressBar = null, ToolStripProgressBar? tsProgressBar = null)
        {
            DeleteProcess deleteProcess = new DeleteProcess();
            Thread.Sleep(500);
            var progress = new Progress<int>(percent =>
            {
                if (statusLabel != null)
                {
                    statusLabel.Text = $"Deleting Backup... {percent}%";
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
            if (!Directory.Exists(data.BaseBackupDir))
            {
                PrintDebug($"[Delete.cs] - [DoDeleteBaseSmartBackup] -> [backupFolderPath = {data.BaseBackupDir}] does not exist!", 2);
                MessageBox.Show($"ERROR! --> [Delete.cs] \n\n [backupFolderPath = {data.BaseBackupDir}] does not exist! Aborting --> [DeleteDirectoryAsync]");
                return;
            }
            await deleteProcess.DeleteDirectoryAsync(data.BaseBackupDir, progress);

            Thread.Sleep(500);
            if (progressBar != null)
            {
                progressBar.Value = 0;
            }
            if (tsProgressBar != null)
            {
                tsProgressBar.Value = 0;
            }
        }
    }
}
