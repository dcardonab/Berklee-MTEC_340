using System;
using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _cam;

    private void Start()
    {
        // Camera.main returns the camera that is currently rendering
        _cam = Camera.main;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Compute the middle of the screen
            Vector3 screenMiddle = new(_cam.pixelWidth * 0.5f, _cam.pixelHeight * 0.5f, 0);
            
            // Convert point into a ray that casts out of the camera
            Ray ray = _cam.ScreenPointToRay(screenMiddle);

            // Create data structure to store information on what the ray hit
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObj = hit.transform.gameObject;
                ReactiveTarget target = hitObj.GetComponent<ReactiveTarget>();

                if (target)
                {
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private void OnGUI()
    {
        int size = 12;

        float posX = _cam.pixelWidth * 0.5f - size * 0.25f;
        float posY = _cam.pixelHeight * 0.5f - size * 0.5f;
        
        GUI.contentColor = Color.red;
        
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    IEnumerator SphereIndicator(Vector3 position)
    {
        // Create sphere and place
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        sphere.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        
        yield return new WaitForSeconds(1.0f);
        Destroy(sphere);
    }
}
