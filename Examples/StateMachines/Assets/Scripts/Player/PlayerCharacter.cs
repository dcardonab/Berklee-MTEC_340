using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] int _health = 5;
    public int Health
    {
        get => _health;
        set
        {
            _health = value;
        }
    }

    public int maxHealth;

    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log($"Health: {_health}");
    }
}
