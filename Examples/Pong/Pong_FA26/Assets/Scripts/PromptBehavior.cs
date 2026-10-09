using System.Collections;
using UnityEngine;
using TMPro;

public class PromptBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Text _messageUI;
    [SerializeField, Range(0.1f, 2.0f)] private float _blinkRate = 0.5f;

    private bool _inCoroutine = false;
    private Coroutine _coroutine;

    private void Update()
    {
        if (!_inCoroutine)
        {
            _coroutine = StartCoroutine(Blink());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            StopCoroutine(_coroutine);
            _inCoroutine = false;
        }
    }

    private IEnumerator Blink()
    {
        _inCoroutine = true;
        
        _messageUI.enabled = !_messageUI.enabled;
        yield return new WaitForSeconds(_blinkRate);
        
        _inCoroutine = false;
    }
}
