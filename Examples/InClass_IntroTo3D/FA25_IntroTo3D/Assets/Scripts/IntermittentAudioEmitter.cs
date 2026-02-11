using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioLowPassFilter))]
public class IntermittentAudioEmitter : MonoBehaviour
{
    [Header("Audio Clips")]
    // Array of audio files
    [SerializeField] AudioClip[] _clips;
    int _currentClipIndex;
    
    [Space(5)]
    [Header("Randomization Attributes")]
    
    // Randomize amplitude
    [SerializeField] bool _randomizeAmplitude;
    [Range(0.25f, 0.75f)] [SerializeField] float _minAmplitude;
    [Range(0.75f, 1.0f)] [SerializeField] float _maxAmplitude;
    
    // Randomize pitch
    [SerializeField] bool _randomizePitch;
    [Range(0.5f, 1.0f)] [SerializeField] float _minPitch;
    [Range(1.0f, 2.0f)] [SerializeField] float _maxPitch;
    
    // Randomize LPF frequency
    [SerializeField] bool _randomizeLpfFrequency;
    [Range(100.0f, 1000.0f)] [SerializeField] float _minLpfFreq;
    [Range(1000.0f, 20000.0f)] [SerializeField] float _maxLpfFreq;
    
    // Randomize time between clips
    [Range(0.0f, 5.0f)] [SerializeField] float _maxGapBetweenClips = 2.0f;
    
    [Space(5)]
    [Header("Position Attributes")]
    [Range(20.0f, 100.0f)] [SerializeField] float _maxDistance;
    
    [Space(5)]
    [Header("Player Info")]
    [SerializeField] Transform _playerTransform;
    
    // References to components
    AudioSource _source;
    AudioLowPassFilter _lpf;
    
    void Start()
    {
        // Get components
        _source = GetComponent<AudioSource>();
        _lpf = GetComponent<AudioLowPassFilter>();
        
        // Init audio properties
        _source.loop = false;
        _source.spatialBlend = 1.0f;        // Make sound 3D
        _source.maxDistance = _maxDistance;

        SetAudioProperties();
    }

    void SetAudioProperties()
    {
        // Load sound
        _currentClipIndex = LoadRandomIndex(_clips.Length, _currentClipIndex);
        _source.clip = _clips[_currentClipIndex];
        
        // Set random attributes
        if(_randomizeAmplitude)
            _source.volume = Random.Range(_minAmplitude, _maxAmplitude);
        
        if (_randomizePitch)
            _source.pitch = Random.Range(_minPitch, _maxPitch);
        
        if (_randomizeLpfFrequency)
            _lpf.cutoffFrequency = Random.Range(_minLpfFreq, _maxLpfFreq);

        transform.position = GenerateRelativeRandomPosition(_playerTransform);

        // Play!
        StartCoroutine(PlaySound());
    }

    int LoadRandomIndex(int arrayLength, int prevIndex)
    {
        int currentIndex;

        do
        {
            currentIndex = Random.Range(0, arrayLength);
        } while (prevIndex == currentIndex);
        
        return currentIndex;
    }

    Vector3 GenerateRelativeRandomPosition(Transform playerTransform)
    {
        float angleX = Random.Range(0.0f, 2.0f * Mathf.PI);
        float angleY = Random.Range(0.0f, Mathf.PI);
        float angleZ = Random.Range(0.0f, 2.0f * Mathf.PI);
        
        float radius = Random.Range(1.0f, _maxDistance);

        return new Vector3(
            playerTransform.position.x + Mathf.Cos(angleX) * radius,
            playerTransform.position.y + Mathf.Sin(angleY) * radius,    // Y MUST use Sine for overhead sounds
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
