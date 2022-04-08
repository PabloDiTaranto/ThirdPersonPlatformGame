using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Vector3 offset;
    
    [SerializeField]
    private float speedX, speedY;

    [SerializeField] private float maxAngle;
    
    private void OnEnable()
    {
        UpdateManager.SuscribeToLateUpdate(OnLateUpdate);
    }

    private void OnDisable()
    {
        UpdateManager.UnsuscribeToLateUpdate(OnLateUpdate);
    }

    private void OnLateUpdate()
    {
        Rotate();
        transform.position = target.transform.position + offset;
        transform.LookAt(target.transform);
    }

    void Rotate()
    {
        offset = Quaternion.AngleAxis(InputManager.GetMouseX() * speedX, Vector3.up) * offset;
        offset =  Quaternion.AngleAxis(-InputManager.GetMouseY() * speedY, Vector3.right) * offset;
    }
    
    
    
}
    
