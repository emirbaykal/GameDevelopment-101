using GameDevelopment_101.SOLID_Principles.InterfaceSegregation.Interfaces;
using UnityEngine;

namespace GameDevelopment_101.SOLID_Principles.InterfaceSegregation
{
    public class Enemy : MonoBehaviour, IAttackable, IMovable
    {
    }
}