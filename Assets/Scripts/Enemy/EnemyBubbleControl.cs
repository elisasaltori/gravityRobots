using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBubbleControl : MonoBehaviour
{

    [Header("Attributes")]
    public int killPoints = 5;

    [Header("References")]
    public GameObject fieldWithMonsteRed;
    public GameObject fieldWithMonsterYellow;


    private PointsSystem ps;

    private void Awake()
    {
        ps = GameObject.FindGameObjectWithTag("PointsManager").GetComponent<PointsSystem>();
    }

    public void EnemyHit(bool isPlayerOne)
    {
        GameObject field;

        //uses appropriate bubble color
        if (isPlayerOne)
        {
            field = Instantiate(fieldWithMonsterYellow);
        }   
        else
        {
            field = Instantiate(fieldWithMonsteRed);
        }

        //add points to player for killing the monster
        ps.AddPoints(isPlayerOne, killPoints);

        //spawns filled field a little above monster so it doesnt get stuck to a platform
        field.transform.position = this.transform.position + new Vector3(0f, 0.1f, 0f); 
        Destroy(gameObject);
    }
}
