using System.Collections;
using UnityEngine;
using TMPro;

public class Flicker : MonoBehaviour
{
    [SerializeField] private float _flickerRate = 0.5f;

    private TMP_Text _text;

    private bool _inCoroutine = false;
    private Coroutine _coroutine;

    void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (!_inCoroutine)
        {
            _coroutine = StartCoroutine(FlickerText());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(_coroutine);
            _inCoroutine = false;
        }
    }

    IEnumerator FlickerText()
    {
        _inCoroutine = true;
        
        // Toggle boolean
        _text.enabled = !_text.enabled;
        yield return new WaitForSeconds(_flickerRate);
        
        _inCoroutine = false;
    }
}
