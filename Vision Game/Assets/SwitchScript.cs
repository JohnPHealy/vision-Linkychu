using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    private Transform playerPos;
    public GameObject objecttochange;
    public GameObject objecttoturnoff;
    public SwitchScriptOff controller;
    private int pressed = 1;
    private bool YES;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        controller = GameObject.FindGameObjectWithTag("SwitchController").GetComponentInChildren<SwitchScriptOff>();

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(playerPos.position, gameObject.transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance < 2f && pressed == 1)
        {
            YES = true;
            Checkforswitch();
        }

        else
        {
            StopCheckingforSwitch();
        }
    }

    void Checkforswitch()
    {

       
        if (distance < 2f && YES == true && Input.GetKeyDown(KeyCode.E) && pressed == 1)
        { 

            objecttochange.SetActive(true);
            objecttoturnoff.SetActive(false);
            pressed = 2;

        }
    }

    void StopCheckingforSwitch()
    {
        if (pressed == 2 && Input.GetKeyDown(KeyCode.E) && distance <= 2f)
        {
            objecttochange.SetActive(false);
            objecttoturnoff.SetActive(true);
            YES = false;
            pressed = 1;

        }
    }
}
