using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public GameObject Player;

    Rigidbody rb;

    Vector3 AngleVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        AngleVelocity = new Vector3(0, 90, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalrotation = Input.GetAxisRaw("Horizontal");
   
        Quaternion deltaRotation = Quaternion.Euler(AngleVelocity * Time.deltaTime *horizontalrotation);
        rb.MoveRotation(rb.rotation * deltaRotation);


    }
}
