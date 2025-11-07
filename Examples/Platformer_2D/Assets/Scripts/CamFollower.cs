using Unity.VisualScripting;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    private Transform _target;

    // Offset so the player isn't centered on the screen, but a bit lower.
    [SerializeField] float _camOffsetY = 1.0f;

    // Smoothing variables
    Vector3 _velocity = Vector3.zero;
    [SerializeField] float _smoothTime = 0.25f;

    void Awake()
    {
        _target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        /*
         * The camera will follow the player. This behavior is declared in
         * LateUpdate so that it takes place after the player's new position has
         * been resolved. Note that the X and Y positions are obtained from
         * the player's position, but the Z position must be the camera's.
         */
        Vector3 targetPosition = new(
            _target.position.x,
            _target.position.y + _camOffsetY,
            transform.position.z
        );
        
        transform.position = Vector3.SmoothDamp(
            transform.position, targetPosition, ref _velocity, _smoothTime
        );
    }
}
