using System;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    private TMP_Text _uiText;
    
    private float _timer;

    public float Timer
    {
        get => _timer;
        set
        {
            _timer = value;
            int minutes = Mathf.FloorToInt(Timer / 60);
            int seconds = Mathf.FloorToInt(Timer % 60);

            _uiText.text = $"{minutes:00}:{seconds:00}";
        } 
    }
    
    void Start()
    {
        _uiText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        Timer += Time.deltaTime;
    }
}
