public interface IStockObserver
{
    void Update(string stockSymbol, double price);
}