using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float XSpeed = 3.0f;
    public float YSpeed = 3.0f;

    private int _xDir;
    private int _yDir;

    public float YLimit = 4.8f;
    
    void Start()
    {
        if (Random.value > 0.5f)
        {
            _xDir = 1;
        }
        else
        {
            _xDir = -1;
        }

        // value = condition ? pass : fail
        _yDir = Random.value > 0.5 ? 1 : -1;
    }
    
    void Update()
    {
        if (Mathf.Abs(transform.position.y) >= YLimit)
        {
            _yDir *= -1;
        }
        
        transform.position += new Vector3(XSpeed * _xDir, YSpeed * _yDir, 0) * Time.deltaTime;
    }
}
