using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PointsSystem ps;
    public GameObject enemy;
    public int sendHim = 0;

    public void Update()
    {
        // Releases flying monster in this interval
        if (Time.time > 9 && Time.time < 10)
        {
            sendHim = 1;
        }

        if(sendHim == 1)
        {
            
            enemy = GameObject.Find("FlyingEnemy");
            Vector3 temp = new Vector3(2.0f, 0, 0);
            if (enemy.transform.position.x < 2500)
            {
                enemy.transform.position += temp;
            } else
            {
                sendHim = 0;
            }
        }
        
    }

    /*function activates when PlayButton is pressed*/
    public void PlayGame()
    {
        Debug.Log("Play game!");
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
