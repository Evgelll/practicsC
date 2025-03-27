using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите путь к папке для отслеживания:");
        string pathToWatch = Console.ReadLine();

        if (Directory.Exists(pathToWatch))
        {
            FileWatcher watcher = new FileWatcher(pathToWatch);
            Console.WriteLine($"Начато отслеживание изменений в папке: {pathToWatch}");

            Console.WriteLine("Нажмите 'q' для выхода.");
            while (Console.Read() != 'q') ;
        }
        else
        {
            Console.WriteLine("Указанная папка не существует.");
        }
    }
}