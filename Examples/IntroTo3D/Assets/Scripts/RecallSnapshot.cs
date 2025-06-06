using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class RecallSnapshot : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    
    [SerializeField] private AudioMixerSnapshot _snapshot1;
    [SerializeField] private AudioMixerSnapshot _snapshot2;

    [SerializeField] private AudioMixerSnapshot[] _snapshots;
    [SerializeField] private float[] _weights;

    [Range(0.5f, 5.0f)] [SerializeField] private float _transitionTime = 3.0f;

    private bool _inCoroutine;

    private void Update()
    {
        if (!_inCoroutine)
        {
            float duration = Random.Range(3.0f, 10.0f);
            StartCoroutine(SetExposedParameter("ChorusDryWet", Random.value, duration));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // _snapshot1.TransitionTo(_transitionTime);
            
            _mixer.TransitionToSnapshots(_snapshots, _weights, _transitionTime);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // _snapshot2.TransitionTo(_transitionTime);
        }
    }

    IEnumerator SetExposedParameter(string parameterName, float destinationValue, float duration)
    {
        _inCoroutine = true;

        float elapsedTime = 0.0f;

        _mixer.GetFloat(parameterName, out float initValue);

        while (elapsedTime < duration)
        {
            float value = Mathf.Lerp(initValue, destinationValue, elapsedTime / duration);
            _mixer.SetFloat(parameterName, value);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        _mixer.SetFloat(parameterName, destinationValue);
        
        _inCoroutine = false;
    }
}
