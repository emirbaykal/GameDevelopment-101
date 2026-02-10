using UnityEngine;

namespace GameDevelopment_101.OOP_Principles.Abstraction.Abstract_Virtual
{
    public abstract class Weapon : MonoBehaviour
    {
        public string WeaponName;
        
        // In the functions defined in the abstract class, no definition is made within the base class.
        // !!! Just like interface functions.
        // !!! I will explain the difference between abstract and interface separately.
        // Child classes must override abstract functions.
        // This is both a security measure and can be used for classes that are not for general use.
        public abstract void Fire();
        
        
        // In virtual functions, we need to implement the function within the BaseClass.
        // Child classes can override this function if they wish.
        public virtual void FireSound()
        {
            //Play base fire sound !!
        } 
    }
}