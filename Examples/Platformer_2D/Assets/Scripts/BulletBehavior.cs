using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] float _speed = 20.0f;
    [SerializeField] Rigidbody2D _rb;   // Assigned via the inspector

    float _initPos;
    float _destroyDistance = 20.0f;
    
    void Start()
    {
        _initPos = transform.position.x;
        _rb.linearVelocity = transform.right * _speed;
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - _initPos) > _destroyDistance)
            Destroy(gameObject);
    }
}
