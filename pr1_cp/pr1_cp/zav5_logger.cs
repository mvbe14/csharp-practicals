using System;

public class Logger
{
    public Action<string> LogHandler;

    public void Log(string message)
    {
        LogHandler?.Invoke(message);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("\n--- Завдання 5: Логування ---");

        Logger logger = new Logger();

        logger.LogHandler = msg => Console.WriteLine($"[Оригінал]: {msg}");
        logger.Log("Тестове повідомлення №1");

        logger.LogHandler = msg => Console.WriteLine($"[UPPERCASE]: {msg.ToUpper()}");
        logger.Log("Тестове повідомлення №2");
    }
}