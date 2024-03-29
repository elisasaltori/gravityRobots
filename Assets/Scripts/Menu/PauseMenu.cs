﻿using System.Collections;
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
    public AudioManager audioManager;

    private bool gameStarted;

    private void Start()
    {
        gameStarted = false;
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
            yield return new WaitForSeconds(1);
            count--;
        }

        // Changes all players state to regular, so they can start moving and shooting
        for (int i = 0; i<2; i++)
        {
        FindObjectsOfType<PlayerMovement>()[i].stunned = false;
        }
        audioManager.Play("Music");

        yield return new WaitForSeconds(1);
        // Removes the Start countdown and the keys tip from screen
        startCountDown.gameObject.SetActive(false);
        p1Tips.gameObject.SetActive(false);
        p2Tips.gameObject.SetActive(false);
        gameStarted = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        //if Escape key is pressed + game has already started (cant pause on countdown)
        if (Input.GetKeyDown(KeyCode.Escape) && gameStarted)
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

        //control tips for players
        p1Tips.gameObject.SetActive(false);
        p2Tips.gameObject.SetActive(false);

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;//resumes the game at normal speed
        gameIsPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);

        //control tips for players are on during pause menu
        p1Tips.gameObject.SetActive(true);
        p2Tips.gameObject.SetActive(true);

        Time.timeScale = 0f;//stops the game
        gameIsPaused = true;
    }
}
