using System;

namespace GameDevSystem
{
    public class Player
    {
        public int MaxHP { get; } = 100;
        public int CurrentHP { get; private set; }

        public event EventHandler<DamageEventArgs> Damaged;

        public Player()
        {
            CurrentHP = MaxHP;
        }

        public void TakeDamage(int amount)
        {
            if (CurrentHP <= 0) return;

            CurrentHP -= amount;
            if (CurrentHP < 0) CurrentHP = 0;

            OnDamaged(new DamageEventArgs(amount, CurrentHP));
        }

        protected virtual void OnDamaged(DamageEventArgs e)
        {
            Damaged?.Invoke(this, e);
        }
    }
}
