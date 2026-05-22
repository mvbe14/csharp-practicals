using System;

public delegate bool Validator(string text);

class Program
{
    static Validator GetValidator(int minLength)
    {
        return text => text != null && text.Length >= minLength;
    }

    static void Main()
    {
        Console.WriteLine("\n--- Завдання 6: Валідатор тексту ---");

        Validator passwordValidator = GetValidator(8);
        Validator loginValidator = GetValidator(3);

        string testLogin = "Jo";
        string testPass = "supersecret123";

        Console.WriteLine($"Чи валідний логін '{testLogin}'? {loginValidator(testLogin)}");
        Console.WriteLine($"Чи валідний пароль? {passwordValidator(testPass)}");

        string correctLogin = "JohnDoe";
        Console.WriteLine($"Чи валідний логін '{correctLogin}'? {loginValidator(correctLogin)}");
    }
}