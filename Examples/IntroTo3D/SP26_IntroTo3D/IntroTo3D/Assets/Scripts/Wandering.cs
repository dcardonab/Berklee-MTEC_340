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

    [SerializeField] private GameObject _fireballPrefab;
    [HideInInspector] public GameObject Fireball;
    
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
                if (hit.transform.CompareTag("Player"))
                {
                    if (!Fireball)
                    {
                        Fireball = Instantiate(
                            _fireballPrefab,    // GameObject to instantiate
                            transform.TransformPoint(Vector3.forward * 1.5f),
                            transform.rotation
                        );
                    }
                }
                
                // When close enough to an obstacle or entity, rotate
                else if (hit.distance < _obstacleRange && !hit.transform.CompareTag("Fireball"))
                {
                    float theta = Random.Range(-135.0f, 135.0f);
                    transform.Rotate(0.0f, theta, 0.0f);
                }
            }
        }
    }
}
