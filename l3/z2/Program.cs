using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int size = 50;
        int[] numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            numbers[i] = rand.Next(1, 101); // Генерация случайных чисел от 1 до 100
        }

        Console.WriteLine("Сгенерированный массив:");
        PrintArray(numbers);

        Array.Sort(numbers);
        Console.WriteLine("\nОтсортированный массив:");
        PrintArray(numbers);

        Console.Write("Введите число k для поиска: ");
        int k = Convert.ToInt32(Console.ReadLine());

        int index = Array.BinarySearch(numbers, k);
        if (index >= 0)
        {
            Console.WriteLine($"Число {k} найдено в массиве на позиции {index}.");
        }
        else
        {
            Console.WriteLine($"Число {k} не найдено в массиве.");
        }

        int lastNumber = numbers[size - 1];
        int countDifferent = 0;
        foreach (int number in numbers)
        {
            if (number != lastNumber)
            {
                countDifferent++;
            }
        }

        Console.WriteLine($"\nКоличество чисел, отличных от последнего числа {lastNumber}: {countDifferent}");
    }

    static void PrintArray(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}