using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWinController : MonoBehaviour
{

    [Header("References")]
    public PointsSystem ps;
    public GameObject p1Win;
    public GameObject p2Win;
    public GameObject draw;
    public Text modelSelected;

    string modelWinText = "MODELO SELECIONADO: ";
    string modelDrawText = "MODELOS EMPATADOS";
    
    // Start is called before the first frame update
    void Start()
    {
        //check who won
        string res = ps.GetMatchResult();


        //disable/enable right images
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
