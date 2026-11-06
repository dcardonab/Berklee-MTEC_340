using UnityEngine;
using System.Collections.Generic;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [HideInInspector] public List<GameObject> Enemies = new List<GameObject>();

    private int _wave = 1;
    private void Update()
    {
        if (Enemies.Count == 0)
        {
            for (int i = 0; i < _wave; i++)
            {
                GameObject enemy = Instantiate(
                    _enemyPrefab,
                    new Vector3(Random.Range(-10.0f, 10.0f), 1.5f, Random.Range(-10.0f, 10.0f)),
                    Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f)
                );
                
                Enemies.Add(enemy);
            }

            _wave++;
        }
    }
}
