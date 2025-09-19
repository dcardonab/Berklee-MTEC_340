using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    public float Speed = 5.0f;

    public KeyCode UpDirection;
    public KeyCode DownDirection;
    
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

        transform.position += new Vector3(0.0f, movement * Time.deltaTime, 0.0f);
    }
}
