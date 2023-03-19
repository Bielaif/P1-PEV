using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Animator _animator;

    //Al entrar en contacte amb l'ascensor fa que puji
    private void OnTriggerEnter(Collider other)
    {
        PlayerControl Control = other.GetComponent<PlayerControl>();
        if (Control != null)
        {
            SetFlight();
        }
    }

    //Quan el personatge baixa de l'ascensor aquest també baixa
    private void OnTriggerExit(Collider other)
    {
        PlayerControl Control = other.GetComponent<PlayerControl>();
        if (Control != null)
        {
            SetGround();
        }
    }

    //Canvia les diferents animacions de l'ascensor
    private void SetFlight()
    {
        _animator.SetBool("Up", true);
    }
    private void SetGround()
    {
        _animator.SetBool("Up", false);
    }
}
