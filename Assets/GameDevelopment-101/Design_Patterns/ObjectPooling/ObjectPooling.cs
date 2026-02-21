using System;
using System.Collections.Generic;
using GameDevelopment_101.Design_Patterns.ObjectPooling.Interfaces;
using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.ObjectPooling
{
    public class ObjectPooling : MonoBehaviour
    {
        public static ObjectPooling instance;
        
        // For Single item pooling
        [SerializeField] private GameObject itemPrefab;
        
        private List<GameObject> pool = new List<GameObject>();

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);
        }

        public GameObject GetItemFromPool(Vector3 spawnPosition, Quaternion spawnRotation)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].activeInHierarchy)
                {
                    var item = pool[i];
                    item.SetActive(true);
                    // Update Transform
                    item.transform.position = spawnPosition;
                    item.transform.rotation = spawnRotation;
                    
                    IPoolable poolable = item.GetComponent<IPoolable>();
                    
                    poolable?.OnPulledToPool();

                    return item;
                }
            }

            GameObject newItem = Instantiate(itemPrefab);
            newItem.SetActive(true);
            pool.Add(newItem);
            
            return newItem;
        }

        public void ReturnToPool(GameObject item)
        {
            if (pool.Contains(item))
            {
                item.SetActive(false);
                //Reset Transform
                item.transform.position = Vector3.zero;
                item.transform.rotation = Quaternion.identity;
                
                IPoolable poolable = item.GetComponent<IPoolable>();
                
                poolable?.OnReturnedToPool();
            }
            else
                Debug.LogWarning("Pool not found this item!!!");
        }
    }
}