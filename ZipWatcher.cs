using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class ZipWatcher
{
    private FileSystemWatcher watcher = new();
    private HashSet<string> processedFiles = new();
    private object lockObj = new(); // für Thread-Sicherheit

    public event EventHandler<string>? ZipFileReady;

    public void StartWatching(string path)
    {
        watcher = new FileSystemWatcher
        {
            Path = path,
            Filter = "*.zip",
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.CreationTime,
            EnableRaisingEvents = true
        };

        watcher.Created += OnZipDetected;
        watcher.Changed += OnZipDetected; // optional
    }

    private async void OnZipDetected(object sender, FileSystemEventArgs e)
    {
        string fullPath = e.FullPath;

        lock (lockObj)
        {
            if (processedFiles.Contains(fullPath))
                return; // Schon verarbeitet, abbrechen

            processedFiles.Add(fullPath);
        }

        // Verzögerung zur Sicherheit, falls Datei noch im Schreiben ist
        await Task.Delay(500);

        if (await WaitUntilFileIsReady(fullPath))
        {
            ZipFileReady?.Invoke(this, fullPath);
        }
        else
        {
            // Wenn Datei nie ready wird → aus HashSet entfernen
            lock (lockObj)
            {
                processedFiles.Remove(fullPath);
            }
        }
    }

    private async Task<bool> WaitUntilFileIsReady(string filePath, int maxAttempts = 10, int delay = 500)
    {
        for (int i = 0; i < maxAttempts; i++)
        {
            try
            {
                using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return true;
                }
            }
            catch (IOException)
            {
                await Task.Delay(delay);
            }
        }
        return false;
    }

    public void StopWatching()
    {
        watcher.EnableRaisingEvents = false;
        watcher?.Dispose();
    }
}
