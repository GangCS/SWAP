using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnCollide : MonoBehaviour
{
    float pickUpTime;
    bool pickedup=false;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (GetComponent<Rigidbody>().isKinematic && !pickedup)
        {
            pickedup = true;
            pickUpTime = Time.time;
        }
    }
    // "When the Box Collide with something its falling"
    private void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<Rigidbody>().isKinematic && pickedup)
        {
            if (Time.time - pickUpTime > 1f)
            {
                transform.SetParent(null);
                GetComponent<Rigidbody>().isKinematic = false;
                pickedup = false;
                pickUpTime = 0;
            }
        }
    }
}
