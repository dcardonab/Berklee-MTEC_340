# Unity Script Lifecycle

Unity has main sections that execute in the following order

1. Initialization --> Awake ; OnEnable

2. Editor --> Reset

3. Initialization --> Start

4. Physics --> Fixed Update ; Internal Animation Update ; Internal Physics Update ; Internal Animation Update ; OnTrigger ; On Collision ; yield WaitForFixedUpdate

5. Input Events

6. Game Logic --> Update ; yield functions ; Internal Animation Update ; Late Update

7. Scene Rendering

8. Gizmo Rendering --> OnDrawGizmos

9. GUI Rendering --> OnGUI

10. End of Frame --> yield WaitForEndOfFrame

11. Pause --> OnApplicationPause

12. Decommissioning --> OnApplicationQuit ; OnDisable ; OnDestroy


## Highlights

* Awake()

    * Equivalent to constructor

    * Initializes objects before the game starts

    > Useful for initializing singletons

* Start()

    * Called on the first frame.

    * Runs once per script.

* FixedUpdate()

    * Executed for the physics engine. It may execute once, zero, or more than once per frame.

    * Used for applying forces, torques, and physics related functions. In other words, anything that needs to be applied to a Rigidbody should be applied in FixedUpdate.

* Update()

* LateUpdate()

    * Executed after the internal animation update that runs in the Game Logic portion of the game.


# Reference

https://docs.unity3d.com/Manual/ExecutionOrder.html
