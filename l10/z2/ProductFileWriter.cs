using System.Collections.Generic;
using System.IO;

public class ProductFileWriter
{
    private const string FileName = "file.data";

    public void WriteProducts(List<Product> products)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Create)))
        {
            foreach (var product in products)
            {
                writer.Write(product.Name);
                writer.Write(product.Price);
                writer.Write(product.Category);
            }
        }
    }
}