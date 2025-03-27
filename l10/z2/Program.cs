using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product("Apple", 0.60m, "Fruits"),
            new Product("Bread", 1.50m, "Bakery"),
            new Product("Milk", 0.80m, "Dairy"),
            new Product("Eggs", 2.00m, "Dairy"),
            new Product("Chicken", 5.00m, "Meat")
        };

        ProductFileWriter writer = new ProductFileWriter();
        writer.WriteProducts(products);

        Console.WriteLine("Товары записаны в файл file.data.");
    }
}