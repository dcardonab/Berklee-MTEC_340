using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public float InitBallSpeed = 5.0f;
    public float BallSpeedIncrement = 1.2f;

    [SerializeField] private int _scoreToVictory = 3;

    [SerializeField] private Player[] _players = new Player[2];

    public Utilities.GameplayState State = Utilities.GameplayState.Play;

    [SerializeField] private TextMeshProUGUI _messages;

    private void Awake()
    {
        // If a duplicate tries to be created,
        // this logic will prevent it from being created
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            // The first time around, this will run
            Instance = this;
            
            // Uncomment this line for level based games
            // DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        ResetGame();

        State = Utilities.GameplayState.Play;
        _messages.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchState();
        }
    }

    private void SwitchState()
    {
        if (State == Utilities.GameplayState.Play)
        {
            State = Utilities.GameplayState.Pause;
            _messages.text = "Pause";
            _messages.enabled = true;
        }
        else
        {
            State = Utilities.GameplayState.Play;
            _messages.enabled = false;
        }
    }

    public void ScorePoint(int playerNumber)
    {
        _players[playerNumber - 1].Score += 1;
        CheckWinner();
    }

    private void CheckWinner()
    {
        foreach (Player p in _players)
        {
            if (p.Score >= _scoreToVictory)
            {
                ResetGame();
            }
        }
    }

    void ResetGame()
    {
        foreach (Player p in _players)
        {
            p.Score = 0;
        }
    }
}
