using UnityEngine;
using UnityEngine.VFX;

namespace GameDevelopment_101.Design_Patterns.ObserverPattern.BadExample
{
    public class Player : MonoBehaviour
    {
        public int health = 100;
        
        public HealtUI healtUI;

        public void TakeDamage(int amount)
        {
            health -= amount;
            
            //healtUI.UpdateUI(health);
        }
    }
}