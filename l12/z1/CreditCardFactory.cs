public class CreditCardFactory : BankCardFactory
{
    public override IBankCard CreateCard()
    {
        return new CreditCard();
    }
}