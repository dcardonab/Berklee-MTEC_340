using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager: MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Platformer");
        }
    }
}
