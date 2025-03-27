using System;
using System.IO;

public class FileManager
{
    public void CreateFile(string path, string content)
    {
        File.WriteAllText(path, content);
    }

    public void CopyFile(string sourcePath, string destPath)
    {
        File.Copy(sourcePath, destPath, true);
    }

    public void MoveFile(string sourcePath, string destPath)
    {
        File.Move(sourcePath, destPath);
    }

    public void RenameFile(string currentPath, string newPath)
    {
        File.Move(currentPath, newPath);
    }

    public void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            throw new FileNotFoundException("Файл не найден для удаления.");
        }
    }

    public void DeleteFilesByPattern(string directory, string searchPattern)
    {
        var files = Directory.GetFiles(directory, searchPattern);
        foreach (var file in files)
        {
            File.Delete(file);
        }
    }

    public void ListFiles(string directory)
    {
        var files = Directory.GetFiles(directory);
        foreach (var file in files)
        {
            Console.WriteLine(file);
        }
    }
}