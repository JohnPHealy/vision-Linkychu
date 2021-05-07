using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScriptOff : MonoBehaviour
{
    public SwitchScript switchscript;

    public bool In;
    public bool Out;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            In = true;
            Out = false;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Out = true;
            In = false;
        }
    }
}
