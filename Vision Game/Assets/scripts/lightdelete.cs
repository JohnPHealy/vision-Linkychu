using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightdelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delete());
    }

    IEnumerator delete()
    {
        yield return new WaitForSeconds(20);
        Destroy(this.gameObject);
    }
}
