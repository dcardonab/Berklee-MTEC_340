using UnityEditor.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PaddleMovement : MonoBehaviour
{
    private float _direction = 0.0f;

    [SerializeField] private KeyCode _upDirection;
    [SerializeField] private KeyCode _downDirection;

    private Rigidbody2D _rb;

    void Start()
    {
        // Get a reference to the Rigidbody
        _rb = GetComponent<Rigidbody2D>();
        
        // Initialize attributes in case they weren't set in the Inspector
        _rb.linearDamping = 0.0f;
        _rb.angularDamping = 0.0f;
        _rb.gravityScale = 0.0f;

        // Assign random color to each paddle
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int index = Random.Range(0, Utilities.Colors.Length);
        spriteRenderer.color = Utilities.Colors[index];
    }

    void FixedUpdate()
    {
        // Apply movement using the Linear Velocity attribute of the Rigidbody
        _rb.linearVelocityY = _direction * GameBehavior.Instance.PaddleSpeed;
    }
    
    void Update()
    {
        // Define direction based on player input
        _direction = 0.0f;

        if (GameBehavior.Instance.CurrentState == Utilities.GameState.Play)
        {
            if (Input.GetKey(_upDirection)) _direction += 1.0f;
            if (Input.GetKey(_downDirection)) _direction -= 1.0f;
        }
    }
}
