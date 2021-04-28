using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float runSpeed = 10f;
    [SerializeField]private float speedControl = 6f;
    public float movementMultiplier = 10f;
    public float airMultiplier = 0.6f;

    public float grounddrag = 6f;
    public float airdrag = 1.3f;

    float playerHeight = 2f;

    float horizontalMovement;
    float verticalMovememt;

    public Transform Playercam;
    public Transform orientation;

    public float maxStepHeight = 0.25f;
    public int stairDetail = 10;
    public LayerMask StairsM;

    [SerializeField] KeyCode JumpKey = KeyCode.Space;

    bool isGrounded;
    float groundDistance = 0.4f;
    public LayerMask Ground;

    public float JumpForce = 5f;


    Vector3 moveDir;
    Vector3 slopeMoveDir;

    Rigidbody rb;

    RaycastHit slopeHit;


    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
        {
            if (slopeHit.normal != Vector3.up)
            {
                return true;
            }

            else 
            {
                return false;
            }

        }

        return false;
     }

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        moveSpeed = speedControl;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 1, 0), groundDistance, Ground);
        

        PlayerInput();
        ControlDrag();

        if (Input.GetKeyDown(JumpKey) && isGrounded)
        {
            Jump();
        }

        slopeMoveDir = Vector3.ProjectOnPlane(moveDir, slopeHit.normal);
    }

    void PlayerInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovememt = Input.GetAxisRaw("Vertical");

        moveDir = orientation.forward * verticalMovememt + orientation.right * horizontalMovement;

        if (isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = speedControl;
        }

    }

    void Jump()
    {
        rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
    }
       
    void ControlDrag()
    {
       if (isGrounded)
        {
            rb.drag = grounddrag;
        }

       else
        {
            rb.drag = airdrag;
        }
    }

    private void FixedUpdate()
    {
        PlayerMove();
        stairs();

        
    }


    void PlayerMove()
    {
        if (isGrounded && !OnSlope())
        {
            rb.AddForce(moveDir.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }

        else if (isGrounded && OnSlope())
        {
            rb.AddForce(slopeMoveDir.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }

        else if (!isGrounded)
        {
            rb.AddForce(moveDir.normalized * moveSpeed * airMultiplier, ForceMode.Acceleration);
        }
    }

    void stairs()
    { 
        bool isFirstCheck = false;
        bool canMove = true;

        for (int i = stairDetail; i >= 1; i--)
        {
            Collider[] collider = Physics.OverlapBox(transform.position - new Vector3(0, i * maxStepHeight / stairDetail), new Vector3(1.1f, maxStepHeight / stairDetail / 2, 1.1f), Quaternion.identity, StairsM);

            if (moveDir != Vector3.zero)
            {
                if (collider.Length > 0 && i == stairDetail)
                {
                    isFirstCheck = true;
                    if (!isGrounded)
                    {
                        canMove = false;
                    }
                }
                if (collider.Length > 0 && !isFirstCheck)
                {
                    transform.position += new Vector3(0, i * maxStepHeight / stairDetail, 0);
                    break;
                }
            }
        }
        if (canMove)
            PlayerMove();

    }

}