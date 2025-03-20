using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите целое число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number % 2 == 0)
        {
            Console.WriteLine($"{number} является четным числом.");
        }
        else
        {
            Console.WriteLine($"{number} является нечетным числом.");
        }
    }
}