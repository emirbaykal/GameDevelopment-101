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

### Liskov Substitution
### Interface Segregation
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
