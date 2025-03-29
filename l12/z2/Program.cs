class Program
{
    static void Main(string[] args)
    {
        ICoffee coffee = new BasicCoffee();
        Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost():C}");

        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost():C}");

        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost():C}");

        coffee = new SyrupDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost():C}");
    }
}