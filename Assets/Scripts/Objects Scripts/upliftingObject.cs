using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upliftingObject : IMovementAction
{
    [SerializeField] Vector3 goalPosition;
    protected Vector3 OriginalPosition;
    protected Vector3 CurrPosition;
    public override void performAction()
    {
        CurrPosition = goalPosition;
    }

    public override void undoAction()
    {
        CurrPosition = OriginalPosition;
    }

    void Start()
    {
        
        OriginalPosition = transform.localPosition;
        CurrPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Slerp(transform.localPosition, CurrPosition, Time.deltaTime * 5f);
    }
}
