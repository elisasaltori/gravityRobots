using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
 * Used for cogs
 * Activates cog collection only when it hits the ground
 **/
public class FallingItem : MonoBehaviour
{
    public GameObject item;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(item, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
