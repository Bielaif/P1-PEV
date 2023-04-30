using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class SpawnPattern : MonoBehaviour
{

    [SerializeField]
    GameObject Enemy;

    public Transform[] spawnLocations;

    bool didSpawn = false;

    private void OnTriggerEnter(Collider other)
    {
        SpawnThem();
    }

    private void SpawnThem()
    {
        if (!didSpawn)
        {
            Quaternion rot = transform.rotation;
            foreach (Transform locations in spawnLocations)
            {
                Instantiate(Enemy, locations.transform.position, rot);
            }
            didSpawn = true;
        }
    }

}

