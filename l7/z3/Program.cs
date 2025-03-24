using System;

public delegate void StatusChangedEventHandler(string newStatus);

public class OrderStatusManager
{
    public event StatusChangedEventHandler StatusChanged;

    private string _status;

    public string Status
    {
        get => _status;
        set
        {
            _status = value;
            OnStatusChanged(_status);
        }
    }

    protected virtual void OnStatusChanged(string newStatus)
    {
        StatusChanged?.Invoke(newStatus);
    }
}

public class CustomerNotifier
{
    public void OnStatusChanged(string newStatus)
    {
        Console.WriteLine($"Клиент уведомлен о новом статусе заказа: {newStatus}");
    }
}

public class AdminLogger
{
    public void OnStatusChanged(string newStatus)
    {
        Console.WriteLine($"Запись в лог: статус заказа изменен на {newStatus}");
    }
}

public class Program
{
    public static void Main()
    {
        OrderStatusManager orderStatusManager = new OrderStatusManager();

        CustomerNotifier customerNotifier = new CustomerNotifier();
        AdminLogger adminLogger = new AdminLogger();

        orderStatusManager.StatusChanged += customerNotifier.OnStatusChanged;
        orderStatusManager.StatusChanged += adminLogger.OnStatusChanged;

        orderStatusManager.Status = "Обработан";
        orderStatusManager.Status = "Отправлен";
        orderStatusManager.Status = "Доставлен";
    }
}