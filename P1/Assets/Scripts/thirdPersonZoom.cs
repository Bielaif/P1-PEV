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
        originalFov = thirdPersonCamera.fieldOfView;
    }


    private void Update()
    {
        //Zoom in
        if (Input.GetKey(KeyCode.Z))
        {
            float newFov = Mathf.Clamp(thirdPersonCamera.fieldOfView + zoomSpeed, minFov, maxFov);
            thirdPersonCamera.fieldOfView = newFov;
        }
        


        //Reseteja el FOV
        if (!Input.GetKey(KeyCode.Z))
        {
            thirdPersonCamera.fieldOfView = originalFov;
        }
    }

}
