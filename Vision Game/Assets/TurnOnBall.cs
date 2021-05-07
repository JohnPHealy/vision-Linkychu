using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnBall : MonoBehaviour
{
    public float switchRange = 10f;


    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E is pressed");
            Switches();
        }
    }

    void Switches()
    {
        RaycastHit hit;
        Ray screenray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if  (Physics.Raycast(screenray, out hit, switchRange))
        {
            BallRespawn ball = hit.transform.GetComponent<BallRespawn>();
            Debug.Log("Not working");

            if (ball != null)
            {
                Debug.Log("isWorking");
                ball.Respawn();
            }
        }

    }    
}
