using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class Flicker : MonoBehaviour
{
    private TMP_Text _textUI;

    [SerializeField] private float _flickerRate = 0.5f;
    
    private bool _inCoroutine = false;
    
    private Coroutine _coroutine;

    private void Start()
    {
        _textUI = GetComponent<TMP_Text>();
    }
    
    void Update()
    {
        if (!_inCoroutine)
        {
            _coroutine = StartCoroutine(Blink());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StopCoroutine(_coroutine);
            _inCoroutine = false;
        }
    }

    IEnumerator Blink()
    {
        _inCoroutine = true;
        
        _textUI.enabled = !_textUI.enabled;
        
        yield return new WaitForSeconds(_flickerRate);
        
        _inCoroutine = false;
    }
}
