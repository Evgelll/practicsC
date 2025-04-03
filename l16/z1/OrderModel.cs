public class OrderModel
{
    public string OrderDetails { get; set; }
    public DateTime OrderDate { get; set; }
    public ClientModel Client { get; set; }
}