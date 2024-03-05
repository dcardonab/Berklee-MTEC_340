using UnityEngine;

public class PaddlePhysics : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _speed = 5.0f;
    int _direction;

    [SerializeField] KeyCode _upKey;
    [SerializeField] KeyCode _downKey;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _direction = 0;

        if (Input.GetKey(_upKey))
            _direction = 1;

        if (Input.GetKey(_downKey))
            _direction = -1;

        if (Input.GetKey(_upKey) && Input.GetKey(_downKey))
            _direction = 0;
    }

    void FixedUpdate() {
        _rb.velocity = new Vector2(0, _speed * _direction);
    }
}
