using System.Collections;
using UnityEngine;
using TMPro;

public class TextFlicker : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] float _flickerDuration = 0.5f;

    private bool _inCoroutine = false;
    private Coroutine _coroutine;

    private void Update()
    {
        // Safeguard coroutine with a boolean to avoid repeatedly
        // and unintentionally calling the coroutine
        if (!_inCoroutine)
        {
            _coroutine = StartCoroutine(Flicker());
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            StopCoroutine(_coroutine);
            _inCoroutine = false;
        }
    }

    IEnumerator Flicker()
    {
        // When calling coroutine from Update, sandwich implementation
        // with a Boolean
        _inCoroutine = true;
        
        _text.enabled = !_text.enabled;
        yield return new WaitForSeconds(_flickerDuration);
        
        _inCoroutine = false;
    }    
}
