using UnityEngine;


// The parallax effect is based on depth perception. As the eye/camera moves,
// the further an object is, the less its perceived motion will be.
public class Parallax : MonoBehaviour
{
    // Movement along a given axis will be based on a displacement distance
    // applied to an object's intial value.
    float _startPosX;

    /*
     * The amount of parallax applied to an object is based on a coefficient
     * applied to the camera desired axis every LateUpdate(). This coefficient
     * can have a specified value or it may depend on the object's Z position.
     * 
     * When working based on the Z axis, an additional scaling coefficient is
     * useful to control the parallax scrolling range. This is particularly
     * important to ensure that the parallax effect value is between 0 and 1.
     * This is an important consideration for implementing infinite scrolling.
     * 
     * A parallax effect of 0 will move objects at the same rate as the camera,
     * which means that those objects are in the foreground. As the parallax
     * value increases, the object's scrolling will decrease, implying distance
     * from the camera.
     */
    [SerializeField] float _parallaxEffect;
    [SerializeField] bool _distanceBased = true;
    [SerializeField] float _parallaxScaling = 0.1f;

    // The motion will be relative to the camera's position.
    GameObject _cam;

    // The length will be used to implement infinite background.
    float _spriteLength;

    private void Start()
    {
        // Retrieve the camera and the object's initial position.
        _cam = GameObject.Find("Main Camera");
        _startPosX = transform.position.x;

        if (_distanceBased)
            _parallaxEffect = transform.position.z * _parallaxScaling;

        // Retrieve the sprite renderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.tileMode = SpriteTileMode.Continuous;
        _spriteLength = spriteRenderer.bounds.size.x;


        // Scale the sprite sideways. Since the sprite's Draw Mode is set to
        // Tiled, it will be duplicated as its size increases.
        Vector2 scaleSprite = new(3, 1);
        spriteRenderer.size *= scaleSprite;
    }

    private void LateUpdate()
    {
        /*
         * Apply the parallax effect to the camera's X position. This multiplier
         * will cause the motion to be less than the movement of the actual
         * camera. This makes the background lag in relation to the camera.
         * The distance will be a larger value when the number is further away,
         * given that the parallax effect is greater. More distance will result
         * in more displacement from their original position in relation to the
         * camera, meaning that their perceived motion will be less in relation
         * to the camera.
         */
        float distance = _cam.transform.position.x * _parallaxEffect;

        transform.position = new(
            _startPosX + distance,
            transform.position.y,
            transform.position.z
        );

        // Check if the camera is going to move beyond the object's bounds.
        // If yes, displace the sprite to create infinite scrolling.
        float deltaX = _cam.transform.position.x - transform.position.x;
        if (Mathf.Abs(deltaX) >= _spriteLength)
            _startPosX += deltaX > 0 ? _spriteLength : -_spriteLength;
    }
}
