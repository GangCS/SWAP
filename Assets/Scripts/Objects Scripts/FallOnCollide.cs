using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnCollide : MonoBehaviour
{
    float pickUpTime;
    bool pickedup=false;

    [SerializeField] AudioClip sound;
    bool falling = false;
    private float cooldownBox;
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
        if(!GetComponent<Rigidbody>().isKinematic && pickedup)
        {
            pickedup = false;
        }
        if (!GetComponent<Rigidbody>().velocity.Equals(Vector3.zero))
        {
            falling = true;
        }
    }
    // "When the Box Collide with something it will fall"
    private void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<Rigidbody>().isKinematic && pickedup)
        {
            if (Time.time - pickUpTime > 0.5f)
            {
                transform.SetParent(null);
                GetComponent<Rigidbody>().isKinematic = false;
                pickedup = false;
                pickUpTime = 0;
            }
        }
        if (falling && Time.time - cooldownBox >= 2f)
        {
            AudioSource.PlayClipAtPoint(sound, transform.position, 1f);
            cooldownBox = Time.time;
            falling = false;
        }
    }
}
