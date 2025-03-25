using System;

public class InvalidAccountNumberException : Exception
{
    public InvalidAccountNumberException() : base() { }

    public InvalidAccountNumberException(string message) : base(message) { }

    public InvalidAccountNumberException(string message, Exception innerException)
        : base(message, innerException) { }
}

public class BankAccount
{
    public void ValidateAccount(string accountNumber)
    {
        if (accountNumber.Length != 10 || !long.TryParse(accountNumber, out _))
        {
            throw new InvalidAccountNumberException("Номер банковского счета должен состоять из 10 цифр.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        BankAccount bankAccount = new BankAccount();
        Console.Write("Введите номер банковского счета: ");
        string accountNumber = Console.ReadLine();

        try
        {
            bankAccount.ValidateAccount(accountNumber);
            Console.WriteLine("Номер счета корректен.");
        }
        catch (InvalidAccountNumberException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}