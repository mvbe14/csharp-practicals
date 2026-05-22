using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializationPractice
{
    public enum OrderStatus { Pending, Processing, Completed }

    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
    }

    public static class OrderSystem
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Завдання 4: Робота з Enum ---");

            Order order = new Order { Id = 1042, Status = OrderStatus.Processing };

            var options = new JsonSerializerOptions { WriteIndented = true };
            options.Converters.Add(new JsonStringEnumConverter());

            string json = JsonSerializer.Serialize(order, options);
            Console.WriteLine("Order у форматі JSON (Enum як text):");
            Console.WriteLine(json);

            Order deserializedOrder = JsonSerializer.Deserialize<Order>(json, options);
            Console.WriteLine($"Десеріалізовано замовлення #{deserializedOrder.Id}. Статус: {deserializedOrder.Status}");
        }
    }
}