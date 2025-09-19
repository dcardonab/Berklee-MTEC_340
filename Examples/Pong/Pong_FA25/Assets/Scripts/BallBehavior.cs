using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float _launchForce = 5.0f;

    [SerializeField] private float _paddleInfluence = 0.4f;
    
    private Rigidbody2D _rb;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        Vector2 direction = new Vector2(
            GetNonZeroRandomFloat(),
            GetNonZeroRandomFloat()
        ).normalized;
        
        _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            if (!Mathf.Approximately(other.rigidbody.linearVelocity.y, 0.0f))
            {
                Vector2 direction = _rb.linearVelocity * (1 - _paddleInfluence)
                                    + other.rigidbody.linearVelocity * _paddleInfluence;

                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized;
            }
        }
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
