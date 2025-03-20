using System;

class Program
{
    static void Main()
    {
        double radius = Convert.ToDouble(5);

        double height = Convert.ToDouble(10);

        double volume = Math.PI * Math.Pow(radius, 2) * height;

        Console.WriteLine($"Объем цилиндра {volume:F2} куб. см.");
    }
}