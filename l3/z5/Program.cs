using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество строк массива: ");
        int rows = Convert.ToInt32(Console.ReadLine());
        int[][] jaggedArray = new int[rows][];

        Random rand = new Random();

        for (int i = 0; i < rows; i++)
        {
            Console.Write($"Введите количество элементов в строке {i + 1}: ");
            int cols = Convert.ToInt32(Console.ReadLine());
            jaggedArray[i] = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                jaggedArray[i][j] = rand.Next(1, 101); // Заполнение случайными числами от 1 до 100
            }
        }

        Console.WriteLine("\nСгенерированный ступенчатый массив:");
        PrintJaggedArray(jaggedArray);

        int maxSumRowIndex = 0;
        int maxSum = 0;

        for (int i = 0; i < rows; i++)
        {
            int currentSum = 0;
            foreach (var number in jaggedArray[i])
            {
                currentSum += number;
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                maxSumRowIndex = i;
            }
        }

        Console.WriteLine($"\nСтрока с наибольшей суммой элементов: {maxSumRowIndex + 1}");
        Console.WriteLine($"Сумма элементов: {maxSum}");
    }

    static void PrintJaggedArray(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + "\t");
            }
            Console.WriteLine();
        }
    }
}