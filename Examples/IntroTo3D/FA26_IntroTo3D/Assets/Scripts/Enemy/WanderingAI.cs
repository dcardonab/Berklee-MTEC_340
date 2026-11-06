using UnityEngine;

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

    private GameObject _fireball;
    [SerializeField] private GameObject _fireballPrefab;
    
    private void Start()
    {
        IsAlive = true;
    }

    private void Update()
    {
        if (IsAlive)
        {
            transform.Translate(0.0f, 0.0f, _speed * Time.deltaTime);
            
            Ray ray = new(transform.position, transform.forward);

            if (Physics.SphereCast(ray, _sphereRadius, out RaycastHit hit, 50.0f))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    if (!_fireball)
                    {
                        _fireball = Instantiate(
                            _fireballPrefab,
                            transform.TransformPoint(Vector3.forward * 1.5f),
                            transform.rotation
                        );
                    }
                }
                
                else if (hit.distance < _obstacleRange && !hit.transform.CompareTag("Fireball"))
                {
                    float theta = Random.Range(-110.0f, 110.0f);
                    transform.Rotate(0.0f, theta, 0.0f);
                }
            }
        }
    }
}
