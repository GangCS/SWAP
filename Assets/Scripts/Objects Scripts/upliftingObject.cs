using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upliftingObject : IMovementAction
{
    [SerializeField] Vector3 goalPosition;
    protected Vector3 OriginalPosition;
    protected Vector3 CurrPosition;

    [SerializeField] AudioClip sound;
    bool toPlay = true;

    void Start()
    {
        OriginalPosition = transform.localPosition;
        CurrPosition = transform.localPosition;
    }
    public override void performAction()
    {
        CurrPosition = goalPosition;
        if (toPlay)
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            toPlay = false;
        }

    }

    public override void undoAction()
    {
        CurrPosition = OriginalPosition;
        if (!toPlay)
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            toPlay = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, CurrPosition, Time.deltaTime * 5f);
    }
}
