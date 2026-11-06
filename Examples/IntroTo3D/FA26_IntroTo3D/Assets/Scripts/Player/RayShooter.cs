using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _cam;

    private void Start()
    {
        _cam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new(_cam.pixelWidth * 0.5f, _cam.pixelHeight * 0.5f, 0.0f);

            Ray ray = _cam.ScreenPointToRay(point);
            
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObj = hit.transform.gameObject;

                EnemyBehavior enemyBehavior = hitObj.GetComponent<EnemyBehavior>();

                if (enemyBehavior)
                {
                    enemyBehavior.ReactToHit();
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
        // Size of the area where the GUI will be rendered
        int size = 12;
        
        float posX = _cam.pixelWidth * 0.5f - size * 0.25f;
        float posY = _cam.pixelHeight * 0.5f - size * 0.5f;
        
        GUI.contentColor = Color.red;
        
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }

    private IEnumerator SphereIndicator(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        
        yield return new WaitForSeconds(1.0f);
        
        Destroy(sphere);
    }
}
