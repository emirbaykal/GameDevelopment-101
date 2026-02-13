using GameDevelopment_101.SOLID_Principles.LiskovSubstitution.Interfaces;
using UnityEngine;

namespace GameDevelopment_101.SOLID_Principles.LiskovSubstitution
{
    public class Soldier : Unit, IMovable
    {
        public void Move()
        {
            Debug.Log("Move Soldier");
        }
    }
}