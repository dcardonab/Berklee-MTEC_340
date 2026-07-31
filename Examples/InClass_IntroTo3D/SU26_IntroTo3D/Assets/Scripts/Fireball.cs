using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Fireball : MonoBehaviour
{
    [SerializeField] private float _speed = 15.0f;
    [SerializeField] private int _damage = 1;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void Update()
    {
        transform.Translate(0.0f, 0.0f, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // DAMAGE PLAYER
        
        Destroy(gameObject);
    }
}
