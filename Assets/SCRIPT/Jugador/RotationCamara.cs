using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCamara : MonoBehaviour
{
    public float mouseSensitivity; 
    public Transform playerBody;         
    public float tiltAmount = 15f;       

    private float xRotation = 0f;         

    void Start()
    {
    
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
    
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

       
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

    }
}
