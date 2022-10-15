using UnityEngine;

using TMPro;

public class Player : MonoBehaviour
{
    private int _score;
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            ScoreGUI.text = Score.ToString();
        }
    }

    public TextMeshProUGUI ScoreGUI;

    private void Start()
    {
        Score = 0;
    }
}
