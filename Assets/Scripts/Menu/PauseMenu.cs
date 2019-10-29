using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject resumeButton;
    public GameObject mainMenuButton;
    public GameObject confirmationBox;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//if Escape key is pressed
        {
            if (gameIsPaused)
            {

                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        confirmationBox.SetActive(false);
        resumeButton.SetActive(true);
        mainMenuButton.SetActive(true);
        
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;//resumes the game at normal speed
        gameIsPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;//stops the game
        gameIsPaused = true;
    }
}
