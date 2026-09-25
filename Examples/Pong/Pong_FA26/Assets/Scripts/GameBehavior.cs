using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;
    
    public Player[] Players = new Player[2];

    void Awake()
    {
        // Singleton pattern
        // Enforce that there is only ever a single instance of this class
        // throughout the execution of the program
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("New instance initialized...");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate instance found and deleted...");
        }
        
        // Alternate initialization of the singleton pattern
        // if (Instance != null && Instance != this)
        // {
        //     Destroy(this);
        // }
        // else
        // {
        //     Instance = this;
        // }
    }

    void Start()
    {
        ResetGame();
    }

    void ResetGame()
    {
        // initializer; condition; iterator
        // for (int i = 0; i < Players.Length; i++)
        // {
        //     Players[i].Score = 0;
        // }

        foreach (Player p in Players)
        {
            p.Score = 0;
        }
    }

    public void ScorePoint(int playerNumber)
    {
        Players[playerNumber].Score++;
    }
}
