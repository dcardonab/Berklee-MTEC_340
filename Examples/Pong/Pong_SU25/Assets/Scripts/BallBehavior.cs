using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class BallBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _prevBallVelocity;
    private bool _isPaused = false;

    private AudioSource _source;

    [SerializeField] private AudioClip _wallHitClip;
    [SerializeField] private AudioClip _paddleHitClip;
    [SerializeField] private AudioClip _scoreClip;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();

        ResetBall();
    }

    private void Update()
    {
        // Check state
        if (GameBehavior.Instance.CurrentState == Utilities.GameState.Pause)
        {
            if (!_isPaused)
            {
                // Store velocity for use when returning to Play state
                _prevBallVelocity = _rb.linearVelocity;
                _rb.linearVelocity = Vector2.zero;
                
                _isPaused = true;   // Set flag
            }
        }
        else
        {
            if (_isPaused)
            {
                // Restore velocity
                _rb.linearVelocity = _prevBallVelocity;
                
                _isPaused = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            if (!Mathf.Approximately(other.rigidbody.linearVelocityY, 0.0f))
            {
                // Compute new direction based on a weighted sum, giving different priorities to the
                // ball and the paddle. We use a one-minus to get the total sum of the weights to be 1.
                Vector2 direction = _rb.linearVelocity * (1 - GameBehavior.Instance.PaddleInfluence)
                                    + other.rigidbody.linearVelocity * GameBehavior.Instance.PaddleInfluence;

                // Apply new direction while maintaining the incoming magnitude.
                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized;
            }
            
            // Apply a small speed increase
            _rb.linearVelocity *= GameBehavior.Instance.BallSpeedIncrement;

            PlaySound(_paddleHitClip);
        }
        else
        {
            PlaySound(_wallHitClip, pitchMax: 1.3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScoreZone"))
        {
            GameBehavior.Instance.ScorePoint(transform.position.x < 0 ? 2 : 1);
            ResetBall();
            
            PlaySound(_scoreClip, pitchMin: 0.9f, pitchMax: 1.1f);
        }
    }

    void PlaySound(AudioClip clip, float pitchMin = 0.8f, float pitchMax = 1.2f)
    {
        _source.clip = clip;
        _source.pitch = Random.Range(pitchMin, pitchMax);
        _source.Play();
    }

    void ResetBall()
    {
        // Stop rigidbody motion and reposition ball to the center
        _rb.linearVelocity = Vector2.zero;
        transform.position = Vector3.zero;
        
        // Compute random 2D direction, and normalize in range -1...1
        Vector2 direction = new Vector2(
            Utilities.GetNonZeroRandomFloat(),
            Utilities.GetNonZeroRandomFloat()
        ).normalized;
        
        // Apply force to normalized vector as an impulse, which behaves as a PING
        _rb.AddForce(direction * GameBehavior.Instance.InitBallForce, ForceMode2D.Impulse);
    }
}
