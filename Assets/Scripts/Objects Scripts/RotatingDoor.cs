using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingDoor : IMovementAction
{
    Quaternion lookRotation;
    public override void performAction()
    {
        lookRotation = Quaternion.Euler(new Vector3(0, -90, 0));
    }

    public override void undoAction()
    {
        lookRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    void Update()
    {
         transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);// Opens the door
    }
}
