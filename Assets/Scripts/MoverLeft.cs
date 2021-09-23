using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class MoverLeft : MonoBehaviour
{
    float moveSpeed = 10f;
    public PlayerController PlayerControllerScript;
    public float boundX;
    private void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (!PlayerControllerScript.gameOver && PlayerControllerScript.entry)
        {
            transform.Translate((-1) * moveSpeed * Time.deltaTime, 0f, 0f);
        }
        if (gameObject.CompareTag("Obsticle") && PlayerControllerScript.entry)
        {
            if(transform.position.x < boundX)
            {
                Destroy(gameObject);
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && PlayerControllerScript.entry)
        {
            moveSpeed =25;
        }else if(PlayerControllerScript.entry)
        {
            moveSpeed = 10;
        }
        
    }
}
