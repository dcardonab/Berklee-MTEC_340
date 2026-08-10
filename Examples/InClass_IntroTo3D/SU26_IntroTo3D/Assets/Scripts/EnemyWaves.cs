using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    public List<GameObject> Enemies = new List<GameObject>();

    private int _waveNumber = 0;
    private float _waveCooldown = 2.0f;
    
    private bool _isSpawning = false;

    private void Update()
    {
        if (Enemies.Count == 0 && !_isSpawning)
        {
            StartCoroutine(SpawnWave(_waveNumber + 1));
        }
    }

    private IEnumerator SpawnWave(int waveNumber)
    {
        _isSpawning = true;
        
        yield return new WaitForSeconds(_waveCooldown);
        
        for (int i = 0; i < waveNumber; i++)
        {
            Vector3 pos = Vector3.zero;
            
            do
            {
                 pos = new Vector3(
                    Random.Range(-20.0f, 20.0f),
                    1.5f,
                    Random.Range(-20.0f, 20.0f)
                );
            } while (
                Physics.BoxCast(
                    pos, transform.localScale * 0.5f, Vector3.zero
                )
            );
            
            GameObject enemy = Instantiate(
                _enemyPrefab,
                pos,
                Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f),
                transform
            );
            
            Enemies.Add(enemy);
        }

        _waveNumber++;
        
        _isSpawning = false;
    }
}
