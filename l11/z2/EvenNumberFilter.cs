using System.Collections.Generic;
using System.Linq;

public class EvenNumberFilter : IFilterStrategy
{
    public IEnumerable<int> Filter(IEnumerable<int> data)
    {
        return data.Where(n => n % 2 == 0);
    }
}