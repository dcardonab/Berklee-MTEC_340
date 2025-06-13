using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float _launchForce = 5.0f;
    [SerializeField] private float _paddleInfluence = 0.4f;
    [SerializeField] private float _ballSpeedIncrement = 1.1f;

    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        ResetBall();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            if (!Mathf.Approximately(other.rigidbody.linearVelocityY, 0.0f))
            {
                // Compute new direction based on a weighted sum, giving different priorities to the
                // ball and the paddle. We use a one-minus to get the total sum of the weights to be 1.
                Vector2 direction = _rb.linearVelocity * (1 - _paddleInfluence)
                                    + other.rigidbody.linearVelocity * _paddleInfluence;

                // Apply new direction while maintaining the incoming magnitude.
                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized;
            }
            
            // Apply a small speed increase
            _rb.linearVelocity *= _ballSpeedIncrement;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScoreZone"))
        {
            ResetBall();
        }
    }

    void ResetBall()
    {
        // Stop rigidbody motion and reposition ball to the center
        _rb.linearVelocity = Vector2.zero;
        transform.position = Vector3.zero;
        
        // Compute random 2D direction, and normalize in range -1...1
        Vector2 direction = new Vector2(
            GetNonZeroRandomFloat(),
            GetNonZeroRandomFloat()
        ).normalized;
        
        // Apply force to normalized vector as an impulse, which behaves as a PING
        _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);
    }

    float GetNonZeroRandomFloat(float min = -1.0f, float max = 1.0f)
    {
        float num;

        do
        {
            num = Random.Range(min, max);
        } while (Mathf.Approximately(num, 0.0f));

        return num;
    }
}
