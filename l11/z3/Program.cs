class Program
{
    static void Main(string[] args)
    {
        var stockMarket = new StockMarket();

        var investor1 = new Investor("Иван");
        var investor2 = new Investor("Мария");

        stockMarket.Subscribe(investor1);
        stockMarket.Subscribe(investor2);

        stockMarket.SetStockPrice("AAPL", 150.00);
        stockMarket.SetStockPrice("GOOGL", 2800.00);

        stockMarket.Unsubscribe(investor1);

        stockMarket.SetStockPrice("MSFT", 299.00);
    }
}