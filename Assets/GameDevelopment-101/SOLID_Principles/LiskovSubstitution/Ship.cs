using GameDevelopment_101.SOLID_Principles.LiskovSubstitution.Interfaces;
using UnityEngine;

namespace GameDevelopment_101.SOLID_Principles.LiskovSubstitution
{
    public class Ship : Unit, ISwimmable
    {
        public void Swim()
        {
            Debug.Log("Ship Swim");
        }
    }
}