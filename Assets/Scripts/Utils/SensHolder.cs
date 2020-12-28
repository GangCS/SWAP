using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensHolder : MonoBehaviour
{
    private float sensativity=1;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void setSens(float sensativity)
    {
        this.sensativity = sensativity;
    }
    public float getSens()
    {
        return sensativity;
    }
}
