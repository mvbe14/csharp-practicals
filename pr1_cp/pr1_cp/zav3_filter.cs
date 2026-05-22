using System;

// 1. Делегат-предикат (умова)
public delegate bool FilterPredicate(int number);

class Program
{
    static void FilterArray(int[] numbers, FilterPredicate predicate)
    {
        foreach (var num in numbers)
        {
            if (predicate(num))
            {
                Console.Write(num + " ");
            }
        }
        Console.WriteLine();
    }

    static bool IsEven(int n) => n % 2 == 0;
    static bool IsGreaterThanFive(int n) => n > 5;

    static void Main()
    {
        Console.WriteLine("\n--- Завдання 3: Фільтрація списку ---");

        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Console.Write("Парні числа: ");
        FilterArray(array, IsEven);

        Console.Write("Числа > 5: ");
        FilterArray(array, IsGreaterThanFive);

        Console.Write("Непарні числа (Лямбда): ");
        FilterArray(array, n => n % 2 != 0);
    }
}