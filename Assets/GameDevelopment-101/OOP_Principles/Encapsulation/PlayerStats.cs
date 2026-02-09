using UnityEngine;

namespace GameDevelopment_101.OOP_Principles.Encapsulation
{
    public class PlayerStats : MonoBehaviour
    {
        // We are making the health variable changeable only from within the class.
            
        // When we want to deal damage, we can use the TakeDamage() function.
            
        // This method allows us to properly manage the Health variable in a large project.

        [SerializeField] private int health = 100;
        public int GetCurrentHealth() => health;
        
        
        // it can also be used this way
        // public int Health { get; private set; }
        
        public void TakeDamage(int damageAmount)
        {
            if(health <= 0) return;
                
            health -= damageAmount;
                
            if (health <= 0) health = 0;

            // PlayHurtSound();

            if (health == 0)
            {
                // Die();
            }
        }
    }
}