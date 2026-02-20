using GameDevelopment_101.Design_Patterns.CommandPattern.Interface;
using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.CommandPattern.Commands
{
    public class MoveCommand : ICommand
    {
        private Vector3 moveVector;
        private Transform playerTransform;
    
        // Inside the SendMoveCommand function in the PlayerController, 
        // we create a MoveCommand object and update its values.
        public MoveCommand(Transform player, Vector3 moveVector)
        {
            playerTransform = player;
            this.moveVector = moveVector;
        }
        
        public void Execute()
        {
            playerTransform.position += moveVector;
        }

        public void Undo()
        {
            playerTransform.position -= moveVector;
        }
    }
}