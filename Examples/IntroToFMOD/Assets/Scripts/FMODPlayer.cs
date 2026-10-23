using UnityEngine;

public class FMODPlayer : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference _eventRef;

    private FMOD.Studio.EventInstance _instance;
    
    bool _isPlaying = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!_isPlaying)
            {
                _instance = FMODUnity.RuntimeManager.CreateInstance(_eventRef);
                _instance.start();
                _isPlaying = true;
            }
            else
            {
                _instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                _instance.release();
                _isPlaying = false;
            }
        }
    }
}
