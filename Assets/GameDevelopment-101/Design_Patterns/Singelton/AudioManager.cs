using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.Singelton
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        public void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void PlaySound()
        {
            // play sound
        }

        public void StopSound()
        {
            // stop sound
        }
    }
}