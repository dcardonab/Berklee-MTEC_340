using System;
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
    [SerializeField] RotationAxes _axes = RotationAxes.MouseXandY;

    [Space(5)] [Header("Sensitivity")]
    [SerializeField] private float _sensitivityHor = 10.0f;
    [SerializeField] private float _sensitivityVer = 10.0f;
    
    [Space(5)] [Header("Constraints")]
    [SerializeField] float _minVer = -45.0f;
    [SerializeField] float _maxVer = 45.0f;

    private float _verticalRot = 0.0f;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb)
        {
            rb.freezeRotation = true;
        }
    }

    private void Update()
    {
        switch (_axes)
        {
            case RotationAxes.MouseX:
                transform.Rotate(
                    0.0f,
                    Input.GetAxis("Mouse X") * _sensitivityHor,
                    0.0f
                );
                
                break;
        }
    }
}
