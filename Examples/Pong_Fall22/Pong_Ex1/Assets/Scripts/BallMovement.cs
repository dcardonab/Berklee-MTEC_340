using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float yEdge;
    public float xBounds;

    private Vector2 velocity;
    private Rigidbody2D rb2d;

    public AudioClip collisionSound;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.State == "Play")
        {
            rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);

            if (Mathf.Abs(rb2d.position.y) >= yEdge)
                WallCollision();

            if (Mathf.Abs(rb2d.position.x) >= xBounds)
                Death();
        }
    }

    private void Death()
    {
        GameManager.Instance.UpdateScore(rb2d.position.x > 0 ? 1 : 2);
        Reset();
    }

    private void WallCollision()
    {
        velocity.y *= -1;

        rb2d.MovePosition(new Vector2(
            rb2d.position.x,
            rb2d.position.y > 0 ? yEdge - 0.01f : -yEdge + 0.01f
        ));

        GameManager.Instance.PlaySound(collisionSound);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            velocity.x *= -1;

            velocity.x = IncrementSpeed(velocity.x);
            velocity.y = IncrementSpeed(velocity.y);

            GameManager.Instance.PlaySound(collisionSound);
        }
    }

    private float IncrementSpeed(float axis)
    {
        axis += axis > 0 ? GameManager.Instance.ballSpeedIncrement : -GameManager.Instance.ballSpeedIncrement;
        return axis;
    }

    private void Reset()
    {
        GameManager.Instance.State = "Serve";

        GameManager.Instance.messagesGUI.text = "Press Enter";
        GameManager.Instance.messagesGUI.enabled = true;

        transform.position = new Vector3(0, 0, 0);

        velocity = new Vector2(
            GameManager.Instance.initBallSpeed * (Random.Range(0.0f, 1.0f) > 0.5f ? 1 : -1),
            GameManager.Instance.initBallSpeed * (Random.Range(0.0f, 1.0f) > 0.5f ? 1 : -1)
        );
    }
}
