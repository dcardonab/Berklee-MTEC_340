using System;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private int _score;
    public int Score
    {
        // Getter property
        get => _score;
        
        // Setter property
        set
        {
            _score = value;
            _scoreUI.text = Score.ToString();
        }
    }

    [SerializeField] private TextMeshProUGUI _scoreUI;
}
