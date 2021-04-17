using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript2 : MonoBehaviour
{
    private Transform playerPos1;
    public GameObject objecttochange1;
    public GameObject objecttoturnoff1;
    public SwitchScriptOff controller1;
    private int pressed1 = 1;
    private bool YES1;
    float distance1;
    // Start is called before the first frame update
    void Start()
    {
        playerPos1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        controller1 = GameObject.FindGameObjectWithTag("SwitchController").GetComponentInChildren<SwitchScriptOff>();
         
    }

    // Update is called once per frame
    void Update()
    {
        distance1 = Vector3.Distance(playerPos1.position, gameObject.transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance1 < 2f && pressed1 == 1)
        {
            YES1 = true;
            Checkforswitch1();
        }

        else
        {
            StopCheckingforSwitch1();
        }
    }

    void Checkforswitch1()
    {

        Debug.Log("yes checking for switch");
        if (distance1 < 2f && YES1 == true && Input.GetKeyDown(KeyCode.E) && pressed1 == 1)
        {

            objecttochange1.SetActive(true);
            objecttoturnoff1.SetActive(false);
            pressed1 = 2;
            
        }
    }

    void StopCheckingforSwitch1()
    {
        if (pressed1 == 2 && Input.GetKeyDown(KeyCode.E) && distance1 <= 2f)
        {
            objecttochange1.SetActive(false);
            objecttoturnoff1.SetActive(true);
            YES1 = false;
            pressed1 = 1;
           
        }
    }
}