using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите значение x: ");
        double x = Convert.ToDouble(Console.ReadLine());
        double y;

        if (x >= 10)
        {
            y = 4 + Math.Pow(x, 2) - Math.Exp(Math.Sqrt(x));
        }
        else
        {
            y = 3.4 - x + 1 + Math.Pow(x, 3);
        }

        Console.WriteLine($"Значение функции y при x = {x} равно {y:F6}");
    }
}