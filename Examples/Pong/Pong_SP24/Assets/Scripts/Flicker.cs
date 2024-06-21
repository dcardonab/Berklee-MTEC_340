using System.Collections;
using UnityEngine;
using TMPro;

public class Flicker : MonoBehaviour
{
    TextMeshProUGUI _textBox;

    [Range(0.5f, 2.0f)]
    [SerializeField] float _flickerInterval = 1.0f;

    bool _onFlickerCoroutine = false;

    Coroutine _flickerCoroutine;


    void Start()
    {
        _textBox = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!_onFlickerCoroutine) {
            _flickerCoroutine = StartCoroutine(FlickerText());
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            Debug.Log("Interrupted Coroutine");
            _onFlickerCoroutine = false;
            StopCoroutine(_flickerCoroutine);
        }
    }

    IEnumerator FlickerText() {
        _onFlickerCoroutine = true;

        _textBox.enabled = !_textBox.enabled;

        yield return new WaitForSeconds(_flickerInterval);

        _onFlickerCoroutine = false;
    }
}
