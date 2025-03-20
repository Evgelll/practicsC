using System;

class Program
{
    static void Main()
    {
        Order[] orders = new Order[]
        {
            new Order(1, "Alice", 150.00m),
            new Order(2, "Bob", 250.00m),
            new Order(3, "Charlie", 75.00m),
            new Order(4, "Alice", 300.00m),
            new Order(5, "David", 50.00m)
        };

        Store store = new Store(orders);

        var highValueOrders = store.GetHighValueOrders(100);
        Console.WriteLine("Заказы дороже 100:");
        foreach (var order in highValueOrders)
        {
            order.DisplayOrder();
        }

        string customerName = "Alice";
        var aliceOrders = store.GetOrdersByCustomer(customerName);
        Console.WriteLine($"\nЗаказы клиента {customerName}:");
        foreach (var order in aliceOrders)
        {
            order.DisplayOrder();
        }
    }
}