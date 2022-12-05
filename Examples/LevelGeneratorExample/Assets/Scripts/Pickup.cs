using UnityEngine;

public class Pickup : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 5f, 0, Space.World);
    }
}
