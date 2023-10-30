using UnityEngine;

public class PlayerFallDetect : MonoBehaviour
{
    void Update()
    {
        // When the player's position is very low, respawn to the beginning
        // of the level
        if (transform.position.y <= -50.0f)
            transform.position = new Vector3(0, 0, 0);
    }
}
