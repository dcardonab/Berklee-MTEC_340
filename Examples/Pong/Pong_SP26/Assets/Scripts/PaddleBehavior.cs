using System;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    
    [SerializeField] private KeyCode _upDirection = KeyCode.W;
    [SerializeField] private KeyCode _downDirection = KeyCode.S;
    
    // The preceeding undescore tells us this is a private member variable
    private Rigidbody2D _rb;
    private float _direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityY = _direction * _speed;
    }

    void Update()
    {
        _direction = 0.0f;

        if (GameBehavior.Instance.GameMode == Utilities.GameState.Play)
        {
            if (Input.GetKey(_upDirection))
            {
                _direction += 1.0f;
            }

            if (Input.GetKey(_downDirection))
            {
                _direction -= 1.0f;
            }
        }
    }
}
