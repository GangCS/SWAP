using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSens : MonoBehaviour
{
    [SerializeField] LookX lookX;
    [SerializeField] LookY lookY;
    [SerializeField] Slider mainSlider;
    GameObject sensativityScript;
    // Start is called before the first frame update
    void Start()
    {
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        sensativityScript = GameObject.Find("SensScript");
        if (sensativityScript != null)
        {
            mainSlider.value =sensativityScript.GetComponent<SensHolder>().getSens();
        }
    }

    public void ValueChangeCheck()
    {
        if (sensativityScript != null)
        {
        
            sensativityScript.GetComponent<SensHolder>().setSens(mainSlider.value);
            lookX.changeRotation(mainSlider.value);
            lookY.changeRotation(mainSlider.value);
        }
    }
}
