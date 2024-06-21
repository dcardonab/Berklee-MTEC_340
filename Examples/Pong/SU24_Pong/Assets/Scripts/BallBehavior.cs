using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    private float _speed;
    [SerializeField] private float _xLimit = 10.0f;
    float _yLimit;
    private Vector2 _direction;
    
    private AudioSource _source;
    [SerializeField] AudioClip _wallHit;
    [SerializeField] AudioClip _paddleHit;
    [SerializeField] AudioClip _losePoint;
    
    void Start()
    {
        _yLimit = GameBehavior.Instance.CalculateYLimit(gameObject);

        _source = GetComponent<AudioSource>();
        
        ResetBall();
    }
    
    void Update()
    {
        if (GameBehavior.Instance.State == GameBehavior.StateMachine.Play)
        {
            transform.position += (Vector3)_direction * _speed * Time.deltaTime;
            CheckBounds();
        }
    }

    void CheckBounds()
    {
        if (Mathf.Abs(transform.position.y) > _yLimit)
        {
            _direction.y *= -1;
            transform.position = new Vector3(
                transform.position.x, Mathf.Sign(transform.position.y) * _yLimit, transform.position.z
            );

            PlaySound(_wallHit);
        }

        if (Mathf.Abs(transform.position.x) > _xLimit)
        {
            GameBehavior.Instance.ScorePoint(
                transform.position.x > 0 ? 0 : 1
            );
            
            PlaySound(_losePoint);
            
            ResetBall();
        }
    }

    void ResetBall()
    {
        transform.position = Vector3.zero;
            
        _direction = new Vector2(
            Random.value > 0.5f ? 1 : -1,
            Random.value > 0.5f ? 1 : -1
        );

        _speed = GameBehavior.Instance.InitialBallSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            _speed *= GameBehavior.Instance.BallSpeedIncrement;
            _direction.x *= -1;
            
            PlaySound(_paddleHit);
        }
    }

    void PlaySound(AudioClip clip)
    {
        _source.pitch = Random.Range(0.9f, 1.1f);
        _source.clip = clip;
        _source.Play();
    }
}
