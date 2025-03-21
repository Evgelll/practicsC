using System;

public class Program
{
    public static int SumArray(int[] array)
    {
        int sum = 0;
        foreach (int number in array)
        {
            sum += number;
        }
        return sum;
    }

    public static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        int totalSum = SumArray(numbers);
        Console.WriteLine($"Сумма элементов массива: {totalSum}");
    }
}