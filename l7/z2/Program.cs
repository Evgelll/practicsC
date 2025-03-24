using System;

public delegate double MathOperation(double a, double b);

public class Program
{
    public static void Main()
    {
        double num1 = 5;
        double num2 = 10;

        double sumResult = Calculate(num1, num2, Add);
        double multiplyResult = Calculate(num1, num2, Multiply);

        Console.WriteLine($"Сумма: {sumResult}");
        Console.WriteLine($"Произведение: {multiplyResult}");
    }

    public static double Calculate(double a, double b, MathOperation operation)
    {
        return operation(a, b);
    }

    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double Multiply(double a, double b)
    {
        return a * b;
    }
}