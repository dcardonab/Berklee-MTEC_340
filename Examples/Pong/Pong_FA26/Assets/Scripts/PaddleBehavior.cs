using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    public float Speed = 5.0f;

    public KeyCode UpDirection = KeyCode.UpArrow;
    public KeyCode DownDirection = KeyCode.DownArrow;

    void Update()
    {
        float movement = 0.0f;
        
        if (Input.GetKey(UpDirection))
        {
            movement += Speed;
        }
        if (Input.GetKey(DownDirection))
        {
            movement -= Speed;
        }
        
        movement *= Time.deltaTime;
        
        transform.Translate(0.0f, movement, 0.0f);
    }
}
