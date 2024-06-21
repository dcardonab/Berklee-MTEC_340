using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static float HeightInUnits;
    
    public static float CalculateYLimit(float spriteHeight)
    {
        return HeightInUnits - spriteHeight * 0.5f;
    }
}
