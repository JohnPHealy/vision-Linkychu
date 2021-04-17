using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3D : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 10f;
    public float jumpSpeed;
    public GameObject jumpCheck;
    bool isGrounded = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        
    }

    private void Move()
    {
        float xmovement = Input.GetAxisRaw("Horizontal");
        float zmovement = Input.GetAxisRaw("Vertical");

        transform.position = transform.position + new Vector3(xmovement * moveSpeed * Time.deltaTime, 0,  zmovement * moveSpeed * Time.deltaTime);
    }
}
