# Operators

## Ternary Operator

Ternary operators `?:`, also known as conditional operators, allow us to reduce an if/else conditional to a single line. They evaluate a boolean expression, and returns one of two expressions. They can be paired with assignment operators or `return` statements.

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