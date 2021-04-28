using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3D : MonoBehaviour
{
     Rigidbody rb;
    public float moveSpeed = 10f;
    public float Sprint;
    public float jumpSpeed;
    private bool isGrounded = false;
    [SerializeField] private LayerMask Ground;
    float groundDistance = 0.4f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()

    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 1, 0), groundDistance, Ground);

        Move();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

    }

    private void Move()
    {
        float xmovement = Input.GetAxisRaw("Horizontal");
        float zmovement = Input.GetAxisRaw("Vertical");

        rb.AddForce(xmovement, 0, zmovement, ForceMode.VelocityChange);

        if(isGrounded && Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = Sprint;
            
        }

       

        
    }

    private void Jump()
    {

        rb.AddForce(0, jumpSpeed, 0,  ForceMode.Impulse);
    }
}
