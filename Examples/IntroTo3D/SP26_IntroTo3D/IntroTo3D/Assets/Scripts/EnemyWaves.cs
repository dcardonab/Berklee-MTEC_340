using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private GameObject _enemy;

    private bool _isSpawning;
    
    void Update()
    {
        if (!_enemy && !_isSpawning)
        {
            _isSpawning = true;
            Invoke(nameof(SpawnEnemy), Random.value * 2.0f);
        }
    }

    void SpawnEnemy()
    {
        _enemy = Instantiate(
            _enemyPrefab,
            new Vector3(0.0f, 2.0f, 0.0f),
            Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f)
        );

        _isSpawning = false;
    }
}
