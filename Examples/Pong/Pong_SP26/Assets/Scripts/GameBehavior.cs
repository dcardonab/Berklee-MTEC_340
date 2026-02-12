using System;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    [SerializeField] private GameObject _ballPrefab;

    private void Awake()
    {
        // Singleton pattern
        
        // // Execute when an instance doesn't exist
        // if (Instance == null)
        // {
        //     Instance = this;
        //     Debug.Log("New instance initialized...");
        //     
        //     DontDestroyOnLoad(gameObject);
        // }
        //
        // // If an instance is trying to be created when one already exists, destroy it
        // else if (Instance != this)
        // {
        //     Destroy(gameObject);
        //     Debug.Log("Duplicate instance found and deleted...");
        // }

        // This is a more common implementation of the Singleton pattern, but it can be
        // more confusing. The code will perform exactly the same as what's above.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Serve();
    }

    private void Serve()
    {
        // Add a ball at the center of the game world with no rotation
        Instantiate(_ballPrefab, Vector3.zero, Quaternion.identity);
    }

    public void Score()
    {
        // Invoke schedules a function to execute after a given duration
        Invoke(nameof(Serve), 2.0f);
    }
}
