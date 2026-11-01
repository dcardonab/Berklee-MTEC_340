using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private float _defeatAnimTime = 1.5f;

    public void ReactToHit()
    {
        Wandering nav = GetComponent<Wandering>();

        if (nav)
        {
            nav.IsAlive = false;
        }

        StartCoroutine(DefeatAnim());
    }

    IEnumerator DefeatAnim()
    {
        float timer = 0.0f;
        
        Quaternion initRotation = transform.rotation;
        Quaternion endRotation = transform.rotation * Quaternion.Euler(-75.0f, 0.0f, 0.0f);

        while (timer < _defeatAnimTime)
        {
            transform.rotation = Quaternion.Lerp(
                initRotation,                   // A
                endRotation,                    // B
                timer / _defeatAnimTime       // Alpha
            );
            
            timer += Time.deltaTime;

            yield return null;  // Skip frame
        }
        
        // Manually reach destination
        transform.rotation = endRotation;
        
        yield return new WaitForSeconds(1.0f);
        
        Destroy(gameObject);
    }
}
