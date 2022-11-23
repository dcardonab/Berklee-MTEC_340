using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float _sensitivity = 5000f;
    [SerializeField] Transform _playerTransform;
    [SerializeField] Canvas _canvas;

    float _xRotation = 0f;

    void Awake()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Lock cursor to the center of the screen to prevent
        // it from going beyond the screen bounds.
        Cursor.lockState = _canvas.enabled ? CursorLockMode.None : CursorLockMode.Locked;

        // Get input
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        // Rotate camera up and down about the X axis
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        // Rotate player about the Y axis
        _playerTransform.Rotate(Vector3.up * mouseX);
    }
}
