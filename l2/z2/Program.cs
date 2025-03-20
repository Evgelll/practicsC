using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите координату x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите координату y: ");
        double y = Convert.ToDouble(Console.ReadLine());

        if (x < 0 && y > 0)
        {
            Console.WriteLine("Данные числа x и y являются координатами точки, лежащей во второй координатной четверти.");
        }
        else
        {
            Console.WriteLine("Данные числа x и y НЕ являются координатами точки, лежащей во второй координатной четверти.");
        }
    }
}