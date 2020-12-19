using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 orgPos;
    void Start()
    {
        orgPos = transform.position;//saving starting position
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5)//if box falls down to the abyss
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = orgPos;//Placing it back
        }
    }
}
