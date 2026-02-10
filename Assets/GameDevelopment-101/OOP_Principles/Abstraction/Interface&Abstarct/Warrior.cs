using GameDevelopment_101.OOP_Principles.Abstraction.Interface_Abstarct.Interfaces;

namespace GameDevelopment_101.OOP_Principles.Abstraction.Interface_Abstarct
{
    // Warrior is a humanoid. It can take damage. It also has the additional ability to swim. 

    // The “Can-Do” question tells us we need to use the “ISwimmable” interface.
    
    public class Warrior : Humanoid, ISwimmable
    {
        public override void Attack()
        {
            throw new System.NotImplementedException();
        }

        public override void TakeDamage(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void Swim()
        {
            throw new System.NotImplementedException();
        }
    }
}