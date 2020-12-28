using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPushed : MonoBehaviour
{
    [Tooltip("The Button")]
    [SerializeField] GameObject Button;
    [Tooltip("Object to perform action on")]
    [SerializeField] IMovementAction[] ActionObject;
    [Tooltip("A specific impacting object")]
    [SerializeField] GameObject Cube = null;
    [Tooltip("Player object")]
    [SerializeField] GameObject Char;
    Vector3 ScaleVector;
    void Start()
    {
        ScaleVector = new Vector3(1, 1, 1);
    }
    private void OnTriggerStay(Collider other) // Button is pushed
    {
        ScaleVector = new Vector3(1, 1, 0.2f);// Pushing the Button down
        if (performForAnyCube() || itsMatchedCube(other) || characterStand(other))
        {
            foreach (var item in ActionObject)
            {
                item.performAction();
            }

        }
    }
    bool performForAnyCube()
    {
        if (Cube == null)
            return true;
        else
            return false;
    }
    bool itsMatchedCube(Collider other)
    {
        if (Cube != null && other.gameObject.Equals(Cube))
            return true;
        else
            return false;
    }
    bool characterStand(Collider other)
    {
        if (Cube != null && Char != null && other.gameObject.Equals(Char))
            return true;
        else
            return false;
    }
    private void OnTriggerExit(Collider other) // Button is no longer pushed
    {
        ScaleVector = new Vector3(1, 1, 1); //Pulling Button back up
        if (performForAnyCube() || itsMatchedCube(other) || characterStand(other))
        {
            foreach (var item in ActionObject)
            {
                item.undoAction();
            }
        }
    }

    void Update()
    {
        Button.transform.localScale = Vector3.Slerp(Button.transform.localScale, ScaleVector, Time.deltaTime * 5f);//Smooth button up/down
    }
}
