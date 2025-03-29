public class VirtualCardFactory : BankCardFactory
{
    public override IBankCard CreateCard()
    {
        return new VirtualCard();
    }
}