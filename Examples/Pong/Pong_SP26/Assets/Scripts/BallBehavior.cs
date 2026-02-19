using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float _launchForce = 3.0f;
    [SerializeField] private float _paddleInfluence = 0.3f;
    [SerializeField] private float _speedMultiplier = 1.1f;
    
    private Rigidbody2D _rb;

    private AudioSource _source;
    [SerializeField] private AudioClip _paddleHit;
    [SerializeField] private AudioClip _wallHit;
    [SerializeField] private AudioClip _scoreSound;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();
        
        Vector2 direction = Random.insideUnitCircle;

        // Abs calculated the absolute value and compares it against a threshold
        if (Mathf.Abs(direction.x) < 0.25f)
            // Sign returns 1 or -1 depending on whether the input is positive or negative
            direction.x += 0.5f * Mathf.Sign(direction.x);
        
        _rb.AddForce(direction.normalized * _launchForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        // if (GameBehavior.Instance.GameMode == Utilities.GameState.Play)
        // {
        //     _rb.simulated = true;
        // }
        // else
        // {
        //     _rb.simulated = false;
        // }

        _rb.simulated = GameBehavior.Instance.GameMode == Utilities.GameState.Play;
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
            _source.resource = _paddleHit;
        }
        else
        {
            _source.resource = _wallHit;
        }

        _source.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ternary operator - abbreviation of if-else
        // condition ? pass : failing
        
        // Score a point through the game manager
        GameBehavior.Instance.Score(transform.position.x > 0 ? 1 : 2);
        
        _source.PlayOneShot(_scoreSound);
        
        // Remove the ball that's in play from the game
        Destroy(gameObject, _scoreSound.length);
    }
}
