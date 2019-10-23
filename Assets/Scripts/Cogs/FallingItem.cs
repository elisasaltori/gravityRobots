using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
 * Used for cogs
 * Activates cog collection only when it hits the ground 
 * by instatiating the active cog in place and destroying this one
 **/
public class FallingItem : MonoBehaviour
{
    public GameObject item;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //cog prefab that is active
        Instantiate(item, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
