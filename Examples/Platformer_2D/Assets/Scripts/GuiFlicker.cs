using System.Collections;
using UnityEngine;
using TMPro;

public class GuiFlicker : MonoBehaviour
{
    TextMeshProUGUI _messagesGUI;
    [SerializeField] float _flickerTime = 1.0f;
    bool _inCoroutine;

    private void Start()
    {
        _messagesGUI = GameObject.Find("Messages").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_inCoroutine)
        {
            StartCoroutine(ToggleGuiDisplay());
            _inCoroutine = true;
        }
    }

    IEnumerator ToggleGuiDisplay()
    {
        _messagesGUI.enabled = !_messagesGUI.enabled;

        yield return new WaitForSeconds(_flickerTime);

        _inCoroutine = false;
    }
}
