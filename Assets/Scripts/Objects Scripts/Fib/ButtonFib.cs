using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFib : MonoBehaviour
{
    [Tooltip("The Button")]
    [SerializeField] GameObject Button;
    [Tooltip("Object to perform action on")]
    [SerializeField] IMovementAction ActionObject;
    [Tooltip("A specific impacting object")]
    [SerializeField] GameObject Cube = null;
    [SerializeField] int ButtonsToPush = 3;

    Vector3 originalScale;
    Vector3 ScaleVector;

    GameObject threeButtonsPushed; 
    ButtonsCounter buttonScript;

    void Start()
    {
        ScaleVector = new Vector3(1, 1, 1);

        threeButtonsPushed = GameObject.Find("Fib");
        buttonScript = threeButtonsPushed.GetComponent<ButtonsCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ScaleVector = new Vector3(1, 1, 0.2f);//Pushing the Button down
        if (itsMatchedCube(other)) 
        {
            buttonScript.ButtonsCounters++;
        }
    }

    private void OnTriggerStay(Collider other) // Button is pushed
    {
        if (itsMatchedCube(other))
        {
            if (buttonScript.ButtonsCounters == ButtonsToPush)
            {
                ActionObject.performAction();
            }
        }
    }

    private void OnTriggerExit(Collider other) // Button is no longer pushed
    {
        ScaleVector = new Vector3(1, 1, 1); //Pulling Button back up
        if (itsMatchedCube(other))
        {
            buttonScript.ButtonsCounters--;
            if (buttonScript.ButtonsCounters != ButtonsToPush)
            {
                ActionObject.undoAction();
            }
        }
    }

    void Update()
    {
        Button.transform.localScale = Vector3.Lerp(Button.transform.localScale, ScaleVector, Time.deltaTime * 5f);//Smooth button up/down
    }

    bool itsMatchedCube(Collider other)
    {
        if (other.gameObject.Equals(Cube))
        {
            return true;
        }
        else
        { 
            return false;
        }    
    }
}
