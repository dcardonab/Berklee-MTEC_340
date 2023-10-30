using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Start()
    {
        // Prevent the object from being destroyed when a new scene is loaded.
        DontDestroyOnLoad(gameObject);
    }
}
