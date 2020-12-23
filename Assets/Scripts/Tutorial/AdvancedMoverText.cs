using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedMoverText : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<BasicMover>().enabled = false;
            other.gameObject.GetComponent<AdvancedMover>().enabled = true;
        }
    }
}
