using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class QuitGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            QuitApp();
        }
    }

    void QuitApp()
    {
        #if UNITY_EDITOR
            // Set variable if game is running from Unity
            EditorApplication.isPlaying = false;
        #else
            // Function will be called if game is running from a build
            Application.Quit();
        #endif
    }
}
