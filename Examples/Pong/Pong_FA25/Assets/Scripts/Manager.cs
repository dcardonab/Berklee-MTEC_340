using System;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public Player[] Players = new Player[2];
    
    // Ball properties
    public float BallSpeedMultiplier = 1.1f;

    private void Awake()
    {
        // Instance is null when no Manager has been initialized
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("New instance initialized...");
            
            DontDestroyOnLoad(gameObject);
        }
        
        // We evaluate this portion when trying to initialize a new instance
        // when one already exists
        else if (Instance != this)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate instance found and deleted...");
        }
    }

    private void Start()
    {
        foreach (Player p in Players)
        {
            p.Score = 100;
        }
    }
}
