using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletControl : MonoBehaviour
{

    [Header("Attributes")]
    public float range = 10f;
    public bool isPlayerBullet;
    public string enemyTag = null;
    public string playerTag = null;

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

    void ShotDistance()
    {
        if (Vector3.Distance(spawnLocation, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //hit an enemy, destroy enemy and begin bubbling up
        if(enemyTag!=null && collision.gameObject.CompareTag(enemyTag))
        {
            Debug.Log("hit an enemy!");
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
