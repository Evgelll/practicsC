using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первое целое число: ");
        int number1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите второе целое число: ");
        int number2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите третье целое число: ");
        int number3 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"{number1} + {number2} + {number3} = {number3} + {number2} + {number1}");
    }
}