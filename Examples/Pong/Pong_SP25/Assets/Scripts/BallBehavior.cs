using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private float _speed;
    
    private int _xDir;
    private int _yDir;

    public float XLimit = 12.0f;
    public float YLimit = 4.8f;

    private AudioSource _source;
    [SerializeField] private AudioClip _wallHit;
    [SerializeField] private AudioClip _paddleHit;
    [SerializeField] private AudioClip _score;
    
    void Start()
    {
        _source = GetComponent<AudioSource>();
        
        ResetBall();
    }
    
    void Update()
    {
        if (Mathf.Abs(transform.position.y) >= YLimit)
        {
            // Manually reposition the ball when exceed the bounds of the board
            transform.position = new Vector3(
                transform.position.x,                       // X
                Mathf.Sign(transform.position.y) * YLimit,  // Y
                transform.position.z                        // Z
            );
            
            _yDir *= -1;

            _source.clip = _wallHit;
            _source.Play();
        }

        if (Mathf.Abs(transform.position.x) >= XLimit)
        {
            _source.clip = _score;
            _source.Play();
            
            ResetBall();
        }
        
        transform.position += new Vector3(_speed * _xDir, _speed * _yDir, 0) * Time.deltaTime;
    }

    void ResetBall()
    {
        transform.position = Vector3.zero;

        // value = condition ? pass : fail
        _xDir = Random.value > 0.5f ? 1 : -1;
        _yDir = Random.value > 0.5f ? 1 : -1;

        _speed = GameBehavior.Instance.InitBallSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            _speed *= GameBehavior.Instance.BallSpeedIncrement;

            _source.clip = _paddleHit;
            _source.Play();
            
            _xDir *= -1;
        }
    }
}
