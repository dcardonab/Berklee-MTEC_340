using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioLowPassFilter))]
public class SmartSource : MonoBehaviour
{
    private AudioSource _source;
    private AudioLowPassFilter _lpf;

    [SerializeField] private Transform _listener;
    
    [SerializeField] private float _clearVolume = 1.0f;
    [SerializeField] private float _occludedVolume = 0.5f;
    [SerializeField] private float _clearCutoff = 22000.0f;
    [SerializeField] private float _occludedCutoff = 2000.0f;
    
    bool _isOccluded = false;
    
    LayerMask _layerMask;

    void Awake()
    {
        _source = GetComponent<AudioSource>();
        _lpf = GetComponent<AudioLowPassFilter>();
    }

    private void Start()
    {
        _layerMask = LayerMask.GetMask("Obstacle");
        
        _source.Play();
    }

    void Update()
    {
        Vector3 direction = (_listener.position - transform.position).normalized;

        if (Physics.Raycast(transform.position, direction, Mathf.Infinity, _layerMask))
        {
            if (!_isOccluded)
            {
                _source.volume = _occludedVolume;
                _lpf.cutoffFrequency = _occludedCutoff;
                _isOccluded = true;
            }
        }

        else
        {
            if (_isOccluded)
            {
                _source.volume = _clearVolume;
                _lpf.cutoffFrequency = _clearCutoff;
                _isOccluded = false;
            }
        }
    }
}
