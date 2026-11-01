using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField, Min(0)] private int _health = 5;

    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            Debug.Log("Health: " + Health);
        }
    }
}
