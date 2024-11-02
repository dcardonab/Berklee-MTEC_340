/*
 * The motion achieved in this script is camera-relative.
 * 
 * This means that movement direction of the player will be based
 * upon the camera's coordinate system and not the player's.
 * This is not an issue in FPS controllers given that the camera
 * is inside the player, meaning that left means the same for both.
 * However, with third-person controllers, the camera's left and
 * right might be different from the player's left and right.
 * 
 * When developing a third-person controller, it is worth considering
 * whether the input should be based on the player or the camera's
 * coordinate system.
 * 
 * Camera-relative controls came to be through experimentation,
 * where game designers concluded that this approach tends to result
 * in more intuitive and easy to understand controls.
 * 
 * Camera-relative controls is implemented in two steps:
 *     1. Rotate the player character to face the direction of the
 *        controls.
 *     2. Move the character forward.
 */

using UnityEngine;

// Require a CharacterController component on the object.
// If no CharacterController component has been attached, it will
// be automatically added.
[RequireComponent(typeof(CharacterController))]

// Place object in a given component bin.
[AddComponentMenu("Control Script/Relative FPS Movement")]

public class RelativeMovement : MonoBehaviour
{
    [SerializeField] Transform _target;

    [SerializeField] float _moveSpeed = 6.0f;
    [SerializeField] float _rotSpeed = 15.0f;

    [SerializeField] float _jumpSpeed = 15.0f;
    [SerializeField] float _gravity = -9.8f;
    [SerializeField] float _terminalVelocity = -20.0f;
    [SerializeField] float _minFall = -1.5f;

    float _vertSpeed;
    float _groundCheckDistance;
    ControllerColliderHit _contact;

    CharacterController _charController;

    // The Animator component is available to all game object that
    // can be animated.
    Animator _animator;

    private void Start()
    {
        /*
         * Initialize vertical speed. This is the value that will
         * control downward movement via applied gravity.
         * 
         * The minimum fall speed used as its initial value is a slight
         * downward component, which will make the character press down
         * against the ground while running around horizontally. This
         * allows running up and down on uneven terrain.
         */
        _vertSpeed = _minFall;

        /*
         * It is necessary to reduce the CharacterController radius for
         * the ground check of this script to work.
         */
        _charController = GetComponent<CharacterController>();
        _charController.radius = 0.4f;

        // Distance that determines when the player is grounded.
        // Since the numerator is greater than the denominator, this
        // code extends beyond the edges of the capsule.
        _groundCheckDistance =
            (_charController.height + _charController.radius) /
            _charController.height * 0.95f;

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Start with zero movement and add components progressively.
        // A default value is important in case the player isn't pressing
        // any buttons.
        Vector3 movement = Vector3.zero;

        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        // Move player only when keys are pressed
        if (horInput != 0 || vertInput != 0)
        {
            /*
             * X and Z movement transformed relative to target.
             * 
             * The `right` property of a Transform can be used to obtain
             * the sideways direction of the target.
             * 
             * For the forward/backward direction, we can use the cross
             * product, which is a unique mathematical operation that can
             * be performed between two vectors that outputs a vector
             * that is perpendicular to the two input vectors.
             * 
             * The cross product can be performed between the retrieved
             * right direction and the `up` property of the Vector3
             * class, which returns a vector in the direction pointed
             * straight up from the ground.
             */
            Vector3 right = _target.right;
            Vector3 forward = Vector3.Cross(right, Vector3.up);

            /*
             * Get the combined movement vector by adding both
             * directional vectors.
             * 
             * Since the magnitude of these vectors is one, we can apply
             * speed by scaling the vector by the desired speed.
             * 
             * Then, limit the diagonal movement's magnitude to the same
             * speed by clamping the vector's components.
             */
            movement = (right * horInput) + (forward * vertInput);
            movement *= _moveSpeed;
            movement = Vector3.ClampMagnitude(movement, _moveSpeed);

            /*
             * Apply the movement direction as rotation to the player
             * character by converting the movement into a quaternion
             * and using the `LookRotation` method.
             * 
             * To smooth the rotation, use Lerp to linearly interpolate
             * between the player's rotation and the newly computed
             * rotation in a given time frame.
             * 
             * Lerp is an acronym for Linear Interpolation.
             * 
             * Slerp is another method provided in the Quaternion class
             * that may be better suited to slower turns. Slerp is an
             * acronym for Spherical Linear Interpolation.
             */
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(
                transform.rotation, direction, _rotSpeed * Time.deltaTime);
        }

        /*
         * The squared magnitude tends to be used for speed and distance
         * checks against a threshold that takes into account the square
         * magnitude. This is preferred over the actual magnitude since
         * it only performs the sum of the squares of the vector
         * components, without actually performing the square root
         * function, which is an expensive computation.
         */
        _animator.SetFloat("Speed", movement.sqrMagnitude);

        /*
         * JUMPING
         * 
         * The player can only jump while the player is grounded. There
         * are multiple approaches for achieving this.
         * 
         * CharacterController has an `isGrounded` property to check
         * if the player is on the ground. Internally, this value is
         * updated every frame and will return true if the bottom of
         * the character collided with anything on the previous frame.
         * 
         * Solely relying on collision detection below the character
         * causes player hovering issues, for instance when stepping
         * off of edges.
         * 
         * To solve this, downward ray casting can be used with a manual
         * grounded flag. The ray will be casted from the middle of the
         * player character, to the whole collider won't make contact.
         * 
         * The player won't slide off of steep slopes initially. For this
         * to work, the player has to slide off of slopes in response to
         * collisions against the bottom sides of the capsule collider.
         * 
         * This is done via the `OnControllerColliderHit` callback in the
         * CharacterController, which registers information about the
         * collision. From this data structure, we retrieve the normal,
         * which is a vector perpendicular to the colliding surface.
         * We can then compute the dot product between the movement and
         * the normal to move the player character.
         * 
         * The dot product is a mathematical operation between two vectors.
         * The range of the dot product, N to -N is based on multiplying
         * the magnitude of both vectors. The dot product will be N when
         * both vectors are pointing in the same direction, and -N means
         * that they both are pointing in opposite directions.
         * 
         * Note that the vertical component of the movement vector will
         * be different depending on whether the player is grounded or 
         * in the air.
         */

        // Raycast downwards to check for steep slopes and dropoff edges
        bool hitGround = false;
        if (_vertSpeed < 0 && Physics.Raycast(
                                  transform.position,
                                  Vector3.down,
                                  out RaycastHit hit))
            hitGround = hit.distance <= _groundCheckDistance;

        if (hitGround)
            if (Input.GetButtonDown("Jump"))
                _vertSpeed = _jumpSpeed;
            else
            {
                _vertSpeed = _minFall;
                _animator.SetBool("Jumping", false);
            }

        else
        {
            /*
             * Gravity is applied as acceleration, which will constantly
             * increase the velocity of an object while it free falls.
             * This results in an arched jump, which could be graphed as
             * a parabola.
             * 
             * Velocity is clamped once ir reaches the terminal velocity.
             */
            _vertSpeed += _gravity * 5 * Time.deltaTime;

            if (_vertSpeed < _terminalVelocity)
                _vertSpeed = _terminalVelocity;

            // This condition prevents immediately transitioning to the
            // jumping state right at the beginning of the level.
            if (_contact != null)
               _animator.SetBool("Jumping", true);

            // This will execute when raycasting didn't detect a
            // collision in range, but the collider might.
            if (_charController.isGrounded)
            {
                // Respond differently depending on whether the
                // player is facing the contact point or not.
                if (Vector3.Dot(movement, _contact.normal) < 0)
                    // If the direction of movement and the normal are
                    // opposite, meaning I'm going up the slope, push
                    // character downward.
                    movement = _contact.normal * _moveSpeed;
                else
                    // If the direction of movement and the normal are
                    // in the same direction, meaning I'm going down the
                    // slope, add contact normal resistance to movement.
                    movement += _contact.normal * _moveSpeed;
            }
        }

        /*
         * Assign the downward velocity (y-component) of the movement
         * vector, and then apply frame rate independent movement via
         * the `Move` method of the CharacterController. This will
         * apply both horizontal and vertical movement to the player.
         */
        movement.y = _vertSpeed;
        _charController.Move(movement * Time.deltaTime);
    }

    /// <summary> 
    /// Store collision data about the CharacterController in an external
    /// variable to use it in `Update`.
    /// </summary>
    /// <param name="hit"></param>
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;
    }
}
