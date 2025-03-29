public class SyrupDecorator : ICoffee
{
    private readonly ICoffee _coffee;

    public SyrupDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public string GetDescription()
    {
        return _coffee.GetDescription() + ", сироп";
    }

    public double GetCost()
    {
        return _coffee.GetCost() + 0.70; 
    }
}