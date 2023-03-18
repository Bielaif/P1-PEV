using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    GameObject Door;

    private void OnTriggerEnter(Collider other)
    {
        PlayerControl Control = other.GetComponent<PlayerControl>(); //Bonk és el nom del script del personatge
        if (Control != null)
        {
            Door.transform.position += new Vector3(0, 4, 0);
        }
    }

}
