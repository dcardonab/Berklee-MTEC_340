using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    private float _direction = 0.0f;
    
    [SerializeField] private float _speed = 5.0f;

    [SerializeField] private KeyCode _upDirection = KeyCode.UpArrow;
    [SerializeField] private KeyCode _downDirection = KeyCode.DownArrow;
    [SerializeField] private KeyCode _shootKey = KeyCode.RightShift;
    
    private Rigidbody2D _rb;

    [HideInInspector] public bool CanShoot = false;
    
    [Header("Projectile")]
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Transform _projectileParent;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityY = _direction * _speed;
    }

    void Update()
    {
        _direction = 0.0f;

        if (GameBehavior.Instance.State == Utilities.GameState.Play)
        {
            if (Input.GetKey(_upDirection))
            {
                _direction += 1.0f;
            }

            if (Input.GetKey(_downDirection))
            {
                _direction -= 1.0f;
            }

            if (CanShoot && Input.GetKeyDown(_shootKey))
            {
                Instantiate(
                    _projectilePrefab,                  // Prefab
                    _projectileSpawnPoint.position,     // Pos
                    _projectileSpawnPoint.rotation,     // Rot
                    _projectileParent);                 // Parent
            }
        }
    }
}
