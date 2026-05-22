using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SerializationPractice
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double AverageScore { get; set; }
    }

    public static class StudentManager
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Завдання 2: Студенти ---");

            List<Student> students = new List<Student>
            {
                new Student { Name = "Олександр", Age = 20, AverageScore = 4.8 },
                new Student { Name = "Марія", Age = 19, AverageScore = 4.5 },
                new Student { Name = "Дмитро", Age = 21, AverageScore = 3.9 },
                new Student { Name = "Анна", Age = 20, AverageScore = 5.0 },
                new Student { Name = "Влад", Age = 22, AverageScore = 4.2 }
            };

            string path = "students.json";

            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
            Console.WriteLine("Список студентів успішно збережено у students.json");

            string loadedJson = File.ReadAllText(path);
            List<Student> deserializedStudents = JsonSerializer.Deserialize<List<Student>>(loadedJson);

            Console.WriteLine("\nДані після десеріалізації:");
            foreach (var student in deserializedStudents)
            {
                Console.WriteLine($"- {student.Name}, Вік: {student.Age}, Сер. бал: {student.AverageScore}");
            }
        }
    }
}