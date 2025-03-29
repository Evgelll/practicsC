using System.Collections.Generic;
using System.Linq;

public class PrimeNumberFilter : IFilterStrategy
{
    public IEnumerable<int> Filter(IEnumerable<int> data)
    {
        return data.Where(IsPrime);
    }

    private bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}