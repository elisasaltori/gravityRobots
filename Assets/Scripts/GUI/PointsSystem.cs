using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Keeps track of players points in game
 **/
public class PointsSystem : MonoBehaviour
{

    int p1Points;
    int p2Points;
    private static PointsSystem instance;

    // Start is called before the first frame update
    void Awake()
    {
        //singleton pattern
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
            p1Points = 0;
            p2Points = 0;
        }
        else if (instance != this){
            Destroy(gameObject);
        }

 
    }

    /**
     * Public function to increase a player's score
     **/
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

    /**
     * Return string indicating the winner of a game:
     * P1, P2, DRAW
     **/
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

    public void Reset()
    {
        Debug.Log("Score reset!");
        p1Points = 0;
        p2Points = 0;
    }

    public void ResetAndSave()
    {
        RankingManager.UpdateRanking("player1", p1Points, "player2", p2Points);
        RankingManager.SaveRanking();
        p1Points = 0;
        p2Points = 0;
    }


}
