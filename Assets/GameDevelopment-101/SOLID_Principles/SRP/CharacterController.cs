using System;
using UnityEngine;

namespace GameDevelopment_101.SOLID_Principles.SRP
{
    public class CharacterController : MonoBehaviour
    {
        private InputHandler inputHandler;
        private CharacterMover characterMover;

        private void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            characterMover = GetComponent<CharacterMover>();
        }

        private void Update()
        {
            Vector2 input = inputHandler.GetInput();
            characterMover.Move(input);
        }
    }
}