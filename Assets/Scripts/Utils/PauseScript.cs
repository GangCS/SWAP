﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    [SerializeField] GameObject PauseMenuCanvas;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Pause()
    {
/*        if (Input.GetKeyDown(KeyCode.Escape)) // if we in pause and press Escape again
        {
            Debug.Log("tesstt");
            Resume();
        }*/
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
