using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    /******************** Movement ********************/
    [SerializeField] float _speed = 5f;
    [SerializeField] float _jumpForce = 5f;

    // Used to flip the SpriteRenderer when rotating the player.
    SpriteRenderer _spriteRenderer;

    // Used to keep track of the direction in which the player is facing.
    bool _facingRight = true;

    private Rigidbody2D _body;
    private CapsuleCollider2D _collider;

    /******************** Powerup ********************/
    private Renderer _renderer;
    [SerializeField] Material MatStandard;
    [SerializeField] Material MatPowerUp;
    [SerializeField] readonly float _powerUpBoost = 3.0f;
    [SerializeField] readonly float _powerUpDuration = 10.0f;


    private void Awake()
    {
        // We will be applying movement to the player directly via the
        // Rigidbody2D and checking if we're grounded via the BoxCollider2D.
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // We will use the renderer to update the material applied to the player.
        // This will provide us with a material that indicates we are powered up.
        _renderer = GetComponent<Renderer>();
    }


    private void Update()
    {
        /********** Horizontal movement and gravity **********/

        // The horizontal axis will be -1, 0, or 1.
        // More info by going to "Edit > Project Settings > Input Manager"
        float deltaX = Input.GetAxis("Horizontal") * _speed;

        // When the player is moving in a given direction but facing in the
        // opposite direction, flip the direction by rotating the player.
        if ((deltaX > 0 && !_facingRight) || (deltaX < 0 && _facingRight))
            Flip();

        /*
         * There is no need to multiply by Time.deltaTime to achieve frame rate
         * independence. This is due to us not affecting position directly.
         * The velocity of the Rigidbody is inherently frame rate independent,
         * due to it being controlled by the physics engine. We are choosing to
         * update the Ridigbody2D (a physics component) as opposed to the
         * position so that Unity's built-in collision detection works.
         * 
         * The Y velocity of the Rigidbody is specified by the physics engine.
         * To change this value, go to "Edit > Project Settings > Physics 2D"
         */
        Vector2 movement = new(deltaX, _body.velocity.y);

        // Apply calculated movement to the Rigidbody2D via its velocity.
        _body.velocity = movement;


        /********** Jumping **********/

        // Retrieve corner edges of the collider
        Vector3 min = _collider.bounds.min; // Bottom left corner
        Vector3 max = _collider.bounds.max; // Top right corner

        // Create corners that will be used for evaluating the ground.
        // The offset will detect collisions against objects below the player.
        float groundDetectOffset = 0.1f;
        Vector2 corner1 = new(min.x, min.y - groundDetectOffset); // Bottom left
        Vector2 corner2 = new(max.x, min.y - groundDetectOffset); // Bottom right

        // OverlapArea method returns collider overlapping testing area.
        Collider2D groundCollision = Physics2D.OverlapArea(corner1, corner2);

        // This conditional expression will assign true or false to our bool.
        bool grounded = groundCollision != null;

        /*
         * If there is a collider underneath the player, then the player is
         * grounded and able to jump. If you wish your player to jump regardless
         * of whether they are touching the ground, you can disregard the
         * grounded portion of the code.
         * 
         * We will add an upward force in the "up" direction. This force
         * will be an "impulse", which is a suddent jolt, as opposed to a
         * continuously applied force.
         */
        if (grounded && Input.GetKeyDown(KeyCode.Space))
            _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Flip direction and SpriteRenderer.
    /// </summary>
    void Flip()
    {
        _facingRight = !_facingRight;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    /// <summary>
    /// This function will be triggered when picking up a coin. It will allow
    /// the player to move faster and jump higher for a given duration.
    /// </summary>
    /// <param name="start"></param>
    public void TogglePowerUp(bool start = true)
    {
        if (start)
        {
            StartCoroutine(ChangeMaterial());
            _speed += _powerUpBoost;
            _jumpForce += _powerUpBoost;
        }
        else
        {
            _speed -= _powerUpBoost;
            _jumpForce -= _powerUpBoost;
        }
    }

    /// <summary>
    /// This function is a coroutine. Coroutine functions have a return type
    /// of IEnumerator. Coroutines are used to simulate code that runs in
    /// parallel. The 'yield return' keyword exits the function for a given
    /// frame, and in the next one, the function will continue to execute from
    /// that point forward. There are various use cases for coroutines, such
    /// as skipping execution for one frame (yield return null), or skipping
    /// execution for a given duration.
    ///
    /// This example executes the latter, and as such, it is returning a Unity
    /// object called "WaitForSeconds()". This code will continue to execute
    /// frames until the duration specified as an argument has elapsed, at which
    /// time the function will continue to execute from the following line. 
    /// </summary>
    /// <returns></returns>
    IEnumerator ChangeMaterial()
    {
        // Ensure the beginning material is the power up material.
        _renderer.material = MatPowerUp;

        yield return new WaitForSeconds(_powerUpDuration * 0.5f);

        // Flickering every 500ms for the last second of the powerup.
        int flicker = 0;
        while (flicker < 4)
        {
            _renderer.material = flicker % 2 == 0 ? MatStandard : MatPowerUp;

            flicker++;

            yield return new WaitForSeconds(_powerUpDuration * 0.25f / 4);
        }

        // Reset the flicker property for next iteration.
        flicker = 0;

        // Flickering every 250ms for the last second of the powerup.
        while (flicker < 8)
        {
            _renderer.material = flicker % 2 == 0 ? MatStandard : MatPowerUp;

            flicker++;

            yield return new WaitForSeconds(_powerUpDuration * 0.25f / 8);
        }

        // Ensure the ending material is the standard material.
        _renderer.material = MatStandard;

        TogglePowerUp(false);
    }
}
