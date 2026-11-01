using UnityEngine;

public class MouseLook : MonoBehaviour
{
    enum RotationAxes
    {
        MouseXandY,
        MouseX,
        MouseY
    }
    
    [Header("Degrees of Freedom")]
    [SerializeField] private RotationAxes _axes = RotationAxes.MouseXandY;
    
    [Space(5)]
    [Header("Sensitivity")]
    [SerializeField] private float _sensitivityHorizontal = 9.0f;
    [SerializeField] private float _sensitivityVertical = 9.0f;
    
    [Space(5)]
    [Header("Constraints")]
    [SerializeField] private float _minVerticalAngle = -45.0f;
    [SerializeField] private float _maxVerticalAngle = 45.0f;
    
    private float _verticalRotation = 0.0f;
    
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        if (rb != null)
            rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_axes)
        {
            case RotationAxes.MouseX:
                transform.Rotate(
                    0.0f,
                    Input.GetAxis("Mouse X") * _sensitivityHorizontal,
                    0.0f);
                break;
            
            case RotationAxes.MouseY:
                _verticalRotation -= Input.GetAxis("Mouse Y") * _sensitivityVertical;
                _verticalRotation = Mathf.Clamp(_verticalRotation, _minVerticalAngle, _maxVerticalAngle);
                
                float horizontalRotation = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(
                    _verticalRotation, horizontalRotation, 0.0f
                );
                
                break;
            
            case RotationAxes.MouseXandY:
                _verticalRotation -= Input.GetAxis("Mouse Y") * _sensitivityVertical;
                _verticalRotation = Mathf.Clamp(_verticalRotation, _minVerticalAngle, _maxVerticalAngle);
                
                float deltaX = Input.GetAxis("Mouse X") * _sensitivityHorizontal;
                horizontalRotation = transform.localEulerAngles.y + deltaX;

                transform.localEulerAngles = new Vector3(
                    _verticalRotation, horizontalRotation, 0.0f
                );
                
                break;
                
        }
    }
}
