using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    [SerializeField]
    private float sensitivityY;
    [SerializeField]
    private float sensitivityX;

    Camera cam;

    float mouseX;
    float mouseY;
    float multiplier = 0.01f;
    float xRotation;
    float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        cam=GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        cam.transform.localRotation = Quaternion.Euler(xRotation,0,0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);   
    }
    
    void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
        
        yRotation += mouseX * sensitivityX * multiplier;
        xRotation -= mouseY * sensitivityY * multiplier;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}
