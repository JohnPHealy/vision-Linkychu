using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InvisiblethroughCoroutine : MonoBehaviour
{
    public Material off;
    public Material on;
    private Material mainMaterial;
    private Collider Collider;
    [SerializeField] int DesiredLayer;

    public int secondsDisappear;
    public int secondsReappear;
    public int normSeconds;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Collider = gameObject.GetComponent<Collider>();
        StartCoroutine(DisappearandReappearTimer());

    }

    public void Disappear()
    {
        GetComponent<Renderer>().material = off;
        gameObject.layer = 8;
    }

    public void Reappear()
    {
        GetComponent<Renderer>().material = on;
        gameObject.layer = DesiredLayer;

    }

    IEnumerator DisappearandReappearTimer()
    {
        yield return new WaitForSeconds(secondsDisappear);

        Disappear();

        yield return new WaitForSeconds(secondsReappear);

        Reappear();

        yield return new WaitForSeconds(normSeconds);
        StartCoroutine(DisappearandReappearTimer());

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            StopCoroutine(DisappearandReappearTimer());
            Reappear();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(DisappearandReappearTimer());
            Disappear();
        }
    }

}
