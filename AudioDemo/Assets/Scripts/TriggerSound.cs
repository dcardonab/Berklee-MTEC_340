using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    // AnimalSoundNames is the declared enum and it is used as the data type.
    [SerializeField] AnimalSoundNames _soundToPlay;     // Declared in EnumDeclaration.cs
    [SerializeField] SoundEmitter _soundEmitter;

    [SerializeField] AudioSource _soundtrackSource;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Generate position relative to the player.
            Vector3 pos = Utilities.GenRelativeRandomPos(other.gameObject.transform);
            _soundEmitter.PlaySound(_soundToPlay, pos);

            StartCoroutine(Utilities.FadeOut(_soundtrackSource));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop playing sound if player exits the trigger.
            _soundEmitter.StopSound();

            StartCoroutine(Utilities.FadeIn(_soundtrackSource, startSound: false));
        }
    }
}
