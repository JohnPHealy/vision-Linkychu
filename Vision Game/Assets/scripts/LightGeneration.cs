using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGeneration : MonoBehaviour
{
    float MinDistance;
    float  MaxDistance;
    private Transform playerPos;
    public GameObject lightprefab;
    public GameObject Player;
    private GameObject clones;
    [SerializeField] private int Lightnumber;
    [SerializeField] private float seconds;
    private bool SpawnLight;
    private Camera cam;
    private Color32 blue = new Color32(197, 250, 240, 255);
    private Color black = Color.black;
    private bool HasSpawned;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerPos.position = Player.transform.position;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;

    }

    // Update is called once per frame
    void Update()
    {
        MinDistance = Vector3.Distance(lightprefab.transform.localPosition, playerPos.position);
        MaxDistance = Vector3.Distance(lightprefab.transform.localPosition, 2 * playerPos.position);

        Debug.Log(lightprefab.transform.localPosition);

        if (SpawnLight != true)
        {
            StartCoroutine(NewSecondsDraw());
        }

        if (SpawnLight == true && HasSpawned != true)
        {
            StartCoroutine(spawnLight());
        }
    }

    IEnumerator spawnLight()
    {
        yield return new WaitForSeconds(seconds);

        if (HasSpawned == false && SpawnLight == true)
        {
            cam.backgroundColor = black;
            RenderSettings.ambientIntensity = 0;
            RenderSettings.reflectionIntensity = 0;
        }
       
        if (HasSpawned == false && SpawnLight == true)
        {
            Instantiate(lightprefab , new Vector3(Random.Range(MinDistance, MaxDistance) + 1.5f * playerPos.position.x, 6f, Random.Range(MinDistance, MaxDistance) + playerPos.position.z), Quaternion.Euler(90, 0, 0));
            HasSpawned = true;
        }
       


        yield return new WaitForSeconds(20);
        cam.backgroundColor = blue;
        RenderSettings.ambientIntensity = 1;
        RenderSettings.reflectionIntensity = 1;
        SpawnLight = false;
        HasSpawned = false;
        seconds = 0;
        
    }


    IEnumerator NewSecondsDraw()
    {
        yield return new WaitForSeconds(20);

        seconds = Random.Range(10, 70);

        if (playerPos.position.x  > MinDistance * Time.deltaTime)
        {
            
            SpawnLight = true;
        }
    }
    
}
    