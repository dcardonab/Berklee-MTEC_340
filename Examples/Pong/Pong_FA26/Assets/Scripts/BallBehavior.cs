using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    private Vector2 _direction;
    
    void Start()
    {
        // Ternary operator: condition ? pass : fail
        _direction.x = Random.value < 0.5f ? 1.0f : -1.0f;
        _direction.y = Random.value < 0.5f ? 1.0f : -1.0f;
    }

    void Update()
    {
        Vector3 movement = new Vector3(_direction.x * _speed, _direction.y * _speed, 0) * Time.deltaTime;
        
        transform.Translate(movement);
    }
}
