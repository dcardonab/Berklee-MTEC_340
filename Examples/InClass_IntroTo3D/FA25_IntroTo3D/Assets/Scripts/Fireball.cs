using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Fireball : MonoBehaviour
{
    [SerializeField] float _speed = 10.0f;
    [SerializeField] int _damage = 1;
    
    void Update()
    {
        transform.Translate(0.0f, 0.0f, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();

        if (player != null)
            player.Health -= _damage;
        
        Destroy(gameObject);
    }
}
