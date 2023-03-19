using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    CharacterController _characterController;
    float _lastVelocity_Y;

    [SerializeField]
    float JumpHeight = 5;

    [SerializeField]
    Transform GroundChecker;

    [SerializeField]
    LayerMask WhatIsGround;

  
    // Update is called once per frame
    void Update()
    {
        LetsJump();
    }


    private void LetsJump() 
    {
        Vector3 velocity = new Vector3(0, 0, 0);
        velocity.y = GetVelocity_Y();

        //Comprova que toqui el terra i toqui els controls de salt
        if (Jumps() && IsGrounded())
        {
            velocity.y += JumpHeight;
        }

        _lastVelocity_Y = velocity.y;
        _characterController.Move(velocity * Time.deltaTime);

        if (velocity.magnitude > 0)
        {
            velocity.y = 0;
            Vector3 target_point = transform.position + velocity;
            Vector3 current_point = transform.position + transform.forward;
            Vector3 point = Vector3.Lerp(current_point, target_point, 0.01f);
            transform.LookAt(point);
        }
    }

    //Controla quan s'apreten els controls de saltar
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
        return Physics.CheckSphere(GroundChecker.position, 0.15f, WhatIsGround);
    }
}