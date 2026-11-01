using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Fireball : MonoBehaviour
{
    [SerializeField] private float _speed = 15.0f;
    [SerializeField] int _damage = 1;
    
    void Update()
    {
        transform.Translate(0.0f, 0.0f, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        
        if (player)
            player.Health -= _damage;
        
        Destroy(gameObject);
    }
}
