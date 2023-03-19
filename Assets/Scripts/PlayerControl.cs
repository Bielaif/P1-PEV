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
    private float Smoothing_Ground=0.1f;
    [SerializeField]
    private float Smoothing_Air = 0.0001f;


    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;


    public Camera currentCamera;

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

        //Per suavitzar el moviment
        float smoothing = IsGrounded() ? Smoothing_Ground : Smoothing_Air;


        Vector3 velocity = new Vector3(0, 0, 0);
        velocity.x = Mathf.Lerp(_lastVelocity_X, targetVelocity_x, smoothing);
        velocity.z = Mathf.Lerp(_lastVelocity_Z, targetVelocity_z, smoothing);


        //Augmenta la velocitat del personatge si aquest sprinta
        if (Sprints())
        {
            velocity.x = localInput.x * SprintSpeed;
            velocity.z = localInput.z * SprintSpeed;
        }


        _characterController.Move(velocity * Time.deltaTime);


        _lastVelocity_X = velocity.x;
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
        //Mira si s'apreten els controls per fer el toggle de camera
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.JoystickButton4))
        {
     
        currentCamera.enabled = false;
       
        // Canvia la camara depenent de quina estigui fent servir
        if (currentCamera == firstPersonCamera)
        {
            currentCamera = thirdPersonCamera;
        }
        else
        {
            currentCamera = firstPersonCamera;
        }
       
            currentCamera.enabled = true;
       
        }
    }
   
   


    //Detecta si el jugador clica shift
    private bool Sprints()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(GroundChecker.position, 0.15f, WhatIsGround);
    }






}


