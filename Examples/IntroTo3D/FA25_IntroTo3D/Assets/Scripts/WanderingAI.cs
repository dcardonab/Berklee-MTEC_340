using UnityEngine;
using Random = UnityEngine.Random;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _obstacleRange = 5.0f;

    private readonly float _sphereRadius = 0.75f;

    private bool _isAlive;

    public bool IsAlive
    {
        get => _isAlive;
        set => _isAlive = value;
    }

    [SerializeField] private GameObject _fireballPrefab;
    [HideInInspector] public GameObject _fireball;
    
    void Start()
    {
        IsAlive = true;
    }

    void Update()
    {
        if (IsAlive)
        {
            transform.Translate(0.0f, 0.0f, _speed * Time.deltaTime);
            
            Ray ray = new(transform.position, transform.forward);

            if (Physics.SphereCast(ray, _sphereRadius, out RaycastHit hit))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(
                            _fireballPrefab,
                            transform.TransformPoint(Vector3.forward * 1.5f),
                            transform.rotation
                        );
                    }
                }
                
                if (hit.distance < _obstacleRange && !hit.transform.CompareTag("Fireball"))
                {
                    float theta = Random.Range(-110.0f, 110.0f);
                    transform.Rotate(0.0f, theta, 0.0f);
                }
            }
        }
    }
}
