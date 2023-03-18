using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftComplex : MonoBehaviour
{
    public Animator _animator;

    [SerializeField]
    Moneda Coin;
    private void OnTriggerEnter(Collider other)
    {
        PlayerControl Control = other.GetComponent<PlayerControl>();
        if (Coin.moneda)
        {
            if (Control != null)
            {
                SetFlight();
            }
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
