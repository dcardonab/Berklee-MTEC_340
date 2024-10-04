using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    private float _speed;
    
    [SerializeField] float _yLimit = 4.85f;
    [SerializeField] float _xLimit = 10.0f;

    private Vector2 _direction;

    private AudioSource _source;

    [SerializeField] private AudioClip _wallHit;
    [SerializeField] private AudioClip _paddleHit;
    [SerializeField] private AudioClip _scorePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        ResetBall();

        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameBehavior.Instance.State == Utilities.GameplayState.Play)
        {
            transform.position += new Vector3(
                _speed * _direction.x,
                _speed * _direction.y,
                0.0f
            ) * Time.deltaTime;

            if (Mathf.Abs(transform.position.y) >= _yLimit)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    (_yLimit - 0.01f) * Mathf.Sign(transform.position.y),
                    transform.position.z
                );
                _direction.y *= -1;

                _source.pitch = Random.Range(0.75f, 1.25f);
                _source.PlayOneShot(_wallHit);
            }

            if (Mathf.Abs(transform.position.x) >= _xLimit)
            {
                GameBehavior.Instance.ScorePoint(
                    transform.position.x > 0 ? 1 : 2
                );
                
                ResetBall();

                _source.pitch = 1.0f;
                _source.PlayOneShot(_scorePoint);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Paddle"))
        {
            _speed *= GameBehavior.Instance.BallSpeedIncrement;
            _direction.x *= -1;
            
            _source.pitch = Random.Range(0.75f, 1.25f);
            _source.PlayOneShot(_paddleHit);
        }
    }

    void ResetBall()
    {
        transform.position = Vector3.zero;
            
        _direction = new Vector2(
            // Ternary operator
            // condition ? passing : failing
            Random.value > 0.5f ? 1 : -1,
            Random.value > 0.5f ? 1 : -1
        );

        _speed = GameBehavior.Instance.InitBallSpeed;
    }
}
