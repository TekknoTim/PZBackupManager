using System.IO;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public class DirectoryCopier
    {
        private const string tempRestoreSuffix = @".pzbm_restore_tmp";
        private const string oldSaveSuffix = @".pzbm_restore_old";

        // The live savegame is only replaced, after the backup was copied completely into a temporary folder next to it.
        // If anything fails before the swap, the live savegame stays untouched.
        public async Task RestoreSaveAsynch(string sourceDir, string destinationDir, IProgress<int> progress)
        {
            if (!Directory.Exists(sourceDir))
                throw new DirectoryNotFoundException($"The backup folder '{sourceDir}' was not found. Your savegame was not changed.");

            var allFiles = Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories);
            int totalFiles = allFiles.Length;
            if (totalFiles <= 0)
                throw new IOException($"The backup folder '{sourceDir}' is empty. Your savegame was not changed.");

            string tempDir = destinationDir + tempRestoreSuffix;
            string oldDir = destinationDir + oldSaveSuffix;

            // Never delete this one automatically: after a failed rollback it may hold the only copy of the original savegame.
            if (Directory.Exists(oldDir))
                throw new IOException($"A folder from an earlier restore still exists:\n'{oldDir}'\n\nIt may contain your previous savegame. Please check it and move or delete it manually. Your savegame was not changed.");

            if (Directory.Exists(tempDir))
                Directory.Delete(tempDir, true);

            try
            {
                Directory.CreateDirectory(tempDir);
                int copiedFiles = 0;

                foreach (var file in allFiles)
                {
                    string relativePath = Path.GetRelativePath(sourceDir, file);
                    string destFile = Path.Combine(tempDir, relativePath);
                    var combPath = Path.GetDirectoryName(destFile);
                    if (combPath == null)
                    {
                        throw new IOException($"Invalid target path for file '{file}'.");
                    }
                    Directory.CreateDirectory(combPath);

                    await Task.Run(() => File.Copy(file, destFile, true));

                    copiedFiles++;
                    int percentComplete = (int)((double)copiedFiles / totalFiles * 100);
                    progress.Report(percentComplete);
                }
            }
            catch
            {
                TryDeleteDirectory(tempDir);
                throw;
            }

            // Swap: live save -> old, temp -> live save. Both folders are in the same parent directory, so these are just renames.
            bool hadLiveSave = Directory.Exists(destinationDir);
            if (hadLiveSave)
            {
                try
                {
                    Directory.Move(destinationDir, oldDir);
                }
                catch
                {
                    TryDeleteDirectory(tempDir);
                    throw;
                }
            }

            try
            {
                Directory.Move(tempDir, destinationDir);
            }
            catch (Exception ex)
            {
                // Put the original savegame back in place
                if (hadLiveSave && !Directory.Exists(destinationDir))
                {
                    try
                    {
                        Directory.Move(oldDir, destinationDir);
                    }
                    catch (Exception rollbackEx)
                    {
                        throw new IOException($"Restore failed ({ex.Message}) and your original savegame could not be moved back.\nIt is stored here: '{oldDir}'", rollbackEx);
                    }
                }
                TryDeleteDirectory(tempDir);
                throw;
            }

            if (hadLiveSave)
            {
                TryDeleteDirectory(oldDir);
            }
        }

        private static void TryDeleteDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                    Directory.Delete(path, true);
            }
            catch (Exception ex)
            {
                PrintDebug($"[Restore.cs] - [TryDeleteDirectory] - [Could not delete '{path}'] - [{ex.Message}]", 2);
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

            if (IsProjectZomboidRunning())
            {
                MessageBox.Show("Project Zomboid is still running!\n\nPlease quit the game completely (back to desktop), before restoring a backup.\nOtherwise the game would overwrite the restored savegame or lock its files.",
                                "Restore aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                statusLabel.Text = @" - ";
                progressBar.Value = 0;
                ChangeCurrentStatus(Status.CANCELED);
                return;
            }

            if (string.IsNullOrWhiteSpace(savegamePath))
            {
                MessageBox.Show("No savegame is loaded. Please select a savegame first!", "Restore aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                statusLabel.Text = @" - ";
                progressBar.Value = 0;
                ChangeCurrentStatus(Status.CANCELED);
                return;
            }

            string backupFolderPath = GetBackupFolderPathFromJson(index);

            if (!Directory.Exists(backupFolderPath))
            {
                MessageBox.Show($"The backup folder could not be found:\n{backupFolderPath}\n\nYour savegame was not changed.", "Restore aborted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = @" - ";
                progressBar.Value = 0;
                ChangeCurrentStatus(Status.CANCELED);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to restore your savegame with backup: " + GetBackupDataNameFromJson(index), "Debug", MessageBoxButtons.OKCancel);

            if (result == DialogResult.Cancel)
            {
                statusLabel.Text = @" - ";
                progressBar.Value = 0;
                ChangeCurrentStatus(Status.CANCELED);
                return;
            }

            try
            {
                await copier.RestoreSaveAsynch(backupFolderPath, savegamePath, progress);
            }
            catch (Exception ex)
            {
                PrintDebug($"[Restore.cs] - [DoRestore] - [Restore failed] - [{ex.Message}]", 2);
                MessageBox.Show($"Restore failed!\n\n{ex.Message}", "Restore failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = @" - ";
                progressBar.Value = 0;
                ChangeCurrentStatus(Status.FAILED);
                return;
            }

            if (showMsgWhenBackupProcessDone)
            {
                MessageBox.Show($"Backup No.{index + 1} successfully restored!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            await Task.Delay(2000);

            statusLabel.Text = @" - ";
            progressBar.Value = 0;
            ChangeCurrentStatus(Status.DONE);
        }
    }
}
