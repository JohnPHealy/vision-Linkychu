using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class door : MonoBehaviour
{
    private ScoreManager objective;
    public int ObjectiveCount;
    void Start()
    {
        objective = GameObject.Find("Canvas").GetComponent<ScoreManager>();
   
    }

    // Update is called once per frame
   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && objective.score == ObjectiveCount)
        {
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }
    }
}
