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
    //[Tooltip("Player object")]
    //[SerializeField] GameObject Char;
    Vector3 originalScale;
    Vector3 ScaleVector;
    GameObject fiveButtonsPushed; 
    ButtonsCounter buttonScript;
    void Start()
    {
        originalScale = Button.transform.localScale;
        ScaleVector = Button.transform.localScale;
        GameObject fiveButtonsPushed = GameObject.Find("FiveButtonsPushed");
        ButtonsCounter buttonScript = fiveButtonsPushed.GetComponent<ButtonsCounter>();
    }
    private void OnTriggerEnter(Collider other)
    {
        ScaleVector = new Vector3(2, 0.2f, 2);//Pushing the Button down
        if (itsMatchedCube(other)) 
        {
            GameObject fiveButtonsPushed = GameObject.Find("FiveButtonsPushed");
            ButtonsCounter buttonScript = fiveButtonsPushed.GetComponent<ButtonsCounter>();
            buttonScript.ButtonsCounter5++;
        }
    }
    private void OnTriggerStay(Collider other) // Button is pushed
    {
        GameObject fiveButtonsPushed = GameObject.Find("FiveButtonsPushed");
        ButtonsCounter buttonScript = fiveButtonsPushed.GetComponent<ButtonsCounter>();
        //Debug.Log("ButtonPushed Counter: " + buttonScript.ButtonsCounter5);
        //ScaleVector = new Vector3(1, 1, 0.2f);//Pushing the Button down
        if (itsMatchedCube(other))
        {
            if (buttonScript.ButtonsCounter5 == 5)
                ActionObject.performAction();
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
        if (other.gameObject.Equals(Cube))
            return true;
        else
            return false;
    }
    /*    bool characterStand(Collider other)
        {
            if (Cube != null && other.gameObject.Equals(Char))
                return true;
            else
                return false;
        }*/
    private void OnTriggerExit(Collider other) // Button is no longer pushed
    {
        ScaleVector = originalScale; //Pulling Button back up
        GameObject fiveButtonsPushed = GameObject.Find("FiveButtonsPushed");
        ButtonsCounter buttonScript = fiveButtonsPushed.GetComponent<ButtonsCounter>();
        if (itsMatchedCube(other)) 
        {
            buttonScript.ButtonsCounter5--;
            if (buttonScript.ButtonsCounter5 != 5)
            {
                ActionObject.undoAction();
            }
        }
    }

    void Update()
    {
        Button.transform.localScale = Vector3.Slerp(Button.transform.localScale, ScaleVector, Time.deltaTime * 5f);//Smooth button up/down
    }
}
