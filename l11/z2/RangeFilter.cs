using System.Collections.Generic;
using System.Linq;

public class RangeFilter : IFilterStrategy
{
    private readonly int _min;
    private readonly int _max;

    public RangeFilter(int min, int max)
    {
        _min = min;
        _max = max;
    }

    public IEnumerable<int> Filter(IEnumerable<int> data)
    {
        return data.Where(n => n >= _min && n <= _max);
    }
}