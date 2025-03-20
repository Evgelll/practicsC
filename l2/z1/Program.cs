using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите массу в килограммах: ");
        double massInKilograms = Convert.ToDouble(Console.ReadLine());

        double fullQuintals = massInKilograms / 100;

        Console.WriteLine($"Число полных центнеров в {massInKilograms} кг равно {Math.Floor(fullQuintals)}.");
    }
}