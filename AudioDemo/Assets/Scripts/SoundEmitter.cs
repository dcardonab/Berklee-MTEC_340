using UnityEngine;

public class SoundEmitter : MonoBehaviour
{
    // The actual audio clips are loaded into this array using the inspector.
    // The clips must be loaded in the same order as the declared enum names.
    [SerializeField] AudioClip[] _animalSoundClips;
    AudioSource _source;

    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlaySound(AnimalSoundNames name, Vector3 pos, bool fadeIn = false)
    {
        // Move object to the location where the sound will be played.
        transform.position = pos;

        // The enum name is being casted as an int to obtain an index.
        _source.clip = _animalSoundClips[(int)name];

        if (fadeIn)
            StartCoroutine(Utilities.FadeIn(_source));
        else
            _source.Play();

        /*
         * Alternatively, use the AudioSource class method PlayClipAtPoint,
         * which will instantiate a GameObject an AudioSource at the specified
         * position and play a given sound. The GameObject will automatically
         * be destroyed after the duration of the clip. The syntax for this
         * method is:
         *     AudioSource.PlayClipAtPoint(AudioClip name, Vector3 pos);
         * 
         * The downside of this approach is that the AudioSource will use the
         * default Spatial settings, i.e., MinDistance, MaxDistance, etc.
         * 
         * For using specified settings, it is best to use the process above
         * or the one included in the RandomSoundEmitter.cs script.
         */
    }

    public void StopSound()
    {
        _source.Stop();
    }
}
