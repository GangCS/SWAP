using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 orgPos;
    void Start()
    {
        orgPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = orgPos;
        }
    }
}
