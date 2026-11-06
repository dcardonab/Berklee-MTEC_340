using System;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private int _damage = 1;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
    
        if (player)
        {
            player.Hurt(_damage);
        }
        
        Destroy(gameObject);
    }
}
