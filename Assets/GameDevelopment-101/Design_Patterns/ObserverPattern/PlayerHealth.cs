using System;
using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.ObserverPattern
{
    public class PlayerHealth : MonoBehaviour
    {
        public static event Action<int> OnHealthChanged;
        private int health = 100;

        public void TakeDamage(int amount)
        {
            health -= amount;
            OnHealthChanged?.Invoke(health);
        }
    }
}