using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameScreenController : MonoBehaviour
{
    public Text highscore;
    public GameObject p1High;
    public GameObject p2High;

    // Start is called before the first frame update
    void Start()
    {
        //get highscore
        int score = RankingManager.GetHighScore();

        //update highscore text
        highscore.text = ""+score;

        //activate highscore message (NEW HIGHSCORE) if needed
        HighScoreMessage(score);

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HighScoreMessage(int score)
    {
        //check if current scores are higher!
        //then activate new highscore message
        PointsSystem ps = GameObject.FindGameObjectWithTag("PointsManager").GetComponent<PointsSystem>();
        int p1 = ps.GetP1Points();
        int p2 = ps.GetP2Points();

        //new highscore from p1
        if (p1 > p2 && p1 > score)
        {
            p1High.SetActive(true);
            p2High.SetActive(false);
        }
        else
        {
            //new highscore from p2
            if (p2 > p1 && p2 > score)
            {
                p1High.SetActive(false);
                p2High.SetActive(true);
            }
            else
            {
                p1High.SetActive(false);
                p2High.SetActive(false);
            }
        }
    }
}
