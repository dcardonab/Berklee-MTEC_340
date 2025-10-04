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
        
        foreach (Player p in Players)
        {
            p.Score = 0;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            State = State == Utilities.GameState.Play ?
                Utilities.GameState.Pause :
                Utilities.GameState.Play;
        }
    }

    public void ScorePoint(int playerNum)
    {
        Players[playerNum - 1].Score++;
    }
}
