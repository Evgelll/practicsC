using System.Collections.Generic;

public interface IFilterStrategy
{
    IEnumerable<int> Filter(IEnumerable<int> data);
}