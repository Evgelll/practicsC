using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var data = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var dataFilter = new DataFilter();

        dataFilter.SetFilterStrategy(new EvenNumberFilter());
        var evenNumbers = dataFilter.FilterData(data);
        Console.WriteLine("Четные числа: " + string.Join(", ", evenNumbers));

        dataFilter.SetFilterStrategy(new PrimeNumberFilter());
        var primeNumbers = dataFilter.FilterData(data);
        Console.WriteLine("Простые числа: " + string.Join(", ", primeNumbers));

        dataFilter.SetFilterStrategy(new RangeFilter(4, 8));
        var rangeFiltered = dataFilter.FilterData(data);
        Console.WriteLine("Числа в диапазоне от 4 до 8: " + string.Join(", ", rangeFiltered));
    }
}