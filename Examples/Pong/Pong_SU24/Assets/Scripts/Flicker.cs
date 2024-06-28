using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flicker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _gui;
    
    [Range(0.5f, 2.0f)]
    [SerializeField] private float _flickerRate = 1.0f;
    
    void Start()
    { 
        StartCoroutine(FlickerMenu());
    }

    IEnumerator FlickerMenu()
    {
        while (true)
        {
            _gui.enabled = !_gui.enabled;
            
            yield return new WaitForSeconds(_flickerRate);
        }
    }
}
