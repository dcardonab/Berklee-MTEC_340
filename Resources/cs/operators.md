# Operators


## Arithmetic

**Two-Operand Arithmetic Operators**

* `+` --> Addition

* `-` --> Subtraction

* `*` --> Multiplication

* `/` --> Division

* `%` --> Modulo - Remainder of the first operand divided by the second one.

**One-Operand Arithmetic Operators**

* `++` --> Increment of operand by 1

* `--` --> Decrement of operand by 1

> Note that `i++` (prefix notation) and `++i` (postfix notation) are different in regards to the order of operations. The former will first assign and then increment, and the latter will increment and then assign.
>
> e.g.
> ``` cs
> int x, y;
> x = 1;
> y = x++;
> Debug.Log(x);     // Debug will output 2.
> Debug.Log(y);     // Debug will output 1.
> 
> x = 1;
> y = ++x;
> Debug.Log(x);     // Debug will output 2.
> Debug.Log(y);     // Debug will output 2.
> ```

Operator precedence follows **PEMDAS**:

1. Parenthesis
2. Exponents
3. Multiplication
4. Division
5. Addition
6. Subtraction


## Arithmetic with Assignment

* `+=` --> Add value to the current value of a variable, and assign it to that same variable.
* `-=` --> Subtract value to the current value of a variable, and assign it to that same variable.
* `*=` --> Multiply value to the current value of a variable, and assign it to that same variable.
* `/=` --> Divide value to the current value of a variable, and assign it to that same variable.
* `%=` --> Modulo the value to the current value of a variable against passed operand, and assign it to that same variable.

## Assignment

* `=` --> Assign value to variable.


## Comparison

* `==` --> Equality ; Evaluates to true if both operands have the same value.
* `!=` --> Inequality ; Evaluates to true if both operands have different values.
* `>` --> Greater than ; Evaluates to true if the first operand is greater than the right operand.
* `>=` --> Greater or equal ; Evaluates to true if the first operand is greater or equal to the right operand.
* `<` --> Lesser than ; Evaluates to true if the first operand is lesser than the right operand.
* `<=` --> Lesser or equal ; Evaluates to true if the first operand is lesser or equal to the right operand.


## Logical

* `&&` --> And
    * **and** will force a result when the first condition is true.

* `||` --> Or
    * **or** will force a result when the first condition is false.

* `!` --> Not


## Concatenation

* `+` --> Concatenate two strings.


## Dot Operator

The dot operator (`.`) is used to access members of a class, regardless of whether they are methods or properties. Methods will be followed by a parenthesis, including any arguments required by that method.

```cs
Object myObject = new SomeObject();

myObject.memberProperty;
myObject.memberMethod();
myObject.memberMethodWithArguments(myArgument);
```

## Ternary Operator

Ternary operators (`?:`), also known as conditional operators, allow us to reduce an if/else conditional to a single line. They evaluate a boolean expression, and returns one of two expressions. They can be paired with assignment operators or `return` statements.

In terms of syntax, a condition is given, followed by a `?`, followed by two value that will be returned if the statement evaluates to `true` (consequent) or `false` (alternative) respectively, both separated by `:`.

``` cs
condition ? consequent : alternative;
```

e.g.:

``` cs
// Ex. 1 - Used in a return statement.
// Function will return the largest value between
// two variables.
return i > j ? i : j;

// Ex. 2 - Used when in assignment.
// `k` will be assigned the largest value between two
// variables.
int k = i > j ? i : j;
```