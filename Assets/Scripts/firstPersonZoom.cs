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
        // Save the original field of view of the first person camera
        originalFov = firstPersonCamera.fieldOfView;
    }


    private void Update()
    {
        // Zoom in when the "z" key is pressed
        if (Input.GetKey(KeyCode.Z))
        {
            float newFov = Mathf.Clamp(firstPersonCamera.fieldOfView - zoomSpeed, minFov, maxFov);
            firstPersonCamera.fieldOfView = newFov;
        }


        // Zoom out when the "x" key is pressed
        if (Input.GetKey(KeyCode.X))
        {
            float newFov = Mathf.Clamp(firstPersonCamera.fieldOfView + zoomSpeed, minFov, maxFov);
            firstPersonCamera.fieldOfView = newFov;
        }


        // Reset the field of view when neither the "z" nor the "x" key is pressed
        if (!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.X))
        {
            firstPersonCamera.fieldOfView = originalFov;
        }
    }

}
