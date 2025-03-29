public class CreditCard : IBankCard
{
    public void Use()
    {
        Console.WriteLine("Используется кредитная карта.");
    }
}