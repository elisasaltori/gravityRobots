using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Takes care of getting names, showing the higscore and updating the ranking
/// </summary>
public class NameScreenController : MonoBehaviour
{
    public Text highscore;
    public GameObject p1High;
    public GameObject p2High;
    public InputField p1Name;
    public InputField p2Name;

    int p1; //points player 1
    int p2; //points player 2

    // Start is called before the first frame update
    void Start()
    {
  
        //show high score
        //activate highscore message (NEW HIGHSCORE) if needed
        HighScoreMessage();

        //start input boxes with last player name used (since game was opened)
        //so that the player doesnt have to type it up everytime
        string p1 = RankingManager.player1Name;
   
        if (p1 != null)
            p1Name.text = p1;
     
        string p2 = RankingManager.player2Name;
        if (p2 != null)
            p1Name.text = p2;
    }

    public void SaveScore()
    {
        string p1string = p1Name.text;
        string p2string = p2Name.text;

        if (p1string.Length < 1)
            p1string = "player1";

        if (p2string.Length < 1)
            p2string = "player2";

        RankingManager.UpdateRanking(p1string, p1, p2string, p2);
        RankingManager.SaveRanking();
    }

    void HighScoreMessage()
    {
        //get highscore
        int score = RankingManager.GetHighScore();

        //update highscore text
        highscore.text = "" + score;

        //check if current scores are higher!
        //then activate new highscore message
        PointsSystem ps = GameObject.FindGameObjectWithTag("PointsManager").GetComponent<PointsSystem>();
        p1 = ps.GetP1Points();
        p2 = ps.GetP2Points();

        //new highscore from p1
        if (p1 > p2 && p1 > score)
        {
            p1High.SetActive(true);
            p2High.SetActive(false);
            highscore.text = "" + p1;
        }
        else
        {
            //new highscore from p2
            if (p2 > p1 && p2 > score)
            {
                p1High.SetActive(false);
                p2High.SetActive(true);
                highscore.text = "" + p2;
            }
            else
            {
                p1High.SetActive(false);
                p2High.SetActive(false);
            }
        }
    }
}
