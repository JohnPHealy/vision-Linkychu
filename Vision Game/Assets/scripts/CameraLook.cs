using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform.position);

    }
}
