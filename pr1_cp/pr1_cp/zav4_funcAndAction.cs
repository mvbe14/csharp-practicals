using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("\n--- Завдання 4: Стандартні делегати (Func, Predicate) ---");

        Func<double, double, double> calc = (x, y) => x + y;
        Console.WriteLine($"Func Додавання: {calc(12, 4)}");

        calc = (x, y) => x * y;
        Console.WriteLine($"Func Множення: {calc(12, 4)}");


        List<string> students = new List<string> { "Олексій", "Марія", "Олена", "Богдан", "Олег" };

        List<string> filteredStudents = students.FindAll(name => name.StartsWith("О"));

        Console.WriteLine("Студенти на літеру 'О':");
        foreach (var student in filteredStudents)
        {
            Console.WriteLine($"- {student}");
        }
    }
}