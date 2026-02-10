using GameDevelopment_101.OOP_Principles.Abstraction.Interface_Abstarct.Interfaces;
using UnityEngine;

namespace GameDevelopment_101.OOP_Principles.Abstraction.Interface_Abstarct
{
    // Humanoid is a base class. Our enemies will be derived from this class.
    
    // However, we do not add interfaces to the base class. 
    
    // Because my characters can perform different actions, they can all take damage,
    // but they can't all swim.
    
    public abstract class Humanoid : MonoBehaviour, IDamageable
    {
        public abstract void Attack();

        public abstract void TakeDamage(int amount);
    }
}