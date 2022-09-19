# Variables

## Declaration Requirements

* Access modifier (Optional): If not provided, the variable will default to a private access modifier.

* Data type: What kind of data will be stored.

* Unique name: Descriptive name for the type of data that is contained, and what it will be used for. Use Pascal (aka. Camel) case for name conventions.

* Value (Optional): Values can be assigned directly when a variable is declared. If unprovided, is is referred to as a type only declaration, and the variable's initial value will assume a default value.

* Semicolon: Close the declaration statement.


## Syntax

`access_modifier data_type variable_name = variable_value;`

e.g.:
``` cs
// Type only declaration.
private string CurrentQuest;

// Variable initialized to a value using an assignment operator.
public int MaxPlayerHealth = 100;
```


## Scope

The scope of a variable determines when a variable exists in a script. There are four types of scopes in C# (the C# documentation does not list Global scope):

* Global: Global variables can be accessed from anywhere in the script.

* Class: Class variables can be accessed from within the class where they are declared. If the variable uses a `public` access modifier, it can be accessed by other scripts as long as an object of that class has been instantiated.

* Method: Method variables can be accessed from within the methods where they are declared. This means that they will only be available within the method/function block that declared them.

* Block: Block variables can only be accessed in the block they are declared. This represents control flow structures, such as conditionals and loops.
