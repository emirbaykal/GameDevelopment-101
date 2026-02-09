using UnityEngine;

namespace GameDevelopment_101.OOP_Principles.Inheritance
{
    public class BaseEnemy : MonoBehaviour
    {
        protected float health;
        protected float speed;

        private void Move()
        {
            // On Move
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
        }
    }
}