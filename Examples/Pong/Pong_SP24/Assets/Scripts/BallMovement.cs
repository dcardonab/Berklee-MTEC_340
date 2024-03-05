using UnityEngine;

public class BallMovement : MonoBehaviour
{
    float _speed;

    int _xDir;
    int _yDir;

    [SerializeField] float _xLimit = 10.0f;
    float _yLimit;


    void Start()
    {
        Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        
        _yLimit = Utilities.SetYLimit(cam, renderer);

        ResetBall();
    }

    void Update()
    {
        if (GameBehavior.Instance.State == GameBehavior.GameState.Play) {
            // Update position
            transform.position += new Vector3(_speed * _xDir, _speed * _yDir, 0.0f) * Time.deltaTime;
            
            // Revert position on Y axis limits
            if (Mathf.Abs(transform.position.y) >= _yLimit)
                _yDir *= -1;

            if (Mathf.Abs(transform.position.x) >= _xLimit) {
                GameBehavior.Instance.ScorePoint(transform.position.x > 0 ? 0 : 1);
                ResetBall();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Paddle")) {
            _xDir *= -1;
            _speed += GameBehavior.Instance.BallSpeedIncrement;
        }
    }

    void ResetBall() {
        // Reset position of the ball
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        // Randomize direction in both X and Y axes
        // Ternary operator:
        //      condition ? passing : failing
        _xDir = Random.Range(0.0f, 1.0f) >= 0.5f ? 1 : -1;
        _yDir = Random.Range(0.0f, 1.0f) >= 0.5f ? 1 : -1;

        _speed = GameBehavior.Instance.InitBallSpeed;
    }
}
