using UnityEngine;

// static makes it so there's only one class, i.e., no instances
public static class Utilities
{
    public enum GameState {
        Play, Pause
    }

    public static Color[] Colors =
    {
        Color.blue, Color.green, Color.red,
        Color.cyan, Color.yellow, Color.magenta
    };
    
    // Methods and field must be static in a static class.
    // `public` will make method accessible globally.
    public static float GetNonZeroRandomFloat(float min = -1.0f, float max = 1.0f)
    {
        float num;

        do
        {
            num = Random.Range(min, max);
        } while (Mathf.Approximately(num, 0.0f));

        return num;
    }
}
