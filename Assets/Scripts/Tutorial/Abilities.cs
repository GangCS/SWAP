using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [SerializeField] IMovementAction Door;
    [SerializeField] string text;

    bool E = false;
    bool Q = false;
    // Start is called before the first frame update
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            E = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Q = true;
        }
        if (E && Q)
        {
            Door.performAction();
        }
    }
}


