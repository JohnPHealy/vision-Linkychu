using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    public GameMaster gameMaster;

    public Transform playerPosition;

    private void Awake()
    {
        gameMaster = GameObject.FindGameObjectWithTag("Game").GetComponent<GameMaster>();

        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.localPosition = gameMaster.lastCheckpointpos;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerPosition.transform.localPosition = gameMaster.lastCheckpointpos;

        }
    }

    public void dead()
    {
        playerPosition.transform.localPosition = gameMaster.lastCheckpointpos;
    }

}

