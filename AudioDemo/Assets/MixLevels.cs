using UnityEngine;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;

    public void SetMusicLvl(float level)
    {
        masterMixer.SetFloat("musicVol", level);
    }
}
