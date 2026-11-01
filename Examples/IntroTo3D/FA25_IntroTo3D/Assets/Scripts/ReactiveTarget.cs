using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private float _defeatAnimTime = 1.5f;

    public void ReactToHit()
    {
        WanderingAI navBehavior = GetComponent<WanderingAI>();

        if (navBehavior != null)
            navBehavior.IsAlive = false;

        StartCoroutine(DefeatAnim());
    }

    private IEnumerator DefeatAnim()
    {
        float elapsedTime = 0.0f;
        
        // Quaternion interpolation to achieve rotation animation
        Quaternion initRotation = transform.rotation;
        
        // To combine the effect of two quaternions, we multiply those quaternions
        Quaternion endRotation = transform.rotation * Quaternion.Euler(-75.0f, 0.0f, 0.0f);

        while (elapsedTime < _defeatAnimTime)
        {
            // Interpolate between A and B based on Alpha:
            //      A = initRotation
            //      B = endRotation
            //      Alpha = timer
            transform.rotation = Quaternion.Lerp(
                initRotation, endRotation, elapsedTime / _defeatAnimTime);
            
            elapsedTime += Time.deltaTime;
            
            yield return null;  // Skip frame
        }
        
        // Make sure we make it to the destination
        transform.rotation = endRotation;
        
        yield return new WaitForSeconds(1.0f);
        
        Destroy(gameObject);
    }
}
