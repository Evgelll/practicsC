using System;
using System.Collections.Generic;

public abstract class Vehicle
{
    public string Model { get; set; }

    public Vehicle(string model)
    {
        Model = model;
    }
}

public interface IElectric
{
    void Charge();
}

public interface IDiesel
{
    void Refuel();
}

public class ElectricCar : Vehicle, IElectric
{
    public ElectricCar(string model) : base(model) { }

    public void Charge()
    {
        Console.WriteLine($"Электромобиль {Model} заряжается.");
    }
}

public class Truck : Vehicle, IDiesel
{
    public Truck(string model) : base(model) { }

    public void Refuel()
    {
        Console.WriteLine($"Грузовик {Model} заправляется дизельным топливом.");
    }
}

public class Program
{
    public static void Main()
    {
        Vehicle[] vehicles = new Vehicle[]
        {
            new ElectricCar("Tesla Model 3"),
            new Truck("Volvo FH"),
            new ElectricCar("Nissan Leaf"),
            new Truck("Scania R 500")
        };

        List<Truck> dieselTrucks = new List<Truck>();

        foreach (Vehicle vehicle in vehicles)
        {
            if (vehicle is Truck truck)
            {
                dieselTrucks.Add(truck);
            }
        }

        Console.WriteLine("Дизельные машины:");
        foreach (Truck truck in dieselTrucks)
        {
            Console.WriteLine($"- {truck.Model}");
        }
    }
}