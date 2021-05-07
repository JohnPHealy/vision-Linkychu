using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{

    public GameObject turnOn;
    public GameObject turnOff;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.rigidbody.mass > 2f)
        {
            turnOn.SetActive(true);
            turnOff.SetActive(false);
        }
    }
}
