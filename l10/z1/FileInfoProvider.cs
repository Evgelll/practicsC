using System;
using System.IO;

public class FileInfoProvider
{
    public void GetFileInfo(string path)
    {
        if (File.Exists(path))
        {
            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine($"Размер: {fileInfo.Length} байт");
            Console.WriteLine($"Дата создания: {fileInfo.CreationTime}");
            Console.WriteLine($"Дата последнего изменения: {fileInfo.LastWriteTime}");
        }
        else
        {
            Console.WriteLine("Файл не найден.");
        }
    }

    public FileAttributes GetFileAttributes(string path)
    {
        if (File.Exists(path))
        {
            return File.GetAttributes(path);
        }
        else
        {
            throw new FileNotFoundException("Файл не найден.");
        }
    }

    public bool CompareFilesBySize(string path1, string path2)
    {
        if (!File.Exists(path1) || !File.Exists(path2))
        {
            Console.WriteLine("Один из файлов не существует.");
            return false; 
        }

        FileInfo file1 = new FileInfo(path1);
        FileInfo file2 = new FileInfo(path2);

        return file1.Length == file2.Length;
    }
}