using System;

public class TemperatureSensor
{
    public event EventHandler<double> TemperatureChanged;

    private double _temperature;

    public double Temperature
    {
        get => _temperature;
        set
        {
            _temperature = value;
            OnTemperatureChanged(_temperature);
        }
    }

    protected virtual void OnTemperatureChanged(double newTemperature)
    {
        TemperatureChanged?.Invoke(this, newTemperature);
    }
}

public class TemperatureMonitor
{
    private readonly TemperatureSensor _sensor;

    public TemperatureMonitor(TemperatureSensor sensor)
    {
        _sensor = sensor;
        _sensor.TemperatureChanged += CoolingSystem.OnTemperatureChanged;
        _sensor.TemperatureChanged += AlarmSystem.OnTemperatureChanged;
    }
}

public class CoolingSystem
{
    public static void OnTemperatureChanged(object sender, double newTemperature)
    {
        if (newTemperature > 25)
        {
            Console.WriteLine("Включение кондиционера.");
        }
    }
}

public class AlarmSystem
{
    public static void OnTemperatureChanged(object sender, double newTemperature)
    {
        if (newTemperature > 30)
        {
            Console.WriteLine("Предупреждение: Перегрев!");
        }
    }
}

public class Program
{
    public static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();
        TemperatureMonitor monitor = new TemperatureMonitor(sensor);

        sensor.Temperature = 28;
        sensor.Temperature = 32;
        sensor.Temperature = 22;
    }
}