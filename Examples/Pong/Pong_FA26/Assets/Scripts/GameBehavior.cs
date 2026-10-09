using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    private Utilities.GameState _state;
    public Utilities.GameState State
    {
        get => _state;

        set
        {
            _state = value;
            _pauseUI.enabled = State == Utilities.GameState.Pause;
        }
    }
    
    [SerializeField] private TMP_Text _pauseUI;
    
    public Player[] Players = new Player[2];
    
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Transform _ballParent;
    private GameObject _ball;

    [SerializeField] private int _winningScore = 5;

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
        ResetScore();
        ResetPoint();

        State = Utilities.GameState.Play;
    }

    private void Update()
    {
        // State machine transition
        if (Input.GetKeyDown(KeyCode.P))
        {
            State = State == Utilities.GameState.Play ?
                    Utilities.GameState.Pause :
                    Utilities.GameState.Play;
        }
        
        if (!_ball)
        {
            ResetPoint();
        }
    }

    void ResetScore()
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

    public void ResetPoint()
    {
        // Add a prefab to the game.
        // This overload uses a custom position, rotation (represented in quaternions), and parent.
        _ball = Instantiate(_ballPrefab, Vector3.zero, Quaternion.identity, _ballParent);
    }

    public void ScorePoint(int playerNumber)
    {
        Players[playerNumber].Score++;

        if (Players[playerNumber].Score >= _winningScore)
        {
            ResetScore();
        }
    }
}
