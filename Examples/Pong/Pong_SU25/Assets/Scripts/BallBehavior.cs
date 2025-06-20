using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        ResetBall();
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
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScoreZone"))
        {
            GameBehavior.Instance.ScorePoint(transform.position.x < 0 ? 2 : 1);
            ResetBall();
        }
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
