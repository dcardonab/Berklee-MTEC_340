using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleSceneManager : MonoBehaviour
{
    private float _timer;
    public float Timer
    {
        get => _timer;
        set
        {
            _timer = value;

            int minutes = Mathf.FloorToInt(Timer / 60.0f);
            int seconds = Mathf.FloorToInt(Timer % 60.0f);
            
            _timerUI.SetText($"{minutes:00}:{seconds:00}");
        }
    }
    [SerializeField] private TMP_Text _timerUI;
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("Pong");
        }
        
        Timer += Time.deltaTime;
    }
}
