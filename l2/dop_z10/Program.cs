using System;

class Program
{
    static void Main()
    {
        int lowerBound = 100;
        int upperBound = 999;

        Console.WriteLine("Автокоммутативные числа в диапазоне от 100 до 999:");
        for (int i = lowerBound; i <= upperBound; i++)
        {
            int square = i * i;
            if (IsAutomorphic(i, square))
            {
                Console.WriteLine(i);
            }
        }
    }

    static bool IsAutomorphic(int number, int square)
    {
        string numberStr = number.ToString();
        string squareStr = square.ToString();

        return squareStr.EndsWith(numberStr);
    }
}