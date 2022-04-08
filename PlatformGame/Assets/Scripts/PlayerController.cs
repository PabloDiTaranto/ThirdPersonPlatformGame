using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rgbd;

    [SerializeField]
    private GameObject _mesh;

    [SerializeField]
    private float speed = 5f;
    
    [SerializeField]
    private float jumpForce = 5f;

    private void Awake()
    {
        _rgbd = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        UpdateManager.SuscribeToFixedUpdate(OnFixedUpdate);
        UpdateManager.SuscribeToUpdate(OnUpdate);
    }
    
    private void OnDisable()
    {
        UpdateManager.UnsuscribeToFixedUpdate(OnFixedUpdate);
        UpdateManager.UnsuscribeToUpdate(OnUpdate);
    }

    private void Start()
    {
        MouseBeheviour.HideMouseAndCursor();
    }

    void OnUpdate()
    {
        if(InputManager.JumpPressed()) Jump();
    }
    
    void OnFixedUpdate()
    {
        //call Move() using the input manager   
        Move(new Vector3(InputManager.GetAxis("Horizontal"), 0, InputManager.GetAxis("Vertical")));
    }

    void Move(Vector3 direction)
    {
        if(direction == Vector3.zero) return;
        
        Vector3 desiredDirection = Camera.main.transform.TransformDirection(direction);
        desiredDirection.y = 0;
        desiredDirection.Normalize();
        direction.y = 0;
        direction.Normalize();
        _rgbd.MovePosition(_rgbd.position + desiredDirection * speed * Time.fixedDeltaTime);
        RotateMesh(desiredDirection);
    }
    
    //set rotation of mesh to movement direction
    void RotateMesh(Vector3 direction)
    {
        _mesh.transform.localRotation = Quaternion.Lerp(_mesh.transform.rotation,Quaternion.LookRotation(direction), 150f);
    }

    //jump by rigidbody
    void Jump()
    {
        _rgbd.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    
}
