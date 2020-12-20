using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnCollide : MonoBehaviour
{
    // "When the Box Collide with something its falling"
    private void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<Rigidbody>().isKinematic)
        {
            transform.SetParent(null);
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
