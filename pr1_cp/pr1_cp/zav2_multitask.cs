using System;

public delegate void NotificationHandler(string message);

class Program
{
    static void SendEmail(string message) => Console.WriteLine($"Email sent: [{message}]");
    static void SendSMS(string message) => Console.WriteLine($"SMS sent: [{message}]");

    static void Main()
    {
        Console.WriteLine("\n--- Завдання 2: Мультикастинг ---");

        NotificationHandler notifier = SendEmail;

        notifier += SendSMS;

        notifier("Привіт! Це тестове сповіщення.");

    }
}