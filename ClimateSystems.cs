using System;

namespace ClimateControlSystem
{
    public class Display
    {
        public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            Console.WriteLine($"[Екран]: Поточна температура: {e.Temperature}°C");
        }
    }

    public class AirConditioner
    {
        public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            if (e.Temperature < 17)
                Console.WriteLine("[Кондиціонер]: Увімкнено ОБІГРІВ 🔥");
            else if (e.Temperature >= 17 && e.Temperature <= 25)
                Console.WriteLine("[Кондиціонер]: Вимкнений 💤");
            else
                Console.WriteLine("[Кондиціонер]: Увімкнено ОХОЛОДЖЕННЯ ❄️");
        }
    }

    public class SecuritySystem
    {
        public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            if (e.Temperature > 40)
                Console.WriteLine("[🚨 Безпека]: УВАГА! Перегрів системи! Терміново перевірте обладнання!");
            else if (e.Temperature < 5)
                Console.WriteLine("[🚨 Безпека]: УВАГА! Ризик замерзання систем труб!");
        }
    }
}