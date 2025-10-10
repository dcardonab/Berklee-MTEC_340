using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    private static float _num = 0.25f;
    
    public enum GameState {
        Play,
        Pause
    }
    
    public static List<Color> Colors = new List<Color> {
        Color.red, Color.blue, Color.green, Color.black,
        Color.cyan, Color.magenta, Color.yellow, Color.white
    };
    
    public static float GetNonZeroRandomFloat(float min = -1.0f, float max = 1.0f)
    {
        do
        {
            _num = Random.Range(min, max);
        } while (_num > 0.25f);

        return _num;
    }
}
