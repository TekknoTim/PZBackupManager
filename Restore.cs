using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public class DirectoryCopier
    {
        public async Task RestoreSaveAsynch(string sourceDir, string destinationDir, IProgress<int> progress)
        {
            if (Directory.Exists(destinationDir))
                Directory.Delete(destinationDir, true);

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
                    Console.WriteLine($"[ERROR] - [ZOMBOID SAVE MANAGER] - [Restore.cs] -> combPath = {combPath}");
                    MessageBox.Show($"[ERROR] - [ZOMBOID SAVE MANAGER] - [Restore.cs] -> combPath = {combPath}");
                }
            }
        }
    }

    public class Restore
    {
        public async Task DoRestore(string savegameName, string savegamePath, int index, ProgressBar progressBar, Label statusLabel, Panel panel)
        {
            panel.Visible = true;
            progressBar.Visible = true;
            statusLabel.Text = @"Starting restore process...";
            statusLabel.Visible = true;
            DirectoryCopier copier = new DirectoryCopier();
            var progress = new Progress<int>(percent =>
            {
                progressBar.Value = percent;
                statusLabel.Text = $"Restoring Backup... {percent}%";
                if (percent >= 99)
                {
                    progressBar.Value = 100;
                    statusLabel.Text = "Backup successfully restored";
                }
            });

            string backupFolderPath = GetBackupFolderPathFromJson(index);

            DialogResult result = MessageBox.Show("Are you sure you want to restore your savegame with backup: " + GetBackupDataNameFromJson(index), "Debug", MessageBoxButtons.OKCancel);

            if (result == DialogResult.Cancel)
            {
                statusLabel.Text = @" - ";
                progressBar.Visible = false;
                progressBar.Value = 0;
                statusLabel.Visible = false;
                panel.Visible = false;
                return;
            }

            await copier.RestoreSaveAsynch(backupFolderPath, savegamePath, progress);

            if (showMsgWhenBackupProcessDone)
            {
                MessageBox.Show($"Backup No.{index + 1} successfully restored!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Thread.Sleep(2000);

            statusLabel.Text = @" - ";
            progressBar.Visible = false;
            progressBar.Value = 0;
            statusLabel.Visible = false;
            panel.Visible = false;
        }
    }
}
