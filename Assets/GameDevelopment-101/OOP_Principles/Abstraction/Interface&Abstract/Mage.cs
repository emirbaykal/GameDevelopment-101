using GameDevelopment_101.OOP_Principles.Abstraction.Interface_Abstract.BaseClasses;

namespace GameDevelopment_101.OOP_Principles.Abstraction.Interface_Abstract
{
    // The Mage is a humanoid.
    // It can take damage.
    // However, it does not have the ability to swim.
    
    public class Mage : Humanoid
    {
        public override void Attack()
        {
            throw new System.NotImplementedException();
        }
        
        public override void TakeDamage(int amount)
        {
            throw new System.NotImplementedException();
        }
        
    }
}