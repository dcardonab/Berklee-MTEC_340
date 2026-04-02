using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    enum RotationAxes
    {
        MouseXAndY,
        MouseX,
        MouseY
    }
    
    [Header("Degrees of Freedom")]
    [SerializeField] private RotationAxes _axes = RotationAxes.MouseXAndY;

    [Space(5)]
    [Header("Sensitivity")]
    [SerializeField] private float _sensitivityHorizontal = 10.0f;
    [SerializeField] private float _sensitivityVertical = 10.0f;
    
    [Space(5)]
    [Header("Constraints")]
    [SerializeField] private float _minVerticalAngle = -45.0f;
    [SerializeField] private float _maxVerticalAngle = 45.0f;

    private float _verticalRotation = 0.0f;
    
    void Update()
    {
        switch (_axes)
        {
            case RotationAxes.MouseX:
                transform.Rotate(
                    0.0f,
                    Input.GetAxis("Mouse X") * _sensitivityHorizontal,
                    0.0f
                );
                break;
            
            case RotationAxes.MouseY:
                _verticalRotation -= Input.GetAxis("Mouse Y") * _sensitivityVertical;
                _verticalRotation = Mathf.Clamp(_verticalRotation, _minVerticalAngle, _maxVerticalAngle);

                float horizontalRotation = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(
                    _verticalRotation, horizontalRotation, 0.0f
                );
                break;
            
            case RotationAxes.MouseXAndY:
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
