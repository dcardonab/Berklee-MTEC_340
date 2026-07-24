using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Game/FPS Input")]
public class FPSInput : MonoBehaviour
{
    [Header("Movement Attributes")]
    [SerializeField, Range(1.0f, 10.0f)] private float _speed = 5.0f;

    private CharacterController _controller;
    private float _gravity = -9.81f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // transform.Translate(
        //     Input.GetAxis("Horizontal") * Time.deltaTime * _speed,
        //     0,
        //     Input.GetAxis("Vertical") * Time.deltaTime * _speed
        // );
        
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;
        
        Vector3 movement = new(deltaX, 0, deltaZ);
        
        // Avoid faster movement when moving diagonally
        movement = Vector3.ClampMagnitude(movement, _speed);
        
        // Apply gravity after computing movement direction and speed
        movement.y = _gravity;
        
        movement *= Time.deltaTime;
        
        // Convert world vector to local space
        movement = transform.TransformDirection(movement);
        
        // Apply movement through the CharacterController
        _controller.Move(movement);
    }
}
