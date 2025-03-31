using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ZomboidBackupManager.FunctionLibrary;
using static ZomboidBackupManager.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ZomboidBackupManager
{
    public enum Status
    {
        NONE = 0,
        INIT = 1,
        READY = 2,
        BUSY = 3,
        DONE = 4,
        FAILED = 5
    }

    public partial class DeleteMulti : Form
    {
        private List<string>? deleteTasks;
        private Dictionary<string,int> pathsToIndices = new Dictionary<string, int>();
        private CancellationTokenSource cancellationTokenSource;
        private int currentTaskIndex = 0;
        private int maxTaskIndex = 0;
        public event EventHandler<Status>? OnStatusChanged;
        private Status status;
        public Status Status { get { return status; } }

        public DeleteMulti(List<string>? backupPaths, Dictionary<string, int> keys)
        {
            status = Status.INIT;
            cancellationTokenSource = new CancellationTokenSource();


            InitializeComponent();
            if (backupPaths != null && backupPaths.Count > 0)
            {
                deleteTasks = backupPaths;
                pathsToIndices = keys;
                maxTaskIndex = backupPaths.Count;
                ProgressBarOverall.Maximum = maxTaskIndex;
                this.OnStatusChanged += StatusChanged;
                ChangeCurrentStatus(Status.READY);
            }
            else
            {
                ChangeCurrentStatus(Status.FAILED);
            }
        }

        public async void StartDeleteMultiple()
        {
            this.Visible = true;

            ProgressBarOverall.Value = 0;

            StatusOverallLabel.Text = @"Starting...";

            if ((status == Status.FAILED) || (status != Status.READY) || (deleteTasks == null) || (deleteTasks.Count < 0))
            {
                int taskCount = 0;
                if (deleteTasks != null)
                {
                    taskCount = deleteTasks.Count;
                }

                PrintDebug($"[ERROR] - [status = {status.ToString()}] - [deleteTasks = {taskCount.ToString()}");
                return;
            }
            ChangeCurrentStatus(Status.BUSY);

            StatusOverallLabel.Text = $"Starting to delete backups. Process - [1 / {maxTaskIndex}]";
            await Task.Delay(500);

            foreach (var dir in deleteTasks)
            {
                if (cancellationTokenSource.Token.IsCancellationRequested)
                {
                    StatusLabel.Text = "Löschvorgang abgebrochen!";
                    ChangeCurrentStatus(Status.FAILED);
                    break; // Stop before the next task
                }
                currentTaskIndex++;
                StatusOverallLabel.Text = $"Deleting backups. Process - [{currentTaskIndex} / {maxTaskIndex}]";
                int jsonIndex = pathsToIndices[dir];
                await DeleteDirectory(dir, cancellationTokenSource.Token, jsonIndex);
                ProgressBarOverall.Value++;
            }
            StatusLabel.Text = "All backups deleted!";
            await Task.Delay(500);
            bool result = SortCurrentLoadedJsonData();
            await Task.Delay(1000);
            PrintDebug($"[StartDeleteMultiple] - [SortCurrentLoadedJsonData] - [result = {result.ToString()}]");
            ChangeCurrentStatus(Status.DONE);
        }

        private void StatusChanged(object? sender, Status s)
        {
            if ((s == Status.DONE) || (s == Status.FAILED)) { this.Visible = false; this.Dispose(); }
        }

        private void ChangeCurrentStatus(Status s)
        {
            status = s;
            OnStatusChanged?.Invoke(this, s);
        }

        private async Task DeleteDirectory(string directory, CancellationToken cancellationToken, int index)
        {
            string? name = GetBackupDataNameFromJson(index);
            int iNum = GetBackupDataPosInList(index);
            ProgressBar.Value = 0;
            DeleteProcess deleteProcess = new DeleteProcess();
            var progress = new Progress<int>(percent =>
            {
                StatusLabel.Text = $"Deleting Backup: {name} - {percent}%";
                ProgressBar.Value = percent;
            });

            try
            {
                await deleteProcess.DeleteDirectoryAsync(directory, progress);
            }
            catch (Exception ex)
            {
                StatusLabel.Text = $"Fehler beim Löschen: {ex.Message}";
                await Task.Delay(5000);
            }

            StatusLabel.Text = "Deleting Backup Done!";
            Thread.Sleep(500);
            StatusLabel.Text = "Modifying JSON File...";
            bool b = DeleteBackupFromJson(iNum, false); // false to disable sorting
            PrintDebug($"[DeleteDirectory] - [DeleteBackupFromJson] - [index = {index.ToString()}] - [iNum = {iNum.ToString()}]  - [result = {b.ToString()}]");

            Thread.Sleep(500);
        }

        private void CancelNextProcessButton_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource == null) cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();
            CancelNextProcessButton.Enabled = false; // Disable cancel button after pressing
        }
    }
}
