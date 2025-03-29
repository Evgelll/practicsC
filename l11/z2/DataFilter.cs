using System.Collections.Generic;

public class DataFilter
{
    private IFilterStrategy _filterStrategy;

    public void SetFilterStrategy(IFilterStrategy filterStrategy)
    {
        _filterStrategy = filterStrategy;
    }

    public IEnumerable<int> FilterData(IEnumerable<int> data)
    {
        return _filterStrategy?.Filter(data) ?? Enumerable.Empty<int>();
    }
}