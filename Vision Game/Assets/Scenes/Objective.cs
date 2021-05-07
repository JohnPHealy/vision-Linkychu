using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Objective : MonoBehaviour
{
    [SerializeField] private int orbs = 1;
    [SerializeField] private Collider playerCheck;
    [SerializeField] private ScoreManager uimanager;
    [SerializeField] private LayerMask playerLayers;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            uimanager.AddScore(orbs);
            Destroy(gameObject);
        }
    }
}
