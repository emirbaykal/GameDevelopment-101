using System;
using GameDevelopment_101.Design_Patterns.StatePattern.Interface;
using GameDevelopment_101.Design_Patterns.StatePattern.States;
using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.StatePattern
{
    public class PlayerController : MonoBehaviour
    {
        private IState currentState;
        
        //Status
        private bool isGrounded;
        private bool isWalking;
        
        //Components

        public PlayerMovement playerMovement;
        
        private void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            
            currentState = new IdleState();
            currentState.EnterState(this);
        }

        private void Update()
        {
            currentState.UpdateState(this);
        }



        public void ChangeState(IState newState)
        {
            if (newState != null)
                currentState.ExitState(this);
            currentState = newState;
            currentState?.EnterState(this);
        }

        public bool IsWalking()
        {
            return isWalking;
        }

        public bool IsGrounded()
        {
            return isGrounded;
        }


    }
}