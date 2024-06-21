using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehavior : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return)) {
            SceneManager.LoadScene("PongPhysics");
        }
    }
}
