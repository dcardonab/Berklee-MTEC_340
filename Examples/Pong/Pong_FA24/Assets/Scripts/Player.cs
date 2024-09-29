using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private int _score = 0;
    public int Score
    {
        // This notation is equivalent to returning the _score value
        get => _score;
        
        set
        {
            // Update value of backing variable
            _score = value;
            
            // Use getter property to update the GUI
            _scoreGUI.text = Score.ToString();
        }
    }

    [SerializeField] private TextMeshProUGUI _scoreGUI;
}
