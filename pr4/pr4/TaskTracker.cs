using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SerializationPractice
{
    public class TaskItem
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }

    public static class TaskTracker
    {
        private const string FileName = "tasks.json";
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions { WriteIndented = true };

        public static void Run()
        {
            Console.WriteLine("\n--- Завдання 1: Task Tracker ---");
            List<TaskItem> tasks = LoadTasks();

            while (true)
            {
                Console.WriteLine("\n1. Додати задачу | 2. Змінити статус | 3. Переглянути задачі | 4. Вийти");
                Console.Write("Виберіть дію: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Введіть назву задачі: ");
                    string title = Console.ReadLine();
                    tasks.Add(new TaskItem { Title = title, IsCompleted = false });
                    Console.WriteLine("Задача додана!");
                }
                else if (choice == "2")
                {
                    ShowTasks(tasks);
                    if (tasks.Count == 0) continue;

                    Console.Write("Введіть номер задачі для зміни статусу: ");
                    if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
                    {
                        tasks[index - 1].IsCompleted = !tasks[index - 1].IsCompleted;
                        Console.WriteLine("Статус змінено!");
                    }
                    else Console.WriteLine("Невірний номер.");
                }
                else if (choice == "3")
                {
                    ShowTasks(tasks);
                }
                else if (choice == "4")
                {
                    SaveTasks(tasks);
                    Console.WriteLine("Стан збережено. Вихід з Task Tracker.");
                    break;
                }
            }
        }

        private static List<TaskItem> LoadTasks()
        {
            if (!File.Exists(FileName)) return new List<TaskItem>();

            try
            {
                string json = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
            catch
            {
                return new List<TaskItem>();
            }
        }

        private static void SaveTasks(List<TaskItem> tasks)
        {
            string json = JsonSerializer.Serialize(tasks, Options);
            File.WriteAllText(FileName, json);
        }

        private static void ShowTasks(List<TaskItem> tasks)
        {
            Console.WriteLine("\nСписок задач:");
            if (tasks.Count == 0) Console.WriteLine("(порожньо)");
            for (int i = 0; i < tasks.Count; i++)
            {
                string status = tasks[i].IsCompleted ? "[X]" : "[ ]";
                Console.WriteLine($"{i + 1}. {status} {tasks[i].Title}");
            }
        }
    }
}