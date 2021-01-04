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

    [SerializeField] LayerMask m_LayerMask;
    public int baseCollisionAmount;
    Collider[] hitColliders;

    void Start()
    {
        ScaleVector = new Vector3(1, 1, 1);

        hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);//get all the collisions
        baseCollisionAmount = hitColliders.Length;//get number of collisions - if in-game you get this number again it means nothing is on the button - pull butt up
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
        hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        if (hitColliders.Length == baseCollisionAmount)//means nothing is on the button
        {
            ScaleVector = new Vector3(1, 1, 1); //Pulling Button back up
        }

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
        Button.transform.localScale = Vector3.Lerp(Button.transform.localScale, ScaleVector, Time.deltaTime * 5f);//Smooth button up/down
    }
}
