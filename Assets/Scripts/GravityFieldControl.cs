using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
/**
 * Behavior of the gravity field after it hits an enemy:
 * -floats up
 * -can be popped by player
 * 
 * TO DO:
 * -random chance for a cog to fall
 **/
public class GravityFieldControl : MonoBehaviour
{
    bool hitCeiling;

    [Header("Attributes")]
    public float floatSpeed;

    // Start is called before the first frame update
    void Start()
    {
        hitCeiling = false;
        GetComponent<Rigidbody2D>().velocity = floatSpeed * Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //go up
 
    }

    private void OnCollisionEnter(Collision collision)
    {
        //check if player
        //if so, pop!
        //TO DO: give points to the corresponding player
    }
}
