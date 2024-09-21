using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    private GameObject _enemy;

    private void Update()
    {
        // Enemies will continue to spawn indefinitely as long as there are no
        // enemies on the scene.
        if (_enemy == null)
        {
            _enemy = Instantiate(
                _enemyPrefab,                                    // Prefab
                new Vector3(0, 1, 0),                           // Position
                Quaternion.Euler(0, Random.Range(0, 360), 0)   // Rotation
            );
        }
    }
}
