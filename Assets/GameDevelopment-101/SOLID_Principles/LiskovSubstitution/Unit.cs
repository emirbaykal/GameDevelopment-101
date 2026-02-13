using System.Collections.Generic;
using GameDevelopment_101.SOLID_Principles.LiskovSubstitution.Interfaces;
using UnityEngine;

namespace GameDevelopment_101.SOLID_Principles.LiskovSubstitution
{
    public class MainCaller
    {
        static void Main(string[] args)
        {
            List<Unit> allUnits = new List<Unit>();
            foreach (var unit in allUnits)
            {
                // For Move
                if (unit is IMovable movableUnit)
                {
                    movableUnit.Move();
                }
                // For Swim
                if (unit is ISwimmable swimmableUnit)
                {
                    swimmableUnit.Swim();
                }
            }
        }
    }
    
    public class Unit : MonoBehaviour
    {
        public int health;
        public string unitName;
    }
}