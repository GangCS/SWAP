using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoverText : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<AdvancedMover>().enabled = false;
            other.gameObject.GetComponent<BasicMover>().enabled = true;
        }
    }
}
