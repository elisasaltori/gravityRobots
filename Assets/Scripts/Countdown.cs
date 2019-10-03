using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [Header("Attributes")]
    public float timeStart = 180f;
    public float runningOutOfTime = 10f;
    public string endSceneName;

    [Header("References")]
    public Text textBox;



    private AudioSource timerSound;
    private float time;
    private bool timeEnding;

    private void Awake()
    {
        timerSound = GetComponent<AudioSource>();
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
        time -= Time.deltaTime;
        textBox.text = Mathf.Round(time).ToString();

        if(time <= runningOutOfTime && !timeEnding)
        {
            timeEnding = true;
            textBox.color = Color.red;
            timerSound.Play();
        }


        //match time is over
        if(time <= 0)
        {
            SceneManager.LoadScene(endSceneName);
        }
    }
}