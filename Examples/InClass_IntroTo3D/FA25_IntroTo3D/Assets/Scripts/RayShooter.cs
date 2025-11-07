using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _cam;
    
    void Start()
    {
        _cam = GetComponent<Camera>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        // Left click
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new(_cam.pixelWidth * 0.5f, _cam.pixelHeight * 0.5f, 0.0f);

            Ray ray = _cam.ScreenPointToRay(point);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject hitObj = hit.transform.gameObject;
                ReactiveTarget target = hitObj.GetComponent<ReactiveTarget>();

                if (target != null)
                    target.ReactToHit();
                else
                    StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }

    void OnGUI()
    {
        int size = 12;
        
        float posX = _cam.pixelWidth * 0.5f - size * 0.25f;
        float posY = _cam.pixelHeight * 0.5f - size * 0.5f;
        
        GUI.contentColor = Color.red;
        
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    IEnumerator SphereIndicator(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        
        yield return new WaitForSeconds(1.0f);
        
        Destroy(sphere);
    }
}
