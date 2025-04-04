using System;
using System.IO;

public class OrderFileWatcher
{
    private FileSystemWatcher _watcher;

    public OrderFileWatcher(string path)
    {
        _watcher = new FileSystemWatcher(path)
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName,
            Filter = "*.txt" // Укажите нужный формат файлов
        };

        _watcher.Changed += OnChanged;
        _watcher.Created += OnChanged;
        _watcher.Deleted += OnChanged;
        _watcher.Renamed += OnRenamed;
    }

    public void Start()
    {
        _watcher.EnableRaisingEvents = true;
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Файл изменен: {e.FullPath}");
        // Здесь можно добавить логику для уведомления пользователей
    }

    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine($"Файл переименован: {e.OldFullPath} -> {e.FullPath}");
    }
}