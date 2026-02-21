using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.ObjectPooling
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawnPoint;
        
        public void Shoot()
        {
            ObjectPooling.instance.GetItemFromPool(bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            
        }
    }
}