# Control Flow

## Conditionals

### if - else if - else

You can write logic for your program using conditionals. The `if`, `else if`, and `else` keywords are used to evaluate conditional expressions and execute blocks of code based on the outcome of the expression.

A conditional expression is also known as a Boolean expression, meaning an expression that evaluates to `true` or `false`.

`if` is always required when declaring conditionals, but `else if` and `else` are optional. There can also be more that one `else if`, but in this case it might be a better approach to use a [`switch` statement`](#switch).

`else if` is used for evaluating an expression for a different outcome when the `if` condition isn't met. The `else` case will be used in all other instances.

Only one of the branches of the `if` and `else if` conditions will execute at a given time, meaning that if the `if` conditional evaluates to `true`, the `else if` won't be evaluated. This provides an opportunity for efficiency by checking the most likely outcome first.

Boolean expressions can directly check if variable is `true` or `false` (if its a Boolean variable), or make use of comparison operators (i.e., `==`, `<`, `>`, `<=`, `>=`) to check how the value of variable of a given data type relates to a given value.

Note that Boolean expressions can make use of logical operators (e.g., `!`, `&&`, `||`) for evaluating multiple conditions. You can take efficient approaches when using the AND (`&&`) or the OR (`||`) logical operators, given that:

* The AND (`&&`) operator will cause an expression to be `false` if its first condition is `false`, meaning that the code will automatically skip evaluating the second portion of the expression.

* The OR (`||`) operator will cause an expression to be `true` if its first condition is `true`, meaning that the code will automatically skip evaluating the second portion of the expression.

#### Syntax

The conditional keyword (i.e., `if`, `else if`, or `else`) starts the line, followed by a parenthesis containing the conditional expression being evaluated, followed by curly brackets containing the block of code that will execute when the given conditional evaluates to `true`. After this block of code, subsequent conditional keywords are included if needed. The curly brackets for a conditional block can be omitted if the block of code that will execute from that condition is only one line.

``` cs
if (condition1)
{
    // Code block executes when condition1 is met
}

else if (condition2)
{
    // Code block executes when condition2 is met
}

else
{
    // Code will execute with neither condition1 nor condition2 are true
}
```


### switch

A `switch` statement should be used when an evaluating (aka. pattern matching) whether an expression (aka. match expression) is equal to specified values (aka. cases). Each different value will be a different case.

Make sure to end each `case` with the `break` keyword for prevent a `case` falling through to the next one, unless this is the intended outcome. Note that once a case evaluates to `true` and in the absence of `break` keywords, it will fall through to cases that would have evaluated to false, and will keep on going until reaching a `keyword`.

### Syntax

The match expression is given in parenthesis, and then within curly brackets, the cases are declared using the `case` word, followed by the value for that case, followed by a colon. If the case matches the match expression (i.e., evaluates to `true`), the block of code after the colon will execute until reaching a `break` keyword. This block of code is not included within curly brackets.

The `default` case will execute if no `case` matched the match expression. `default` tends to be declared last, and though the `break` keyword for the `default` case is optional (given that the code will have nowhere to cascade to) in languages such as C, Java, or Javascript, C# requires that last `break` keyword.

``` cs
switch (match_expression)
{
    // Given that code will cascade until reaching break keyword, this is an
    // example of providing the same outcome for two values.
    case value1:
    case value2:
        // Code here will execute if value1 or value2 match the match_expression.
        break;
    case value3:
        // Code here will execute if value3 matches the match_expression,
        // and given the absence of a break, it will go on to execute the
        // default case.
    default:
        // Code here will execute when no case above matches.
        break;  // break in the default case is required by C#.
}
```


## Loops and Iteration

Loops make use of a condition in order to determine how many times they should execute.

> Note that the `break` keyword can be used to break out from a loop, but it's better practice to declare conditions that will prevent certain types of loops from iterating infinitely.


### for loops

`for` loops tend to be used when a block of code is to be executed a specific number of times. Their construction uses the `for` keyword, followed by a set of parenthesis containing three elements:

* Initializer: A local variable that's initialized to keep track of the number of iterations.

* Condition: As long as this condition is met, the loop will continue to iterate. This condition is checked at the beginning of each iteration, i.e., prior to the execution of the loop. If the condition is true, the code will proceed to the iterator, which updates the initializer variable. The loop will break when the condition is false.

* Iterator: An update of the initializer variable that executes at the end of each loop. Generally speaking, the iterator will increment (`++`) or decrement (`--`) the initializer value.

These elements are separated by semicolons.

Finally, the body of the loop will be declared withing curly brackets.

``` cs
// for loop blueprint.
for (initializer; condition; iterator)
{
    // Block of code that will execute on each iteration.
}

// A common for loop to iterate over a collection would look like this:

// Use `Count` instead of `length` for lists and dictionaries.
// This condition will ensure that we don't get an out-of-range exception.
for (int i = 0; i < myArray.length; i++)
{
    // Index into each element in the array.
    Debug.Log(myArray[i]);
}
```


### foreach loops

`foreach` loops iterate over each element in the collection, and on each iteration, each element is stored into a local variable so that it can be accessed in the body of the loop. Note that the type of the local variable and the object type must match.

These kinds of loops can be used with arrays, lists, and dictionaries. They are specially useful with dictionaries as they do not use numeric indexing, but rather key-value pairs.

``` cs
// foreach loop blueprint
foreach (elementType localName in collectionVariable)
{
    // Block of code that will execute on each iteration.
}

// A common for loop to iterate over a collection would look like this:

foreach (string item in < myList)
{
    Debug.Log(item);
}

// A dictionary uses different initialization syntax.
// It relies on the KeyValuePair type, including the corresponding data types
// in left-right arrow characters, separated by a comma.
foreach (KeyValuePair<string, int> kvp in myDict)
{
    // KeyValuePair types have a Key and a Value property.
    // Each can be accessed using dot notation.
    Debug.Log($"{kvp.Key} - {kvp.Value}");
}
```


### while loops

`while` loops are similar to `if` statements in that they only take one condition, but the block of code will continue to run indefinitely until this condition is no longer a passing condition (i.e., it becomes a failing condition).

They can optionally utilize an initializer that is declared prior to the `while` loop body, and is updated using an iterator within the body. The can alternatively use a Boolean value or a value comparison for its condition.

``` cs
// Blueprint
initializer;
while (condition)
{
    // body
    iterator;
}

// e.g.
int i = 0;
while (i < 5)
{
    Debug.Log($"The number of current iterations is {i}")
    i++;
}
```

> Note that `while` loops tend to be avoided in Unity because they can deter performance and because of the need to manually manage them.

### do-while loops

`do-while` loops are just like `while` loops, with the exception that check the condition at the end of the loop. This means that they will execute at least once.

``` cs
// Blueprint
do
{
    // loop body
} while (condition);

// e.g.
int i = 0;
do
{
    Debug.Log($"The number of current iterations is {i}")
    i++;
} while (i < 5);
```
