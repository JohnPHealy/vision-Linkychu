using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    public GameObject ball;
    private Vector3 ballInitPos;
    private void Start()
    {
        ballInitPos = ball.transform.localPosition;
    }
    public void Respawn()
    {
        ball.transform.localPosition = ballInitPos;
    }
}
