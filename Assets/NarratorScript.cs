using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorScript : MonoBehaviour
{
    [SerializeField] AudioSource NarratorSpeech;
    // Start is called before the first frame update
    void Start()
    {
        NarratorSpeech.Play();
    }

}
