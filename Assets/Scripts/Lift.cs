using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Animator _animator;
    private void OnTriggerEnter(Collider other)
    {
        PlayerControl Control = other.GetComponent<PlayerControl>();
        if (Control != null)
        {
            SetFlight();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerControl Control = other.GetComponent<PlayerControl>();
        if (Control != null)
        {
            SetGround();
        }
    }

    private void SetFlight()
    {
        _animator.SetBool("Up", true);
    }
    private void SetGround()
    {
        _animator.SetBool("Up", false);
    }
}
