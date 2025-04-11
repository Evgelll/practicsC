using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Введите email-адрес: ");
        string email = Console.ReadLine();

        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        bool isValidEmail = Regex.IsMatch(email, pattern);

        if (isValidEmail)
        {
            Console.WriteLine("Email-адрес корректен.");
        }
        else
        {
            Console.WriteLine("Email-адрес некорректен.");
        }
    }
}