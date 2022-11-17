using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    CharacterController _controller;

    // Movement sensitivity
    [SerializeField] float _speed = 12f;
    [SerializeField] float _jumpHeight = 3f;

    // Artificial gravity
    Vector3 _velocity;
    readonly float _gravity = -9.81f * 2;

    // Ground checking
    [SerializeField] Transform _groundCheck;
    float _groundDistance = 0.4f;
    public LayerMask _groundMask;
    bool _isGrounded;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // CheckSphere takes a transform's position,
        // the distance to a given layer mask,
        // and a layer mask
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        // Reset gravity if player is grounded
        if (_isGrounded && _velocity.y < 0)
            // Could be reset to 0, but -2 gives smoother results
            _velocity.y = -2f;

        // Get keyboard input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Create a vector using the gathered input
        // times the directional vectors
        Vector3 move = transform.right * x + transform.forward * z;

        // Apply vector
        _controller.Move(_speed * Time.deltaTime * move);

        // Jump input automatically maps to the space bar
        if (Input.GetButtonDown("Jump") && _isGrounded)
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);

        // Manual application of gravity
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    void LateUpdate()
    {
        // Teleport back to center if falling.
        if (transform.position.y < -3f)
        {
            // The CharacterController component won't allow
            // direct changes to the transform's position,
            // so it must be disabled to teleport.
            _controller.enabled = false;
            transform.position = new Vector3(0, 10f, 0);
            _controller.enabled = true;
        }
    }
}
