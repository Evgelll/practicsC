using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите угол a в градусах: ");
        double angleInDegrees = Convert.ToDouble(Console.ReadLine());

        double a = angleInDegrees * (Math.PI / 180);

        double z1 = (1 - 2 * Math.Pow(Math.Sin(a), 2)) / (1 + Math.Pow(Math.Sin(2 * a), 2));

        double tga = Math.Tan(a);
        double z2 = (1 - tga) / (1 + tga);

        Console.WriteLine($"z1 = {z1:F6}");
        Console.WriteLine($"z2 = {z2:F6}");

        if (Math.Abs(z1 - z2) < 1e-6) 
        {
            Console.WriteLine("Результаты совпадают.");
        }
        else
        {
            Console.WriteLine("Результаты не совпадают.");
        }
    }
}