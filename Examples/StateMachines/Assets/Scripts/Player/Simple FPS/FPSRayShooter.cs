using System.Collections;
using UnityEngine;

public class FPSRayShooter : MonoBehaviour
{
    private Camera _cam;

    bool _enemyStateMachine;

    private void Start()
    {
        _cam = GetComponent<Camera>();

        // Lock cursor to the middle of the screen and hide it.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Try to retrieve the version of the enemy that is using a state
        // machine to set a flag so the enemy properly reacts to being shot
        GameObject enemy = GameObject.Find("Enemy_StateMachine(Clone)");
        _enemyStateMachine = enemy == null;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
        // Left click
        if (Input.GetMouseButtonDown(0))
        {
            // Create a point at the middle of the viewport
            Vector3 point = new(_cam.pixelWidth / 2, _cam.pixelHeight / 2, 0);

            // Create a ray to the created point
            Ray ray = _cam.ScreenPointToRay(point);

            // Check if the created ray collided with any geometry
            // RaycastHit is a data structure to record information about
            // the ray collision
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Retrieve GameObject ray collided with.
                GameObject hitObj = hit.transform.gameObject;
                ReactiveTarget target = hitObj.GetComponent<ReactiveTarget>();

                if (target != null)
                    if (!_enemyStateMachine)
                        target.ReactToHit();
                    else
                        hitObj.GetComponent<EnemyStateMachine>().ReactToHit();
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
        float posX = _cam.pixelWidth / 2 - size / 4;
        float posY = _cam.pixelHeight / 2 - size / 2;

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
