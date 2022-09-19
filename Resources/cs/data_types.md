# Data Types

## Signed and unsigned integral

Signed values span the total range of the integral across both positive and negative values, whereas unsigned span the total integral range only in the positive direction.

**Signed**

> | Data Type  | Size   | Range                                                       |
> | ---------- | ------ | ----------------------------------------------------------- |
> | `sbyte`    | 8-bit  | $-128$ to $127$                                             |
> | `short`    | 16-bit | $-32,768$ to $32,767$                                       |
> | `int`      | 32-bit | $-2,147,483,648$ to $2,147,483,647$                         |
> | `long`     | 64-bit | $-9,223,372,036,854,775,808$ to $9,223,372,036,854,775,807$ |

**Unsigned**

> | Unsigned | Size   | Range                               |
> | -------- | ------ | ----------------------------------- |
> | `byte`   | 8-bit  | $0$ to $255$                        |
> | `ushort` | 16-bit | $0$ to $65,535$                     |
> | `uint`   | 32-bit | $0$ to $4,294,967,295$              |
> | `ulong`  | 64-bit | $0$ to $18,446,744,073,709,551,615$ |


## Unicode Characters

* `char` --> represents a UTF-16 code unit.

    > UTF-16 stands for **16-bit Unicode Transformation Format**, a character encoding capable of encoding all $1,112,064$ valid code points of Unicode. This is possible due to the encoding being variable-length, allowing code points to be encoded with one or two 16-bit code units. This leaves headroom for additional codes.
    >
    > * One code unit: $2^{16} = 65,536$ possible values
    >
    > * Two code units: $2^{32} = 4,294,967,296$ possible values
    >
    > To put this in perspective, [extended ASCII codes](https://www.asciitable.com) can only encode 256 values:
    >
    >  * $2^{8} = 256$


## Floats and Decimals

> | Data Type | Size                    | Range                                  | Definition                             |
> | --------- | ----------------------- | -------------------------------------- | -------------------------------------- |
> | `float`   | 32-bit - ~6-9 digits    | $\pm 1.5e^{-45}$ to $\pm 3.4e^{38}$    | Single precision binary floating-point |
> | `double`  | 64-bit - ~15-16 digits  | $\pm 5e^{-324}$ to $\pm 1.7e^{308}$    | Double precision binary floating-point |
> | `decimal` | 128-bit - ~28-29 digits | $\pm 1.0e^{-28}$ to $\pm 7.9228e^{28}$ | High-precision decimal floating-point  |

* *IEEE: Institute of Electrical and Electronics Engineers*


## Boolean

* `bool` --> Boolean values (i.e., `true` or `false`)


## Inferred

* `var` --> Variable will automatically infer its datatype based on the type of assigned data.


## Class

* The base class for all other types: `object`

* `string` --> Sequence of UTF-16 code units

* User-defined types of the form `class C {...}`
