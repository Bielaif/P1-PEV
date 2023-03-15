using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;

    private bool moving = false;
    private bool running = false;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && WASDPressed())
        {
            SetRunning();
        }
        else 
        {
            SetNotRunning();
        }

        if (WASDPressed())
        {
            SetMoving();
        }
        else
        {
            SetNotMoving();
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

    void SetMoving() 
    {
        _animator.SetBool("IsMoving", true);
        moving = true;
    }
    void SetNotMoving()
    {
        _animator.SetBool("IsMoving", false);
        moving = false;
    }
    void SetRunning()
    {
        _animator.SetBool("IsRunning", true);
        running = true;
    }
    void SetNotRunning()
    {
        _animator.SetBool("IsRunning", false);
        running = false;
    }
}
