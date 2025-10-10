using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TMP_Text _timerText;
    
    private float _timeElapsed = 0.0f;
    private float TimeElapsed
    {
        get => _timeElapsed;
        set
        {
            _timeElapsed = value;
            
            int minutes = Mathf.FloorToInt(TimeElapsed / 60);
            int seconds = Mathf.FloorToInt(TimeElapsed % 60);

            _timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    private void Start()
    {
        _timerText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        TimeElapsed += Time.deltaTime;
    }
}
