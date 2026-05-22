using System;

namespace GameDevSystem
{
    public class DamageEventArgs : EventArgs
    {
        public int DamageAmount { get; }
        public int CurrentHP { get; }

        public DamageEventArgs(int damageAmount, int currentHP)
        {
            DamageAmount = damageAmount;
            CurrentHP = currentHP;
        }
    }
}