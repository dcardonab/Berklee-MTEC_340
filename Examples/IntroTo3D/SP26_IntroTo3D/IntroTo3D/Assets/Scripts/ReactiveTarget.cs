using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private float _defeatAnimTime = 1.5f;

    public void ReactToHit()
    {
        Wandering nav = GetComponent<Wandering>();
        
        if (nav != null)
            nav.IsAlive = false;

        StartCoroutine(DefeatAnim());
    }

    IEnumerator DefeatAnim()
    {
        float elapsedTime = 0.0f;
        
        Quaternion initRotation = transform.rotation;
        
        // Multiplying quaternions combines the effect of both
        Quaternion endRotation = transform.rotation * Quaternion.Euler(-75.0f, 0.0f, 0.0f);

        // Interpolation logic
        while (elapsedTime < _defeatAnimTime)
        {
            transform.rotation = Quaternion.Lerp(
                initRotation,
                endRotation,
                elapsedTime / _defeatAnimTime
            );
            
            elapsedTime += Time.deltaTime;

            yield return null;  // Skip frame
        }
        
        // Reach destination
        transform.rotation = endRotation;
        
        yield return new WaitForSeconds(1.0f);
        
        Destroy(gameObject);
    }
}
