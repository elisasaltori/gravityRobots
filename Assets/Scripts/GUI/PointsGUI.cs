using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsGUI : MonoBehaviour
{

    [Header("References")]
    public Text points1Text;
    public Text points2Text;


    private PointsSystem ps;
    // Start is called before the first frame update
    void Awake()
    {
        ps = GameObject.FindGameObjectWithTag("PointsManager").GetComponent<PointsSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        points1Text.text = ""+ps.GetP1Points();
        points2Text.text = "" + ps.GetP2Points();

    }
}
