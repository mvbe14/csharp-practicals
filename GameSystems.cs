using System;

namespace GameDevSystem
{
    public class UIHealthBar
    {
        public void OnPlayerDamaged(object sender, DamageEventArgs e)
        {
            Console.WriteLine($"[UI HealthBar]: HP оновлено -> {e.CurrentHP}/{100}");
        }
    }

    public class SoundSystem
    {
        public void OnPlayerDamaged(object sender, DamageEventArgs e)
        {
            Console.WriteLine("[🔊 Звук]: *Ай!* (Звук поранення)");

            if (e.CurrentHP <= 20 && e.CurrentHP > 0)
            {
                Console.WriteLine("[🔊 Звук]: *Ту-дум... Ту-дум...* (Критичний стан!)");
            }
        }
    }

    public class AchievementSystem
    {
        private bool _hasHalfHealthAchievement = false;
        private bool _hasFirstDeathAchievement = false;

        public void OnPlayerDamaged(object sender, DamageEventArgs e)
        {
            if (e.CurrentHP <= 50 && !_hasHalfHealthAchievement)
            {
                _hasHalfHealthAchievement = true;
                Console.WriteLine("[🏆 Досягнення]: Отримано ачівку 'Half Health'!");
            }

            if (e.CurrentHP <= 0 && !_hasFirstDeathAchievement)
            {
                _hasFirstDeathAchievement = true;
                Console.WriteLine("[🏆 Досягнення]: Отримано ачівку 'First Death'!");
            }
        }
    }

    public class GameLogger
    {
        public void OnPlayerDamaged(object sender, DamageEventArgs e)
        {
            Console.WriteLine($"[💾 Лог]: Отримано {e.DamageAmount} урону. Залишок HP: {e.CurrentHP}.");
        }
    }
}