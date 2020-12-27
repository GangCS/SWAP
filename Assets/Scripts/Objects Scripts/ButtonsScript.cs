using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] platformArray;
    
    private Material[] ButtonColors;
    private MeshRenderer mr;

    private float currTime;
    private int i;
    void Start()
    {
        ButtonColors = new Material[platformArray.Length];
        for (int j=0;j<platformArray.Length;j++)
        {
            ButtonColors[j] = platformArray[j].GetComponent<MeshRenderer>().material;
        }
        mr = GetComponent<MeshRenderer>();
        currTime = Time.time;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - currTime >= 1)
        {
            mr.material = ButtonColors[i];
            i++;
            currTime = Time.time;
            if(i== ButtonColors.Length)
            {
                i = 0;
            }
        }
    }

    public void Click()
    {
        foreach (var item in platformArray)
        {
            MovingPlatform movingPlatformScirpt = item.GetComponent<MovingPlatform>();
            movingPlatformScirpt.ChangeTarget();
        }
    }
}
