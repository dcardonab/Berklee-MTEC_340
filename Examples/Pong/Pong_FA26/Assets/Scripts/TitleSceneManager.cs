using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("Pong");
        }
    }
}
