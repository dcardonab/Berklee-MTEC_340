# C# Basics (in Unity)

## Getting Ready and Basic Considerations

* In Unity, the name of the script and the class contained by the script **MUST** be the same. This is specific to Unity, and other application of C# may not have this requirement.

> If your rename the name of a `cs` file, make sure to rename the class inside the file, as well as the corresponding `.meta` file (see **Assets > Scripts** in the Finder).

* Unity creates metadata files (`.meta`) for each asset it contains. These contain GUID (Global Unique Identifiers), import settings, and other information. These files are important and should be kept track of when using version control systems. They must also be included for shipping Unity packages.

* Scripts will be automatically synchronized between Unity and Visual Studio. If they are not synchronized, right click on the troublesome script and select **Refresh**.

* Write `arg` to the Unity Console Panel: `Debug.Log(arg);`

---

## Variables and Data Types

> You can access a list of useful C# data types for Unity in [this document](./data_types.md).<br />
> *Note that this document contains a non-comprehensive list.*

A **variable** is a section of the computer's memory that holds an assigned value (i.e., a container). Variables keep track of where the information is stored (memory address), its value, and its type.

Each variable must have a unique name, and they can be used exactly like values themselves:

``` cs
int myNumber = 10;

Debug.Log(10 + 5);  // The output will be 15.
Debug.Log(myNumber + 5);  // The output will also be 15.
```

The basic data types that we'll use include text (`char`, `string`), numbers (`int`, `float`), Booleans (`bool`). The type of the variable will have an impact on how much memory is allocated at a given address for storing a value.

---

## Functions and Methods

Methods and functions perform actions when called by names. These actions are sets of instructions that are executed sequentially, generally operating over the arguments that are passed in when declared. Methods and functions are declared using parameters, and arguments are assigned to these parameters when being called.

Though many use the words parameters and arguments interchangeably, the former pertains to a function/method declaration, and arguments are the values that are passed in for those parameters when the function/method is called.

``` cs
// `num1` and `num2` are the parameters of the `sum` function.
void sum(float num1, float num2) {
    Debug.Log(num1 + num2);
}

// `2` and `3.5` are the arguments passed to the sum function,
// corresponding to its parameters in order.
sum(2, 3.5f);

// Output: 5.5
```

Methods and functions also take space in memory, but instead of containers for values, they are containers for sets of instructions.

The advantage of functions is that they create layers of abstraction, allowing to update a set of instructions that is likely to be used more than once by only updating it in one place. This prevents issues of missing other updates that use the same set of instructions, improving the quality of the code.

---

## Classes and Objects.

A class is a data structure that contains variables and functions that are relevant to itself. You can think of it like a blueprint from which objects can be created. Objects are referred to as instances. You can create as many instances (i.e., objects) from a given class as you want.

Class variables and functions are referred to as member properties (not property declarations, which we will cover later) and member methods, respectively. The member word simply implies that they are a member of a class.

A new object of a class is declared using the `new` keyword. Methods for that newly created object can be called using what is referred to as `.` dot notation. This means that we use the name of variable, followed by a dot, followed by the name of the method. Just as when calling functions, parentheses are necessary when calling methods.

For instance, a car class will contain some properties (i.e., variables) of wheels, doors, speed, etc. It will also have some methods (i.e., functions) that are relevant to itself, such as accelerating, which will directly affect it position. Car objects can then be created from this car class, each having its own number of wheels, doors, and engine speed, and each capable of accelerating.

``` cs
// Class declaration.
public class Car {
    // Properties
    public int wheels = 4;
    public int doors = 4;
    public float speed = 0;

    // Methods
    private void accelerate() {
        speed += 0.1f;
    }

    public void break() {
        speed = 0;
    }

    public void move() {
        accelerate();
        // `this` refers to the very object that is being called.
        this.position += speed;
    }
}

// Create an object of the class.
Object car1 = new Car();

// Calling this method will update the car's speed and move.
car1.move();

// Calling this method will zero the speed.
car1.break();
```

### MonoBehaviour

MonoBehaviour is the default class in Unity. It has a number of properties, including the capacity for scripts to be added as components to GameObjects, as well as declarations for fundamental functions in the lifecycle of a script in Unity, such as the Start() and the Update() functions.

Classes that inherit from a MonoBehaviour class can be attached to GameObjects in the Unity scene. It is worth noting that not every script in Unity must be attached to a GameObject, but if you want your script to work as a component, it **MUST** inherit from MonoBehaviour.

We will cover inheritance later one, but for now, be aware that the inheritance syntax for inheriting from MonoBehaviour is:

``` cs
public class Movement : MonoBehaviour
{
    // body of the class
}
```

[MonoBehaviour – Unity Scripting API](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html)

---

## Basic Syntax

* White space is ignored by the compiler and is used for readability. The exception to this is separating words. It however does not matter if these are separated by one space or five spaces.

* `;` denotes a statement.

* `{}` denotes the body of a function, condition, or loop.

* `()` is used in function calls and definitions. Arguments are provided within the parenthesis in function calls, and parameters are declared (with explicit data types) in function definitions.

* Comments:
    * `//` denotes a single line comment. Anything after these characters will be a comment.
    * `/* */` denotes a multi line comment. Use `/*` to open a comment and `*/` to close it.
    * `/// <summary> /// </summary>` is used to add comments relevant to a block of code, and it is helpful to be able to see these comments via IntelliSense. There is generally a line-break after the first summary tag, and the closing tag is the last line. Make sure your comments are within the *summary* tags.
        * e.g.:
            > ``` cs
            > /// <summary>
            > /// Summary of my block of code.
            > /// </summary>
            > ```
    * Comments aren't compiled.

* `:` in class declarations, specifies inheritance, with the new class name to the left of the colon, and the class that our new class is inheriting from to the right of the colon.

---

## Notes on Unity

* When assigning a value for a `public` variable in the inspector, that value will take precedence over values declared in the script.

* Every script in Unity is a class by default.
