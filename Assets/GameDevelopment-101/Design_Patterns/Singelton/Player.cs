using System;
using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.Singelton
{
    public class Player : MonoBehaviour
    {
        private void Start()
        {
            AudioManager.Instance.PlaySound();
        }

        private void OnDestroy()
        {
            AudioManager.Instance.StopSound();
        }
    }
}