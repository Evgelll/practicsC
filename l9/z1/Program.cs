using System;

public class Program
{
    public static void Main()
    {
        TaskManager taskManager = new TaskManager();

        taskManager.AddTask(new Task(1, "Задача 1", 1));
        taskManager.AddTask(new Task(2, "Задача 2", 2));
        taskManager.AddTask(new Task(3, "Задача 3", 3));

        Console.WriteLine("Незавершенные задачи:");
        foreach (var task in taskManager.GetPendingTasks())
        {
            Console.WriteLine(task);
        }

        Console.WriteLine("\nОбработка задачи:");
        Task processedTask = taskManager.ProcessTask();
        if (processedTask != null)
        {
            Console.WriteLine($"Обработана: {processedTask}");
        }
        else
        {
            Console.WriteLine("Нет задач для обработки.");
        }

        Console.WriteLine("\nОставшиеся незавершенные задачи:");
        foreach (var task in taskManager.GetPendingTasks())
        {
            Console.WriteLine(task);
        }
    }
}