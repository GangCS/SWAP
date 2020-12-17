using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPushed : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Button;
    [SerializeField]
    GameObject Door;
    Quaternion lookRotation;
    void Start()
    {
        
    }
    //transform.localScale = new Vector3(1, 1, 0.2f);
    // transform.localScale = new Vector3(1, 1, 1);
    private void OnTriggerEnter(Collider other)
    {
        Button.transform.localScale = new Vector3(1, 1, 0.2f);
        lookRotation = Quaternion.Euler(new Vector3(0, -90, 0));

        //
       // Door.transform.rotation = lookRotation;
    }
    private void OnTriggerExit(Collider other)
    {
        Button.transform.localScale = new Vector3(1, 1, 1);
        lookRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    // Update is called once per frame
    void Update()
    {
        Door.transform.rotation = Quaternion.Slerp(Door.transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
