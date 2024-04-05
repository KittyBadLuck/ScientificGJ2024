using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //Variables
    
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;
    public bool inDialogue = true;
    
    // Start is called before the first frame update
    void Start()
    {
        // Lock cursor
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.timeScale != 0  && !inDialogue)
        {
            
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        
    }
}
