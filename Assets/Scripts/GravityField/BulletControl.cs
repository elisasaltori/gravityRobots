using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controls projectiles. Can be used for either
 * player gravity fields or enemy bullets
 **/
[RequireComponent(typeof(Collider2D))]
public class BulletControl : MonoBehaviour
{

    [Header("Attributes")]
    public float range = 10f;
    public bool isPlayerBullet;
    public bool isPlayerOne;
    public string enemyTag = null; //should remain null if enemy bullet
    public string playerTag = null; //always should have the Player tag
    public string fieldTag = null; //fields with monsters tag so bubble can ignore them

    //used for checking if range has been reached
    private Vector3 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //destroys itself if range is reached
        ShotDistance();
    }

    //Destroy bullet if it has travelled over the range distance
    void ShotDistance()
    {
        if (Vector3.Distance(spawnLocation, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ignores trigger if it's a floating field (filled with a monster)
        if (fieldTag == null || !collision.gameObject.CompareTag(fieldTag))
        {
            //hit an enemy, destroy enemy and begin bubbling up
            if (enemyTag != null && collision.gameObject.CompareTag(enemyTag))
            {
                Debug.Log("hit an enemy!");
                //
                collision.gameObject.GetComponent<EnemyBubbleControl>().EnemyHit(isPlayerOne);


            }
            else
            {
                //hit a player, call stun
                if (playerTag != null && collision.gameObject.CompareTag(playerTag))
                {
                    Debug.Log("hit a player!");
                }

            }

            //destroy bullet on collision 
            Destroy(gameObject);
        }
    }
}
