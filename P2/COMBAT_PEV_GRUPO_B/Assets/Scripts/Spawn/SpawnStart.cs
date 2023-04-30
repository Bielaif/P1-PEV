using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class SpawnStart : MonoBehaviour
{

    [SerializeField]
    GameObject enemy1;

    [SerializeField]
    Vector3 pos1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnThem(pos1);
    }

    private void SpawnThem(Vector3 pos1)
    {
        Quaternion rot = transform.rotation;
        Instantiate(enemy1, pos1, rot);
    }

}

