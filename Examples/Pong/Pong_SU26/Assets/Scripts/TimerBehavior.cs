using UnityEngine;
using TMPro;

public class TimerBehavior : MonoBehaviour
{
    private float _timer = 0;
    public float Timer
    {
        get => _timer;
        set
        {
            _timer = value;
            
            int minutes = Mathf.FloorToInt(Timer / 60);
            int seconds = Mathf.FloorToInt(Timer % 60);

            _timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }
    
    [SerializeField] TMP_Text _timerText;
    
    void Update()
    {
        Timer += Time.deltaTime;
    }
}
