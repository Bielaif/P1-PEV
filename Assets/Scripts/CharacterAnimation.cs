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
                if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton2))
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
                else if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton2))
                {
                    SetNotRunning();
                }
            }
        } else if (IsStationary())
            {
            if (SpacePressed()) {
                SetJumping();
            }
            else if (Input.GetKeyDown(KeyCode.G) || Input.GetKey(KeyCode.JoystickButton3))
            {
                SetDancing();
            }
            else if (Input.GetKeyUp(KeyCode.G) || Input.GetKey(KeyCode.JoystickButton3))
            {
                SetNotDancing();
            }
            else 
                {
                    SetIdle();
                }
            }

       
    } 

    

    //Mira si el personatge esta en moviment
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

    //Mira si el personatge esta quiet
    private bool IsStationary()
    {
        return Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0;
    }

    //Comprova si s'utilitzen els botons de salt
    private bool SpacePressed(){
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0))
        {
            return true;
        } else {
            return false;
        }
    }

    //Activa o desactiva els estats de les animacions
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