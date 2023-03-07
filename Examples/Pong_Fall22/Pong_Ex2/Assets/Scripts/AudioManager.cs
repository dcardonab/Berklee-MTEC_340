using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioSource _audioSource;


    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
        {
            Instance = this;

            // Avoid destroying object when loading another scene.
            // Note that `gameObject` represents the current game object.
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySound(AudioClip clip, AudioSource source, float loudness = 1.0f)
    {
        source.volume = loudness;
        source.PlayOneShot(clip);
    }
}
