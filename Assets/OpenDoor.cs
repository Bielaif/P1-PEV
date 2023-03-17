using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    GameObject Door;

    bool opened = false;

    void OnTriggerEnter(Collider col) {
        if (!opened)
        {
            opened = true;
            Door.transform.position += new Vector3(0, 4, 0);
        }
    }
}
