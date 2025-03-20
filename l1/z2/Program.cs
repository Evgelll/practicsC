using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите двузначное число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number < 10 || number > 99)
        {
            Console.WriteLine("Ошибка: введенное число должно быть двузначным.");
            return;
        }

        int tens = number / 10; 
        int units = number % 10; 

        int product = tens * units;

        Console.WriteLine($"Произведение цифр числа {number} равно {product}.");
    }
}