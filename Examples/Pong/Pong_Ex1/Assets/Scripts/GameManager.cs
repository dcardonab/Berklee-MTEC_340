using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player P1;
    public Player P2;

    private Player[] Players = new Player[2];

    public float initBallSpeed;
    public float ballSpeedIncrement;
    public int pointsToVictory;

    private string _state;
    public string State
    {
        get => _state;
        set
        {
            _state = value;
        }
    }

    public KeyCode startKey;
    public KeyCode pauseKey;

    public TextMeshProUGUI messagesGUI;

    private AudioSource m_audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        Players[0] = P1;
        Players[1] = P2;

        m_audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        State = "Game Over";
    }

    private void Update()
    {
        if ((State == "Game Over" || State == "Serve") && Input.GetKeyUp(startKey))
        {
            State = "Play";
            messagesGUI.enabled = false;
        }

        else if (Input.GetKeyUp(pauseKey))
            State = State == "Play" ? "Pause" : "Play";
    }

    public void UpdateScore(int player)
    {
        Players[player - 1].Score++;

        foreach (Player p in Players)
        {
            if (p.Score >= pointsToVictory)
            {
                ResetGame();
                break;
            }
        }
    }

    private void ResetGame()
    {
        State = "Game Over";

        foreach (Player p in Players)
            p.Score = 0;
    }

    public void PlaySound(AudioClip clip, float volume=1.0f)
    {
        m_audioSource.volume = volume;
        m_audioSource.PlayOneShot(clip);
    }
}
