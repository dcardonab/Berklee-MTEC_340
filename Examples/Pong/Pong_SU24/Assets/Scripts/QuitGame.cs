using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class QuitGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            QuitPong();
        }       
    }

    void QuitPong()
    {
        #if UNITY_EDITOR
            // Function will be called if the game is running through Unity
            EditorApplication.isPlaying = false;
        #else
            // Function will be called if the game is running from a Build
            Application.Quit();
        #endif
    }
}
