using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float speed = 7.0f;

    private visionDetection visionDetectionScript;

    private Vector3 direction;

    private void Start()
    {
        visionDetectionScript = GetComponent<visionDetection>();
    }

    private void Update()
    {
        if (visionDetectionScript.isChasing)
        {
            direction = player.position - transform.position;
            direction.y = 0; // Mantenemos la dirección horizontal

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}


