using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.JsonData;
using SharpCompress;
using Microsoft.VisualBasic;
using System.IO;
using SharpCompress.Common;
using SharpCompress.Archives.Zip;
using SharpCompress.Archives;

namespace ZomboidBackupManager
{
    public class Compress
    {
        string fileExt = @".zip";

        public Compress()
        {

        }

        public async Task DoCompress(string backupName, string sourcePath ,int index , Label sLabel)
        {
            
            string destinationPath = Path.Combine(sourcePath, backupName);
            string zipFile = destinationPath + fileExt;
            string zipDestinationPath = Path.Combine(destinationPath, backupName) + fileExt;

            PrintDebug($"[DoCompress] - [Creating Zip archive] - [Source = {sourcePath}] - [destinationPath = {destinationPath}] - [zipFile = {zipFile}]");
                Thread.Sleep(1000);
                try
                {
                    await Task.Delay(500);
                    sLabel.Text = "Creating Zip archive...";

                    await Task.Run(() => CreateZipFromDirectory(destinationPath, zipFile));
                    await Task.Delay(500);
                    PrintDebug($"[DoCompress] - [Done creating Zip archive] - [Source = {sourcePath}] - [destinationPath = {destinationPath}]");
                    sLabel.Text = "Creating Zip Done! - Moving Zip inside backup folder!";
                    await Task.Delay(500);
                    await Task.Run(() => Directory.Move(zipFile, zipDestinationPath));
                    PrintDebug($"[DoCompress] - [Done moving Zip archive] - [Source = {zipFile}] - [destinationPath = {zipDestinationPath}]");
                    sLabel.Text = "Moving Zip inside backup folder done! - Writing JSON File...";
                    await Task.Delay(500);
                    await Task.Run(() => AddZipPathToBackupData(index, zipDestinationPath, true));
                    sLabel.Text = "Writing JSON File Done!";
                    await Task.Delay(500);

            }
                catch (Exception ex)
                {
                    PrintDebug($"[DoCompress] - [Error] - [CreatingFromDirectory failed!] - [{ex.ToString()}]", 2);
                    MessageBox.Show($"Failed to create  zip archive! \n [Message = {ex.ToString()}]");
                }

        }
        private void CreateZipFromDirectory(string folderPath, string zip)
        {
            using (var archive = ZipArchive.Create())
            {
                archive.AddAllFromDirectory(folderPath);
                archive.SaveTo(zip, CompressionType.Deflate64);
            }
        }
    }
}
