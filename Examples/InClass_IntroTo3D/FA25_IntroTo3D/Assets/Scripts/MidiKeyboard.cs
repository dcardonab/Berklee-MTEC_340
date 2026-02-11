using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MidiKeyboard : MonoBehaviour
{
    Dictionary<KeyCode, AudioClip> _samples = new Dictionary<KeyCode, AudioClip>();

    private readonly KeyCode[] _keyMap =
    {
        KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.E, KeyCode.D, KeyCode.F,
        KeyCode.T, KeyCode.G, KeyCode.Y, KeyCode.H, KeyCode.U, KeyCode.J
    };

    [SerializeField] private AudioClip[] Sounds = new AudioClip[12];

    [SerializeField] private bool _isPolyphonic;
    
    AudioSource _source;

    void Start()
    {
        _source = GetComponent<AudioSource>();
        InitDictionary();
    }

    void Update()
    {
        foreach (KeyValuePair<KeyCode, AudioClip> sample in _samples)
        {
            if (Input.GetKeyDown(sample.Key))
            {
                if (_isPolyphonic)
                {
                    _source.PlayOneShot(sample.Value);
                }
                else
                {
                    _source.clip = sample.Value;
                    _source.Play();
                }
            }
        }
    }

    void InitDictionary()
    {
        int count = Mathf.Min(_keyMap.Length, Sounds.Length);

        for (int i = 0; i < count; i++)
        {
            _samples[_keyMap[i]] = Sounds[i];
        }
    }
}
