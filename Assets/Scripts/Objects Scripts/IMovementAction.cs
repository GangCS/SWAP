using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class IMovementAction : MonoBehaviour
{
    public abstract void performAction();
    public abstract void undoAction();

}
