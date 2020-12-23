using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdvancedMover : MonoBehaviour
{
    [SerializeField] IMovementAction Door;
    [SerializeField] string text;

    bool Shift = false;
    bool Space = false;

    void Start()
    {
        GameObject textObj = GameObject.Find("instructions");
        textObj.GetComponent<TextMeshProUGUI>().text = text;
    }

    private void OnEnable()
    {
        GameObject textObj = GameObject.Find("instructions");
        textObj.GetComponent<TextMeshProUGUI>().text = text;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Space = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Shift = true;
        }
        if (Shift && Space)
        {
            Door.performAction();
        }
    }
}
