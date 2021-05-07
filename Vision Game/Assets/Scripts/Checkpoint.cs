using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public DeathOnimpact deathOnimpact;
    public Material off;
    public Material on;


    

    public Renderer checkpointrenderer;

    private void Start()
    {
        
    
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
            deathOnimpact.playerPos = transform.localPosition;

            CheckpointOn();
        }
    }
}

