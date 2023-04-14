using UnityEngine;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] AudioMixer soundDesignMixer;

    public void SetMusicLvl(float level)
    {
        // -80 --> 0.0001
        // 0 --> 1
        float logLevel = 20.0f * Mathf.Log10(level);
        masterMixer.SetFloat("musicVol", logLevel);
    }

    public void SetAmbientLvl(float level)
    {
        soundDesignMixer.SetFloat("ambientVol", level);
    }
}
