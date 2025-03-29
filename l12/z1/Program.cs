class Program
{
    static void Main(string[] args)
    {
        BankCardFactory creditFactory = new CreditCardFactory();
        IBankCard creditCard = creditFactory.CreateCard();
        creditCard.Use(); 

        BankCardFactory debitFactory = new DebitCardFactory();
        IBankCard debitCard = debitFactory.CreateCard();
        debitCard.Use(); 

        BankCardFactory virtualFactory = new VirtualCardFactory();
        IBankCard virtualCard = virtualFactory.CreateCard();
        virtualCard.Use();
    }
}