using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    CharacterController _characterController;

    float _horizontal;
    float _vertical;
    //float _rotate;
    float _lastVelocity_Y;

    [SerializeField]
    float Speed = 2;

    //[SerializeField]
    //float RotationSpeed = 40;

    [SerializeField]
    float SprintSpeed = 8;

    [SerializeField]
    float JumpSpeed = 5;

    [SerializeField]
    Transform GroundChecker;

    [SerializeField]
    LayerMask WhatIsGround;

    [SerializeField]
    bool Isgrounded;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        Move(_horizontal, _vertical);
    }

    private void GetInputs()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        //_rotate=Input.GetAxis("Rotate");
    }

    private void Move(float horizontal, float vertical)
    {
        Vector3 velocity = new Vector3(0, 0, 0);
        velocity.x = horizontal * Speed;
        velocity.y = GetVelocity_Y();
        velocity.z = vertical * Speed;

        //Vector3 rotation = new Vector3(0.0f, _rotate, 0.0f);
        //rb.AddTorque(rotation * RotationSpeed);

        if (Sprints())
        {
            velocity.x = horizontal * SprintSpeed;
            velocity.z = vertical * SprintSpeed;
        }
        
        if (Jumps() && IsGrounded())
        {
            velocity.y += JumpSpeed;
        }

        _characterController.Move(velocity * Time.deltaTime);

        _lastVelocity_Y = velocity.y;

        if (velocity.magnitude > 0)
        {
            velocity.y = 0;
            Vector3 target_point = transform.position + velocity;
            Vector3 current_point = transform.position + transform.forward;
            Vector3 point = Vector3.Lerp(current_point, target_point, 0.01f);
            transform.LookAt(point);
            Isgrounded = false;
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


