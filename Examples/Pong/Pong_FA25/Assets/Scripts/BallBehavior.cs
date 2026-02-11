using System;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float _launchForce = 5.0f;

    [SerializeField] private float _paddleInfluence = 0.4f;

    [SerializeField] private AudioResource _scorePoint;
    [SerializeField] private AudioResource _paddleHit;
    [SerializeField] private AudioResource _wallHit;
    
    private Rigidbody2D _rb;
    private AudioSource _source;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();
        
        ResetBall();

        StartCoroutine(TremoloAlarm(0.5f));
    }

    IEnumerator TremoloAlarm(float rate) {
        while(_playerSpotted) {
            // On
            _source.volume = 1.0f;
            yield return new WaitForSeconds(rate);

            // off
            _source.volume = 0.0f;
            yield return new WaitForSeconds(rate);
        }
    }

    private void Update()
    {
        _rb.simulated = Manager.Instance.State != Utilities.GameState.Pause;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            if (!Mathf.Approximately(other.rigidbody.linearVelocity.y, 0.0f))
            {
                // Calculate new direction based on a weighted sum and a one-minus
                Vector2 direction = _rb.linearVelocity * (1 - _paddleInfluence)
                                    + other.rigidbody.linearVelocity * _paddleInfluence;
                
                // Apply new direction to the ball
                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized;
            }
            
            // Apply speed increment
            _rb.linearVelocity *= Manager.Instance.BallSpeedMultiplier;

            _source.resource = _paddleHit;
        }
        else
            _source.resource = _wallHit;
        
        _source.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Manager.Instance.ScorePoint(transform.position.x > 0 ? 1 : 2);

        _source.resource = _scorePoint;
        _source.Play();
        
        ResetBall();
    }

    void ResetBall()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Utilities.Colors[Random.Range(0, Utilities.Colors.Count)];
        
        // Stop the ball
        _rb.linearVelocity = Vector2.zero;
        
        // Recenter ball
        transform.position = Vector3.zero;
        
        // Compute new direction
        Vector2 direction = new Vector2(
            Utilities.GetNonZeroRandomFloat(),
            Utilities.GetNonZeroRandomFloat()
        ).normalized;
        
        // Ping the ball
        _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);
    }
}
