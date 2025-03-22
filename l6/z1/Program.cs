using System;

public abstract class Animal
{
    public abstract void MakeSound();
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow!");
    }
}

public class Cow : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Moo!");
    }
}

public class Program
{
    public static void Main()
    {
        Animal[] animals = new Animal[3];
        animals[0] = new Dog();
        animals[1] = new Cat();
        animals[2] = new Cow();

        foreach (Animal animal in animals)
        {
            animal.MakeSound();
        }
    }
}