using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 initialPos;
    void Start()
    {
        initialPos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if(initialPos.x - transform.position.x > GetComponent<BoxCollider>().size.x / 2)
        {
            transform.position = initialPos;
        }
    }
}
