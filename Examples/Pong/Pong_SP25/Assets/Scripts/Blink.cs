using System.Collections;
using UnityEngine;
using TMPro;

public class Blink : MonoBehaviour
{
    private TextMeshProUGUI _message;
    private bool _inCoroutine = false;  // Safeguard coroutine using a boolean
    
    [SerializeField] private float _blinkRate = 0.5f;

    private Coroutine _coroutine;

    private void Start()
    {
        _message = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_inCoroutine)
        {
            _coroutine = StartCoroutine(Flicker());
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            StopCoroutine(_coroutine);
            _inCoroutine = false;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            StopAllCoroutines();
        }
    }

    IEnumerator Flicker()
    {
        _inCoroutine = true;
        
        _message.enabled = !_message.enabled;

        // Interrupt execution for one frame only
        // yield return null;

        yield return new WaitForSeconds(_blinkRate);

        _inCoroutine = false;
    }
}
