using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Timers;
using UnityEditor.Timeline;
using UnityEngine;

public class ControlDron : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 MoveDir;


    public Transform DroneTransform;

    public float FlySpeed;
    public float MouseSensitivity;

    //W & S AXIS
    private float x;
    private float z;

    void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        YRotate();
        Tilt();
    }


    void Move()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        MoveDir = transform.right * x + transform.forward * z;
        _controller.Move(MoveDir * FlySpeed * Time.deltaTime);
    }

    void Tilt()
    {
        if (x > 0)
        {
            DroneTransform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Mathf.Clamp(transform.rotation.z, -5, 0 ));
        }
    }

    void YRotate()
    {
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        DroneTransform.Rotate(Vector3.up * MouseX);
    }
}