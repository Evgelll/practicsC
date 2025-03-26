using System;

public class Program
{
    public static void Main()
    {
        QueueManager<string> queueManager = new QueueManager<string>();

        queueManager.AddItem("Первый элемент");
        queueManager.AddItem("Второй элемент");
        queueManager.AddItem("Третий элемент");

        queueManager.PrintQueue();

        Console.WriteLine($"Удаленный элемент: {queueManager.RemoveItem()}");

        queueManager.PrintQueue();

        Console.WriteLine($"Первый элемент очереди: {queueManager.PeekItem()}");
    }
}