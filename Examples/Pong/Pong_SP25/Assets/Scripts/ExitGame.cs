using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class ExitGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
