using System.IO;
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
                    Directory.CreateDirectory(combPath);

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

        public async Task DoRestore(string savegameName, string savegamePath, int index, ProgressBar progressBar, Label statusLabel)
        {
            ChangeCurrentStatus(Status.BUSY);

            statusLabel.Text = @"Starting restore process...";
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
                progressBar.Value = 0;
                ChangeCurrentStatus(Status.CANCELED);
                return;
            }

            await copier.RestoreSaveAsynch(backupFolderPath, savegamePath, progress);

            if (showMsgWhenBackupProcessDone)
            {
                MessageBox.Show($"Backup No.{index + 1} successfully restored!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Thread.Sleep(2000);

            statusLabel.Text = @" - ";
            progressBar.Value = 0;
            ChangeCurrentStatus(Status.DONE);
        }
    }
}
