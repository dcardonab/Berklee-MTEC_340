# Property Attributes

## Common Property Attributes

* `DisableMultipleComponent`
    * Prevents component from being added more than once to a GameObject.
    * Applied to a class.

* `Range(min, max)`
    * Creates a slider in the Inspector ranging from min to max inclusive.
    * Applied to a numeric field.

* `RequireComponent(typeof(ComponentType))`
    * Enforces that a specific component exists in the GameObject.
    * Script will add specified component to the GameObject it was added to if it doesn't have one yet.
    * Replace **ComponentType** for the actual component name.
    * Note that multiple components can be enforced by adding additional `typeof()` functions separated by commas:
        * `RequireComponent(typeof(ComponentType1), typeof(ComponentType2))`
    * Applied to a class.

* `SerializeField`
    * Serializes private fields to that they can be seen and modified via the Inspector pane. This is due that only serialized field will display in the Inspector.
    * Applied to fields.

* `Space`
    * Adds some spacing in the Inspector.
    * Applied in between fields.