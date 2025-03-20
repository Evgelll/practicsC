using System;
using System.Linq;

public class Store
{
    private Order[] orders;

    public Store(Order[] orders)
    {
        this.orders = orders;
    }

    public Order[] GetHighValueOrders(decimal minAmount)
    {
        return orders.Where(o => o.TotalAmount > minAmount).ToArray();
    }

    public Order[] GetOrdersByCustomer(string customerName)
    {
        return orders.Where(o => o.CustomerName.Equals(customerName, StringComparison.OrdinalIgnoreCase)).ToArray();
    }
}