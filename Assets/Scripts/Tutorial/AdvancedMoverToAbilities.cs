using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedMoverToAbilities : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<AdvancedMover>().enabled = false;
            other.gameObject.GetComponent<Abilities>().enabled = true;
        }
    }
}
