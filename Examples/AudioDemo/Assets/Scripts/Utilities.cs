using System.Collections;
using UnityEngine;

public static class Utilities
{
    /**************************** RANDOM POSITION ****************************/
    public static Vector3 GenRelativeRandomPos(Transform pos, float minRadius = 3f, float maxRadius = 30f)
    {
        // Retrieve the current location of the player.
        float xPos = pos.position.x;
        float yPos = pos.position.y;
        float zPos = pos.position.z;

        // Determine location of randomly generated sound.
        float radius = Random.Range(minRadius, maxRadius);

        // Use angles around and above from the player.
        // These angles will be calculated in radians.
        float angleHor = Random.Range(0, 2 * Mathf.PI);
        float angleVer = Random.Range(0, Mathf.PI);

        // Use data to create the sound's position.
        return new Vector3(
            /*
             * Horizontal angle will be in range of 0 - 2π
             *     cos(0) && cos(2π) = 1
             *     cos(π) = -1
             * 
             * Vertical angle will be in range of 0 – π
             *     sin(0) && sin(π) = 0
             *     sin(n) > 0 -when- 0 < n < π
             *     
             * Unity's Mathf sin and cos functions receive an angle in radians.
             */
            xPos + Mathf.Cos(angleHor) * radius,
            yPos + Mathf.Sin(angleVer) * radius,
            zPos + Mathf.Cos(angleHor) * radius
        );
    }

    /********************************* FADES *********************************/
    public static IEnumerator FadeIn(AudioSource source, float fadeTime = 2.0f, bool startSound = true)
    {
        if (startSound || !source.isPlaying)
            source.Play();

        source.volume = 0.0f;

        while (source.volume < 0.95f)
        {
            source.volume += Time.deltaTime / fadeTime;
            yield return null;  // Skip a frame
        }

        source.volume = 0.95f;
    }

    public static IEnumerator FadeOut(AudioSource source, float fadeTime = 2.0f, bool stopSound = false)
    {
        while (source.volume > 0.0f)
        {
            // We divide deltaTime by fade time to obtain the duration in seconds.
            // If we multiply, we obtain half the inverse duration:
            // e.g.: if the fade duration is 2
            //     deltaTime / 2 --> correct fade duration --> approx. 2 secs
            //     deltaTime * 2 --> incorrect duration --> approx. 0.5 secs
            source.volume -= Time.deltaTime / fadeTime;
            yield return null;
        }

        source.volume = 0.0f;

        if (stopSound && source.isPlaying)
            source.Stop();
    }
}
