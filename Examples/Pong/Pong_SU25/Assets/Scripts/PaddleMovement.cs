using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PaddleMovement : MonoBehaviour
{
    private float _direction = 0.0f;

    [SerializeField] private KeyCode _upDirection;
    [SerializeField] private KeyCode _downDirection;

    private Rigidbody2D _rb;

    void Start()
    {
        // Get a reference to the Rigidbody
        _rb = GetComponent<Rigidbody2D>();
        
        // Initialize attributes in case they weren't set in the Inspector
        _rb.linearDamping = 0.0f;
        _rb.angularDamping = 0.0f;
        _rb.gravityScale = 0.0f;
    }

    void FixedUpdate()
    {
        // Apply movement using the Linear Velocity attribute of the Rigidbody
        _rb.linearVelocityY = _direction * GameBehavior.Instance.PaddleSpeed;
    }
    
    void Update()
    {
        // Define direction based on player input
        _direction = 0.0f;

        if (Input.GetKey(_upDirection)) _direction += 1.0f;
        if (Input.GetKey(_downDirection)) _direction -= 1.0f;
    }
}
