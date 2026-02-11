using UnityEngine;

namespace GameDevelopment_101.SOLID_Principles.SRP
{
    public class InputHandler
    {
        public Vector2 GetInput()
        {
            // Input handling logic
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}