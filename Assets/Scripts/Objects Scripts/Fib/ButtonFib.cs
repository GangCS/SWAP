using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFib : MonoBehaviour
{
    [Tooltip("The Button")]
    [SerializeField] GameObject Button;
    [Tooltip("Object to perform action on")]
    [SerializeField] IMovementAction [] ActionObject;
    [Tooltip("A specific impacting object")]
    [SerializeField] GameObject Cube = null;
    [SerializeField] int ButtonsToPush = 3;

    Vector3 ScaleVector;

    [SerializeField] LayerMask m_LayerMask;
    public int baseCollisionAmount;
    Collider[] hitColliders;

    GameObject threeButtonsPushed; 
    ButtonsCounter buttonScript;

    void Start()
    {
        hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);//get all the collisions
        baseCollisionAmount = hitColliders.Length;//get number of collisions - if in-game you get this number again it means nothing is on the button - pull butt up

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
                foreach (var item in ActionObject)
                {
                    item.performAction();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) // Button is no longer pushed
    {
        hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        if (hitColliders.Length == baseCollisionAmount)//means nothing is on the button
        {
            ScaleVector = new Vector3(1, 1, 1); //Pulling Button back up
        }

        if (itsMatchedCube(other))
        {
            buttonScript.ButtonsCounters--;
            if (buttonScript.ButtonsCounters != ButtonsToPush)
            {
                foreach (var item in ActionObject)
                {
                    item.undoAction();
                }
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
