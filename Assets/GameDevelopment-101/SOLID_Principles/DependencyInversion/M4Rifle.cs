using GameDevelopment_101.SOLID_Principles.DependencyInversion.Interfaces;
using UnityEngine;

namespace GameDevelopment_101.SOLID_Principles.DependencyInversion
{
    public class M4Rifle : MonoBehaviour, IWeapon
    {
        public void Fire()
        {
            Debug.Log("M4Rifle Fire");
        }
    }
}