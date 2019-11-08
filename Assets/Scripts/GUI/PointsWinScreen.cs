using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows points on Win Screen
/// (unlike the script used during the game, this one does not update the points)
/// </summary>
public class PointsWinScreen : MonoBehaviour
{

    [Header("References")]
    public Text points1Text;
    public Text points2Text;


    private PointsSystem ps;
    // Start is called before the first frame update
    void Awake()
    {
        ps = GameObject.FindGameObjectWithTag("PointsManager").GetComponent<PointsSystem>();
        points1Text.text = "" + ps.GetP1Points();
        points2Text.text = "" + ps.GetP2Points();
        

    }


}
