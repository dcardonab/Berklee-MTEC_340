using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blink : MonoBehaviour
{
    private TextMeshProUGUI _messagesGui;

    private bool _inCoroutine = false;

    [SerializeField] private float _blinkRate = 0.5f;

    private Coroutine _myStoppableCoroutine;
    
    private void Start()
    {
        _messagesGui = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!_inCoroutine)
        {
            _myStoppableCoroutine = StartCoroutine(BlinkMenu());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StopCoroutine(_myStoppableCoroutine);
            _inCoroutine = false;
        }
    }

    // COROUTINES
    IEnumerator BlinkMenu()
    {
        _inCoroutine = true;
        
        _messagesGui.enabled = !_messagesGui.enabled;

        yield return new WaitForSeconds(_blinkRate);

        _inCoroutine = false;
    }
}
