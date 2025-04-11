using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        string result = input.Replace(" ", "");

        Console.WriteLine("Строка без пробелов: " + result);
    }
}