using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform movingPlatform;
    public Vector3 position1;
    public Vector3 position2;
    public Vector3 newPosition;
    public bool isAtPosition1;
    public float resetTime;

    // Use this for initialization
    void Start()
    {
        isAtPosition1 = true;
        newPosition = position1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movingPlatform.localPosition = Vector3.Lerp(movingPlatform.localPosition, newPosition, Time.deltaTime);
    }

    public void ChangeTarget()
    {
        if (isAtPosition1)
        {
            newPosition = position2;
            isAtPosition1 = false;
        }
        else
        {
            newPosition = position1;
            isAtPosition1 = true;
        }

      /*  if (currentState == "Moving To Position 1")
        {
            currentState = "Moving To Position 2";
            newPosition = position2;
        }
        else if (currentState == "Moving To Position 2")
        {
            currentState = "Moving To Position 1";
            newPosition = position1;
        }
        else if (currentState == "")
        {
            currentState = "Moving To Position 2";
            newPosition = position2;
        }*/


    }
}
