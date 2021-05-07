using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Invisible : MonoBehaviour
{
    public Material off;
    public Material on;
    private Material mainMaterial;
    private Collider Collider;
    [SerializeField] int DesiredLayer;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Collider = gameObject.GetComponent<Collider>();
        
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
}
