using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioLowPassFilter))]
public class IntermittentAudioEmitter : MonoBehaviour
{
    [Header("Audio Clips")]
    // Array of audio files
    [SerializeField] private AudioClip[] _animalSounds;

    [Space(5)]
    [Header("Randomization Attributes")]
    
    // Randomize amplitude
    [SerializeField] private bool _randomizeAmplitude;
    [Range(0.25f, 0.75f)] [SerializeField] private float _minAmplitude;
    [Range(0.75f, 1.0f)] [SerializeField] private float _maxAmplitude;
    
    // Randomize pitch
    [SerializeField] private bool _randomizePitch;
    [Range(0.5f, 1.0f)] [SerializeField] private float _minPitch;
    [Range(1.0f, 2.0f)] [SerializeField] private float _maxPitch;
    
    // Randomize time between clips
    [Range(0.0f, 5.0f)] [SerializeField] private float _maxGapBetweenClips = 2.0f;

    [Space(5)]
    [Header("Player Info")]
    [SerializeField] private Transform _playerTransform;

    [Space(5)]
    [Header("Position Attributes")]
    [Range(20.0f, 50.0f)] [SerializeField] private float _maxDistance;
    
    // Reference to components in GameObject
    private AudioSource _source;
    private AudioLowPassFilter _lpf;

    private int _currentClipIndex;
    
    void Start()
    {
        // Get component references
        _source = GetComponent<AudioSource>();
        _lpf = GetComponent<AudioLowPassFilter>();
        
        // Initialize audio properties
        _source.loop = false;
        _source.spatialBlend = 1.0f;
        _source.maxDistance = _maxDistance;

        SetAudioProperties();
    }

    void SetAudioProperties()
    {
        // Load sound
        _currentClipIndex = LoadRandomIndex(_animalSounds.Length, _currentClipIndex);
        _source.clip = _animalSounds[_currentClipIndex];
        
        // Set randomization attributes
        if (_randomizeAmplitude)
        {
            _source.volume = Random.Range(_minAmplitude, _maxAmplitude);
        }

        if (_randomizePitch)
        {
            _source.pitch = Random.Range(_minPitch, _maxPitch);
        }

        transform.position = GenerateRelativeRandomPosition(_playerTransform);

        StartCoroutine(PlaySound());
    }

    int LoadRandomIndex(int arrayLength, int prevIndex)
    {
        int currentIndex;

        // do-while is just like the while loop, but it guarantees running at least once
        do
        {
            currentIndex = Random.Range(0, arrayLength);
        } while (prevIndex == currentIndex);

        return currentIndex;
    }

    Vector3 GenerateRelativeRandomPosition(Transform playerTransform)
    {
        float radius = Random.Range(1.0f, _maxDistance);

        float angleX = Random.Range(0, 2 * Mathf.PI);
        float angleY = Random.Range(0, Mathf.PI);
        float angleZ = Random.Range(0, 2 * Mathf.PI);

        return new Vector3(
            playerTransform.position.x + Mathf.Cos(angleX) * radius,
            playerTransform.position.y + Mathf.Sin(angleY) * radius,    // Must use Sine
            playerTransform.position.z + Mathf.Sin(angleZ) * radius
        );
    }

    IEnumerator PlaySound()
    {
        _source.Play();

        yield return new WaitForSeconds(
            Random.Range(_source.clip.length, _source.clip.length + _maxGapBetweenClips)
        );
        
        SetAudioProperties();
    }
}
