public class MilkDecorator : ICoffee
{
    private readonly ICoffee _coffee;

    public MilkDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public string GetDescription()
    {
        return _coffee.GetDescription() + ", молоко";
    }

    public double GetCost()
    {
        return _coffee.GetCost() + 0.50; 
    }
}