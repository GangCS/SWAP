using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upliftingObjectTimed : upliftingObject
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
        OriginalPosition = transform.localPosition;
        CurrPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, CurrPosition, Time.deltaTime * 5f);
        if (isTriggered && Time.time - TriggerTime > timeForAction)
        {
            base.undoAction();
            isTriggered = false;
        }
    }
}