using UnityEngine;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] AudioMixer soundDesignMixer;

    public void SetMusicLvl(float level)
    {
        masterMixer.SetFloat("musicVol", level);
    }

    public void SetAmbientLvl(float level)
    {
        soundDesignMixer.SetFloat("ambientVol", level);
    }
}
