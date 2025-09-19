using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SnapshotRecall : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot _targetSnapshot;
    [SerializeField] private float _transitionDuration = 5.0f;

    [SerializeField] private AudioMixer _targetMixer;
    [SerializeField] private AudioMixerSnapshot[] _snapshots;
    [SerializeField] private float[] _weights;

    private void OnTriggerEnter(Collider other)
    {
        // Transition to a snapshot
        // Called from the target snapshot
        // _targetSnapshot.TransitionTo(_transitionDuration);
        
        // Transition in between several snapshots
        // Called from the mixer that contains the snapshots
        // _targetMixer.TransitionToSnapshots(_snapshots, _weights, _transitionDuration);

        StartCoroutine(TransitionPitch(0.25f));
    }

    IEnumerator TransitionPitch(float endValue)
    {
        _targetMixer.GetFloat("PitchShift", out float startValue);
        
        float elapsedTime = 0.0f;
        float transitionDuration = 5.0f;

        while (elapsedTime < transitionDuration)
        {
            float value = Mathf.Lerp(startValue, endValue, elapsedTime / transitionDuration);

            _targetMixer.SetFloat("PitchShift", value);

            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
        
        _targetMixer.SetFloat("PitchShift", endValue);
    }
}
