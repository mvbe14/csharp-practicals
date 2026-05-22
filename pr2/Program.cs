using System;
using ClimateControlSystem;
using GameDevSystem;

namespace Practice2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("=== ЗАВДАННЯ 1: СИСТЕМА КЛІМАТ-КОНТРОЛЮ ===");

    
            TemperatureSensor sensor = new TemperatureSensor();

            Display display = new Display();
            AirConditioner ac = new AirConditioner();
            SecuritySystem security = new SecuritySystem();

            sensor.TemperatureChanged += display.OnTemperatureChanged;
            sensor.TemperatureChanged += ac.OnTemperatureChanged;
            sensor.TemperatureChanged += security.OnTemperatureChanged;

            Console.WriteLine("\n--- Встановлюємо 22°C ---");
            sensor.Temperature = 22;

            Console.WriteLine("\n--- Встановлюємо 15°C ---");
            sensor.Temperature = 15;

            Console.WriteLine("\n--- Встановлюємо 32°C ---");
            sensor.Temperature = 32;

            Console.WriteLine("\n--- Встановлюємо 45°C (Небезпека!) ---");
            sensor.Temperature = 45;


            Console.WriteLine("\n" + new string('=', 50) + "\n");










            //2


            Console.WriteLine("=== ЗАВДАННЯ 2: GAMEDEV OBSERVER ===");

            Player player = new Player();

            UIHealthBar healthBar = new UIHealthBar();
            SoundSystem sound = new SoundSystem();
            AchievementSystem achievements = new AchievementSystem();
            GameLogger logger = new GameLogger();

            player.Damaged += healthBar.OnPlayerDamaged;
            player.Damaged += sound.OnPlayerDamaged;
            player.Damaged += achievements.OnPlayerDamaged;
            player.Damaged += logger.OnPlayerDamaged;

            Console.WriteLine("\n--- Гравець отримує 35 урону ---");
            player.TakeDamage(35);

            Console.WriteLine("\n--- Гравець отримує 20 урону (HP впаде нижче 50%) ---");
            player.TakeDamage(20);

            Console.WriteLine("\n--- Гравець отримує 30 урону (Критичний стан!) ---");
            player.TakeDamage(30);

            Console.WriteLine("\n--- Гравець отримує 20 урону (Смерть) ---");
            player.TakeDamage(20);

            Console.ReadLine();
        }
    }
}
