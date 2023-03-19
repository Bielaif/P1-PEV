using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    GameObject Door;

    //S'obra la porta al fer colisio amb el personatge
    private void OnTriggerEnter(Collider other)
    {
        PlayerControl Control = other.GetComponent<PlayerControl>(); 

        if (Control != null)
        {
            Door.transform.position += new Vector3(0, 4, 0);
        }
    }

}
