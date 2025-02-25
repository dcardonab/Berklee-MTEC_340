using System;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    private float _speed = 4.0f;

    public KeyCode UpDirection;
    public KeyCode DownDirection;

    public float YLimit = 3.45f;

    private void Start()
    {
        _speed = GameBehavior.Instance.PaddleSpeed;
    }

    void Update()
    {
        if (GameBehavior.Instance.State == Utilities.GameplayState.Play)
        {
            // Resolve movement based on keyboard presses
            float movement = 0;
            
            if (Input.GetKey(UpDirection) && transform.position.y < YLimit)
            {
                movement += _speed;
            }
            
            if (Input.GetKey(DownDirection) && transform.position.y > -YLimit)
            {
                movement -= _speed;
            }

            // Move the paddle based on the resulting movement
            transform.position += new Vector3(0, movement, 0) * Time.deltaTime;
        }
    }
}
