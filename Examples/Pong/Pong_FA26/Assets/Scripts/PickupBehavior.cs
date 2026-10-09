using System;
using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    [SerializeField, Range(1.0f, 100.0f)] private float _rotateSpeed = 20.0f; 
    
    private void Update()
    {
        transform.Rotate(0.0f, 0.0f, _rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D ballRB = other.GetComponent<Rigidbody2D>();

        if (ballRB)
        {
            GameBehavior.Instance.PowerUp(
                ballRB.linearVelocityX >= 0.0f ? 0 : 1
            );
        }
        
        Destroy(gameObject);
    }
}
