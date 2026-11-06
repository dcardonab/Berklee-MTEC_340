using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 5;

    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log(_health);
    }
}
