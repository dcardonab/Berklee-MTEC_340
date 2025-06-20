using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    // Backing variable
    private int _score;
    // Getter and setter properties
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            _scoreGUI.text = Score.ToString();
        }
    }

    [SerializeField] private TMP_Text _scoreGUI;
}
