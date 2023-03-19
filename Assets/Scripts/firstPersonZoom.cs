using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPersonZoom : MonoBehaviour
{
    public Camera firstPersonCamera;
    public float minFov = 10.0f;
    public float maxFov = 100.0f;
    public float zoomSpeed = 10.0f;


    private float originalFov;


    private void Start()
    {
        originalFov = firstPersonCamera.fieldOfView;
    }


    private void Update()
    {
        //Zoom in
        if (Input.GetKey(KeyCode.Z))
        {
            float newFov = Mathf.Clamp(firstPersonCamera.fieldOfView - zoomSpeed, minFov, maxFov);
            firstPersonCamera.fieldOfView = newFov;
        }


        //Zoom out
        if (Input.GetKey(KeyCode.X))
        {
            float newFov = Mathf.Clamp(firstPersonCamera.fieldOfView + zoomSpeed, minFov, maxFov);
            firstPersonCamera.fieldOfView = newFov;
        }


        //Reseteja el FOV
        if (!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.X))
        {
            firstPersonCamera.fieldOfView = originalFov;
        }
    }

}
