using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public Player[] Players = new Player[2];

    [Header("Gameplay")]
    public int ScoreGoal = 5;

    [Header("Paddle")]
    public float PaddleSpeed = 5.0f;
    
    [Header("Ball")]
    [Range(2.0f, 10.0f)]
    public float InitialBallSpeed = 5.0f;
    [Range(1.1f, 2.0f)]
    public float BallSpeedIncrement = 1.25f;

    public enum StateMachine
    {
        Play,
        Pause
    }

    private StateMachine _state;

    public StateMachine State
    {
        get => _state;
        set
        {
            _state = value;
            
            // We don't need a ternary operator since we can assign a boolean directly.
            _pauseGUI.enabled = State == StateMachine.Pause;
        }
    }

    [Header("GUI")]
    [SerializeField] TextMeshProUGUI _pauseGUI;

    private void Awake()
    {
        // Singleton Pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        ResetGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Transition for the State Machine
            State = State == StateMachine.Play ? StateMachine.Pause : StateMachine.Play;
        }
    }

    public float CalculateYLimit(GameObject gO) {
        SpriteRenderer renderer = gO.GetComponent<SpriteRenderer>();
        float spriteHeight = renderer.bounds.size.y;

        return Utilities.CalculateYLimit(spriteHeight);
    }

    public void ScorePoint(int playerIndex)
    {
        Players[playerIndex].Score++;
        CheckWinner();
    }

    private void CheckWinner()
    {
        foreach (Player element in Players)
        {
            if (element.Score >= ScoreGoal)
            {
                ResetGame();
            }
        }
    }

    private void ResetGame()
    {
        foreach (Player playerElement in Players)
        {
            playerElement.Score = 0;
        }
        
        State = StateMachine.Play;
    }
}
