using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingPlayer : MonoBehaviour
{
/*    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.parent = gameObject.transform;
        Debug.Log("Player stand on platform");
    }*/
    void OnTriggerStay(Collider col)
    {
        col.transform.parent = gameObject.transform;
        Debug.Log("Player stand on platform");
    }

    void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
        Debug.Log("Player exit from platform");
    }
}
