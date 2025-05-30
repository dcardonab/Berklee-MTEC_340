using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] float _speed = 3.0f;
    [SerializeField] float _obstacleRange = 5.0f;

    private readonly float _sphereRadius = 0.75f;
    
    private bool _isAlive;

    public bool IsAlive
    {
        get => _isAlive;
        set => _isAlive = value;
    }

    [SerializeField] private GameObject _fireballPrefab;
    [HideInInspector] public GameObject _fireball;

    private void Start()
    {
        IsAlive = true;
    }

    private void Update()
    {
        if (IsAlive)
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);

            Ray ray = new(transform.position, transform.forward);

            // Cast a sphere in the direction of the ray and see if it collides
            // with the player or with the walls.
            if (Physics.SphereCast(ray, _sphereRadius, out RaycastHit hit))
            {
                // Shoot a fireball if the ray collided with the player.
                if (hit.transform.CompareTag("Player"))
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(
                            _fireballPrefab,
                            // TransformPoint from local space to global space.
                            // The fireball will be placed in front of the
                            // entity and facing in the same direction.
                            transform.TransformPoint(Vector3.forward * 1.5f),
                            transform.rotation);
                    }
                }

                // Otherwise, the ray collided with a wall.
                else if (hit.distance < _obstacleRange && !hit.transform.CompareTag("Fireball"))
                {
                    float theta = Random.Range(-110, 110);
                    transform.Rotate(0, theta, 0);
                }
            }
        }
    }
}
