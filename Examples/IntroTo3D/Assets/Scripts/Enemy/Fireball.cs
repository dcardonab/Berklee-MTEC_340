using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] float _speed = 10.0f;
    [SerializeField] int _damage = 1;

    private void Update()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
    }

    // Note that the Fireball needs a Rigidbody to be detected by Unity's
    // collision system. Additionally, its collider Trigger must be activated.
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = GetComponent<PlayerCharacter>();
        if (player != null)
            player.Hurt(_damage);

        Destroy(gameObject);
    }
}
