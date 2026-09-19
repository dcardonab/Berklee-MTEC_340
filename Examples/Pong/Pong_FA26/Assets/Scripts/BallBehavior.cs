using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float _launchForce = 7.0f;
    [SerializeField] private float _speedIncrement = 1.1f;
    
    [SerializeField] private float _paddleInfluence = 0.4f;
    
    Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        ResetBall();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            if (!Mathf.Approximately(collision.rigidbody.linearVelocityY, 0.0f))
            {
                Debug.Log("Collision with paddle!!!");
                
                // We compute direction using a weighted sum, where the weights
                // use a one-minus to be determined
                Vector2 direction = _rb.linearVelocity * (1.0f - _paddleInfluence)
                                    + collision.rigidbody.linearVelocity * _paddleInfluence;
                
                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized * _speedIncrement;
            }    
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ResetBall();
    }

    private void ResetBall()
    {
        // Stop the ball
        _rb.linearVelocity = Vector2.zero;
        
        // Teleport the ball to the middle of the screen
        transform.position = Vector3.zero;
        
        // Compute a new random direction
        Vector2 direction = Random.insideUnitCircle.normalized;
        
        // Launch ball in the computed direction with the specified force
        _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);
    }
}
