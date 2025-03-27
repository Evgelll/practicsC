using System;

public class Program
{
    public static void Main()
    {
        ProductFileReader reader = new ProductFileReader();
        List<Product> products = reader.ReadProducts();

        Console.WriteLine("Прочитанные товары:");
        foreach (var product in products)
        {
            Console.WriteLine($"Название: {product.Name}, Цена: {product.Price}, Категория: {product.Category}");
        }

        ProductProcessor processor = new ProductProcessor();
        List<Product> sortedProducts = processor.SortByPrice(products, true); 

        Console.WriteLine("\nТовары, отсортированные по цене:");
        foreach (var product in sortedProducts)
        {
            Console.WriteLine($"Название: {product.Name}, Цена: {product.Price}, Категория: {product.Category}");
        }
    }
}