using System.Collections.Generic;
using System.IO;

public class ProductFileReader
{
    private const string FileName = @"C:\1\practicsC#\l10\z2\bin\Debug\net8.0\file.data";

    public List<Product> ReadProducts()
    {
        List<Product> products = new List<Product>();

        if (!File.Exists(FileName))
        {
            Console.WriteLine("Файл не найден. Убедитесь, что он существует.");
            return products; 
        }

        using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
        {
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                string name = reader.ReadString();
                decimal price = reader.ReadDecimal();
                string category = reader.ReadString();

                products.Add(new Product(name, price, category));
            }
        }

        return products;
    }
}