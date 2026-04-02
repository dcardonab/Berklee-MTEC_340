using UnityEngine;

public class Wandering : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _obstacleRange = 5.0f;

    [SerializeField] private float _sphereRadius = 0.75f;

    private bool _isAlive;

    public bool IsAlive
    {
        get => _isAlive;
        set => _isAlive = value;
    }
    
    void Start()
    {
        IsAlive = true;
    }

    void Update()
    {
        if (IsAlive)
        {
            // Move forward
            transform.Translate(0.0f, 0.0f, _speed * Time.deltaTime);
            
            Ray ray = new(transform.position, transform.forward);

            if (Physics.SphereCast(ray, _sphereRadius, out RaycastHit hit))
            {
                // When close enough to an obstacle or entity, rotate
                if (hit.distance < _obstacleRange)
                {
                    float theta = Random.Range(-135.0f, 135.0f);
                    transform.Rotate(0.0f, theta, 0.0f);
                }
            }
        }
    }
}
