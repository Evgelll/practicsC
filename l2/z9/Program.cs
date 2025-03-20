using System;

class Program
{
    static void Main()
    {
        double A = Math.PI / 4; 
        double B = Math.PI / 2; 
        int M = 15;              

        double H = (B - A) / M;
        double x = A;          
        Console.WriteLine("Значения функции F(x) = 2 - sin(x):");

        for (int i = 1; i <= M; i++)
        {
            double y = 2 - Math.Sin(x); 
            Console.WriteLine($"x = {x:F4}, F(x) = {y:F4}");
            x += H; 
        }
    }
}