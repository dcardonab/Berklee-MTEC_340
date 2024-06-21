using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitializer : MonoBehaviour
{
    private void Awake()
    {
        Camera cam = GetComponent<Camera>();
        Utilities.SetHeightInUnits(cam);
    }
}
