using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _force = 5.0f;

    AudioSource _source;
    [Header("Audio Clips")]
    [SerializeField] AudioClip _wallCollision;
    [SerializeField] AudioClip _paddleCollision;
    [SerializeField] AudioClip _losePoint;
    [Space(5)]

    [Range(0.0f, 1.0f)]
    [SerializeField] float _paddleMovementInfluence = 0.5f;

    [SerializeField] float _xLimit = 12.0f;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();

        ResetBall();
    }

    void Update() {
        if (Mathf.Abs(transform.position.x) >= _xLimit) {
            GameBehavior.Instance.ScorePoint(transform.position.x > 0 ? 0 : 1);
            PlaySample(_losePoint);
            ResetBall();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Paddle")) {
            if (other.rigidbody.velocity.y != 0) {
                Vector2 direction = (_rb.velocity * (1 - _paddleMovementInfluence) +
                                     other.rigidbody.velocity * _paddleMovementInfluence
                        ).normalized;

                // 1.1 is a magic number. We do NOT like magic numbers.
                // Better approach is to implement it via the GameBehavior script.
                _rb.velocity = _rb.velocity.magnitude * direction * 1.1f;
            }

            PlaySample(_paddleCollision);
        }

        else {
            PlaySample(_wallCollision);
        }
    }

    void ResetBall() {
        _rb.velocity = Vector2.zero;

        transform.position = Vector3.zero;

        Vector2 direction = new Vector2(
            GetNonZeroRandomFloat(),
            GetNonZeroRandomFloat()
        ).normalized;

        _rb.AddForce(direction * _force, ForceMode2D.Impulse);
    }

    float GetNonZeroRandomFloat() {
        float num;
        do {
            num = Random.Range(-1.0f, 1.0f);
        } while (Mathf.Approximately(num, 0.0f));

        return num;
    }

    void PlaySample(AudioClip clip) {
        _source.clip = clip;
        _source.Play();             // Play interrupts previous sample.

        _source.PlayOneShot(clip);  // PlayOneShot plays sounds all the way through.
    }
}
