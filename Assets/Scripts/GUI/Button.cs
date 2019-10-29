using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;//makes shure the game goes back at normal speed
        SceneManager.LoadScene(0);//scene 0 is MainMenu
    }
}
