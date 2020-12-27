using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingDoor : IMovementAction
{
    [SerializeField] AudioClip sound;
    [SerializeField] Vector3 goalRotation;
    [SerializeField] Vector3 currRotation;
    protected Quaternion lookRotation;
    bool toPlay = true;

    public override void performAction()
    {
        lookRotation = Quaternion.Euler(goalRotation);
        if (toPlay)
        {
            AudioSource.PlayClipAtPoint(sound, transform.position, 1f);
            toPlay = false;
        }
        
    }

    public override void undoAction()
    {
        lookRotation = Quaternion.Euler(currRotation);
        if (!toPlay)
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            toPlay = true;
        }
    }
/*    private void playDoorMusic()
    {
        if (toPlay)
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            toPlay = !toPlay;
        }
    }*/

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);// Opens the door
    }
}
