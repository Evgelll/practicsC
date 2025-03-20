using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Цикл while:");
        int numberWhile = 80;
        while (numberWhile >= 10)
        {
            Console.WriteLine(numberWhile);
            numberWhile -= 2;
        }

        Console.WriteLine("\nЦикл do while:");
        int numberDoWhile = 80;
        do
        {
            Console.WriteLine(numberDoWhile);
            numberDoWhile -= 2;
        } while (numberDoWhile >= 10);

        Console.WriteLine("\nЦикл for:");
        for (int numberFor = 80; numberFor >= 10; numberFor -= 2)
        {
            Console.WriteLine(numberFor);
        }
    }
}