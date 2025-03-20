using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите целое число N (1 <= N <= 20): ");
        int N = Convert.ToInt32(Console.ReadLine());

        double result = 0.0;

        for (int i = 1; i <= N; i++)
        {
            result += (i % 2 == 0 ? -i / 10.0 : i / 10.0);
        }

        Console.WriteLine($"Результат: {result:F4}");
    }
}