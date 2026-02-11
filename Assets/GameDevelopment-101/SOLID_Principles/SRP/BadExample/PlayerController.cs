using System;
using UnityEngine;

namespace GameDevelopment_101.SOLID_Principles.SRP.BadExample
{
    public class PlayerController : MonoBehaviour
    {
        // Readability, debugging, updating code, and teamwork become difficult.

        //Everything is in a single class. 
        
        private void Update()
        {
            throw new NotImplementedException();
        }

        private void HandleInput()
        {
            // Input handling logic
        }

        private void MoveCharacter()
        {
            // Character Movement logic
        }
    }
}