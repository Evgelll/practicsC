using System;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException() : base() { }

    public InsufficientFundsException(string message) : base(message) { }

    public InsufficientFundsException(string message, Exception innerException)
        : base(message, innerException) { }
}

public class BankAccount
{
    private decimal _balance;

    public BankAccount(decimal initialBalance)
    {
        _balance = initialBalance;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > _balance)
        {
            throw new InsufficientFundsException("Недостаточно средств для снятия.");
        }
        _balance -= amount;
    }

    public decimal GetBalance()
    {
        return _balance;
    }
}

public class Program
{
    public static void Main()
    {
        BankAccount account = new BankAccount(100m);
        Console.WriteLine($"Текущий баланс: {account.GetBalance()}");

        Console.Write("Введите сумму для снятия: ");
        decimal amountToWithdraw;

        if (decimal.TryParse(Console.ReadLine(), out amountToWithdraw))
        {
            try
            {
                account.Withdraw(amountToWithdraw);
                Console.WriteLine($"Остаток: {account.GetBalance()}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод суммы.");
        }
    }
}