using System;
using System.Text.Json;

namespace SerializationPractice
{
    public static class ErrorHandling
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Завдання 8: Обробка помилок десеріалізації ---");

            string brokenJson = "{ \"Name\": \"Arthas\", \"Age\": broken_number ";

            try
            {
                Student student = JsonSerializer.Deserialize<Student>(brokenJson);
                Console.WriteLine($"Студент: {student.Name}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine("[⚠️ Помилка!] Файл збереження пошкоджено або має неправильний формат.");
                Console.WriteLine($"Деталі для розробника: {ex.Message}");

                Console.WriteLine("\nСтворюємо новий безпечний профіль...");
                Student defaultStudent = new Student { Name = "Новий користувач", Age = 18, AverageScore = 4.0 };
                Console.WriteLine($"Створено тимчасовий профіль: {defaultStudent.Name}");
            }
        }
    }
}