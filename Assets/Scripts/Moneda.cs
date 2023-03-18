using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    
    public bool moneda = false;

    private void OnTriggerEnter(Collider other)
    {
        PlayerControl Control = other.GetComponent<PlayerControl>();
        moneda = true;
        KillMyself();
    }

    private void KillMyself()
    {
        MeshRenderer mr = this.GetComponent<MeshRenderer>();
        mr.enabled = false;

    }
}
