using System.Collections;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreUI;
    
    // Backing variable
    private int _score;

    // Public variable
    public int Score
    {
        get => _score;

        set
        {
            _score = value;
            _scoreUI.SetText(Score.ToString());
        }
    }

    private PaddleBehavior _paddle;

    [SerializeField, Range(1.0f, 10.0f)] private float _powerUpDuration = 5.0f; 

    private void Start()
    {
        _paddle = GetComponent<PaddleBehavior>();
    }

    public IEnumerator PowerUp()
    {
        if (_paddle.CanShoot)
        {
            // Break out of coroutine from within the coroutine function
            yield break;
        }

        _paddle.CanShoot = true;
        
        yield return new WaitForSeconds(_powerUpDuration);
        
        _paddle.CanShoot = false;
    }
}
