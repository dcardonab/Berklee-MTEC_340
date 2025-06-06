using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float Speed = 5.0f;

    public float LimitY = 3.75f;

    public KeyCode UpDirection;
    public KeyCode DownDirection;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 0.0f;
        
        // Check if the given keycode is currently pressed
        if (Input.GetKey(UpDirection))
        {
            // Update position by adding two vectors
            movement += Speed;
        }
        
        if (Input.GetKey(DownDirection))
        {
            // Update position by adding two vectors
            movement -= Speed;
        }

        // Create new position within defined bounds
        Vector3 newPosition = transform.position + new Vector3(0.0f, movement, 0.0f) * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, -LimitY, LimitY);

        // Apply new position
        transform.position = newPosition;
    }
}
