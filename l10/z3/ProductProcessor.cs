using System.Collections.Generic;
using System.Linq;

public class ProductProcessor
{
    public List<Product> SortByPrice(List<Product> products, bool ascending)
    {
        return ascending
            ? products.OrderBy(p => p.Price).ToList()
            : products.OrderByDescending(p => p.Price).ToList();
    }
}