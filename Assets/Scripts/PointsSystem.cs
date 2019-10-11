using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsSystem : MonoBehaviour
{

    private int p1Points;
    private int p2Points;


    // Start is called before the first frame update
    void Awake()
    {
        p1Points = 0;
        p2Points = 0;
        DontDestroyOnLoad(this.gameObject); //so its not destroyed when score scene is loaded
    }


    public void AddPoints(bool isPlayerOne, int points)
    {
        if (isPlayerOne)
            p1Points += points;
        else
            p2Points += points;
    }


    public int GetP1Points()
    {
        return p1Points;
    }

    public int GetP2Points()
    {
        return p2Points;
    }

    public string GetMatchResult()
    {
        if (p1Points > p2Points)
        {
            return ("P1");
        }
        else
        {
            if (p2Points > p1Points)
                return ("P2");
            else
                return ("DRAW");
        }
            

    }
}
