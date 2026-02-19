using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private int _score;

    public int Score
    {
        // get
        // {
        //     return _score;
        // }
        get => _score;
        
        // Score = 1
        set
        {
            _score = value;
            _scoreUI.text = Score.ToString();
        }
    }

    [SerializeField] private TMP_Text _scoreUI;
}
