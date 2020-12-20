using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPushed : MonoBehaviour
{
    [Tooltip("This Script Opens The 'Door' When 'Button' is pushed down")]
    [SerializeField] GameObject Button;
    [SerializeField] GameObject Door;
    Quaternion lookRotation;
    void Start()
    {
        
    }
    //transform.localScale = new Vector3(1, 1, 0.2f);
    //transform.localScale = new Vector3(1, 1, 1);

    private void OnTriggerStay(Collider other) // Button is pushed
    {
        Button.transform.localScale = new Vector3(1, 1, 0.2f);//Pushing the Button down
        lookRotation = Quaternion.Euler(new Vector3(0, -90, 0));
       // Door.transform.rotation = lookRotation;
    }
    private void OnTriggerExit(Collider other) // Button is no longer pushed
    {
        Button.transform.localScale = new Vector3(1, 1, 1); //Pulling Button back up
        lookRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    void Update()
    {
        Door.transform.rotation = Quaternion.Slerp(Door.transform.rotation, lookRotation, Time.deltaTime * 5f);// Opens the door
    }
}
