using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -3f)
            transform.TransformPoint(new Vector3(0, 3, 0));
    }
}
