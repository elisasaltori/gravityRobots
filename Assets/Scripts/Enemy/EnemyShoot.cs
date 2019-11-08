using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Attributes")]
    public string objectTag;

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
