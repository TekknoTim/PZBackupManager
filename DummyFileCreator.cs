using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using static ZomboidBackupManager.Configuration;
using static ZomboidBackupManager.FunctionLibrary;

namespace ZomboidBackupManager
{
    public class DummyFileCreator
    {
        public void SelectAndLoadDatabaseFromFile()
        {
            string? path = string.Empty;

            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.FileName;
                    if (!File.Exists(path) && !Path.GetExtension(path).Equals(".json"))
                    {
                        MessageBox.Show($"Die ausgewählte Datei existiert nicht oder ist ungültig.");
                        return;
                    }
                    MessageBox.Show($"Ausgewählte Datei: {path}");
                    string? json = File.ReadAllText(path);
                    if (string.IsNullOrWhiteSpace(json))
                    {
                        MessageBox.Show("Die Datei ist leer oder konnte nicht gelesen werden.");
                        return;
                    }
                    Dictionary<string, FileRecord>? data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, FileRecord>>(json);
                    if (data == null || data.Count == 0)
                    {
                        MessageBox.Show("Die Datei enthält keine gültigen Dateieinträge.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Erfolgreich geladen: {data.Count} Dateieinträge.");
                        CreateDummyFilesFromDictionary(data);
                    }
                }
            }
        }


        public void CreateDummyFilesFromDictionary(Dictionary<string, FileRecord> fileRecords)
        {
            if (fileRecords == null || fileRecords.Count == 0)
            {
                Console.WriteLine("Das Dictionary ist leer oder null. Es wurden keine Dateien erstellt.");
                return;
            }

            string? baseFolderPath = string.Empty;

            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Wählen Sie einen Basisordner für die Erstellung der Dateien";
                dialog.UseDescriptionForTitle = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    baseFolderPath = dialog.SelectedPath;
                    Console.WriteLine($"Ausgewählter Basisordner: {baseFolderPath}");
                }
                else
                {
                    Console.WriteLine("Vorgang vom Benutzer abgebrochen. Es wurden keine Dateien erstellt.");
                    return;
                }
            }

            Console.WriteLine("Beginne mit der Erstellung der Dummy-Dateien...");

            int filesCreated = 0;

            foreach (var record in fileRecords.Values)
            {
                try
                {

                    if (string.IsNullOrWhiteSpace(record.FilePath))
                    {
                        Console.WriteLine("Warnung: Ein FileRecord hat einen leeren FilePath und wird übersprungen.");
                        continue;
                    }

                    string fullPath = Path.Combine(baseFolderPath, record.FilePath);

                    string? directoryPath = Path.GetDirectoryName(fullPath);

                    if (!string.IsNullOrEmpty(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    File.WriteAllText(fullPath, $"Dies ist eine Dummy-Datei für: {record.FilePath}");
                    filesCreated++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Erstellen der Datei '{record.FilePath}': {ex.Message}");
                }
            }

            MessageBox.Show($"Vorgang abgeschlossen. {filesCreated} von {fileRecords.Count} Dateien erfolgreich erstellt.");
        }
    }

    public class DummyFileCreatorUtility
    {

        public static void CreateDummyFiles()
        {
            var creator = new DummyFileCreator();

            creator.SelectAndLoadDatabaseFromFile();

            Console.WriteLine("Drücken Sie eine beliebige Taste, um das Programm zu beenden.");
            Console.ReadKey();
        }
    }
}

