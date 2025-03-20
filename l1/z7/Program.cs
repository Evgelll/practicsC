using System;

class Program
{
    static void Main()
    {
        const double g = 9.81523;

        Console.Write("Введите высоту h (в метрах): ");
        double h = Convert.ToDouble(Console.ReadLine());

        double t = Math.Sqrt(2 * h / g);

        Console.WriteLine($"Время падения камня с высоты {h} м равно {t:F6} секунд.");
    }
}