using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    [Header("Movement Attributes")]
    
    [SerializeField, Range(1.0f, 10.0f)] private float _speed = 5.0f;
    [SerializeField, Range(2.0f, 5.0f)] private float _runBoost = 3.0f;
    
    [SerializeField] private float _gravity = -9.81f;
    
    private float _verticalVelocity;
    [SerializeField, Range(5.0f, 20.0f)] private float _jumpVelocity = 15.0f; 

    private CharacterController _controller;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // transform.Translate(
        //     Input.GetAxis("Horizontal") * _speed * Time.deltaTime,
        //     0,
        //     Input.GetAxis("Vertical") * _speed * Time.deltaTime
        // );

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed += _runBoost;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed -= _runBoost;
        }

        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;
        
        Vector3 movement = new(deltaX, 0.0f, deltaZ);

        // Clamp diagonal movement
        movement = Vector3.ClampMagnitude(movement, _speed);
        
        // Jumping behavior
        if (_controller.isGrounded)
        {
            _verticalVelocity = _gravity;

            if (Input.GetButtonDown("Jump"))
            {
                _verticalVelocity = _jumpVelocity;
            }
        }
        else
        {
            _verticalVelocity += _gravity * 3.0f * Time.deltaTime;
        }
        
        movement.y = _verticalVelocity;

        movement *= Time.deltaTime;

        // Convert world vector to local space.
        movement = transform.TransformDirection(movement);
        
        // Apply movement using the CharacterController component.
        // CharacterController expects coordinates in world space.
        _controller.Move(movement);
    }
}
