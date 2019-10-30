using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Attributes")]
    public int damage = 1;
    public string objectTag;
    //public string playerTag = null; //always should have the Player tag

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == objectTag) 
        {
            collider.gameObject.GetComponent<PlayerMovement>().Stun();
        }
        Destroy(gameObject);
    }
}
