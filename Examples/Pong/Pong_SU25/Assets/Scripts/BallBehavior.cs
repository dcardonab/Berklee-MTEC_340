using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public Vector2 Speed = new (5.0f, 5.0f);
    
    void Start()
    {
        // Ternary operator
        // condition ? passing : failing;
        Speed.x *= Random.value < 0.5 ? -1 : 1;
        Speed.y *= Random.value < 0.5 ? -1 : 1;
    }
    
    void Update()
    {
        transform.position += (Vector3)Speed * Time.deltaTime;
    }
}
