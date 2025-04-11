using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        bool containsDigit = false;

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                containsDigit = true;
                break;
            }
        }

        if (containsDigit)
        {
            Console.WriteLine("В строке содержится хотя бы одна цифра.");
        }
        else
        {
            Console.WriteLine("В строке нет цифр.");
        }
    }
}