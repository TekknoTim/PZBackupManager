using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public class DeleteAllProcess
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
                    Console.WriteLine($"[ERROR] - [ZOMBOID SAVE MANAGER] - [Delete.cs] -> combPath = {combPath}");
                    MessageBox.Show($"[ERROR] - [ZOMBOID SAVE MANAGER] - [Delete.cs] -> combPath = {combPath}");
                    progress.Report(0);
                }
            }
            //Directory.Delete(directoryPath, true);
        }
    }

    public class DeleteAll
    {
        public async Task DoDeleteAll(Label statusLabel, ProgressBar progressBar, Panel panel)
        {

            string? path = currentLoadedBackupFolderPATH + @"\";
            DeleteProcess deleteProcess = new DeleteProcess();
            panel.Visible = true;
            progressBar.Visible = true;
            statusLabel.Visible = true;
            var progress = new Progress<int>(percent =>
            {
                statusLabel.Text = $"Deleting Backups... {percent}%";
                progressBar.Value = percent;
            });



            await deleteProcess.DeleteDirectoryAsync(path, progress);

            statusLabel.Text = "Deleting Files Done!";
            Thread.Sleep(500);
            statusLabel.Text = "Modifying JSON File...";
            DeleteAllBackupsFromJson();
            Thread.Sleep(1000);
            statusLabel.Text = "Done!";

            Thread.Sleep(500);

            progressBar.Visible = false;
            progressBar.Value = 0;
            statusLabel.Visible = false;
            panel.Visible = false;
            statusLabel.Text = @" - ";
        }
    }
}
