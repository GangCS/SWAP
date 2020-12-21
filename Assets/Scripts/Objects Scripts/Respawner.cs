using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [Tooltip("This Script Re spawns the object when destroyed on his original position")]
    Vector3 originalPosition;
    void Start()
    {
        originalPosition = transform.position; //saving starting position
    }

    void Update()
    {
        if(transform.position.y < -5)//if box falls down to the abyss
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if(rb!= null)
            {
                rb.velocity = Vector3.zero;
            }
           
            if(transform.tag == "Player")
            {
                CharacterController _cc = GetComponent<CharacterController>();
                _cc.enabled = false;
                transform.position = originalPosition; // Placing it back
                _cc.enabled = true;
            }
            transform.position = originalPosition; // Placing it back
        }
    }

}
