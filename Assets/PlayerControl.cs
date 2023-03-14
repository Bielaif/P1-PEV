using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    CharacterController _characterController;

    float _horizontal;
    float _vertical;
    float _lastVelocity_Y;

    [SerializeField]
    float Speed = 2;

    [SerializeField]
    float SprintSpeed = 8;

    [SerializeField]
    float JumpSpeed = 2;

    [SerializeField]
    float JumpSprintSpeed = 8;

    [SerializeField]
    Transform GroundChecker;

    [SerializeField]
    LayerMask WhatIsGround;

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
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    private void Move(float horizontal, float vertical)
    {
        Vector3 velocity = new Vector3(0, 0, 0);
        velocity.x = horizontal * Speed;
        velocity.y = GetVelocity_Y();
        velocity.z = vertical * Speed;

        if (Sprints() && IsGrounded())
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
            Vector3 point = transform.position + velocity;
            transform.LookAt(point);
        }


    }
    //Detecta si el jugador clica shift
    private bool Sprints()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    private bool Jumps()
    {
        return Input.GetKeyDown(KeyCode.Space);

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
        return Physics.CheckSphere(GroundChecker.position, 0.15f, WhatIsGround);
    }

    private void Sprint() { 
        
    }
}


