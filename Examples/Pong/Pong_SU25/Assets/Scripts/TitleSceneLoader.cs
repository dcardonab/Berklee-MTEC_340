using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneLoader : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Pong");
        }
    }
}
