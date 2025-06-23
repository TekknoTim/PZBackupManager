using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.SmartBackupUtil;

namespace ZomboidBackupManager
{
    public static class SmartBackupProcess
    {

        public static event EventHandler<bool>? OnSmartBackupProcessDone;

        public async static void StartSmartBackupProcess(Backup backup,DatabaseData data, Label? txtLabel = null, System.Windows.Forms.ProgressBar? progressBar = null)
        {
            string sResult = string.Empty;
            if (data.HasDatabase)
            {
                if (!data.DatabaseLoaded)
                {
                    PrintDebug($"[SmartBackupProcess.cs] - [StartSmartBackupProcess] - [Database Exists, But Isn't Currently Loaded]");
                    sResult = data.LoadDatabase(false);
                }
                if (!data.DatabaseLoaded || sResult.Equals("Loading Failed"))
                {
                    PrintDebug($"[SmartBackupProcess.cs] - [StartSmartBackupProcess] - [Database is null or not loaded] - [CANCELED]");
                    MessageBox.Show("Even if the database should exist, the serialia");
                    OnSmartBackupProcessDone?.Invoke(null, false);
                    return;
                }
            }

            PrintDebug($"[SmartBackupProcess.cs] - [StartSmartBackupProcess] - [Database successfully loaded]");
            List<string> filesToCopy = SmartBackupUtil.FindChangedFiles(data.SavegamePath, data.GetDatabase()!);

            if (filesToCopy.Any())
            {
                PrintDebug($"{filesToCopy.Count} neue oder geänderte Dateien gefunden. Starte Kopiervorgang");
                //SmartBackupData smartBackupData = new SmartBackupData(idx, FunctionLibrary.GetDefaultBackupFolderName(idx), Configuration.GetSmartBackupDirPath( SmartBackupUtil.GetSmartBackupListSize(data.Savegame!), data.Savegame!), filesToCopy);
                bool backupSuccess = await backup.DoSmartBackup(data.Savegame, filesToCopy, txtLabel, progressBar);
                if (backupSuccess)
                {
                    PrintDebug($"[SmartBackupProcess.cs] - [StartSmartBackupProcess] - [Updating Database]");
                    bool bResult = data.UpdateDatabase(filesToCopy);
                    PrintDebug($"[SmartBackupProcess.cs] - [StartSmartBackupProcess] - [Updating Database] - [bResult = {bResult}]");
                    PrintDebug($"[SmartBackupProcess.cs] - [StartSmartBackupProcess] - [Successfully Finished]");
                }
                else
                {
                    PrintDebug($"[SmartBackupProcess.cs] - [StartSmartBackupProcess] - [backupSuccess = {backupSuccess}]", 2);
                }
            }
            else
            {
                PrintDebug($"[SmartBackupProcess.cs] - [StartSmartBackupProcess] - [CANCELED] -  [NO CHANGED FILES TO COPY FOUND]");
            }
            OnSmartBackupProcessDone?.Invoke(null, true);
        }
    }
}
