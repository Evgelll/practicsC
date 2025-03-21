using System;

public class Program
{
    public static int Fibonacci(int n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException("n", "Число должно быть неотрицательным.");
        }
        if (n == 0) return 0;
        if (n == 1) return 1;

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    public static void Main()
    {
        try
        {
            int number = 6;
            int result = Fibonacci(number);
            Console.WriteLine($"Число Фибоначчи с номером {number} равно {result}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}