public class SugarDecorator : ICoffee
{
    private readonly ICoffee _coffee;

    public SugarDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public string GetDescription()
    {
        return _coffee.GetDescription() + ", сахар";
    }

    public double GetCost()
    {
        return _coffee.GetCost() + 0.20;
    }
}