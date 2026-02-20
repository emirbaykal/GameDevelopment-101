using GameDevelopment_101.Design_Patterns.CommandPattern.Commands;
using GameDevelopment_101.Design_Patterns.CommandPattern.Interface;
using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.CommandPattern
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private CommandInvoker commandInvoker;
        private float stepSize = 1.0f;
        
        // Button action
        public void MoveUp() => SendMoveCommand(Vector3.up);
        public void MoveDown() => SendMoveCommand(Vector3.down);
        public void MoveLeft() => SendMoveCommand(Vector3.left);
        public void MoveRight() => SendMoveCommand(Vector3.right);

        private void SendMoveCommand(Vector3 direction)
        {
            ICommand move = new MoveCommand(playerTransform, direction * stepSize);
            commandInvoker.ExecuteCommand(move);
        }
    }
}