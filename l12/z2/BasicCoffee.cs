public class BasicCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Черный кофе";
    }

    public double GetCost()
    {
        return 2.00; 
    }
}