using System;
using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.ObserverPattern
{
    public class HealtUI : MonoBehaviour
    {
        private void OnEnable()
        {
            PlayerHealth.OnHealthChanged += UpdateUI;
        }

        private void UpdateUI(int healthAmount)
        {
            Debug.Log("Current health: " + healthAmount);
        }

        private void OnDestroy()
        {
            PlayerHealth.OnHealthChanged -= UpdateUI;
        }
    }
}