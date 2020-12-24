using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensClass : MonoBehaviour
{
    private float sensativity;
    // Start is called before the first frame update
    public Slider mainSlider;

    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        GameObject.Find("SensScript").GetComponent< SensHolder>().setSens(mainSlider.value);
    }
}
