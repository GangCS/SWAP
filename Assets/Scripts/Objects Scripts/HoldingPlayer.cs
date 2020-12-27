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
    }

    void OnTriggerExit(Collider col)
    {
        GameObject upDown = GameObject.Find("upDown");
        //Debug.Log(col.transform.parent);
        if (col.transform.parent != upDown.transform)
        {
            col.transform.parent = null;
        }
    }
}
