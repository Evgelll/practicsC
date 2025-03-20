using System;

class A
{
    private int a;
    private int b;

    public A(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public int CalculateDifference()
    {
        return a - b;
    }

    public double CalculateExpression()
    {
        if (a - b == 0)
        {
            throw new DivideByZeroException("Деление на ноль: a и b равны.");
        }
        return (double)(a + b) / (a - b);
    }

    public void DisplayValues()
    {
        Console.WriteLine($"a: {a}, b: {b}");
    }
}

class Program
{
    static void Main()
    {
        A obj = new A(10, 5);

        obj.DisplayValues();

        int difference = obj.CalculateDifference();
        Console.WriteLine($"Разность a и b: {difference}");

        try
        {
            double expressionResult = obj.CalculateExpression();
            Console.WriteLine($"Результат выражения (a + b) / (a - b): {expressionResult}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}