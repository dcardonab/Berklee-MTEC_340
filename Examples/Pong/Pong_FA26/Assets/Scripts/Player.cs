using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreUI;
    
    // Backing variable
    private int _score;

    // Public variable
    public int Score
    {
        get => _score;

        set
        {
            _score = value;
            _scoreUI.SetText(Score.ToString());
        }
    }
}
