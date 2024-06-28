using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] KeyCode _upDirection;
    [SerializeField] KeyCode _downDirection;
    
    float _yLimit;

    private void Start()
    {
        _yLimit = GameBehavior.Instance.CalculateYLimit(gameObject);
    }

    void Update()
    {
        if (GameBehavior.Instance.State == GameBehavior.StateMachine.Play)
        {
            // Use a float to save computational space
            float movement = 0f;
            
            // Apply speed to the movement
            if (Input.GetKey(_upDirection))
            {
                movement += GameBehavior.Instance.PaddleSpeed;
            }
            
            if (Input.GetKey(_downDirection))
            {
                movement -= GameBehavior.Instance.PaddleSpeed;
            }

            // Compute a new position based on the current position,
            // and add the movement scaled by delta time.
            Vector3 newPosition = transform.position + new Vector3(0, movement * Time.deltaTime, 0);
            
            // Clamp the position of the new vector to make sure that it is never beyond bounds.
            newPosition.y = Mathf.Clamp(newPosition.y, -_yLimit, _yLimit);

            // Replace the position by the computed position.
            // Note that we are NOT using += here, but fully overwriting the position.
            transform.position = newPosition;
        }
    }
}
