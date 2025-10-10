using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    private Utilities.GameState _state;
    public Utilities.GameState State
    {
        get => _state;
        set
        {
            _state = value;
            _messagesUI.enabled = State == Utilities.GameState.Pause;
        }
    }

    public Player[] Players = new Player[2];
    
    // Ball properties
    public float BallSpeedMultiplier = 1.1f;
    
    [SerializeField] private int _scoreToVictory = 5;

    [SerializeField] private TMP_Text _messagesUI;

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
        State = Utilities.GameState.Play;
        
        ResetGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            State = State == Utilities.GameState.Play ?
                Utilities.GameState.Pause :
                Utilities.GameState.Play;
        }
        
        // A better way to pause the game!
        Time.timeScale = State == Utilities.GameState.Play ? 1 : 0;
    }

    public void ScorePoint(int playerNum)
    {
        Players[playerNum - 1].Score++;
        CheckWinner();
    }

    private void CheckWinner()
    {
        foreach (Player p in Players)
        {
            if (p.Score >= _scoreToVictory)
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
