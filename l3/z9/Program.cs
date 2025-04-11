using System;
using System.Text;

class Program
{
    static void Main()
    {
        string initialInput = "Это исходная строка.";

        StringBuilder sb = new StringBuilder(initialInput);

        Console.Write("Введите строку для добавления: ");
        string additionalInput = Console.ReadLine();
        sb.Append(" "); 
        sb.Append(additionalInput);

        Console.WriteLine("Исходная строка: " + initialInput);
        Console.WriteLine("Текущий текст в StringBuilder: " + sb.ToString());
    }
}