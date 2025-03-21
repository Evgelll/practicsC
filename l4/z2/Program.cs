using System;
using System.Linq;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public static class ArrayUtils
{
    public static void SortByName(Person[] persons)
    {
        Array.Sort(persons, (x, y) => string.Compare(x.Name, y.Name));
    }

    public static Person[] FilterByAge(Person[] persons, int minAge)
    {
        return persons.Where(p => p.Age >= minAge).ToArray();
    }

    public static double CalculateAverageAge(Person[] persons)
    {
        if (persons.Length == 0) return 0;
        return persons.Average(p => p.Age);
    }

    public static Person[] GenerateRandomPersons(int count)
    {
        Random rand = new Random();
        var names = new[] { "Адриан", "Иван", "Евгений", "Артем", "Кирилл" };
        Person[] persons = new Person[count];

        for (int i = 0; i < count; i++)
        {
            string name = names[rand.Next(names.Length)];
            int age = rand.Next(18, 100);
            persons[i] = new Person(name, age);
        }

        return persons;
    }
}

class Program
{
    static void Main()
    {
        Person[] persons = ArrayUtils.GenerateRandomPersons(10);

        Console.WriteLine("Сгенерированные данные:");
        foreach (var person in persons)
        {
            Console.WriteLine($"Имя: {person.Name}, Возраст: {person.Age}");
        }

        ArrayUtils.SortByName(persons);
        Console.WriteLine("\nОтсортированные данные по имени:");
        foreach (var person in persons)
        {
            Console.WriteLine($"Имя: {person.Name}, Возраст: {person.Age}");
        }

        var filteredPersons = ArrayUtils.FilterByAge(persons, 25);
        Console.WriteLine("\nФильтрация по возрасту (мин. 25 лет):");
        foreach (var person in filteredPersons)
        {
            Console.WriteLine($"Имя: {person.Name}, Возраст: {person.Age}");
        }

        double averageAge = ArrayUtils.CalculateAverageAge(persons);
        Console.WriteLine($"\nСредний возраст: {averageAge}");
    }
}