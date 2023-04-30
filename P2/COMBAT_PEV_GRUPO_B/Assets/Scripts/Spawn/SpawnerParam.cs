using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class SpawnerParam : MonoBehaviour
{

    [SerializeField]
    GameObject Enemy;

    [SerializeField]
    float Distance = 1.5f;

    [SerializeField]
    int nColums = 3;

    [SerializeField]
    int nRows = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            for (int j = 0; j < nRows; j++)
            {
                for (int i = 0; i < nColums; i++)
                {
                    SpawnOne(i, j);
                }
            }

        }
    }

    private void SpawnOne(int i, int j)
    {
        Vector3 pos = GetPosition(i, j);
        Quaternion rot = transform.rotation;
        Instantiate(Enemy, pos, rot);
    }

    private Vector3 GetPosition(int i, int j)
    {
        Vector3 pos = transform.position;
        pos.x += i * Distance;
        pos.z += j * Distance;
        return pos;
    }

    private bool ShouldSpawn() 
    {
        return Input.GetKeyDown(KeyCode.Alpha1);
    }
}

