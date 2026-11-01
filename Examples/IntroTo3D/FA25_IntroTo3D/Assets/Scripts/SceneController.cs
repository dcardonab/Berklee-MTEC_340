using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private GameObject _enemy;
    
    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(
                _enemyPrefab,
                new Vector3(0.0f, 2.0f, 0.0f),
                Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f)
            );
        }
    }
}
