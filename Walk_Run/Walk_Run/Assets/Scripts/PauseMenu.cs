using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    private void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Load()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
