using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 5f;          
    public float jumpForce = 5f;      
    public LayerMask groundMask;      

    private Rigidbody rb;             
    private bool isGrounded;          

    void Start()
    {
     
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        Move();
        Jump();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

   
        Vector3 direction = transform.right * horizontal + transform.forward * vertical;

  
        transform.position += direction * speed * Time.deltaTime;
    }

    void Jump()
    {
    
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundMask);

     
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    void OnColissionEnter(Collision collision)
    {
        rb.velocity=Vector3.zero;   
        rb.angularVelocity=Vector3.zero;
    }
}