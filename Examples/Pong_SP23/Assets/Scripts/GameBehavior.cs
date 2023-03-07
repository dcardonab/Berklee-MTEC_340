using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    [SerializeField] Player[] Players = new Player[2];

    public State CurrentState;

    public float VelocityIncrement = 1.0f;
    public float InitVelocity = 5.0f;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        CurrentState = State.Play;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CurrentState = CurrentState == State.Play ? State.Pause : State.Play;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
            QuitGame();
    }

    public void UpdateScore(int player)
    {
        Players[player - 1].Score++;
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
            // Function will be called if the game is running from Unity.
            EditorApplication.isPlaying = false;
        #else
            // Function will be called if the game is running from a build.
            Application.Quit();
        #endif
    }
}
