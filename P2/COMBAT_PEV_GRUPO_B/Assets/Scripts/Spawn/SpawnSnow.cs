using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnow : MonoBehaviour
{

    public GameObject snowPrefab;

    // Update is called once per frame
    void Update()
    {
        if (SnowStart())
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-83, 20), 20, (Random.Range(-2, 30)));
            Instantiate(snowPrefab, randomSpawnPosition, Quaternion.identity);
        }
    }

    private bool SnowStart()
    {
        if (Input.GetKey(KeyCode.N))
        {
            return true;
        } else
        {
            return false;
        }
    }
}