namespace GameDevelopment_101.OOP_Principles.Abstraction.Abstract_Virtual
{
    public class Pistol : Weapon
    {
        public override void Fire()
        {
            // Fire pistol 
        }

        // If we want, we can choose not to call this function.
        // The code we provided in the base class will run.

        public override void FireSound()
        {
            //Play pistol sound.
        }
    }
}