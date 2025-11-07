using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Scripts/FPS Input")]
public class FPSInput : MonoBehaviour
{
    [Header("Movement Attributes")]
    [Range(1.0f, 10.0f)]
    [SerializeField] float _speed = 5.0f;
    [SerializeField] float _gravity = -9.8f;
    
    CharacterController _controller;
    
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
        
        // Gather input info
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;
        
        // Create movement vector
        Vector3 movement = new(deltaX, 0.0f, deltaZ);

        // Clamp diagonal movement
        movement = Vector3.ClampMagnitude(movement, _speed);
        
        // Apply gravity after X and Z have been clampedx
        movement.y = _gravity;
        
        // Consider frame rate
        movement *= Time.deltaTime;
        
        // Convert movement vector to the rotation of the player
        movement = transform.TransformDirection(movement);

        // Move!
        _controller.Move(movement);
    }
}
