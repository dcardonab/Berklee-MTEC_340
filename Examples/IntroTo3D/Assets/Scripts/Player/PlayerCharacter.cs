using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] int _health = 5;

    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log($"Health: {_health}");
    }
}
