# Property

Properties offer mechanisms to access the member variables of a class from code outside of the class.

Though this can be achieved using `public` variables. Though this is sufficient, it is a better practice to use `get` and `set` methods to complete this task.

This is in line with declarative programming practives, which expresses the logic for completing a task (what do to). This differs from imperative programming, which directly describes its control flow (how to do). [More info](#Advantages).

Properties act like variables and encapsulate other variables (also referred to as fields).


## Syntax

A property is created by specifying the access modifier (e.g., `public`), followed by the return type (e.g., `int`), and the name of the property. The convention is to give the property the same name as the field it encapsulates, but capitalized.

Following the property name, within curly braces the property **accessors** are provided.

There are two property accessors: `get` and `set`. These are the called functions when a property is referenced. Braces follow the `get` and `set` keywords.

`get` returns the encapsulated field. `set` allocates the field using the `value` keyword.

Any code can run within each accessor, so the encapsulated field can be modified prior to being returned, or the value can be altered prior to being written. This also allows calling other functions inside the accessors, potentially initiating co-routines.

Note that the encapsulation doesn't need to be direct, meaning that multiple properties can reference the same fields.


## Advantages

1. By omitting the `get` or the `set` accessor, a field can be respectively made **read-only** or **write-only**.

2. Private fields cannot be read without a `get` accessor, and they cannot be written to without a `get` accessor.

3. Accessors can be treated like functions, allowing for other lines of code to be run.


## Auto-implemented Properties

Properties can also be auto-implemented using shorthand syntax, avoiding the curly braces after the accessors, and replacing them by semicolons.

This shorthand syntax allows a property to behave exactly like a field. Omitting an accessor in shorthand also limits whether a property can be read or written to.


## Example

In this example, the Player properties are accessed from the Game class.

**Player**
``` cs
public class Player {
    // Field
    private int experience;

    // Property
    public int Experience {
        get {
            return experience;
        }
        set {
            experience = value;
        }
    }

    // Property indirectly encapsulating experience.
    public int Level {
        get {
            return experience / 1000;
        }
        set {
            experience = value * 1000;
        }
    }
    
    // Auto-implemented property.
    public int Health {get; set;}
}
```

**Game**
``` cs
public class Game : MonoBehaviour {
    void Start() {
        Player myPlayer = new Player();

        // Set property.
        myPlayer.Experience = 5;

        // Get property.
        int x = myPlayer.Experience;
    }
}
```


# Reference

[Unity Learn - Creating Properties](https://learn.unity.com/tutorial/creating-properties#)