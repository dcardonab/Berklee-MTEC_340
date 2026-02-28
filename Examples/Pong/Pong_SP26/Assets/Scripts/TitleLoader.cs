using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLoader : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Pong");
        }
    }
}
