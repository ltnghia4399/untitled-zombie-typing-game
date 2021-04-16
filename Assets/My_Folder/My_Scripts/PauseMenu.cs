using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pausePanel;

    private void Start()
    {
        if (pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.instance.gameStared && !GameManager.instance.gameEnded)
            {
                if (isPaused)
                {
                    //Resume Game
                    ResumeGame();
                }
                else
                {
                    //Pause Game
                    PauseGame();

                }
            }

        }
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    private void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void RestartGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
