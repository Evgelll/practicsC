using System;
using System.Linq;

public abstract class BankAccount
{
    public string AccountNumber { get; private set; }
    public decimal Balance { get; protected set; }
    public string OwnerName { get; private set; }

    protected BankAccount(string accountNumber, string ownerName, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = initialBalance;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Депозит {amount} выполнен на счёт {AccountNumber}. Новый баланс: {Balance}");
        }
        else
        {
            Console.WriteLine("Сумма депозита должна быть положительной.");
        }
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Снятие {amount} выполнено с счёта {AccountNumber}. Новый баланс: {Balance}");
        }
        else
        {
            Console.WriteLine("Недостаточно средств или неверная сумма снятия.");
        }
    }
}

public sealed class SavingsAccount : BankAccount
{
    public SavingsAccount(string accountNumber, string ownerName, decimal initialBalance)
        : base(accountNumber, ownerName, initialBalance) { }
}

public sealed class CheckingAccount : BankAccount
{
    public CheckingAccount(string accountNumber, string ownerName, decimal initialBalance)
        : base(accountNumber, ownerName, initialBalance) { }
}

public class Bank
{
    private BankAccount[] accounts;

    public Bank(BankAccount[] accounts)
    {
        this.accounts = accounts;
    }

    public BankAccount GetRichestClient()
    {
        return accounts.OrderByDescending(a => a.Balance).FirstOrDefault();
    }

    public decimal GetTotalBankBalance()
    {
        return accounts.Sum(a => a.Balance);
    }
}

class Program
{
    static void Main()
    {
        BankAccount[] accounts = new BankAccount[]
        {
            new SavingsAccount("ACC001", "Alice", 1500),
            new CheckingAccount("ACC002", "Bob", 2500),
            new SavingsAccount("ACC003", "Charlie", 3000),
            new CheckingAccount("ACC004", "David", 500)
        };

        Bank bank = new Bank(accounts);

        BankAccount richestClient = bank.GetRichestClient();
        if (richestClient != null)
        {
            Console.WriteLine($"Самый богатый клиент: {richestClient.OwnerName}, Баланс: {richestClient.Balance}");
        }

        decimal totalBalance = bank.GetTotalBankBalance();
        Console.WriteLine($"Общий баланс всех клиентов в банке: {totalBalance}");
    }
}