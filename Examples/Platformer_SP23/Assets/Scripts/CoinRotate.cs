using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    readonly float _rotationSpeed = 90.0f;

    void Update()
    {
        // Increase rotation every frame relative to the World space.
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0, Space.World);
    }
}
