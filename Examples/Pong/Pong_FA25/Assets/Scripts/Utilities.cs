using UnityEngine;

public static class Utilities
{
    private static float num = 0.25f;
    
    public enum GameState {
        Play,
        Pause
    }
    
    public static float GetNonZeroRandomFloat(float min = -1.0f, float max = 1.0f)
    {
        do
        {
            num = Random.Range(min, max);
        } while (num > 0.25f);

        return num;
    }
}
