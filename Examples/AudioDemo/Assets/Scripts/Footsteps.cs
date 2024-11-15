using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Footsteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] _footsteps;
    private AudioSource _source;

    private int _index = 0;
    private int _prevIndex = -1;
    
    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void PlayFootstep()
    {
        // Iterate as long as index is different from previous iteration
        do
        {
            _index = Random.Range(0, _footsteps.Length);
        } while (_index == _prevIndex);

        // Update previous index for next iteration
        _prevIndex = _index;

        // Randomize parameters
        _source.volume = Random.Range(0.75f, 1.0f);
        _source.pitch = Random.Range(0.9f, 1.1f);
        
        // Assign clip
        _source.clip = _footsteps[_index];
        
        // LET THERE BE SOUND!!!
        _source.Play();
    }
}