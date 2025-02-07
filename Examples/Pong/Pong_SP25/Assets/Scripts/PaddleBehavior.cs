using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    public float Speed = 4.0f;

    public KeyCode UpDirection;
    public KeyCode DownDirection;

    public float YLimit = 3.45f;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        // Resolve movement based on keyboard presses
        float movement = 0;
        
        if (Input.GetKey(UpDirection) && transform.position.y < YLimit)
        {
            movement += Speed;
        }
        
        if (Input.GetKey(DownDirection) && transform.position.y > -YLimit)
        {
            movement -= Speed;
        }

        // Move the paddle based on the resulting movement
        transform.position += new Vector3(0, movement, 0) * Time.deltaTime;
    }
}
