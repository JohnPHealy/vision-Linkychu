using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelChangeOntrigger : MonoBehaviour
{
    public GameObject levelLoaderAsync;
    public LevelLoaderAsync async;
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            async.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
