using System.Collections;
using UnityEngine;
using UnityEngine.Audio;    // Contains AudioMixerSnapshot

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class PauseManager : MonoBehaviour
{
    [SerializeField] AudioMixerSnapshot paused;
    [SerializeField] AudioMixerSnapshot unpaused;

    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            canvas.enabled = !canvas.enabled;
            Pause();
        }
    }

    void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Lowpass(0.1f);
    }

    void Lowpass(float transitionTime)
    {
        if (Time.timeScale == 0)
            paused.TransitionTo(transitionTime);
        else
            unpaused.TransitionTo(transitionTime);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            // Function will be called if the game is running from Unity.
            EditorApplication.isPlaying = false;
        #else
            // Function will be called if the game is running from a build.
            Application.Quit();
        #endif
    }
}
