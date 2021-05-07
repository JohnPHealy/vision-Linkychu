using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallrun : MonoBehaviour
{
    [SerializeField] Transform orientation;

    [Header("Wall Running")]
    [SerializeField] float wallDistance = 0.5f;
    [SerializeField] float minimumJumpHeight = 1.5f;
    [SerializeField] private float WallRunGravity;
    [SerializeField] private float WallRunForce;

    

    bool wallLeft = false;
    bool wallRight = false;

    [Header("Camera")]
    public Camera cam;
    [SerializeField] private float fov;
    [SerializeField] private float wallRunfov;
    [SerializeField] private float wallRunfovTime;
    [SerializeField] private float camTilt;
    [SerializeField] private float camTiltTime;
    [SerializeField] LayerMask wall;

    public float tilt { get; private set; }

    private Rigidbody rb;

    RaycastHit leftWallhit;
    RaycastHit RightWallhit;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            CanWallRun();
        }
    }
    bool CanWallRun()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minimumJumpHeight);
    }
    void WallCheck()
    {
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallhit, wallDistance , wall);
        wallRight = Physics.Raycast(transform.position, orientation.right, out RightWallhit, wallDistance, wall);

    }

    private void Update()
    {
        WallCheck();

        if (CanWallRun())
        {
            if (wallLeft)
            {
                StartWallRun();

            }

            if (wallRight)
            {
                StartWallRun();
                
            }

            else
            {
                StopWallRun();
            }
        }

        else
        {
            StopWallRun();
        }
    }

    void StartWallRun()
    {
        rb.useGravity = false;

        rb.AddForce(Vector3.down * WallRunGravity, ForceMode.Force);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, wallRunfov, wallRunfovTime * Time.deltaTime);

        if (wallLeft)
            tilt = Mathf.Lerp(tilt, -camTilt, camTiltTime * Time.deltaTime);
        else if (wallRight)
            tilt = Mathf.Lerp(tilt, camTilt, camTiltTime * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (wallLeft)
            {
                Vector3 wallRunJumpDirection = transform.up + leftWallhit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(wallRunJumpDirection * WallRunForce * 100f, ForceMode.Force);
            }

            else if (wallRight)
            {
                Vector3 wallRunJumpDirection = transform.up + RightWallhit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(wallRunJumpDirection * WallRunForce * 100f, ForceMode.Force);
            }
        }

       
    }

    void StopWallRun()
    {
        rb.useGravity = true;

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, wallRunfovTime * Time.deltaTime);

        tilt = Mathf.Lerp(tilt, 0, camTiltTime * Time.deltaTime);
    }    
}
