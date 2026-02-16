using GameDevelopment_101.Design_Patterns.StatePattern.Interface;
using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.StatePattern.States
{
    public class JumpState : IState
    {
        public void EnterState(PlayerController player)
        {
            Debug.Log("Entering WalkState");
        }

        public void UpdateState(PlayerController player)
        {
            player.playerMovement.HandleJumping();
            
            if(player.IsWalking() && player.IsGrounded())
                player.ChangeState(new WalkState());
            else if(!player.IsWalking() && player.IsGrounded())
                player.ChangeState(new IdleState());
        }

        public void ExitState(PlayerController player)
        {
            Debug.Log("Exiting WalkState");
        }
    }
}