using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;    // The UI contains Text instances.

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance { get; private set; }

    /*************************************************************************/
    /*
     * Players
     * Player objects exist on each paddle, and each one contains a reference
     * to its corresponding TextMeshProUGUI object, and keeps track of their
     * score
     */
    
    [SerializeField] Player m_P1;
    [SerializeField] Player m_P2;
    private readonly Player[] _players = new Player[2];

    private Ball ball;

    /*************************************************************************/
    // Global GUIs
    [SerializeField] TextMeshProUGUI m_Message;

    /*************************************************************************/
    // State Manager
    private string _state = "Game Over";
    public string State
    {
        get => _state;
        set => _state = value;
    }

    private readonly string[] ExcludedStates = new string[] { "Play", "Pause", "Score" };

    [SerializeField] KeyCode m_StartKey;
    [SerializeField] KeyCode m_PauseKey;

    /*************************************************************************/
    // Game Properties
    public float m_initBallSpeed;
    public float speedIncrement;
    public int pointsToVictory;

    /*************************************************************************/
    // Audio Manager
    private AudioSource _audioSource;
    [SerializeField] AudioClip s_StartGame;
    [SerializeField] AudioClip s_Serve;
    [SerializeField] AudioClip s_GameOver;
    [SerializeField] AudioClip s_Pause;

    /*************************************************************************/
    // Object Lifecycle Methods
    private void Awake()
    {
        /*
         * The reference to the script is static, meaning that it is the same
         * in any and all instances of the class. However, the instance that
         * the reference points to will not necessarily be the same.
         * 
         * This means that although the reference can only point to one
         * instance of the script, it is possible to have multiple instances
         * of a singleton in the scene.
         * 
         * As such, it is important to ensure that only one instance of a
         * singleton exists. This is done by checking to see if the static
         * reference matches the script instance. If it does not, it will be
         * a duplication and will delete itself.
         * 
         * The conditional below is known as the singleton pattern.
         */
        if (Instance != null && Instance != this)
            Destroy(this);

        else
            Instance = this;

        _players[0] = m_P1;
        _players[1] = m_P2;

        ball = GameObject.Find("Ball").GetComponent<Ball>();

        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        AudioManager.Instance.PlaySound(s_StartGame, _audioSource, 0.2f);

        // Initialize score
        foreach (Player p in _players)
            p.Score = 0;

        ResetServe();
    }

    private void Update()
    {
        if (!ExcludedStates.Contains(State) && Input.GetKeyUp(m_StartKey))
        {
            if (State == "Game Over")
                SceneManager.LoadScene("PlayScene");

            else
            {
                // Hide Message when the game starts.
                SetGUI(m_Message, false);

                State = "Play";

                AudioManager.Instance.PlaySound(s_Serve, _audioSource);
            }
        }

        // Pause Game
        if (Input.GetKeyUp(m_PauseKey))
            Pause();
    }


    /*************************************************************************/
    // Other Methods

    private void CheckWinner()
    {
        if (m_P1.Score >= pointsToVictory || m_P2.Score >= pointsToVictory)
        {
            // Play GameOver sound only when the game was in play.
            // This will avoid a bug that will play this sound again when
            // restarting a game. This is due to the score being updated, and
            // since one player had a score that represents a victory, this
            // function will evaluate to true.
            if (State != "Game Over")
                AudioManager.Instance.PlaySound(s_GameOver, _audioSource);

            // Declare game over if there is a winner.
            State = "Game Over";

            // Ternary operator.
            // Return first option (after question mark) if condition is true.
            // Otherwise, return second option (after the colon).
            // Note that the condition does not need to be in parenthesis.
            SetGUI(
                m_Message, true,
                $"Game Over!\nPlayer {(m_P1.Score > m_P2.Score ? 1 : 2)} Won!\nPress Return to Start"
            );

        }

        else
            ResetServe();
    }

    private void Pause()
    {
        if (State == "Play")
        {
            State = "Pause";
            SetGUI(m_Message, true, "Game Paused");
        }

        else if (State == "Pause")
        {
            State = "Play";
            SetGUI(m_Message, false);
        }

        AudioManager.Instance.PlaySound(s_Pause, _audioSource, 0.25f);
    }

    private void ResetServe()
    {
        ball.ResetBall();
        SetGUI(m_Message, true, "Press Return to Start");

        State = "Serve";
    }

    public void SetGUI(TextMeshProUGUI gui, bool enabled, string message="")
    {
        gui.text = message;
        gui.enabled = enabled;
    }

    public IEnumerator UpdateScore(int playerNumber)
    {
        // Changing the state to something other than play is very important
        // to prevent calling the UpdateScore function multiple times from the
        // ball's update function.
        State = "Score";

        _ = playerNumber == 1 ? m_P1.Score += 1 : m_P2.Score += 1;

        yield return new WaitForSeconds(1.0f);

        CheckWinner();
    }
}
