using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _speed = 20.0f;
    
    void Update()
    {
        transform.Rotate(0.0f, _speed * Time.deltaTime, 0.0f);
    }
}
