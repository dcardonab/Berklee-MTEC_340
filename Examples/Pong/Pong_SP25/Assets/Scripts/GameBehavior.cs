using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public float InitBallSpeed = 5.0f;
    public float BallSpeedIncrement = 1.1f;

    public float PaddleSpeed = 4.0f;
    
    void Start()
    {
        // Singleton pattern
        
        // When creating an instance, check if one already exists,
        // and if the existing is the one that is trying to be created.
        if (Instance != null && Instance != this)
        {
            // If a different instance already exists,
            // please destroy the instance that is currently being created.
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    
    void Update()
    {
        
    }
}
