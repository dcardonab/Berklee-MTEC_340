using System.Collections;
using UnityEngine;

/*
 * Context
 * 
 * The context manages the current state and the transitions between states.
 * This is the only script that will be attached to the player.
 * 
 * The context passes data to the currently active concrete state. This data
 * will be used by the concrete state to react with its specific logic.
 * 
 * The context retains all the necessary player variables. By having all
 * data stored in te context, multiple state machines can be running off
 * of the same data.
 */
public class PlayerStateMachine : MonoBehaviour
{
    /******************* STATES *******************/

    /*
     * _currentState holds a reference to the current state of the player.
     * 
     * The state factory is used to handle the various possible states of the
     * player, allowing to easily add other states.
     * 
     * Note that the current state is making use of getter and setter properties
     * to safely handle how it is being modified.
     */
    PlayerBaseState _currentState;
    PlayerStateFactory _states;

    public PlayerBaseState CurrentState
    {
        get => _currentState;
        set { _currentState = value; }
    }


    /******************* MOVEMENT *******************/

    CharacterController _controller;
    Transform _cameraTransform;
    Camera _cam;

    [Header("Movement")]
    [SerializeField] float _speed = 6.0f;
    [SerializeField] float _gravity = -9.8f;

    [Space(10)]
    [Header("Rotation Sensitivity")]
    [SerializeField] float _sensitivityHor = 9.0f;
    [SerializeField] float _sensitivityVert = 9.0f;

    [Space(10)]
    [Header("Rotation Constraints")]
    [SerializeField] float _minVert = -45.0f;
    [SerializeField] float _maxVert = 45.0f;

    private float _verticalRot = 0;


    /******************* PLAYER PROPERTIES *******************/

    [Space(10)]
    [Header("Health Properties")]
    public int Health = 5;
    public int MaxHealth = 10;


    /******************* MONO BEHAVIOUR METHODS *******************/

    void Awake()
    {
        // Get references to player components.
        _controller = GetComponent<CharacterController>();

        // Retrieve the transform of the camera child.
        _cameraTransform = transform.Find("Main Camera");

        // Retrieve camera component
        _cam = GetComponentInChildren<Camera>();

        /******************* STATES *******************/

        // Initialize the State Factory. Note that the state factory
        // constructor requires a reference to the game's context.
        _states = new PlayerStateFactory(this);

        /*
         * The initial state of the state machine must be specified.
         * Given that all player states are derived from the base state,
         * it is possible to assign any state to a variable object of the
         * base class type.
         */
        _currentState = _states.Grounded();

        /*
         * Initialize the passed in state and pass the player context using
         * the keyword `this`. Recall that all functions expect the context
         * to be passed in as an argument.
         */
        _currentState.EnterState();
    }

    void Start()
    {
        /******************* MOVEMENT *******************/

        // Lock cursor to the middle of the screen and hide it.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Constraints to ensure that the Rigidbody doesn't react
        // to rotation, in case there is one. This is because rotation is
        // being manually handled.
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.freezeRotation = true;
    }

    void Update()
    {
        HandleRotation();

        // Call the update method for the current state.
        _currentState.UpdateState();
    }

    void OnGUI()
    {
        _currentState.OnGUIState();
    }


    /******************* MOVEMENT METHODS *******************/

    public void HandleInput()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;

        Vector3 movement = new(deltaX, 0, deltaZ);

        // Clamp diagonal movement
        movement = Vector3.ClampMagnitude(movement, _speed);

        // Apply gravity after X and Z have been clamped
        movement.y = _gravity;

        movement *= Time.deltaTime;

        // Transform movement from local to global coordinates
        movement = transform.TransformDirection(movement);

        _controller.Move(movement);
    }

    public void HandleRotation()
    {
        // Rotate player capsule upon the Y axis (Yaw)
        transform.Rotate(0, Input.GetAxis("Mouse X") * _sensitivityHor, 0);

        // Set Pitch about Y axis
        _verticalRot -= Input.GetAxis("Mouse Y") * _sensitivityVert;
        _verticalRot = Mathf.Clamp(_verticalRot, _minVert, _maxVert);

        float horizontalRot = transform.localEulerAngles.y;

        // Update rotation
        _cameraTransform.localEulerAngles = new Vector3(
            _verticalRot, horizontalRot, 0);
    }


    /******************* WEAPON METHODS *******************/

    public void Shoot()
    {
        // Left click
        if (Input.GetMouseButtonDown(0))
        {
            // Create a point at the middle of the viewport
            Vector3 point = new(_cam.pixelWidth / 2, _cam.pixelHeight / 2, 0);

            // Create a ray to the created point
            Ray ray = _cam.ScreenPointToRay(point);

            // Check if the created ray collided with any geometry
            // RaycastHit is a data structure to record information about
            // the ray collision
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Retrieve GameObject ray collided with.
                GameObject hitObj = hit.transform.gameObject;
                ReactiveTarget target = hitObj.GetComponent<ReactiveTarget>();

                if (target != null)
                    target.ReactToHit();
                else
                    StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }

    public void RenderAim()
    {
        // Size of the rectangular GUI that will contain the text.
        int size = 12;

        // Position of the text. Note that subtracting the scaled size will
        // ensure that the star is centered.
        float posX = _cam.pixelWidth / 2 - size / 4;
        float posY = _cam.pixelHeight / 2 - size / 2;

        // Change the color of the GUI's contents to red.
        GUI.contentColor = Color.red;

        // Render a label that defines a position and the text it contains.
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    IEnumerator SphereIndicator(Vector3 pos)
    {
        // Create and place a sphere where the hit collided.
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }


    /******************* PLAYER PROPERTIES *******************/
    public void Hurt(int damage)
    {
        Health -= damage;
    }
}
