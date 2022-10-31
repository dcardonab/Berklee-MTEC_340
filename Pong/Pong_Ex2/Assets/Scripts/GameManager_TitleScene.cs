using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_TitleScene : MonoBehaviour
{
    public static GameManager_TitleScene Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
            SceneManager.LoadScene("PlayScene");
    }
}
