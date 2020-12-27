using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingDoorTimes : RotatingDoor
{

    [SerializeField]
    float timeForAction = 3f;

    bool isTriggered;
    float TriggerTime;

    public override void performAction()
    {
        TriggerTime = Time.time;
        base.performAction();
        isTriggered = true;
    }

    public override void undoAction()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);// Opens the door
        if (isTriggered && Time.time - TriggerTime > timeForAction)
        {
            isTriggered = false;
            base.undoAction();
        }
    }
}
