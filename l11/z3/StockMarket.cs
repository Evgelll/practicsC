using System;
using System.Collections.Generic;

public class StockMarket
{
    private readonly Dictionary<string, double> _stockPrices = new Dictionary<string, double>();
    private readonly List<IStockObserver> _observers = new List<IStockObserver>();

    public void Subscribe(IStockObserver observer)
    {
        _observers.Add(observer);
    }

    public void Unsubscribe(IStockObserver observer)
    {
        _observers.Remove(observer);
    }

    public void SetStockPrice(string stockSymbol, double price)
    {
        _stockPrices[stockSymbol] = price;
        NotifyObservers(stockSymbol, price);
    }

    private void NotifyObservers(string stockSymbol, double price)
    {
        foreach (var observer in _observers)
        {
            observer.Update(stockSymbol, price);
        }
    }
}