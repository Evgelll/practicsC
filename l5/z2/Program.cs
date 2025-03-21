using System;

public class Program
{
    public static void PowerA234(double A, out double B, out double C, out double D)
    {
        B = Math.Pow(A, 2); 
        C = Math.Pow(A, 3); 
        D = Math.Pow(A, 4);
    }

    public static void Main()
    {
        double[] numbers = { 1.0, 2.0, 3.0, 4.0, 5.0 };

        double secondPower, thirdPower, fourthPower;

        foreach (double number in numbers)
        {
            PowerA234(number, out secondPower, out thirdPower, out fourthPower);
            Console.WriteLine($"Число: {number}, Вторая степень: {secondPower}, Третья степень: {thirdPower}, Четвертая степень: {fourthPower}");
        }
    }
}