using GameDevelopment_101.Design_Patterns.StatePattern.Interface;
using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.StatePattern.States
{
    public class WalkState : IState
    {
        public void EnterState(PlayerController player)
        {
            Debug.Log("Entering WalkState");
        }

        public void UpdateState(PlayerController player)
        {
            player.playerMovement.HandleMovement();
            
            if(!player.IsWalking() || !player.IsGrounded())
                player.ChangeState(new IdleState());
            else if(!player.IsGrounded())
                player.ChangeState(new JumpState());
        }

        public void ExitState(PlayerController player)
        {
            Debug.logger.Log("Exiting WalkState");
        }
    }
}