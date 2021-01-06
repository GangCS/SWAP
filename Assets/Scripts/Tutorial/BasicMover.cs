using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasicMover : MonoBehaviour
{
    [SerializeField] IMovementAction Door;
    [SerializeField] string text;
    bool W = false;
    bool A = false;
    bool S = false;
    bool D = false;

    //instructions
    void Start()
    {
        GameObject instructionsTextObj = GameObject.Find("instructions");
        instructionsTextObj.GetComponent<TextMeshProUGUI>().text = text;

        
        StartCoroutine(showTextForSeconds());
    }

    IEnumerator showTextForSeconds()
    {
        yield return new WaitForSeconds(9);
        GameObject narratorTextObj = GameObject.Find("NarratorText");
        narratorTextObj.GetComponent<TextMeshProUGUI>().text = "";
    }
    private void OnEnable()
    {
        GameObject instructionsTextObj = GameObject.Find("instructions");
        instructionsTextObj.GetComponent<TextMeshProUGUI>().text = text;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            W = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            A = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            S = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            D = true;
        }
        if(W && A && S && D)
        {
            Door.performAction();
        }
    }
}
