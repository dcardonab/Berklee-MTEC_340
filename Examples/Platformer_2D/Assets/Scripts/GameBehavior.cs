using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public State GameState;

    private float _timer;
    public float Timer
    {
        get => _timer;
        set
        {
            _timer = value;

            int minutes = Mathf.FloorToInt(Timer / 60.0f);
            int seconds = Mathf.FloorToInt(Timer % 60.0f);

            // :00 formats the int to be displayed as two digits.
            TimerGUI.text = $"{minutes:00}:{seconds:00}";
        }
    }
    public TextMeshProUGUI TimerGUI;


    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;

        GameState = State.Play;
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        /*
         * Pause the game by switching Time.timeScale to 0.
         * The timeScale controls how quickly time passes. You can create
         * slo-mo by setting it to a value between 0 and 1.
         */
        Time.timeScale = GameState == State.Pause ? 0 : 1;

        if (Input.GetKeyDown(KeyCode.P))
            GameState = GameState == State.Play ? State.Pause : State.Play;
    }
}
