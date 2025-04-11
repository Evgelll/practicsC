using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размер матрицы N (N < 10): ");
        int N = Convert.ToInt32(Console.ReadLine());

        if (N >= 10)
        {
            Console.WriteLine("Ошибка: N должно быть меньше 10.");
            return;
        }

        Console.Write("Введите диапазон a (может быть отрицательным): ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите диапазон b (может быть отрицательным): ");
        int b = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[N, N];
        Random rand = new Random();

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = rand.Next(a, b + 1);
            }
        }

        Console.WriteLine("\nИсходная матрица:");
        PrintMatrix(matrix, N);

        int sumNegative = 0;
        int[] evenCountPerRow = new int[N];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (matrix[i, j] < 0)
                {
                    sumNegative += matrix[i, j];
                }
                if (matrix[i, j] % 2 == 0)
                {
                    evenCountPerRow[i]++;
                }
            }
        }

        Console.WriteLine($"\nСумма отрицательных элементов: {sumNegative}");
        Console.WriteLine("Количество четных элементов в каждой строке:");

        for (int i = 0; i < N; i++)
        {
            Console.WriteLine($"Строка {i + 1}: {evenCountPerRow[i]}");
        }
    }

    static void PrintMatrix(int[,] matrix, int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}