using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUp : MonoBehaviour
{
    [SerializeField]
    GameObject Lift;

    bool opened = false;

    float LiftSpeed = 20;

    Vector3 velocity = new Vector3(0, 0, 0);

    void Update()
    {
        CheckPosition(velocity);
    }

    private void CheckPosition(Vector3 velocity)
    {

        if (opened)
        {
            velocity.y = LiftSpeed * Time.deltaTime;
        }
        else 
        {
            velocity.y = 0;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (!opened)
        {
            opened = true;

        }
    }
}
