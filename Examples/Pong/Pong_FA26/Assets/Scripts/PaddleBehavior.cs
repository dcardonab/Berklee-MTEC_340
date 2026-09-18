using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    [SerializeField] private KeyCode _upDirection = KeyCode.UpArrow;
    [SerializeField] private KeyCode _downDirection = KeyCode.DownArrow;

    // public float Limit = 3.5f;

    void Update()
    {
        float movement = 0.0f;
        
        if (Input.GetKey(_upDirection))
        {
            movement += _speed;
        }
        if (Input.GetKey(_downDirection))
        {
            movement -= _speed;
        }
        
        movement *= Time.deltaTime;
        
        transform.Translate(0.0f, movement, 0.0f);

        
        // The code below allows for constaining the paddle within two bounds.
        
        // if (Mathf.Abs(transform.position.y) > Limit)
        // {
        //     transform.position = new Vector3(transform.position.x, Mathf.Sign(transform.position.y) * Limit, transform.position.z);
        // }
        
        // float yPos = Mathf.Clamp(transform.position.y, -Limit, Limit);
        // transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
