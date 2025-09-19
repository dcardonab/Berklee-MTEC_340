using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float Speed = 5.0f;

    private int _xDirection;
    private int _yDirection;
    
    void Start()
    {
        _xDirection = Random.value >= 0.5f ? 1 : -1;
        _yDirection = Random.value >= 0.5f ? 1 : -1;
    }

    
    void Update()
    {
        transform.position += new Vector3(
            Speed * _xDirection, Speed * _yDirection, 0.0f) * Time.deltaTime;
    }
}
