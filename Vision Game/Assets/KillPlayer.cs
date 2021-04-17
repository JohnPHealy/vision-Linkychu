using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KillPlayer : MonoBehaviour
{
    public GameMaster gameMaster;

    public PlayerPos PlayerPosition;


    void Awake() 
    {
        gameMaster = GameObject.FindGameObjectWithTag("Game").GetComponent<GameMaster>();

        PlayerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPos>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPosition.dead();
        }
    }
}
