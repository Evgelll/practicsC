using System;

public class Investor : IStockObserver
{
    private readonly string _name;

    public Investor(string name)
    {
        _name = name;
    }

    public void Update(string stockSymbol, double price)
    {
        Console.WriteLine($"Инвестор {_name} получил уведомление: цена акции {stockSymbol} изменилась на {price}");
    }
}