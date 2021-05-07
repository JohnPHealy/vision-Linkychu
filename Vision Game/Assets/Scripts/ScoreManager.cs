using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ScoreManager : MonoBehaviour
{
    public UnityEvent<string> addScore;
    public int score;


    void Start()
    {
        score = 0;
        addScore.Invoke(score.ToString());
    }

    // Update is called once per frame
    
    public void AddScore(int scoreAmt)
    {
        score += scoreAmt;
        addScore.Invoke(score.ToString());
    }
}
