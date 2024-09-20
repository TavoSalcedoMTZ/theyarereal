using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speedOrigin = 2.0f;
    public float speed = 2.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;
    public int maxStamina = 100;
    public int stamina;


    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        stamina = maxStamina; 
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

      
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

     
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            speed = speedOrigin +3;
          
        }
        else
        {
            speed = speedOrigin; 
            if (stamina < maxStamina)
            {
   
            }
        }




        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}