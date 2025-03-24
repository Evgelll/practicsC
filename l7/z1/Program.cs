using System;

public delegate double MathOperation(double a, double b);

public class Addition
{
    public double Add(double a, double b)
    {
        return a + b;
    }
}

public class Multiplication
{
    public double Multiply(double a, double b)
    {
        return a * b;
    }
}

public class Program
{
    public static void Main()
    {
        Addition addition = new Addition();
        Multiplication multiplication = new Multiplication();

        MathOperation addOperation = addition.Add;
        MathOperation multiplyOperation = multiplication.Multiply;

        double addResult = addOperation(3, 5);
        double multiplyResult = multiplyOperation(3, 5);

        Console.WriteLine($"Результат сложения: {addResult}");
        Console.WriteLine($"Результат умножения: {multiplyResult}");
    }
}