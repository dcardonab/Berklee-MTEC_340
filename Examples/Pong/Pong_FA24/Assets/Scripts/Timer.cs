using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _duration;

    private TextMeshProUGUI _timerGui;
    
    private float _elapsedTime;
    public float ElapsedTime
    {
        get => _elapsedTime;
        set
        {
            _elapsedTime = value;

            int minutes = Mathf.FloorToInt(ElapsedTime / 60.0f);
            int seconds = Mathf.FloorToInt(ElapsedTime % 60.0f);

            _timerGui.text = $"{minutes:00}:{seconds:00}";
        }
    }

    private void Start()
    {
        _timerGui = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime >= _duration)
        {
            Debug.Log("Timer is finished!");
            ElapsedTime -= _duration;
        }
    }
}
