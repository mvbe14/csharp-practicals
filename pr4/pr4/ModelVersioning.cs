using System;
using System.Text.Json;

namespace SerializationPractice
{
    public class ModernPlayer
    {
        public string Name { get; set; }
        public int Level { get; set; } = 1;
    }

    public static class ModelVersioning
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Завдання 7: Версійність моделей ---");

            string oldJson = "{ \"Name\": \"Gimli\" }";

            ModernPlayer player = JsonSerializer.Deserialize<ModernPlayer>(oldJson);

            Console.WriteLine("Завантаження старого файлу:");
            Console.WriteLine($"Ім'я: {player.Name}");
            Console.WriteLine($"Рівень: {player.Level}");
        }
    }
}