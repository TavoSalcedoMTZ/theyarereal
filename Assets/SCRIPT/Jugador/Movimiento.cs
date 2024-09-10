using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;
    public GameObject Linterna;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private Light linternaLight;

    void Start()
    {
        controller = GetComponent<CharacterController>();

      
        if (Linterna != null)
        {
            linternaLight = Linterna.GetComponent<Light>();
        }
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.F) && linternaLight != null)
        {
            linternaLight.enabled = !linternaLight.enabled;
        }

        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}