using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOutliner : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ray to Middle Screen HitPosition
        Vector3 ScreenMiddle = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray rayFromCameraToClickPosition = Camera.main.ScreenPointToRay(ScreenMiddle); //rayCast hit position

        // Outliner for box
        RaycastHit hittedBox;
        bool hasHit = Physics.Raycast(rayFromCameraToClickPosition, out hittedBox);
        if (hasHit)
        {
            if (hittedBox.transform.gameObject.tag == "Box")//ray hit box
            {
                // hitInfo is the box
                hittedBox.transform.gameObject.GetComponent<Outline>().enabled = true; // make a red circle around the box
            }
        }
    }
}
