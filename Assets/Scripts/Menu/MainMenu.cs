using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PointsSystem ps;


    /*function activates when PlayButton is pressed*/
    public void PlayGame()
    {
        Debug.Log("Play game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//goes to next scene

    }

    /*function activates when QuitButton is pressed*/
    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;//necessary for the QuitButton to work inside unity editor
     
        Debug.Log("QUIT!");//for tests inside unity editor only
        Application.Quit();
    }
}
