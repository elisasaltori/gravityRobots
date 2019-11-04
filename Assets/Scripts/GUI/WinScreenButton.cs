using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenButton : MonoBehaviour
{
    public GameObject nameScreen;
    public GameObject winScreen;

   public void ToNameScreen()
    {
        //activates name input options
        //disactivates score text
        nameScreen.SetActive(true);
        winScreen.SetActive(false);
    }
}
