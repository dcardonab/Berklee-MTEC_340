using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoyObject : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
