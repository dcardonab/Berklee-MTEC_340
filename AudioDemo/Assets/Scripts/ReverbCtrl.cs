using UnityEngine;
using UnityEngine.Audio;

public class ReverbCtrl : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioMixerSnapshot[] snapshots;
    [SerializeField] float[] weights;

    public void BlendSnapshots(int triggerNr)
    {
        switch (triggerNr)
        {
            case 0:
                weights[0] = 1.0f;
                weights[1] = 0.0f;
                break;
            case 1:
                weights[0] = 0.8f;
                weights[1] = 0.2f;
                break;
            case 2:
                weights[0] = 0.5f;
                weights[1] = 0.5f;
                break;
            case 3:
                weights[0] = 0.2f;
                weights[1] = 0.8f;
                break;
            case 4:
                weights[0] = 0.0f;
                weights[1] = 1.0f;
                break;
            default:
                break;
        }
        mixer.TransitionToSnapshots(snapshots, weights, 2.0f);
    }
}
