using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] float movement_speed = 5f;
    [SerializeField] float yEdge;
    public KeyCode up;
    public KeyCode down;

    void Update()
    {
        if (GameBehavior.Instance.State == "Play")
        {
            // transform.position can only be updated by assigning a new Vector3 object to it.
            // However, its properties can be looked up using the dot operator.
            if (Input.GetKey(up) && transform.position.y <= yEdge)
                transform.position += new Vector3(0, movement_speed * Time.deltaTime, 0);

            else if (Input.GetKey(down) && transform.position.y >= -yEdge)
                transform.position += new Vector3(0, -movement_speed * Time.deltaTime, 0);
        }
    }
}
