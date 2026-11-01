using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Collider))]
public class SnapshotRecall : MonoBehaviour
{
    [SerializeField] AudioMixerSnapshot _snapshot;
    [SerializeField, Range(0.0f, 20.0f)] private float _transitionDuration = 2.5f;

    private void Start()
    {
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        _snapshot.TransitionTo(_transitionDuration);
    }
}
