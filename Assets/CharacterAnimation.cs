using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (WASDPressed())
        {
            SetNotDancing();
            if (SpacePressed()){
                SetJumping();
            }
            else
            {
                SetMoving();
                if(Input.GetKeyDown(KeyCode.LeftShift))
                {
                    if (SpacePressed())
                    {
                        SetJumping();
                    }
                    else {
                        SetRunning();
                        SetNotJumping();
                    }
                } 
                else if(Input.GetKeyUp(KeyCode.LeftShift))
                {
                    SetNotRunning();
                }
            }
        } else if (IsStationary())
            {
            if (SpacePressed()) {
                SetJumping();
            }
            else if (Input.GetKeyDown(KeyCode.G)){
                SetDancing();
            }
            else if (Input.GetKeyUp(KeyCode.G))
            {
                SetNotDancing();
            }
            else 
                {
                    SetIdle();
                }
            }

       
    } 

    


    private bool WASDPressed()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            return true;
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    private bool IsStationary()
    {
        if (Input.GetAxis("Vertical") == 0)
        {
            return true;

        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    private bool SpacePressed(){
        if (Input.GetKeyDown(KeyCode.Space)){
            return true;
        } else {
            return false;
        }
    }

    void SetIdle()
    {
        SetNotJumping();
        SetNotMoving();
        SetNotRunning();
    }
    void SetJumping(){
        _animator.SetBool("IsJumping", true);
    }

    void SetNotJumping(){
        _animator.SetBool("IsJumping", false);
    }

    void SetMoving() 
    {
        _animator.SetBool("IsMoving", true);
    }
    void SetNotMoving()
    {
        _animator.SetBool("IsMoving", false);
    }
    void SetRunning()
    {
        _animator.SetBool("IsRunning", true);
    }
    void SetNotRunning()
    {
        _animator.SetBool("IsRunning", false);
    }
    void SetDancing()
    {
        _animator.SetBool("IsDancing", true);
    }
    void SetNotDancing()
    {
        _animator.SetBool("IsDancing", false);
    }

}