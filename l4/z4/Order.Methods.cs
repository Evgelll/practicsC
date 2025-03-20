using System;

public partial class Order
{
    public void DisplayOrder()
    {
        Console.WriteLine($"Order ID: {OrderID}, Customer: {CustomerName}, Total Amount: {TotalAmount}");
    }
}