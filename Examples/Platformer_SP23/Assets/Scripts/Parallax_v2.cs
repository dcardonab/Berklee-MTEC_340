using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_v2 : MonoBehaviour
{
    /*
     * Intial position of the object. This is important given that the movement
     * along the desired axis will be based on a computed distance that will be
     * added/subtracted from this value.
     */
    float _startPosX;

    /*
     * How much parallax will be applied to the object is based on a coefficient
     * that will be applied based on the camera's X position every Update().
     * 
     * This may be assigned as a specific value, or it may be dependent up the
     * object's Z position. This is logical given that the further away objects
     * are, the less their perceived motion will be. When basic motion on the
     * Z axis, a scaling coefficient may be used to control the parallax
     * scrolling range. This is especially useful for making sure that the
     * parallax effect results in a value between 0 and 1, which is important
     * for implementing infinite scrolling.
     * 
     * A parallax effect of 0 will move objects at the same rate as the camera,
     * which means that those objects are in the foreground.
     * The scrolling will be slower as the parallax value increase, implying
     * distance from the camera.
     */
    [SerializeField] float _parallaxEffect;
    [SerializeField] bool _distanceBased = true;
    [SerializeField] float _parallaxScaling = 0.1f;

    /*
     * Scale the sprite sideways. Since the sprite is set to Tiled rendering,
     * it will be duplicated when its size in the X axis is updated in the
     * Start() method.
     */
    Vector2 _scaleSprite = new(3, 1);

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
        _spriteLength = spriteRenderer.bounds.size.x;

        spriteRenderer.size *= _scaleSprite;
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

        //// Check if the camera is going to move beyond the object's bounds.
        float deltaX = _cam.transform.position.x - transform.position.x;
        if (Mathf.Abs(deltaX) >= _spriteLength)
            _startPosX += deltaX > 0 ? _spriteLength : -_spriteLength;
    }
}
