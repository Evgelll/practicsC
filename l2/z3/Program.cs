using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите целое число A (1 <= A <= 100): ");
        int A = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите целое число B (1 <= B <= 100, A < B): ");
        int B = Convert.ToInt32(Console.ReadLine());

        if (A >= B || A < 1 || A > 100 || B < 1 || B > 100)
        {
            Console.WriteLine("Ошибка: убедитесь, что A < B и оба числа находятся в пределах от 1 до 100.");
            return;
        }

        Console.WriteLine("Числа между A и B (включая A и B):");
        for (int i = A; i <= B; i++)
        {
            Console.Write(i + " ");
        }

        int N = B - A + 1;
        Console.WriteLine($"\nКоличество чисел (N): {N}");
    }
}