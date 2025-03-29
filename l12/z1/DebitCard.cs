public class DebitCard : IBankCard
{
    public void Use()
    {
        Console.WriteLine("Используется дебетовая карта.");
    }
}