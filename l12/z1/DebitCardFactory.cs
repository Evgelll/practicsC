public class DebitCardFactory : BankCardFactory
{
    public override IBankCard CreateCard()
    {
        return new DebitCard();
    }
}