using System;
using System.Collections.Generic;
using System.Text.Json;

namespace SerializationPractice
{
    public class PlayerWithInventory
    {
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
    }

    public class Inventory
    {
        public List<string> Items { get; set; } = new List<string>();
    }

    public static class NestedObjects
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Завдання 6: Вкладені об'єкти ---");

            string corruptedJson = "{ \"Name\": \"Legolas\", \"Inventory\": null }";

            PlayerWithInventory player = JsonSerializer.Deserialize<PlayerWithInventory>(corruptedJson);

            Console.WriteLine($"Гравець: {player.Name}");
            Console.WriteLine($"Чи інвентар null одразу після десеріалізації? -> {player.Inventory == null}");

            player.Inventory ??= new Inventory();
            player.Inventory.Items.Add("Старий дерев'яний лук");

            Console.WriteLine("Інвентар безпечно відновлено. Вміст:");
            foreach (var item in player.Inventory.Items)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
}