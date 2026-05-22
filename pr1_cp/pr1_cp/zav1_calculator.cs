using System;

namespace DelegatingPractice
{
    public delegate double MathOperation(double a, double b);

    class Program
    {
        static double Add(double x, double y) => x + y;
        static double Subtract(double x, double y) => x - y;
        static double Multiply(double x, double y) => x * y;
        static double Divide(double x, double y)
        {
            if (y == 0) throw new DivideByZeroException("Ділення на нуль!");
            return x / y;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- Завдання 1: Калькулятор ---");

            MathOperation operation;

            operation = Add;
            Console.WriteLine($"Додавання (10 + 5): {operation(10, 5)}");

            operation = Subtract;
            Console.WriteLine($"Віднімання (10 - 5): {operation(10, 5)}");

            operation = Multiply;
            Console.WriteLine($"Множення (10 * 5): {operation(10, 5)}");

            operation = Divide;
            Console.WriteLine($"Ділення (10 / 5): {operation(10, 5)}");
        }
    }
}