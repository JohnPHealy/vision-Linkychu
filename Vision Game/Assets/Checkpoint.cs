using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gameMaster;
    public Material off;
    public Material on;


    

    public Renderer checkpointrenderer;

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("Game").GetComponent<GameMaster>();
    
    }

    void CheckpointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach (Checkpoint checkpoint in checkpoints)
        {
            checkpoint.CheckpointOff();
        }

        checkpointrenderer.material = on;
    }

    void CheckpointOff()
    {
        checkpointrenderer.material = off;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameMaster.lastCheckpointpos = transform.position;

            CheckpointOn();
        }
    }
}

