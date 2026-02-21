# GameDevelopment-101 (Work in progress 02/11/2026)

## Object Oriented Programming Principles
   * [Encapsulation](Assets/GameDevelopment-101/OOP_Principles/Encapsulation)
   * [Inheritance](Assets/GameDevelopment-101/OOP_Principles/Inheritance)
   * [Polymorphism](Assets/GameDevelopment-101/OOP_Principles/Polymorphism)
   * Abstraction
     *  [Should I use abstraction? Or virtual?](Assets/GameDevelopment-101/OOP_Principles/Abstraction/Abstract&Virtual)
     *  [Interface vs Abstract](Assets/GameDevelopment-101/OOP_Principles/Abstraction/Interface&Abstract)
## SOLID Principles
### [Single Responsibility Principle (SRP)](Assets/GameDevelopment-101/SOLID_Principles/SRP)

In short, each class should perform a single task. In the example, I proceeded with a Character. I emphasized that Input, Movement, and updates should be in separate classes, not in a single controller.
      
  * The most important reasons for using this method are:
    - Easy readability
    - Ease of updating the code.
    - Reduced dependency in teamwork.
    - Easy debugging
### [Open Closed Principle](Assets/GameDevelopment-101/SOLID_Principles/OpenClose)

Actually, this principle is similar to what I explained with polymorphism and abstraction. 

It's a system where we can increase the number of enemies as we wish with minimal or even zero changes to the BaseClasses, as in the simple enemy example I gave.

The important thing here is to think about and design our main functions and classes from the outset in a way that is **open to development but closed to change**.

### [Liskov Substitution](Assets/GameDevelopment-101/SOLID_Principles/LiskovSubstitution)

The reason we use this principle is to increase the code's readability and reliability. 

When developing games, we know that many things can change. The method we use here minimizes the impact of dependencies, so when system changes are required, it doesn't complicate our work. 

Without LSP, we might trigger unnecessary functions that could be overlooked. This leads to errors.

The interface structure we use prevents this.

### [Interface Segregation](Assets/GameDevelopment-101/SOLID_Principles/InterfaceSegregation)

At first, we might think of this principle as interface usage, but it actually differs from normal interface usage.

When we look at it, Player, Enemy, and Villager are all characters. We could have created a single interface for them, as in the example below.

Bad Example
```
public interface ICharacter {
    void Move();
    void Attack();
    void CastMagic();
    void Trade();
}
```
### What happens if we define it like in the example above? Why shouldn't we do this? 

For example, we have a peasant character that only has the Trade feature; it cannot move or attack. When we use the above method, we cannot leave the Move and Attack functions empty for it.

Instead, the following example would be cleaner and more understandable.

```
public interface IMovable { void Move(); }
public interface IAttackable { void Attack(); }
public interface IMagicUser { void CastMagic(); }
public interface ITrader { void Trade(); }
```
As a result, our classes will appear as follows. 
```
public class Villager : MonoBehaviour, ITrader
{
}
public class Player : MonoBehaviour, IMovable, IAttackable
{
}
public class Enemy : MonoBehaviour, IAttackable, IMovable
{
}
```
### [Dependency Inversion](Assets/GameDevelopment-101/SOLID_Principles/DependencyInversion)

The fundamental principle here is that **“High-level classes should not depend on lower-level classes. Both should depend on Abstract classes or Interfaces.”**

#### What do I mean?

I want to explain how not to do it by modifying the code examples I've created.

```
public class Soldier : MonoBehaviour {
    private M4Rifle weapon; //Here the upper class is connected to the lower class

    void Start() {
        weapon = new M4_Rifle();
    }

    void Shoot() {
        weapon.Fire();
    }
}
```
What we need to do is manage the “M4Rifle” and ‘Soldier’ classes with an “IWeapon” interface.

Like this: 

Weapon Interface :
```
public interface IWeapon
{
  void Fire();
}
```
Soldier Class :
```
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
```
NOTE:

“M4Rifle” and ‘Soldier’ do not know each other. They only communicate through the “IWeapon” interface. 

And when we want to change the weapon, or add new weapons, or make significant changes to the “M4Rifle” class, we won't need to make changes within the ‘Soldier’ class again. The system will work the same way. Like the [“Open/Close”](Assets/GameDevelopment-101/SOLID_Principles/OpenClose) principle. 


## Design Patterns
### [State Machine](Assets/GameDevelopment-101/Design_Patterns/StatePattern)
### [Observer](Assets/GameDevelopment-101/Design_Patterns/ObserverPattern)
### [Command](Assets/GameDevelopment-101/Design_Patterns/CommandPattern)
### [Model-View-Presenter](Assets/GameDevelopment-101/Design_Patterns/ModelViewPresenter)
### [Object Pool](Assets/GameDevelopment-101/Design_Patterns/ObjectPooling)
### [Strategy](Assets/GameDevelopment-101/Design_Patterns/StrategyPattern)
### [Singleton](Assets/GameDevelopment-101/Design_Patterns/Singelton)
