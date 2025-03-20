public partial class Order
{
    public int OrderID { get; private set; }
    public string CustomerName { get; private set; }
    public decimal TotalAmount { get; private set; }

    public Order(int orderId, string customerName, decimal totalAmount)
    {
        OrderID = orderId;
        CustomerName = customerName;
        TotalAmount = totalAmount;
    }
}