using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float _sensitivity = 5000f;

    float _xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get input
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        // Rotate camera up and down about the X axis
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        // Rotate player about the Y axis
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
