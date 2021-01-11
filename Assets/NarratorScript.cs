using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarratorScript : MonoBehaviour
{
    [SerializeField] AudioSource NarratorSpeech;
    [SerializeField] int secondToShowNarratorText = 5;
    // Start is called before the first frame update
    void Start()
    {
        if (!PauseScript.gameIsPaused)
        {
            NarratorSpeech.Play();
            StartCoroutine(showTextForSeconds());
        }
    }
    private void Update()
    {
        if (PauseScript.gameIsPaused)
        {
            if (NarratorSpeech.isPlaying)
            {
                NarratorSpeech.Pause();
            }

        }
        else
        {
            NarratorSpeech.UnPause();
        }
    }
    IEnumerator showTextForSeconds()
    {

        yield return new WaitForSeconds(secondToShowNarratorText);
        GameObject narratorTextObj = GameObject.Find("NarratorText");
        narratorTextObj.GetComponent<TextMeshProUGUI>().text = "";
    }

}
