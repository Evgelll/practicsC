using System;

class Program
{
    static void Main()
    {
        double x = 5;

        double y = Math.Exp(2 * x) - Math.Exp(Math.Sqrt(Math.Abs(1 - x))) + (2 * Math.Pow(Math.Sin(x), 2)) / (Math.PI * Math.Pow(x, 2));

        Console.WriteLine($"Значение функции y при x = {x} равно {y:F6}");
    }
}