using System;
using GameDevelopment_101.Design_Patterns.ObjectPooling.Interfaces;
using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.ObjectPooling.Item
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        
        public void OnPulledToPool()
        {
            // Spawn
        }

        public void OnReturnedToPool()
        {
            // Destroy
        }

        private void OnTriggerEnter(Collider other)
        {
            ObjectPooling.instance.ReturnToPool(gameObject);
        }
    }
}