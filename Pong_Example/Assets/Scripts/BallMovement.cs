using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private float ballSpeed;

    public float yEdge;
    public float xBounds;

    private int xDir;
    private int yDir;

    public AudioClip collisionSound;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.State == "Play")
        {
            if (Mathf.Abs(transform.position.y) >= yEdge)
            {
                SwitchDirectionY();
                GameManager.Instance.PlaySound(collisionSound, 0.25f);
            }

            transform.position += new Vector3(
                xDir * ballSpeed * Time.deltaTime,
                yDir * ballSpeed * Time.deltaTime,
                0
            );

            if (Mathf.Abs(transform.position.x) >= xBounds)
            {
                GameManager.Instance.UpdateScore(transform.position.x > 0 ? 1 : 2);
                Reset();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            xDir *= -1;
            ballSpeed += GameManager.Instance.ballSpeedIncrement;
        }
    }

    private int SetDirection()
    {
        return Random.Range(0.0f, 1.0f) > 0.5f ? 1 : -1;
    }

    private void SwitchDirectionY()
    {
        // Reposition
        transform.position = new Vector3(
            transform.position.x, yEdge * yDir, 0
        );

        // Change direction
        yDir *= -1;
    }

    private void Reset()
    {
        GameManager.Instance.State = "Serve";

        GameManager.Instance.messagesGUI.text = "Press Enter";
        GameManager.Instance.messagesGUI.enabled = true;

        transform.position = new Vector3(0, 0, 0);

        ballSpeed = GameManager.Instance.initBallSpeed;

        xDir = SetDirection();
        yDir = SetDirection();
    }
}
