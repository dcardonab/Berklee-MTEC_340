# Methods

## Declaration Requirements

* Access modifier (Optional): If not provided, the method will default to a private access modifier.

* Return data type: What kind of data will be returned from the function. `void` will not return a value and does not need a `return` keyword in the body of the function.

* Unique name: Descriptive name for the action that the function will complete. Use Pascal (aka. Camel) case for name conventions.

* Parenthesis with parameters enclosed: It is not required to provide parameters. Provided parameters must specify their data type and their name. Parameters will be locally scoped to the method/function block. For more than one parameter, separate them using a comma.

* Curly braces: Contains the body of the method/function, i.e., the code that will be executed when the function is called.

* Call a function by name followed by parenthesis. If parameters are necessary, pass values as arguments. Arguments do not require their data type to be specified. Arguments should follow the same order as the order used for declaring parameters. Arguments must also be separated by commas if there is more than one.

## Syntax

``` cs
// Declaration without parameters
access_modifier return_type MethodName1()
{
    method_body;

    // Optional for `void` return type.
    return variable_of_specified_return_type;
}

// Declaration with parameters
access_modifier return_type MethodName2(parameter_type parameter1, parameter_type parameter2)
{
    method_body;
}

// Call methods
MethodName1();
MethodName1(arg1, arg2);

```
