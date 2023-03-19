using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    
    public bool moneda = false;

    //Al fer contacte amb la moneda la borra
    private void OnTriggerEnter(Collider other)
    {
        PlayerControl Control = other.GetComponent<PlayerControl>();
        moneda = true;
        KillMyself();
    }

    //S'amaga el mesh de la moneda
    private void KillMyself()
    {
        MeshRenderer mr = this.GetComponent<MeshRenderer>();
        mr.enabled = false;

    }
}
