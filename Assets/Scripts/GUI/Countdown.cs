using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Timer that constrols play time
 * It also updates the GUI with the remaining time
 **/
public class Countdown : MonoBehaviour
{
    [Header("Attributes")]
    public float timeStart = 180f;
    public float runningOutOfTime = 10f;
    public string endSceneName;

    [Header("References")]
    public Text textBox; //timer on gui


    private AudioSource timerSound;
    private float time;
    private bool timeEnding;

    private void Awake()
    {
        timerSound = GetComponent<AudioSource>();
    }

    public float GetTime()
    {
        return time;
    }

    // Use this for initialization
    void Start()
    {
        textBox.text = timeStart.ToString();
        time = timeStart;
        timeEnding = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Does not start counter if the 3 2 1 GO still on
        if (FindObjectOfType<PauseMenu>().startCountDown.activeSelf)
        {
            return;
        }

        //reduces timer and updates text
        time -= Time.deltaTime;
        textBox.text = Mathf.Round(time).ToString();

        //set timer text to red if time is running out!
        if(time <= runningOutOfTime && !timeEnding)
        {
            timeEnding = true;
            textBox.color = Color.red;
            timerSound.Play();
        }


        //match time is over
        if(time <= 0)
        {
            //load end scene
            SceneManager.LoadScene(endSceneName);
        }
    }
}