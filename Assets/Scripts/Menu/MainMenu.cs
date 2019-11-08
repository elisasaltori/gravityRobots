using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PointsSystem ps;
    GameObject enemy;
    bool sendHim = false;
    Vector3 originalPosition;

    public void Start()
    {
        enemy = GameObject.Find("FlyingEnemy");
        originalPosition = enemy.transform.position;
    }

    public void Update()
    {
        // Releases flying monster in this interval
        if (Time.time % 10 > 9)
        {
            sendHim = true;
        }

        if(sendHim)
        {
            
            Vector3 temp = new Vector3(2.0f, 0, 0);
            if (enemy.transform.position.x < 2500)
            {
                enemy.transform.position += temp;
            } else
            {
                if(Time.time % 30 < 1)
                {
                    sendHim = false;
                    enemy.transform.position = originalPosition;
                }
                    

                
            }
        }
        
    }

    /*function activates when PlayButton is pressed*/
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//goes to next scene

    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);//goes to last scene

    }

    /*function activates when QuitButton is pressed*/
    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;//necessary for the QuitButton to work inside unity editor
     
        Debug.Log("QUIT!");//for tests inside unity editor only
        Application.Quit();
    }
}
