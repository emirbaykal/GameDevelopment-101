using GameDevelopment_101.Design_Patterns.StatePattern.Interface;
using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.StatePattern.States
{
    public class IdleState : IState
    {
        public void EnterState(PlayerController player)
        {
            Debug.Log("Entering IdleState");
        }

        public void UpdateState(PlayerController player)
        {
            if(player.IsWalking() && player.IsGrounded())
                player.ChangeState(new WalkState());
            else if (!player.IsGrounded())
                player.ChangeState(new JumpState());
        }

        public void ExitState(PlayerController player)
        {
            Debug.logger.Log("Exiting IdleState");
        }
    }
}