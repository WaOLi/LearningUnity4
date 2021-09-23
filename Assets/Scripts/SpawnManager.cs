using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public GameObject[] obsticle;
    Vector3 position = new Vector3(35,0.5f,0);
    public float timeDif = 2;
    public float timeBuf = 2;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("ObsticleGenerator", timeBuf, Random.Range(2f,5f));
    }
    void ObsticleGenerator()
    {
        if (!playerControllerScript.gameOver && playerControllerScript.entry)
        {
            int indexOfObsticle = Random.Range(0, 4);
            Instantiate(obsticle[indexOfObsticle], position, obsticle[indexOfObsticle].transform.rotation);
        }
        
    }
}
