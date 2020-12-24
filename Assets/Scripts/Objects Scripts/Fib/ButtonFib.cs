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

    Vector3 originalScale;
    Vector3 ScaleVector;

    GameObject fiveButtonsPushed; 
    ButtonsCounter buttonScript;

    void Start()
    {
        originalScale = Button.transform.localScale;//Button's Transform scale to pull up
        ScaleVector = Button.transform.localScale;

        fiveButtonsPushed = GameObject.Find("Fib");
        buttonScript = fiveButtonsPushed.GetComponent<ButtonsCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ScaleVector = new Vector3(2, 0.2f, 2);//Pushing the Button down
        if (itsMatchedCube(other)) 
        {
            buttonScript.ButtonsCounter3++;
        }
    }

    private void OnTriggerStay(Collider other) // Button is pushed
    {
        if (itsMatchedCube(other))
        {
            if (buttonScript.ButtonsCounter3 == 3)
            {
                ActionObject.performAction();
            }
        }
    }

    private void OnTriggerExit(Collider other) // Button is no longer pushed
    {
        ScaleVector = originalScale; //Pulling Button back up
        if (itsMatchedCube(other))
        {
            buttonScript.ButtonsCounter3--;
            if (buttonScript.ButtonsCounter3 != 3)
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
