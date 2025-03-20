using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите четырехзначное число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number < 1000 || number > 9999)
        {
            Console.WriteLine("Ошибка: введенное число должно быть четырехзначным.");
            return;
        }

        int thousands = number / 1000;
        int hundreds = (number / 100) % 10;
        int tens = (number / 10) % 10;
        int units = number % 10;

        int product = thousands * hundreds * tens * units;

        Console.WriteLine($"Произведение цифр числа {number} равно {product}.");
    }
}