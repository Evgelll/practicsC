using System;
using System.IO;

public class FileWatcher
{
    private readonly FileSystemWatcher _fileWatcher;
    private readonly string _backupDirectory;

    public FileWatcher(string pathToWatch)
    {
        _backupDirectory = Path.Combine(pathToWatch, "backup");

        if (!Directory.Exists(_backupDirectory))
        {
            Directory.CreateDirectory(_backupDirectory);
        }

        _fileWatcher = new FileSystemWatcher(pathToWatch)
        {
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
            Filter = "*.*"
        };

        _fileWatcher.Changed += OnChanged;
        _fileWatcher.Created += OnChanged;
        _fileWatcher.Deleted += OnDeleted;
        _fileWatcher.Renamed += OnRenamed;

        _fileWatcher.EnableRaisingEvents = true;
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Файл изменен: {e.FullPath}");
        CreateBackup(e.FullPath);
    }

    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Файл удален: {e.FullPath}");
    }

    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine($"Файл переименован: {e.OldFullPath} -> {e.FullPath}");
    }

    private void CreateBackup(string filePath)
    {
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        string fileExtension = Path.GetExtension(filePath);
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string backupFileName = $"{fileName}_{timestamp}.bak";

        string backupFilePath = Path.Combine(_backupDirectory, backupFileName);

        File.Copy(filePath, backupFilePath, true);
        Console.WriteLine($"Создана резервная копия: {backupFilePath}");
    }
}