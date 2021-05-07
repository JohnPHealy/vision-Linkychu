using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimationViaCollision : MonoBehaviour
{
    private Rigidbody Object;
    private Rigidbody mainrb;


    private void Start()
    {
        mainrb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 11)
        {
            Object = collision.gameObject.GetComponent<Rigidbody>();

            mainrb.isKinematic = false;
            Object.isKinematic = false;
            Object.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
