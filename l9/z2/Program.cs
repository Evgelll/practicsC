using System;

public class Program
{
    public static void Main()
    {
        DictionaryManager<string, int> manager = new DictionaryManager<string, int>();

        manager.AddKeyValue("Яблоко", 1);
        manager.AddKeyValue("Банан", 2);
        manager.AddKeyValue("Груша", 3);

        Console.WriteLine("Поиск 'Банан': " + manager.FindValue("Банан"));

        manager.RemoveKey("Яблоко");
        Console.WriteLine("После удаления 'Яблоко':");
        manager.DisplayAll();

        Console.WriteLine("Поиск 'Яблоко': " + manager.FindValue("Яблоко"));
    }
}