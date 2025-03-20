using System;

class Program
{
    static void Main()
    {
        double x = 0.5;

        double y = x * Math.Exp(Math.Pow(x, 2) - (Math.Sin(Math.Sqrt(x)) + Math.Pow(Math.Cos(Math.Log(x)), 2)) / (Math.Sqrt(Math.Abs(1 - Math.PI * x))));

        Console.WriteLine($"Значение функции y при x = {x} равно {y:F6}");
    }
}