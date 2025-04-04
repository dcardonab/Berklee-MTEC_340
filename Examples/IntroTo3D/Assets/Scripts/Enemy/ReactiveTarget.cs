using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] float _deathAnimTime = 1.5f;

    // This code will be triggered once the entity has been shot.
    public void ReactToHit()
    {
        // Switch AI off to prevent entity from continuing to move.
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
            behavior.IsAlive = false;

        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        float elapsedTime = 0.0f;
        
        // Use quaternion interpolation to achieve a rotation animation.
        Quaternion initRotation = transform.rotation;
        // To combine the effect of two quaternions, we multiply those quaternions together.
        Quaternion endRotation = transform.rotation * Quaternion.Euler(-75, 0, 0);
        
        while (elapsedTime < _deathAnimTime)
        {
            // Interpolate between A and B based on an Alpha value:
            //     A = initRotation
            //     B = endRotation
            //     Alpha = timer
            transform.rotation = Quaternion.Lerp(
                initRotation, endRotation, elapsedTime / _deathAnimTime);

            elapsedTime += Time.deltaTime;

            yield return null;  // Skip frame
        }

        // Make sure that the rotation actually makes it to the destination parameter.
        transform.rotation = endRotation;

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
