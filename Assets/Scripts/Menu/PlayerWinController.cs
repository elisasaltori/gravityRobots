using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/***
 * Gets final score and sets win screen parameters to match result
 **/
public class PlayerWinController : MonoBehaviour
{

    [Header("References")]
    
    public GameObject p1Win;
    public GameObject p2Win;
    public GameObject draw;
    public Text modelSelected;

    string modelWinText = "SELECTED MODEL: ";
    string modelDrawText = "DRAW!";
    PointsSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("PointsSystem").GetComponent<PointsSystem>();
        //check who won
        string res = ps.GetMatchResult();
        Debug.Log("match result: " + res);

        //disable/enable right images/objects
        //change win text
        if (res.Equals("P1"))
        {
            modelSelected.text = modelWinText + res;
            p1Win.SetActive(true);
            p2Win.SetActive(false);
            draw.SetActive(false);
        }
        else
        {
            if (res.Equals("P2"))
            {
                modelSelected.text = modelWinText + res;
                p1Win.SetActive(false);
                p2Win.SetActive(true);
                draw.SetActive(false);
            }
            else
            {
                modelSelected.text = modelDrawText;
                p1Win.SetActive(false);
                p2Win.SetActive(false);
                draw.SetActive(true);
            }
        }
        
    }

 
}
