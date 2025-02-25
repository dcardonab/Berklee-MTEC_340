using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public Utilities.GameplayState State;
    [SerializeField] private TextMeshProUGUI _pauseMessage;

    public float InitBallSpeed = 5.0f;
    public float BallSpeedIncrement = 1.1f;

    public float PaddleSpeed = 4.0f;

    public Player[] Players = new Player[2];

    [SerializeField] private int _victoryScore = 5;
    
    void Awake()
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

    private void Start()
    {
        ResetGame();

        State = Utilities.GameplayState.Play;
        _pauseMessage.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            State = State == Utilities.GameplayState.Play
                ? Utilities.GameplayState.Pause
                : Utilities.GameplayState.Play;

            _pauseMessage.enabled = !_pauseMessage.enabled;
        }
    }

    public void ScorePoint(int playerNumber)
    {
        Players[playerNumber - 1].Score++;
        CheckWinner();
    }

    private void CheckWinner()
    {
        foreach (Player p in Players)
        {
            if (p.Score >= _victoryScore)
            {
                ResetGame();
            }
        }
    }

    private void ResetGame()
    {
        foreach (Player p in Players)
        {
            p.Score = 0;
        }
    }
}
