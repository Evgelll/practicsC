using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество строк массива: ");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество столбцов массива: ");
        int cols = Convert.ToInt32(Console.ReadLine());

        int[,] array = new int[rows, cols];
        Random rand = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = rand.Next(1, 101); // Заполнение массива случайными числами от 1 до 100
            }
        }

        Console.WriteLine("\nСгенерированный массив:");
        PrintArray(array);

        Console.Write("Введите номер строки для проверки (0 - {0}): ", rows - 1);
        int rowNumber = Convert.ToInt32(Console.ReadLine());

        if (rowNumber < 0 || rowNumber >= rows)
        {
            Console.WriteLine("Ошибка: Номер строки вне диапазона.");
            return;
        }

        Console.Write("Введите заданное число для сравнения: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int sum = 0;
        for (int j = 0; j < cols; j++)
        {
            sum += array[rowNumber, j];
        }

        Console.WriteLine($"Сумма элементов строки {rowNumber}: {sum}");
        if (sum > number)
        {
            Console.WriteLine($"Сумма элементов строки превышает заданное число {number}.");
        }
        else
        {
            Console.WriteLine($"Сумма элементов строки не превышает заданное число {number}.");
        }
    }

    static void PrintArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}