using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class BallBehavior : MonoBehaviour
{
    [Header("Ball Properties")]
    [SerializeField] private float _launchForce = 7.0f;
    [SerializeField, Range(1.0f, 2.0f)] private float _speedIncrement = 1.1f;

    [SerializeField, Range(0.0f, 1.0f)] private float _steepnessThreshold = 0.25f;
    
    [SerializeField, Range(0.0f, 1.0f)] private float _paddleInfluence = 0.4f;
    
    private Rigidbody2D _rb;
    private AudioSource _source;

    [Header("Audio Properties")]
    [SerializeField] private AudioClip _wallHit;
    [SerializeField] private AudioClip _paddleHit;
    [SerializeField] private AudioClip _scorePoint;
    
    [SerializeField] private AudioResource _wallAudioContainer;
    
    void Start()
    {        
        _rb = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();

        ResetBall();
    }

    void Update()
    {
        _rb.simulated = GameBehavior.Instance.State == Utilities.GameState.Play;
    }

    // void OnDestroy()
    // {
    //     GameBehavior.Instance.ResetPoint();
    // }

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
                
                direction.Normalize();
                
                CheckSteepness(ref direction);
                
                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction * _speedIncrement;
            }
            
            _source.PlayOneShot(_paddleHit);
        }
        else
        {
            _source.pitch = Random.Range(0.9f, 1.1f);
            _source.volume = Random.Range(0.8f, 1.0f);
            
            _source.resource = _wallAudioContainer;
            _source.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScoreArea"))
        {
            GameBehavior.Instance.ScorePoint(transform.position.x < 0 ? 1 : 0);
            
            // Monophonic-like behavior
            _source.clip = _scorePoint;
            _source.Play();

            Invoke(nameof(DestroyBall), _source.clip.length + 0.5f);
        }
    }

    private void CheckSteepness(ref Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < _steepnessThreshold)
        {
            direction.x += 0.5f * Mathf.Sign(direction.x);
            direction.Normalize();
        }
    }

    private void DestroyBall()
    {
        Destroy(gameObject);
    }

    private void ResetBall()
    {
        // // Stop the ball
        // _rb.linearVelocity = Vector2.zero;
        //
        // // Teleport the ball to the middle of the screen
        // transform.position = Vector3.zero;
        
        // Compute a new random direction
        Vector2 direction = Random.insideUnitCircle.normalized;
        
        CheckSteepness(ref direction);
        
        // Launch ball in the computed direction with the specified force
        _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);
    }
}
