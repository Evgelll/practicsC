using System;

public static class IntExtensions
{
    public static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Введите число: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number.IsEven())
            {
                Console.WriteLine($"{number} является четным.");
            }
            else
            {
                Console.WriteLine($"{number} является нечетным.");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
        }
    }
}