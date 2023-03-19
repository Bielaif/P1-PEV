using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 2.0f;
    public float smoothSpeed = 0.125f;


    private Vector3 _offset;


    private void Start()
    {
        //_offset = transform.position - target.position;
    }


    private void LateUpdate()
    {
        float targetAngle = target.eulerAngles.y;
        float currentAngle = transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, targetAngle, smoothSpeed * Time.deltaTime);

        //Quaternion ajuda amb les rotacions
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        Vector3 targetPosition = target.position - (rotation * Vector3.forward * distance);
        targetPosition.y = target.position.y + height;


        transform.position = targetPosition;
        transform.LookAt(target);
    }

}
