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

The structure we call Observer is actually the use of Action events that we use in Unity. But I wonder how this works in the background.

Yes, I define an action, but when I Invoke it, how do other classes know about it?

Technically, an Action is an object that is derived from a special class called MulticastDelegate in the background.

## What is happening in RAM? 

  ### Action Is an Object and Keeps a List

When you define something like
public static event Action<int> OnHealthChanged;
C# actually creates an Invocation List in the background. This list is like a guide that stores the memory addresses (pointers) of functions.

  ### What Happens During the += (Subscribe) Operation?

When you write OnHealthChanged += UpdateUI;:

In the background, the Delegate.Combine method runs.
The memory address of the UpdateUI function and the object it belongs to (target) are added to the list inside the Action object.

Technical Detail: Delegates are immutable structures. This means when you use +=, the old list is not modified. Instead, a completely new list object is created with the old list plus the new function.

  ### What Happens When Invoke() Is Called?

  * When you write OnHealthChanged?.Invoke(10);, these steps happen:
  * Null Check: With the ? operator, the system checks if the list is empty or not.
  * Loop: In the background, a for or foreach loop starts over the Invocation List.
  * Call One by One: Each function address in the list is visited in order. The processor jumps to that address, runs the function with the parameter (in our example, 10), and then returns.
  * Synchronous Execution: This is very important; the Invoke operation is not asynchronous. This means the second function will not start until the first function finishes. If one of the subscribers does a heavy operation, the class that calls Invoke must wait until it finishes.


PlayerHealth :

    public class PlayerHealth : MonoBehaviour
    {
        public static event Action<int> OnHealthChanged;
        private int health = 100;

        public void TakeDamage(int amount)
        {
            health -= amount;
            OnHealthChanged?.Invoke(health);
        }
    }

We subscribe to the action we defined from inside HealthUI, and when it is invoked, the function we subscribed there is triggered.

HealthUI:

    public class HealtUI : MonoBehaviour
    {
        private void OnEnable()
        {
            PlayerHealth.OnHealthChanged += UpdateUI;
        }

        private void UpdateUI(int healthAmount)
        {
            Debug.Log("Current health: " + healthAmount);
        }

        private void OnDestroy()
        {
            PlayerHealth.OnHealthChanged -= UpdateUI;
        }
    }

### [Command](Assets/GameDevelopment-101/Design_Patterns/CommandPattern)

Why Do We Use It?

  * Undo / Redo: Since every action is an object, we can store them in a Stack and reverse them when needed.
  * Action History (Logging): We can keep all the player’s actions in a list and later build a Replay system to watch them again.
  * Extensibility: Adding a new command (for example a jump command) means writing a new class without breaking the existing code.
  * Flexibility: It makes it very easy to change key bindings dynamically.

In my example, I will use the undo system that is commonly used in mobile games.

First, it is important to understand the Stack logic that we will use with the command type here. If you do not know it, I recommend researching it first.

ICommand :

    public interface ICommand
    {
        public void Execute();
        public void Undo();
    }

The MoveCommand we use for the move action will be triggered when the Player creates it.

    public class MoveCommand : ICommand
    {
        private Vector3 moveVector;
        private Transform playerTransform;
    
        // Inside the SendMoveCommand function in the PlayerController, 
        // we create a MoveCommand object and update its values.
        public MoveCommand(Transform player, Vector3 moveVector)
        {
            playerTransform = player;
            this.moveVector = moveVector;
        }
        
        public void Execute()
        {
            playerTransform.position += moveVector;
        }

        public void Undo()
        {
            playerTransform.position -= moveVector;
        }
    }

Our Invoker will be the class where we manage the Stack logic. Here, we add commands to the stack and also take the top item from the stack. This is the place where the stack logic is used.

    public class CommandInvoker
    {
        private Stack<ICommand> history = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            // We add to the top of the stack.
            history.Push(command);
        }

        public void Undo()
        {
            if (history.Count > 0)
            {
                // We remove the item from the top of the stack.
                ICommand lastCommand = history.Pop();
                lastCommand.Undo();
            }
        }
    }

Inside the Player, we add the actions we do from the UI to the Stack. Later, when we want to use undo, we can do it easily.

I will add the final look of the project as a GIF below.

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private CommandInvoker commandInvoker;
        private float stepSize = 1.0f;
        
        // Button action
        public void MoveUp() => SendMoveCommand(Vector3.up);
        public void MoveDown() => SendMoveCommand(Vector3.down);
        public void MoveLeft() => SendMoveCommand(Vector3.left);
        public void MoveRight() => SendMoveCommand(Vector3.right);

        private void SendMoveCommand(Vector3 direction)
        {
            ICommand move = new MoveCommand(playerTransform, direction * stepSize);
            commandInvoker.ExecuteCommand(move);
        }
    }
    
![Recording 2026-02-17 175127](https://github.com/user-attachments/assets/687b6110-23ae-40b5-8c0c-6ceaa21914c9)

### [Model-View-Presenter](Assets/GameDevelopment-101/Design_Patterns/ModelViewPresenter)

MVP is an architectural pattern that clearly separates Data (Model), View, and Logic (Presenter) from each other.

It is one way to avoid the spaghetti code we often see in games.

The difference from the MVC pattern is that in MVP, we can use the View part with the Canvas. In Unity, we use the Canvas as a View.

The image below will help you understand the MVP structure more clearly.

<img width="1500" height="600" alt="MVP" src="https://github.com/user-attachments/assets/72515740-963b-4af9-b4fe-771c62d41a01" />

## What is Presenter? 

The Presenter works like a bridge between the Model and the View. It receives interactions from the View, updates the Model, and then shows the result on the View again.

In our example, I built an Inventory System. In this game, when we click the button in the scene, we earn gold.

InventoryPresenter :

    public class InventoryPresenter
    {
        private InventoryModel _model;
        private InventoryView _view;
        
        public InventoryPresenter(InventoryModel model, InventoryView view)
        {
            _model = model;
            _view = view;

            _view.OnAddGoldClicked += HandleAddGold;

            RefreshView();
        }

        private void HandleAddGold()
        {
            _model.AddGold(10);
            RefreshView();
        }

        private void RefreshView()
        {
            _view.UpdateGoldDisplay(_model.Gold);
        }
    }

Here, it is important that the parts work together. When we earn gold, we take the input from the View, add 10 gold to the Model, and then refresh the View again.

The HandleAddGold function helps us understand and manage this process easily.

You can review the InventoryView and InventoryModel classes below.

InventoryModel : 

    public class InventoryModel
    {
        public int Gold { get; set; }
        
        public InventoryModel(int initialGold)
        {
            Gold = initialGold;
        }
        
        public void AddGold(int amount) => Gold += amount;

        public bool RemoveGold(int amount)
        {
            if (Gold < amount) return false;
            Gold -= amount;
            return true;
        }
    }

InventoryView :

    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI goldText;
        [SerializeField] private Button addGoldButton;

        public event Action OnAddGoldClicked;

        private void Awake()
        {
            addGoldButton.onClick.AddListener(() => OnAddGoldClicked?.Invoke());
        }
        
        public void UpdateGoldDisplay(int amount)
        {
            goldText.text = $"Gold: {amount}";
        }
    }

Another important advantage of this method is that it makes teamwork easier in large teams. While you update the calculation logic inside the InventoryModel, your teammate can work inside the InventoryView at the same time.


### [Object Pool](Assets/GameDevelopment-101/Design_Patterns/ObjectPooling)

Object Pool is one of the most well-known and commonly used patterns. But many times, people skip the question: why do we use it and what technical benefits it gives.

We use Object Pool for optimization. But what exactly is optimized?

## Why Object Pooling is an optimization?

The Instantiate and Destroy operations we use in our game create unnecessary load in RAM.

If we continue with the example I gave, every time we Instantiate a "Bullet", a new space is created in the HEAP area of RAM.

When we Destroy it, that space stays as garbage and it cannot be cleaned immediately.

When RAM becomes full, the Garbage Collector runs and cleans that space. This is one of the reasons for small lags in games.

By using Object Pooling, instead of doing these operations again and again, we actually simulate them. We reuse existing objects instead of creating and destroying them each time.

## How to Use Object Pooling

NOTE :
In this example, I will design it as if we need only one object. However, we can also do it by using a Dictionary and giving a key to control many different objects.

        private List<GameObject> pool = new List<GameObject>();

Now let’s look at how we get an object from the pool. I designed my system using GameObject, but we can also control it with a base class.

In my design, I want to use the IPoolable interface. By giving the IPoolable interface to objects that can be pooled, we can manage them through the pool system.

GetItemFromPool :

        public GameObject GetItemFromPool(Vector3 spawnPosition, Quaternion spawnRotation)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].activeInHierarchy)
                {
                    var item = pool[i];
                    item.SetActive(true);
                    // Update Transform
                    item.transform.position = spawnPosition;
                    item.transform.rotation = spawnRotation;
                    
                    IPoolable poolable = item.GetComponent<IPoolable>();
                    
                    poolable?.OnPulledToPool();

                    return item;
                }
            }

            GameObject newItem = Instantiate(itemPrefab);
            newItem.SetActive(true);
            pool.Add(newItem);
            
            return newItem;
        }

You can see this interface below. The interface structure works better with multiple objects when we use a Dictionary, but I designed it this way to also talk about multi-object pooling.

    public interface IPoolable
    {
        public void OnPulledToPool();
        public void OnReturnedToPool();
    }

  The Bullet class below will be the object in our pool. When it hits something, it goes back to the pool. The ReturnToPool function handles this.

    public class Bullet : MonoBehaviour, IPoolable
    {
        
        public void OnPulledToPool()
        {
            // Spawn
        }

        public void OnReturnedToPool()
        {
            // Destroy
        }

        private void OnTriggerEnter(Collider other)
        {
            ObjectPooling.instance.ReturnToPool(gameObject);
        }
    }

Now I will show what I want to do in the ReturnToPool function. Actually, we just hide the object by using the SetActive function.

Inside OnReturnToPool from the interface, or when it is used again inside OnPulledFromPool, we can do the actions we want.

    public void ReturnToPool(GameObject item)
        {
            if (pool.Contains(item))
            {
                item.SetActive(false);
                //Reset Transform
                item.transform.position = Vector3.zero;
                item.transform.rotation = Quaternion.identity;
                
                IPoolable poolable = item.GetComponent<IPoolable>();
                
                poolable?.OnReturnedToPool();
            }
            else
                Debug.LogWarning("Pool not found this item!!!");
        }
        
### [Strategy](Assets/GameDevelopment-101/Design_Patterns/StrategyPattern)

Strategy Pattern is a behavioral design pattern that lets us change an object's behavior at runtime. It works by putting the algorithm (how a task is done) into separate classes. This way, the main object does not depend on these details.

## Why Do We Use It?

I create a class called ObjectPooling. Inside this class, we will handle taking objects from the pool and returning them back.

We keep the objects in the pool inside a list, and the operations work on this list. Depending on the needs of the game, we can also use a Queue instead of a List.

  * Open/Closed Principle: We do not need to change existing code to add a new behavior. We only add a new strategy class.
  * Clean Code: It helps us avoid very large if-else or switch-case blocks.
  * Flexibility: We can change our character’s movement type or attack type during the game with only one line of code.
  * Testability: Each strategy is independent, so it is easier to write unit tests.

Using this method with ScriptableObject is one of the most common and clean approaches. I will explain how we can use it.

    public abstract class SkillStrategy : UnityEngine.ScriptableObject
    {
        public GameObject skillPrefab;
        public float skillDuration;
        
        public abstract void CastSkill();
    }

In the code above, we create a ScriptableObject class. In the Unity Editor, we will create the skills we want from this class. I am adding below how they look visually.

<img width="417" height="115" alt="Rage" src="https://github.com/user-attachments/assets/d087d850-0715-4cdf-87bb-308a1960963a" />
<img width="412" height="126" alt="Slash" src="https://github.com/user-attachments/assets/050e658b-4bcd-4166-a714-94dc02d9d3ed" />
<img width="413" height="126" alt="Shield" src="https://github.com/user-attachments/assets/510152cc-c910-4a7d-9906-e4b8af4c8eb5" />

For each one, we create classes that derive from SkillStrategy. We can use them by filling the values that come from the parent, like in the images above.

Rage :

    [CreateAssetMenu(fileName = "Skills", menuName = "ScriptableObjects/Skills/Rage")]
    public class Rage : SkillStrategy
    {
        public override void CastSkill()
        {
            var rage = Instantiate(skillPrefab);
            Destroy(rage, skillDuration);
        }
    }

Shield :

    [CreateAssetMenu(fileName = "Skills", menuName = "ScriptableObjects/Skills/Shield")]
    public class Shield : SkillStrategy
    {
        public override void CastSkill()
        {
            var shield = Instantiate(skillPrefab);
            Destroy(shield, skillDuration);
        }
    }

Slash :

    [CreateAssetMenu(fileName = "Skills", menuName = "ScriptableObjects/Skills/Slash")]
    public class Slash : SkillStrategy
    {
        public override void CastSkill()
        {
            var slash = Instantiate(skillPrefab);
            Destroy(slash, skillDuration);
        }
    }

We do not need to define everything again. Inside CastSkill, the values for skillPrefab and skillDuration will come from the ScriptableObject that we filled in the Editor.

This way, we avoid messy code. At the same time, we also follow the Open/Closed Principle.
    
### [Singleton](Assets/GameDevelopment-101/Design_Patterns/Singelton)

Singleton is one of the most common patterns in game development. Many people know about it, but some developers are careful when they want to use it. When it is used correctly, it has some advantages.

First, I want to explain how Singleton works technically. A Singleton is created only once in a special place in RAM called the "Static Storage Area".

First, let’s look at how we define a Singleton.

It is defined like this:

```
public static ClassName Instance;
```
The static keyword here means that our variable is stored in the place we mentioned before, which is called the Static Storage Area.

After that, we define it inside Awake like this:

```
public void Awake()
{
  if (Instance == null) Instance = this;
  else Destroy(gameObject);
}
```

Why are people afraid of Singleton, and why do many developers say we should not use it too much?
Now we will talk about the reasons and also where we should use it.
  * Tight Coupling: If you write GameManager.Instance.AddGold() inside the Player class, you cannot use the Player class anywhere without the GameManager anymore. It hides the dependencies.
  * Race Condition: If more than one script tries to access the same Singleton inside Awake, you cannot know which one will run first. This creates a risk of a NullReferenceException.
  * False Simplicity: Using a Singleton is like using a global variable. It looks easy, but it can make debugging very hard, because you cannot easily find which part of the project changed that data.

## Where Should You Use It?
You should not use Singleton for everything. You should use it only for system managers.
 * Audio Manager: Sounds should be controlled from one central place.
 * Save System: Saving data should go through a single system.
 * Scene Manager: Scene transitions and loading screens.
 * Game Manager: The general state of the game (Started / Finished / Pause).







