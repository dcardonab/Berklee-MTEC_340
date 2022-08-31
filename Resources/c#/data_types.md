# Data Types

## Value Types

### Simple Types

* Signed and unsigned integral
    > | Signed  | Unsigned | Definition |
    > | ------- | -------- | ---------- |
    > | `sbyte` | `byte`   | |
    > | `short` | `ushort` | |
    > | `int`   | `uint`   | |
    > | `long`  | `ulong`  | |

* Unsigned integral
    * `char` --> represents a UTF-16 code unit.

        > UTF-16 stands for **16-bit Unicode Transformation Format**, a character encoding capable of encoding all $1,112,064$ valid code points of Unicode. This is possible due to the encoding being variable-length, allowing code points to be encoded with one or two 16-bit code units. This leaves headroom for additional codes.
        >
        > * One code unit: $2^{16} = 65,536$
        >
        > * Two code units: $2^{32} = 4,294,967,296$
        >
        > To put this in perspective, [extended ASCII codes](https://www.asciitable.com) can only encode 256 values:
        >
        >  * $2^{8} = 256$

* IEEE binary floating-point
    * `float`
    * `double`

* High-precision decimal floating-point
    * `decimal`

* Boolean
    * `bool` --> Boolean values (i.e., `true` or `false`)

### Enum Types

### Struct Types

### Nullable Value Types

### Tuple Value Types


## Reference Types

### Class Types

### Interface Types

### Array Types

### Delegate Types
