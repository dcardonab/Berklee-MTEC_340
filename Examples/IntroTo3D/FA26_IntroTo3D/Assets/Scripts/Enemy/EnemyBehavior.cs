using System.Collections;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float _defeatAnimationTime = 1.5f;
    
    private SceneController _sceneController;

    private void Start()
    {
        _sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
    }

    private void OnDestroy()
    {
        _sceneController.Enemies.Remove(gameObject);
    }

    public void ReactToHit()
    {
        WanderingAI wanderBehavior = GetComponent<WanderingAI>();
        if (wanderBehavior)
        {
            wanderBehavior.IsAlive = false;
        }

        StartCoroutine(DefeatAnimation());
    }

    private IEnumerator DefeatAnimation()
    {
        Quaternion initRotation = transform.rotation;
        
        // To combine the effect of two quaternions, we can multiply them
        Quaternion endRotation = transform.rotation * Quaternion.Euler(-75.0f, 0.0f, 0.0f);

        float elapsedTime = 0.0f;

        while (elapsedTime < _defeatAnimationTime)
        {
            // Iterpolate between A and B based on an Alpha value
            transform.rotation = Quaternion.Lerp(initRotation, endRotation, elapsedTime / _defeatAnimationTime);
            
            elapsedTime += Time.deltaTime;
            
            yield return null;  // Skip frame
        }
        
        transform.rotation = endRotation;
        
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
