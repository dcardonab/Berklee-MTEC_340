using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    // Properties
    int _score = 0;
    public int Score {
        // getter property
        get => _score;
        // setter property
        set {
            _score = value;
            TextBox.text = Score.ToString();
        }
    }

    public TextMeshProUGUI TextBox;
}
