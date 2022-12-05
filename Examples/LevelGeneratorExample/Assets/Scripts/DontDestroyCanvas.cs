using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCanvas : MonoBehaviour
{
    public static DontDestroyCanvas Instance = null;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
