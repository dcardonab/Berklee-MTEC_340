using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _yLimit = 3.6f;

    [SerializeField] private KeyCode _upKey;
    [SerializeField] private KeyCode _downKey;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_upKey) && transform.position.y < _yLimit)
        {
            transform.position += new Vector3(0, _speed * Time.deltaTime, 0);
        }
        
        if (Input.GetKey(_downKey) && transform.position.y > -_yLimit)
        {
            transform.position -= new Vector3(0, _speed * Time.deltaTime, 0);
        }
    }
}
