using UnityEngine;

// Require a CharacterController component on the object.
// If no CharacterController component has been attached, it will
// be automatically added.
[RequireComponent(typeof(CharacterController))]

// Place object in a given component bin.
[AddComponentMenu("Control Script/FPS Input")]
    
public class FPSInput : MonoBehaviour
{
    [Header("Movement Attributes")]
    [Range(1.0f, 10.0f)]
    [SerializeField] float _speed = 6.0f;
    [SerializeField] float _gravity = -9.8f;

    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Moving the transform via the Translate method won't engage
        // collision detection.

        // transform.Translate(
        //    Input.GetAxis("Horizontal") * _speed * Time.deltaTime,
        //    0,
        //    Input.GetAxis("Vertical") * _speed * Time.deltaTime);

        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;
        
        Vector3 movement = new(deltaX, 0, deltaZ);
        
        // Clamp diagonal movement
        movement = Vector3.ClampMagnitude(movement, _speed);
        
        // Apply gravity after X and Z have been clamped
        movement.y = _gravity;
        
        movement *= Time.deltaTime;
        
        // Convert movement vector to rotation settings of player
        movement = transform.TransformDirection(movement);
        
        _controller.Move(movement);
    }
}
