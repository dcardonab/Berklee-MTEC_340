using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _cam;

    private void Start()
    {
        _cam = GetComponent<Camera>();

        // Lock cursor to the middle of the screen and hide it.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Left click
        if (Input.GetMouseButtonDown(0))
        {
            // Create a point at the middle of the viewport
            Vector3 point = new(_cam.pixelWidth * 0.5f, _cam.pixelHeight * 0.5f, 0);

            // Create a ray to the created point
            Ray ray = _cam.ScreenPointToRay(point);

            // Data structure to record information about the ray collision
            RaycastHit hit;

            // Check if the created ray collided with any geometry
            if (Physics.Raycast(ray, out hit))
            {
                // Retrieve GameObject ray collided with.
                GameObject hitObj = hit.transform.gameObject;
                ReactiveTarget target = hitObj.GetComponent<ReactiveTarget>();

                if (target != null)
                    target.ReactToHit();
                else
                    StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }

    // OnGUI runs after the scene has been rendered.
    void OnGUI()
    {
        // Size of the rectangular GUI that will contain the text.
        int size = 12;

        // Position of the text. Note that subtracting the scaled size will
        // ensure that the star is centered.
        float posX = _cam.pixelWidth * 0.5f - size * 0.25f;
        float posY = _cam.pixelHeight * 0.5f - size * 0.5f;

        // Change the color of the GUI's contents to red.
        GUI.contentColor = Color.red;

        // Render a label that defines a position and the text it contains.
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    IEnumerator SphereIndicator(Vector3 pos)
    {
        // Create and place a sphere where the hit collided.
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
