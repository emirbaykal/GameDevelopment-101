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

### Interface Segregation

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

For example, we have a peasant character that only has the trace feature; it cannot move or attack. When we use the above method, we cannot leave the Move and Attack functions empty for it.

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

### Dependency Inversion

## Design Patterns
### Command
### Composite
### Decorator
### Model-View-Presenter
### Object Pool
### Observer
### Singleton
### State Machine
### Strategy
