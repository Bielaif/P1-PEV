using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    [SerializeField]
    float wind = 50;

    // Update is called once per frame
    void Update()
    {
        float windSpeed = wind * Time.deltaTime;
        transform.Rotate(windSpeed, 0, 0);
    }
}
