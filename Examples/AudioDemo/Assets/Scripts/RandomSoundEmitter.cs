/* 
 * Contrary to the SoundEmitter.cs script, this script isn't making use of the
 * enum structure, as it will randomly, and not selectively, generate sounds.
 * 
 * A potential usecase for this could include choosing between two types of
 * sounds using probability. This would require small adaptations. If a random
 * number is greater/lesser than a given value, choose a random sample of a
 * given category. Each category would be stored in an independent collection.
 * It would then be possible to use triggers to broadcast a message (or use any
 * other setter mechanism) to update the probability value based on where in the
 * scene the player is. A message can be broadcasted using the BroadcastMessage
 * function. Note that said approach will require making this script a child of
 * the player. A function could then be declared in this script to set that
 * probability value.
 * 
 * See the BroadcastMessage function:
 *     https://docs.unity3d.com/ScriptReference/Component.BroadcastMessage.html
 */

using System.Collections;
using UnityEngine;

public class RandomSoundEmitter : MonoBehaviour
{
    [SerializeField] AudioClip[] _animalSoundClips;

    // Constraints for generating position and duration of sounds.
    [SerializeField] float _minRadius, _maxRadius;
    [SerializeField] float _minTime, _maxTime;
    bool _isWaiting;

    // Variables used to ensure that every randomly played sound
    // is different than the previous one.
    int _i, _j = 0;

    // Audio sources will be instantiated at random locations
    // and destroyed after playing the sounds.
    [SerializeField] GameObject _audioSourcePrefab;
    [SerializeField] Transform _animalSoundsContainer;
    GameObject _tmpObj;
    AudioSource _source;

    Transform _characterTransform;

    void Awake()
    {
        _characterTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Start()
    {
        _isWaiting = false;
    }

    void Update()
    {
        if (!_isWaiting)
            StartCoroutine(TriggerSound());
    }

    float GenerateSound()
    {
        // Generate position relative to the player.
        Vector3 pos = Utilities.GenRelativeRandomPos(
            _characterTransform, _minRadius, _maxRadius
        );

        // Instantiate Prefab containing an AudioSource set to 3D audio.
        _tmpObj = Instantiate(
            _audioSourcePrefab, pos, Quaternion.identity, _animalSoundsContainer
        );
        _source = _tmpObj.GetComponent<AudioSource>();

        // Randomly choose a clip.
        // Make sure the newly generated clip is different from the previous one.
        do
        {
            _i = Random.Range(0, _animalSoundClips.Length - 1);
        } while (_i == _j);
        // Update index of previously selected clip.
        _j = _i;

        _source.clip = _animalSoundClips[_i];

        // Randomly assign a pitch.
        _source.pitch = Random.Range(0.9f, 1.1f);

        // Play sound.
        _source.Play();

        // Return length of the clip to destroy object after.
        return _source.clip.length;
    }

    IEnumerator TriggerSound()
    {
        // Make sure only one sound is triggered at a time using a boolean flag
        _isWaiting = true;

        // Randomly choose the duration to the next sound
        float waitTime = Random.Range(_minTime, _maxTime);
        yield return new WaitForSeconds(waitTime);

        // GenerateSound returns the duration of the generated sound
        float destroyTime = GenerateSound() + 0.1f;
        yield return new WaitForSeconds(destroyTime);

        Destroy(_tmpObj);
        _isWaiting = false;
    }
}
