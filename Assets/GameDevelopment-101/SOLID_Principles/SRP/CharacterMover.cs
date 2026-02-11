using UnityEngine;

namespace GameDevelopment_101.SOLID_Principles.SRP
{
    public class CharacterMover : MonoBehaviour
    {
        public void Move(Vector2 input)
        {
            // Movement logic
            transform.Translate(input * Time.deltaTime);
        }
    }
}