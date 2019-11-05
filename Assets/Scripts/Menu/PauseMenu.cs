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
    public GameObject startCountDown;
    public GameObject p1Tips;
    public GameObject p2Tips;


    private void Start()
    {
        //move.stunned = true;
        StartCoroutine(Countdown(3));
    }

    // This is used for the start countdown. 3 2 1 GO
    IEnumerator Countdown(int seconds)
    {
        // Changes all players state to stunned, so they can't move or shoot
        for (int i = 0; i < 2; i++)
        {
            FindObjectsOfType<PlayerMovement>()[i].stunned = true;
        }

        int count = seconds;
        
        while (count > 0)
        {
            Debug.Log(count);
            yield return new WaitForSeconds(1);
            count--;
        }

        // Changes all players state to regular, so they can start moving and shooting
        for (int i = 0; i<2; i++)
        {
        FindObjectsOfType<PlayerMovement>()[i].stunned = false;
        }
        // Removes the Start countdown and the keys tip from screen
        startCountDown.gameObject.SetActive(false);
        p1Tips.gameObject.SetActive(false);
        p2Tips.gameObject.SetActive(false);
    }

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
