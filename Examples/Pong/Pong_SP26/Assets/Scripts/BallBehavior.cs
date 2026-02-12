using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float _launchForce = 3.0f;
    [SerializeField] private float _paddleInfluence = 0.3f;
    [SerializeField] private float _speedMultiplier = 1.1f;
    
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        Vector2 direction = Random.insideUnitCircle;

        // Abs calculated the absolute value and compares it against a threshold
        if (Mathf.Abs(direction.x) < 0.25f)
            // Sign returns 1 or -1 depending on whether the input is positive or negative
            direction.x += 0.5f * Mathf.Sign(direction.x);
        
        _rb.AddForce(direction.normalized * _launchForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            // This will execute when the paddle IS moving
            if (!Mathf.Approximately(other.rigidbody.linearVelocity.y, 0.0f))
            {
                // Weighted sum and one-minus
                Vector2 direction = _rb.linearVelocity * (1.0f - _paddleInfluence)
                                    + other.rigidbody.linearVelocity * _paddleInfluence;

                // Magnitude is the length of a vector, and we use it to maintain the same speed.
                // Normalization allows the length of the direction to always be 1.
                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized;
            }
            
            _rb.linearVelocity *= _speedMultiplier;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Score a point through the game manager
        GameBehavior.Instance.Score();
        
        // Remove the ball that's in play from the game
        Destroy(gameObject);
    }
}
