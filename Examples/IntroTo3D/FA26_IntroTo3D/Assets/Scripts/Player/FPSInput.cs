using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField, Range(1.0f, 20.0f)] private float _speed = 7.5f;
    [SerializeField] private float _gravity = -9.8f;
    
    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // // Transform-based movement will not trigger collisions.
        // transform.Translate(
        //     Input.GetAxis("Horizontal") * _speed * Time.deltaTime,
        //     0.0f,
        //     Input.GetAxis("Vertical") * _speed * Time.deltaTime
        // );

        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;
        
        Vector3 movement = new(deltaX, 0.0f, deltaZ);
        
        movement = Vector3.ClampMagnitude(movement, _speed);
        
        movement.y = _gravity;
        
        movement *= Time.deltaTime;
        
        movement = transform.TransformDirection(movement);
        
        _controller.Move(movement);
    }
}
