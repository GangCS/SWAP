using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [Tooltip("This Script Respawns the object when destroyed on his original position")]
    Vector3 originalPosition;
    void Start()
    {
        originalPosition = transform.position; //saving starting position
    }

    void Update()
    {
        if(transform.position.y < -5)//if box falls down to the abyss
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = originalPosition; // Placing it back
        }
    }

}
