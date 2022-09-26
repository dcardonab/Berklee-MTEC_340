# Collections

> *Note that this is just an introduction for the collections available in C#. Look at the official documentation for additional methods and functionality.*

## Arrays

* Arrays are containers for multiple values of the same type.

* These values can be accessed or modified individually.

* The number of items an array can contain is set when the array is declared, and it cannot be modified afterwards. This is due to memory allocation. This makes them the least flexible but the fastest collection in C#.

* Arrays are very efficient because the offer random access (the capacity to index directly into objects). This is only possible due to initial memory allocation (how many blocks of consecutive memory will the array span across).

* Elements in an empty array are initialized to a default value. This is `0` for numeric data types, and `null` for all other types.

* If there is an attempt to change the size of the array, elements contained in the existing array will be lost. This is due to the change directly creating a new array the is assigned to the existing array variable (variables are containers).


### Syntax

Arrays are declared by specifying the data type, followed by empty square brackets. Then, the name of the array is provided, and for an empty array, it is assigned (`=`) a `new` array object with a set number of elements provided within another set of square brackets.

If initial items will be assigned, there are two initialization syntaxes, longhand and shortcut. The longhand does not require the number of elements to be provided, but it is followed by curly brackets containing the values. The number of elements will be inferred by the number of values provided within the curly brackets.

For shorthand notation, the curly brackets containing the values can be specified right after the assignment operator. The number of items will also be inferred.

```cs
// Empty array initialization.
elementType[] arrayName = new elementType[numberOfElements];
int[] myIntArray = new int[3];   // Array with 3 elements.

// Longhand initialization. More explicit.
elementType[] array_name = new elementType[] {item1, item2, item3};
int[] myIntArray = new int[] { 0, 7, 12 };  // Array with 3 elements.

// Shorthand initialization. Common practice.
elementType[] array_name = { item1, item2, item3 };
int[] myIntArray = { 0, 7, 12 };  // Array with 3 elements.
```


### Indexing

Arrays in C# are zero-indexed, meaning that the first element in the array is item 0, the second element is item 1, and so on. Elements are stored in the order they assigned.

Arrays are indexed to using the subscript operator, which receives an index number within square brackets and follow the array name that is being accessed.

The subscript operator is also used for directly modifying values in the array.

``` cs
int[] myArray = { 5, 7, 9 };

int value = myArray[0]; // Accessing item at index 0 using the subscript operator.

Debug.Log(value);   // This will print 5 to the Unity console.

myArray[1] = 12;

Debug.Log(myArray[1]);  // This will print 12 to the console.
```


### Range Exceptions

The number of elements in an array cannot be changed due to a fixed amount of memory being allocated when it is initialized. Trying to index a value beyond the available items in the array will return an `IndexOutOfRange` exception, because that value doesn't exist.

It is possible avoiding `IndexOutOfRange` exceptions by checking if the value we are trying to access exists.

A useful property of the array object is `length`, which is an integer corresponding to the number of values in the array. Since arrays are zero-indexed, the last indexable item in the array will be `array.length - 1`.


## Lists

Lists store elements of the same type, but they have the capacity to add, remove, and update elements. Elements stored in lists aren't stored sequentially. They are also mutable, meaning that it is possible to change its length without overwriting the whole list. This gives them superior flexibility over array, but comes at a higher computational expense. Because their length can be modified, there is no need to indicate the number of elements the list will contain when initializing it.

### Syntax

Lists are initialized by using the `List` keyword, followed by the data type it will store within left and right arrow characters. Then, a unique name is declared, followed by the assignment of a `new` list of a given element type, followed by open and closed parenthesis. In the list is being initialized with items, these are specified after the parenthesis within curly brackets.

``` cs
// Empty list
List<elementType> listName = new List<elementType>();

// List with initial values.
List<elementType> listName = new List<elementType>() { value1, value 2 };
```

Elements are stored in the order they are added. Lists are zero-indexed, and like arrays, values can be accessed using the subscript operator.

As opposed to arrays, which use the `length` property, to access the number of elements in the list the `Count` method is used.

``` cs
listName.Count;
```


### Common Methods

``` cs
// Append a new element to the end of the list.
myList.Add(value);

// Insert an element at a given index.
// This will cause all elements after the index to increase their indices by 1.
myList.Insert(1, value);    // args: index, value

// Remove element by index.
myList.RemoveAt(1); // arg: index.

// Remove element by literal value.
myList.Remove(value);

// Both remove elements will reduce the indices of all following values by 1.
```


## Dictionaries

Dictionaries store key-value pairs for each element, as opposed to single values, and they are indexed by keys. Contrary to arrays and lists, dictionaries are unordered. They can however be sorted and ordered after they have been created based on specific methods.

Keys must be unique and cannot be changed. Values on the other hand can be changed. To update a key, it is necessary to remove the key-value pair, and add the updated key as a new key-value pair.

### Syntax

Dictionaries are declared with a syntax that closely resembles lists, with the exception that the data type for both keys and values must be specified.

As with lists, for specifying parameters when initializing, values can be enclosed in curly brackets. However, each element (i.e., key-value pair) will be declared within these curly brackets in its own curly brackets. Keys and values are separated using a comma within their curly brackets, and each element (i.e., set of key-value pairs) is also separated using commas.

``` cs
// Empty dictionary.
Dictionary<keyType, valueType> dictionaryName =  new Dictionary<keyType, valueType>();

// Dictionary with values.
Dictionary<keyType, valueType> dictionaryName =  new Dictionary<keyType, valueType>()
{
    {key1, value1},
    {key2, value2}
};
```

Dictionaries also use the `Count` method for obtaining the number of elements they contain.


### Common Methods and Workflow

``` cs
// Values in a dictionary can be accessed using subscript notation using the key.
int value = myDict['key'];

// This same approach can be used to update the value of a key-value pair.
myDict['key'] = newValue;

// Subscript notation can be used to add a new key-value pair.
// The new key is specified using subscript notation,
// and the assignment operator is used for the new value.
myDict['newKey'] = newValue;

// Alternatively, new elements can be added using the add method.
// The types of both key and value must match the declared values
// used when the dictionary was initialized.
myDict.Add('newKey', newValue);

// To avoid errors and exceptions, it is important to ensure that
// a key exists prior to trying to access or update it.
// This can be done using the `ContainsKey` method in a conditional.
if (myDict.ContainsKey('myKey'))
{
    myDict['myKey'] = newValue;
}

// Elements can be removed from a dictionary using the `Remove` method,
// which takes in the key to be removed as an argument.
myDict.Remove('keyToBeRemoved');
```
