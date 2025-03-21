using System;

public abstract class Animal
{
    public abstract void MakeSound();

    public virtual void Sleep()
    {
        Console.WriteLine("Это животное спит.");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
    }

    public override void Sleep()
    {
        Console.WriteLine("Собака спит в своей будке.");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow!");
    }

    public override void Sleep()
    {
        Console.WriteLine("Кошка спит на окне.");
    }
}

public class Program
{
    public static void Main()
    {
        Animal myDog = new Dog();
        Animal myCat = new Cat();

        myDog.MakeSound();
        myDog.Sleep();

        myCat.MakeSound();
        myCat.Sleep();
    }
}