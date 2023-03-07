using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_v1 : MonoBehaviour
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

        _spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        /*
         * The parallax effect is the offset coefficient applied to the object.
         * By subtracting that offset from 1, we retrieve the position of the
         * object at a given point in time. For this, we need to make sure that
         * the parallax effect values we provide are between 0 and 1.
         */
        float temp = _cam.transform.position.x * (1 - _parallaxEffect);

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
        if (temp > _startPosX + _spriteLength)
            // Apply the entire length of the sprite to the start position.
            _startPosX += _spriteLength;
        else if (temp < _startPosX - _spriteLength)
            _startPosX -= _spriteLength;
    }
}
