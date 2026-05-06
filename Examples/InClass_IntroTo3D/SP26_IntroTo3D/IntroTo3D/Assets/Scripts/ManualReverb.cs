using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ManualReverb : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    [SerializeField] private string _parameterName;
    [SerializeField, Range(0.0f, 5.0f)] private float _transitionDuration = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine(FadeParameter(-80.0f, 0.0f));
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine(FadeParameter(0.0f, -80.0f));
    }

    IEnumerator FadeParameter(float start, float end)
    {
        float elapsedTime = 0.0f;
        
        // _mixer.GetFloat(_parameterName, out float startValue);

        while (elapsedTime < _transitionDuration)
        {
            float value = Mathf.Lerp(start, end, elapsedTime / _transitionDuration);
            _mixer.SetFloat(_parameterName, value);
            elapsedTime += Time.deltaTime;
            yield return null;  // Skip frame
        }
        
        _mixer.SetFloat(_parameterName, end);
    }
}
