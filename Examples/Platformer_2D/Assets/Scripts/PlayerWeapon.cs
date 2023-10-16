using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    Transform _firePoint;
    Transform _bulletParent;
    // Start is called before the first frame update
    void Start()
    {
        _firePoint = GameObject.Find("Fire Point").transform;
        _bulletParent = GameObject.Find("Bullets").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse button 0 is left click
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(
                _bullet,                // Prefab
                _firePoint.position,    // Position to instantiate
                _firePoint.rotation,    // Rotation applied
                _bulletParent           // Parent object
            );
        }
    }
}
