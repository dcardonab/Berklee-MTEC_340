using UnityEngine;
using UnityEngine.Audio;

public class ParameterMapping : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] string _parameterName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Get the current value of the exposed parameter
            _mixer.GetFloat(_parameterName, out float value);
            
            // Update the value that was retrieved
            _mixer.SetFloat(_parameterName, value + 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _mixer.ClearFloat(_parameterName);
        }
    }
}
