using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializationPractice
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Dog), "dog")]
    [JsonDerivedType(typeof(Cat), "cat")]
    public abstract class Animal
    {
        public string Name { get; set; }
    }

    public class Dog : Animal
    {
        public int BarkVolume { get; set; }
    }

    public class Cat : Animal
    {
        public int Lives { get; set; }
    }

    public static class PolymorphicAnimals
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Завдання 5: Поліморфізм ---");

            List<Animal> zoo = new List<Animal>
            {
                new Dog { Name = "Сірко", BarkVolume = 85 },
                new Cat { Name = "Мурчик", Lives = 9 }
            };

            var options = new JsonSerializerOptions { WriteIndented = true };

            string json = JsonSerializer.Serialize(zoo, options);
            Console.WriteLine("Поліморфний JSON:");
            Console.WriteLine(json);

            List<Animal> restoredZoo = JsonSerializer.Deserialize<List<Animal>>(json, options);

            Console.WriteLine("\nОб'єкти після десеріалізації:");
            foreach (var animal in restoredZoo)
            {
                if (animal is Dog dog)
                    Console.WriteLine($"[Собака] {dog.Name}, Гучність гавкоту: {dog.BarkVolume}");
                else if (animal is Cat cat)
                    Console.WriteLine($"[Кіт] {cat.Name}, Залишилось життів: {cat.Lives}");
            }
        }
    }
}