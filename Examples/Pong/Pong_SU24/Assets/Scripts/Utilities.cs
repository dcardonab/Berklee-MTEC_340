using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static float HeightInUnits;

    public static void SetHeightInUnits(Camera cam)
    {
        HeightInUnits = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, 0)).y;
    }
    
    
    public static float CalculateYLimit(float spriteHeight)
    {
        return HeightInUnits - spriteHeight * 0.5f;
    }
}
