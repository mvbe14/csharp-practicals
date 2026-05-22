using System;

namespace SerializationPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("====== ПРАКТИЧНА РОБОТА №4 ======");
            Console.WriteLine("1. Запустити інтерактивний Task Tracker (Завдання 1)");
            Console.WriteLine("2. Запустити демонстрацію решта тестів серіалізації (Завдання 2-8)");
            Console.Write("\nВиберіть режим: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                TaskTracker.Run();
            }
            else if (choice == "2")
            {
                StudentManager.Run();
                CyclicReferences.Run();
                OrderSystem.Run();
                PolymorphicAnimals.Run();
                NestedObjects.Run();
                ModelVersioning.Run();
                ErrorHandling.Run();
            }
            else
            {
                Console.WriteLine("Невірний вибір. Завершення роботи.");
            }

            Console.WriteLine("\nПрактична робота виконана. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}