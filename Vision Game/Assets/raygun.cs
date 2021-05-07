using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raygun : MonoBehaviour
{
    public float shootRate;
    private float m_shootRateTimeStamp;


    public GameObject greenBullet;
    public GameObject purpleBullet;

    RaycastHit hit;
    public float range = 100;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                shootGreenRay();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                shootPurpleRay();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }


    }

    void shootGreenRay()
    {
        Ray greenray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(greenray, out hit, range))
        {
            GameObject Greenlaser = GameObject.Instantiate(greenBullet, transform.position, transform.rotation) as GameObject;
            Greenlaser.GetComponent<GreenBullet>().setTarget(hit.point);

            
            GameObject.Destroy(Greenlaser, 2f);


        }

    }

    void shootPurpleRay()
    {
       
            Ray purpleray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(purpleray, out hit, range))
            {
                GameObject Purplelaser = GameObject.Instantiate(purpleBullet, transform.position, transform.rotation) as GameObject;
                Purplelaser.GetComponent<PurpleBullet>().setTarget(hit.point);

              
                

                GameObject.Destroy(Purplelaser, 2f);


            }

        }

    }


