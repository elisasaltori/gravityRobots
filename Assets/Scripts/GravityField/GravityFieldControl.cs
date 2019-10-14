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
     public string playerTag = "Player";

    private string ceilingTag = "platform";

    [Header("Attributes")]
    public float floatSpeed;
    public int popPoints = 10; 

    private PointsSystem ps;

    private void Awake()
    {
        ps = GameObject.FindGameObjectWithTag("PointsManager").GetComponent<PointsSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = floatSpeed * Vector3.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //stops bubble if it hits the ceiling
        if (collision.gameObject.CompareTag(ceilingTag))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        else
        {
            if (collision.gameObject.CompareTag(playerTag))
            {
                //check if player
                //if so, add points to player then pop!
                Debug.Log("Field popped!");
                GetComponent<Collider2D>().enabled = false;
                ps.AddPoints(collision.GetComponent<IsPlayerOne>().isPlayerOne, popPoints);
                Destroy(gameObject);
            }
        }
    }
}
