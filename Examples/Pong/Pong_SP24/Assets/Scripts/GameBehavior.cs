using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public enum GameState {
        Play,
        Pause
    }

    // `static` ensures that there is only of something
    public static GameBehavior Instance;

    public GameState State = GameState.Play;

    [SerializeField] Player[] _players = new Player[2];

    public float InitBallSpeed = 5.0f;
    public float BallSpeedIncrement = 5.0f;

    [SerializeField] int _pointsToVictory = 5;

    // Awake runs before Start
    void Awake()
    {
        // Singleton pattern
        // The Singleton pattern enforces a single reference to the instance
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void Start() {
        ResetGame();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            State = State == GameState.Play ? GameState.Pause : GameState.Play;
        }
    }

    void ResetGame() {
        foreach (Player player in _players)
            player.Score = 0;
    }

    public void ScorePoint(int player) {
        _players[player].Score++;
        CheckWinner();
    }

    void CheckWinner() {
        foreach(Player player in _players) {
            if (player.Score >= _pointsToVictory) {
                ResetGame();
            }
        }
    }
}
