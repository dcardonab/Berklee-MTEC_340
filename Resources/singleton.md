# Singleton

A singleton in Unity is a globally accessible class that exists in the scene, but **only once**.

This allows other scripts to access the singleton, easily connecting objects.

A singleton class is like any other class, except that the class holds a public static reference to an instance of its own type.

``` cs
// Since the class is globally accessible, it needs the `public` identifier.
public class Singleon : MonoBehaviour {
    public static Singleton instance;
}
```

The `public` keyword allows other objects to find the class.

A `static` variable makes it shared by all instances of the class, allowing any script to access the singleton by class name **without needing a reference**:

``` cs
Singleton.instance;
```

All public methods and variables that exist in the singleton class can be accessed using dot notation.

Because any scrip can access the class, it is helpful to protect the instance with a `private` setter [property](./property.md).

``` cs

```
