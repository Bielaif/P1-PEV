using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonZoom : MonoBehaviour
{
    public Camera thirdPersonCamera;
    public float minFov = 10.0f;
    public float maxFov = 30.0f;
    public float zoomSpeed = 10.0f;


    private float originalFov;


    private void Start()
    {
        // Save the original field of view of the first person camera
        originalFov = thirdPersonCamera.fieldOfView;
    }


    private void Update()
    {
        // Zoom in when the "z" key is pressed
        if (Input.GetKey(KeyCode.Z))
        {
            float newFov = Mathf.Clamp(thirdPersonCamera.fieldOfView + zoomSpeed, minFov, maxFov);
            thirdPersonCamera.fieldOfView = newFov;
        }
        


        // Reset the field of view when neither the "z" nor the "x" key is pressed
        if (!Input.GetKey(KeyCode.Z))
        {
            thirdPersonCamera.fieldOfView = originalFov;
        }
    }

}
