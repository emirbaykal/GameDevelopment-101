using GameDevelopment_101.OOP_Principles.Abstraction.Interface_Abstarct.Interfaces;
using UnityEngine;

namespace GameDevelopment_101.OOP_Principles.Abstraction.Interface_Abstarct
{
    // Ships can take damage just like the “humanoid” class.
    // But here we need to ask the “Is-A” question.
    // Ships can take damage, but they are not humanoids.
    
    // When using interfaces, we need to ask the “Can-Do” question. 
    public class Ship : MonoBehaviour, IDamageable, ISwimmable
    {
        public void TakeDamage(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void Swim()
        {
            throw new System.NotImplementedException();
        }
    }
}