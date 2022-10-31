using UnityEngine;

public class Ball : MonoBehaviour
{
    /*************************************************************************/
    // Boundaries to trigger collisions
    public float yEdge;
    public float xBound;

    /*************************************************************************/
    // Rigidbody variables
    private Rigidbody2D rb2D;
    private Vector2 velocity;

    /*************************************************************************/
    // Audio
    public AudioClip s_WallHit;
    public AudioClip s_PaddleHit;
    public AudioClip s_Death;

    // The `m_` prefix is a convention to declare member object.
    public AudioSource m_AudioSource;


    /*************************************************************************/
    // MonoBehaviour Methods
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (GameBehavior.Instance.State == "Play")
        {
            rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);

            if (Mathf.Abs(rb2D.position.y) >= yEdge)
                WallCollision();

            if (Mathf.Abs(rb2D.position.x) >= xBound)
                Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Revert X direction.
            velocity.x *= -1;

            // Apply speed increment to each vector component
            velocity.x = IncrementSpeed(velocity.x);
            velocity.y = IncrementSpeed(velocity.y);

            AudioManager.Instance.PlaySound(s_PaddleHit, m_AudioSource);
        }
    }

    /*************************************************************************/
    // Other Methods
    void Death()
    {
        // Check what player scored based on the ball's position.
        StartCoroutine(GameBehavior.Instance.UpdateScore(rb2D.position.x > 0 ? 1 : 2));

        AudioManager.Instance.PlaySound(s_Death, m_AudioSource);
    }

    private float IncrementSpeed(float axis)
    {
        axis += axis > 0 ? GameBehavior.Instance.speedIncrement : -GameBehavior.Instance.speedIncrement;
        return axis;
    }

    public void ResetBall()
    {
        // Center ball
        rb2D.MovePosition(new Vector2(0, 0));

        // Initialize ball velocity, setting direction randomly.
        velocity = new Vector2(
            GameBehavior.Instance.m_initBallSpeed * (Random.Range(0f, 1f) < 0.5 ? 1 : -1),
            GameBehavior.Instance.m_initBallSpeed * (Random.Range(0f, 1f) < 0.5 ? 1 : -1)
        );
    }

    private void WallCollision()
    {
        // Revert Y direction.
        velocity.y *= -1;

        // Update position to avoid a bug that keeps the ball bound to the wall.
        rb2D.MovePosition(new Vector2(
            rb2D.position.x,
            rb2D.position.y > 0 ? yEdge - 0.01f : -yEdge + 0.01f
        ));

        AudioManager.Instance.PlaySound(s_WallHit, m_AudioSource);
    }
}
