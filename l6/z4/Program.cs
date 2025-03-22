using System;

public interface IEmailNotifier
{
    void SendNotification(string message);
}

public interface ISmsNotifier
{
    void SendNotification(string message);
}

public class NotificationService : IEmailNotifier, ISmsNotifier
{
    void IEmailNotifier.SendNotification(string message)
    {
        Console.WriteLine($"Отправка уведомления по электронной почте: {message}");
    }

    void ISmsNotifier.SendNotification(string message)
    {
        Console.WriteLine($"Отправка уведомления по SMS: {message}");
    }
}

public class Program
{
    public static void Main()
    {
        NotificationService notificationService = new NotificationService();

        IEmailNotifier emailNotifier = notificationService;
        ISmsNotifier smsNotifier = notificationService;

        emailNotifier.SendNotification("Здравствуйте! Это уведомление по электронной почте.");
        smsNotifier.SendNotification("Здравствуйте! Это уведомление по SMS.");
    }
}