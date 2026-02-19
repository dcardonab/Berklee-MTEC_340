using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    private Utilities.GameState _gameMode;
    public Utilities.GameState GameMode
    {
        get => _gameMode;
        set
        {
            _gameMode = value;
            _pauseUI.enabled = GameMode != Utilities.GameState.Play;
        }
    }

    [SerializeField] private GameObject _ballPrefab;

    [SerializeField] private Player[] _players = new Player[2];

    [SerializeField] private TMP_Text _pauseUI;
    
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
        foreach (Player p in _players)
        {
            p.Score = 0;
        }

        GameMode = Utilities.GameState.Play;
        
        Serve();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameMode = GameMode == Utilities.GameState.Play ?   // Condition
                Utilities.GameState.Pause : // Passing value
                Utilities.GameState.Play;   // Failing value
        }
    }

    private void Serve()
    {
        // Add a ball at the center of the game world with no rotation
        Instantiate(_ballPrefab, Vector3.zero, Quaternion.identity);
    }

    public void Score(int playerNum)
    {
        // Array indexing in C# is zero-indexed
        _players[playerNum - 1].Score++;
        
        // Invoke schedules a function to execute after a given duration
        Invoke(nameof(Serve), 2.0f);
    }
}
