using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField, Range(5.0f, 50.0f)] private float _projectileSpeed = 10.0f;
    
    void Update()
    {
        transform.Translate(_projectileSpeed * Time.deltaTime * Vector3.right);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScoreArea"))
        {
            Destroy(gameObject);
        }
    }
}
