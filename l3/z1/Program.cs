using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int size = 10;
        double[] numbers = new double[size];

        for (int i = 0; i < size; i++)
        {
            numbers[i] = rand.NextDouble() * 100;
        }

        double sum = 0;
        int count = numbers.Length;

        foreach (double number in numbers)
        {
            sum += number;
        }

        Console.WriteLine("Сгенерированный массив:");
        foreach (double number in numbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine($"Сумма элементов массива: {sum}");
        Console.WriteLine($"Количество элементов массива: {count}");
    }
}