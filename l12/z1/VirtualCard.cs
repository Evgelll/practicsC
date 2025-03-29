public class VirtualCard : IBankCard
{
    public void Use()
    {
        Console.WriteLine("Используется виртуальная карта.");
    }
}