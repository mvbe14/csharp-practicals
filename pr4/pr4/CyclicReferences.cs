using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializationPractice
{
    public class Author
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }

    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
    }

    public static class CyclicReferences
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Завдання 3: Циклічні посилання ---");

            Author author = new Author { Name = "Тарас Шевченко" };
            Book book1 = new Book { Title = "Кобзар", Author = author };
            Book book2 = new Book { Title = "Гайдамаки", Author = author };

            author.Books.Add(book1);
            author.Books.Add(book2);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            try
            {
                string json = JsonSerializer.Serialize(author, options);
                Console.WriteLine("Успішна серіалізація з виправленням циклів:");
                Console.WriteLine(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка серіалізації: {ex.Message}");
            }
        }
    }
}