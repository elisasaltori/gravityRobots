using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Get collected if hit by player.
//Call points for player!
public class CogBehavior : MonoBehaviour
{
    PointsSystem ps;
    public int points = 5;
    // Start is called before the first frame update
    void Awake()
    {
        ps = GameObject.Find("PointsSystem").GetComponent<PointsSystem>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            //give points to correct player
            bool playerOne = collision.gameObject.GetComponent<IsPlayerOne>().isPlayerOne;
            ps.AddPoints(playerOne, points);
            //destroy itself
            Destroy(gameObject);
        }
    }
}
