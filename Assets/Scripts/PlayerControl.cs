using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    CharacterController _characterController;
    Rigidbody rb;
   
    float _horizontal;
    float _vertical;
   
    float _lastVelocity_Y;
    float _lastVelocity_X;
    float _lastVelocity_Z;


    [SerializeField]
    float Speed = 2;


    [SerializeField]
    float RotationSpeed = 40f;


    [SerializeField]
    float SprintSpeed = 6;


    [SerializeField]
    float JumpSpeed = 5;


    [SerializeField]
    Transform GroundChecker;


    [SerializeField]
    LayerMask WhatIsGround;


    [SerializeField]
    bool Isgrounded;


    [SerializeField]
    private float Smoothing_Ground=0.1f;
    [SerializeField]
    private float Smoothing_Air = 0.0001f;


    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;


    private Camera currentCamera;
    private Vector3 originalThirdPersonCameraPosition;
    private float zoomDistance;
    private float originalFirstPersonFov;
    private float minFov = 10.0f;
    private float maxFov = 60.0f;
    private float zoomSpeed = 1.0f;


   


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        currentCamera = firstPersonCamera;
        thirdPersonCamera.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        GetInputs();
        Move(_horizontal, _vertical);
        changeCamera();
    }


    private void GetInputs()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
         
       
    }


    private void Move(float horizontal, float vertical)
    {
        Vector3 localInput = transform.right * horizontal + transform.forward * vertical;


        float targetVelocity_x = localInput.x * Speed;
        float targetVelocity_z = localInput.z * Speed;


        float smoothing = IsGrounded() ? Smoothing_Ground : Smoothing_Air;


        Vector3 velocity = new Vector3(0, 0, 0);
        velocity.x = Mathf.Lerp(_lastVelocity_X, targetVelocity_x, smoothing);
        velocity.y = GetVelocity_Y();
        velocity.z = Mathf.Lerp(_lastVelocity_Z, targetVelocity_z, smoothing);


        // Scale the target velocities by sprint speed if player is sprinting
        if (Sprints())
        {
            velocity.x = localInput.x * SprintSpeed;
            velocity.z = localInput.z * SprintSpeed;


            }


        if (Jumps() && IsGrounded())
        {
            {
                velocity.y += JumpSpeed;
            }
        }


        _characterController.Move(velocity * Time.deltaTime);


        _lastVelocity_X = velocity.x;
        _lastVelocity_Y = velocity.y;
        _lastVelocity_Z = velocity.z;


        if (velocity.magnitude > 0)
        {
            velocity.y = 0;
            Vector3 target_point = transform.position + velocity;
            Vector3 current_point = transform.position + transform.forward;
            Vector3 point = Vector3.Lerp(current_point, target_point, 0.01f);
            transform.LookAt(point);
        }
       
       
    }


    private void changeCamera()
    {
        // Switch camera when the "C" key is pressed
    if (Input.GetKeyDown(KeyCode.C) || Input.GetKey(KeyCode.JoystickButton1))
    {
        // Disable the current camera
        currentCamera.enabled = false;
       
        // Switch the current camera to the other camera
        if (currentCamera == firstPersonCamera)
        {
            currentCamera = thirdPersonCamera;
        }
        else
        {
            currentCamera = firstPersonCamera;
        }
       
        // Enable the new current camera
        currentCamera.enabled = true;
       
    }
    }
   
   


    //Detecta si el jugador clica shift
    private bool Sprints()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton10))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private bool Jumps()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0))
        {
            return true;
        }
        else
        {
            return false;
        }


    }


    private float GetVelocity_Y()
    {
        if (IsGrounded())
        {
            return 0;
        }
        float oldvelocity = _lastVelocity_Y;
        float gravity = -9.81f;




        float newVelocity = oldvelocity + gravity * Time.deltaTime;
        return newVelocity;
    }


    bool IsGrounded()
    {
        Isgrounded=true;
        return Physics.CheckSphere(GroundChecker.position, 0.15f, WhatIsGround);
    }


}


