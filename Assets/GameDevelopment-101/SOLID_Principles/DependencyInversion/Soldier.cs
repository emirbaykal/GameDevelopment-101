using GameDevelopment_101.SOLID_Principles.DependencyInversion.Interfaces;
using UnityEngine;

namespace GameDevelopment_101.SOLID_Principles.DependencyInversion
{
    public class Soldier : MonoBehaviour
    {
        private IWeapon weapon;

        public void SetWeapon(IWeapon newWeapon)
        {
            weapon = newWeapon;
        }

        private void Shoot()
        {
            weapon?.Fire();
        }
    }
}