using UnityEngine;
using TMPro;

// Manager class - Instance of the game
// Software Design Pattern - Singleton pattern
public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public Utilities.GameState CurrentState;

    [SerializeField] private TMP_Text _messagesGUI; 

    public float PaddleSpeed = 5.0f;
    public float InitBallForce = 5.0f;
    public float PaddleInfluence = 0.4f;
    public float BallSpeedIncrement = 1.1f;

    [SerializeField] int _pointsToVictory;

    [SerializeField] private Player[] _players = new Player[2];
    
    // Initializer: runs before Start()
    void Awake()
    {
        // Singleton pattern initializer
        if (Instance != null && Instance != this)
            Destroy(this);
        else
        {
            // Assign Game Manager (GM) if none exists
            Instance = this;
            
            // Make sure object owning the GM isn't destroyed when
            // exiting a scene
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        ResetGame();

        CurrentState = Utilities.GameState.Play;
        _messagesGUI.enabled = false;
    }

    private void Update()
    {
        // Game State Transition
        if (Input.GetKeyDown(KeyCode.P))
        {
            switch (CurrentState)
            {
                case Utilities.GameState.Play:
                    CurrentState = Utilities.GameState.Pause;
                    _messagesGUI.enabled = true;
                    break;
                case Utilities.GameState.Pause:
                    CurrentState = Utilities.GameState.Play;
                    _messagesGUI.enabled = false;
                    break;
                default:
                    break;
            }
        }
    }

    public void ScorePoint(int playerNum)
    {
        _players[playerNum - 1].Score++;
        CheckWinner();
    }

    void CheckWinner()
    {
        foreach (Player p in _players)
        {
            if (p.Score >= _pointsToVictory)
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
